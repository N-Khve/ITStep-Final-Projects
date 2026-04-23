using BookManager.Repository.Exceptions;
using BookManager.Repository.Interfaces;
using BookManager.Repository.Models;
using BookManager.Service.Dto_s;
using BookManager.Service.Interfaces;

namespace BookManager.Service
{
    public class BookService : IBookService
    {
        private IBookRepository _repository { get; set; }

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBookDto>> GetAllBooksAsync()
        {
            try
            {
                var books = await _repository.GetAllBooksAsync();

                return books.Select(b => new GetBookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    PublicationYear = b.PublicationYear
                }).ToList();
            }
            catch (Exception)
            {
                throw new BookManagerException("Failed to Fetch books");
            }
        }

        public async Task<GetBookDto> GetBookByIdAsync(int id)
        {
            try
            {
                var book = await _repository.GetBookByIdAsync(id);

                return new GetBookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    PublicationYear = book.PublicationYear
                };
            }
            catch (Exception)
            {
                throw new BookNotFoundException(id);
            }
        }

        public async Task<int> AddBookAsync(CreateBookDto model)
        {
            var newBook = new Book
            {
                Title = model.Title,
                Author = model.Author,
                PublicationYear = model.PublicationYear
            };

            try
            {
                return await _repository.AddBookAsync(newBook);
            }
            catch (Exception)
            {
                throw new BookManagerException("Failed to add book");
            }
        }
    }
}