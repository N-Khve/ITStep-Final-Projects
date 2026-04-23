using BookManager.Repository.Models;

namespace BookManager.Repository.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();

        Task<Book> GetBookById(int id);

        Task<int> AddBook(Book newBook);
    }
}