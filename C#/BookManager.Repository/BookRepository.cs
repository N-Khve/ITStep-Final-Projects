using BookManager.Repository.Exceptions;
using BookManager.Repository.Interfaces;
using BookManager.Repository.Models;
using BookManager.Repository.Models.Comparers;
using System.Text;
using System.Text.Json;

namespace BookManager.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books;

        private readonly string _filePath;

        private readonly SemaphoreSlim _semaphore = new(1, 1);

        private readonly Lock _lock = new();

        public BookRepository(string filePath, List<Book> books)
        {
            _filePath = filePath;
            _books = books;
        }

        public static async Task<BookRepository> CreateAsync(string filePath)
        {
            List<Book> books = new();

            await foreach (var book in LoadBooksAsync(filePath))
            {
                books.Add(book);
            }

            return new BookRepository(filePath, books);
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            lock (_lock)
            {
                return _books;
            }
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            try
            {
                lock (_lock)
                {
                    if (!_books.Any(b => b.Id == id))
                        throw new BookNotFoundException(id);

                    return _books.FirstOrDefault(b => b.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> AddBookAsync(Book newBook)
        {
            var bookComparer = new IBookDuplicateComparer();

            lock (_lock)
            {
                bool isDupe = _books.Any(b => bookComparer.Equals(b, newBook));

                if (isDupe)
                    throw new DuplicateBookException(newBook.Title, newBook.Author, newBook.PublicationYear);

                newBook.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
                _books.Add(newBook);
            }

            try
            {
                await SaveBooksAsync();
            }
            catch (Exception ex)
            {
                throw new BookManagerException("failed to add book", ex);
            }

            return newBook.Id;
        }

        #region HELPERS

        private static async IAsyncEnumerable<Book> LoadBooksAsync(string filePath)
        {
            if (!File.Exists(filePath))
                yield break;

            using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192, useAsync: true);
            using var ms = new MemoryStream();
            await fs.CopyToAsync(ms);
            ms.Position = 0;

            var json = Encoding.UTF8.GetString(ms.ToArray());

            List<Book> deserialized = null;

            try
            {
                deserialized = JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (Exception ex)
            {
                throw new BookManagerException("LoadBooksAsync failed", ex);
            }

            if (deserialized == null) yield break;

            foreach (var book in deserialized)
            {
                yield return book;
            }
        }

        private async Task SaveBooksAsync()
        {
            await _semaphore.WaitAsync();

            try
            {
                List<Book> snapshot;

                lock (_lock)
                {
                    snapshot = _books;
                }

                var jsonPayload = JsonSerializer.Serialize(snapshot, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                using var fs = new FileStream(
                   _filePath,
                   FileMode.Create,
                   FileAccess.Write,
                   FileShare.None,
                   8192,
                   useAsync: true);

                var bytes = Encoding.UTF8.GetBytes(jsonPayload);
                await fs.WriteAsync(bytes, 0, bytes.Length);
                await fs.FlushAsync();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        #endregion HELPERS
    }
}