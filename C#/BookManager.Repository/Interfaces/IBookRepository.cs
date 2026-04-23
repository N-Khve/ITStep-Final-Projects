using BookManager.Repository.Models;

namespace BookManager.Repository.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync();

        Task<Book> GetBookByIdAsync(int id);

        Task<int> AddBookAsync(Book newBook);
    }
}