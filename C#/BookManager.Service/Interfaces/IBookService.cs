using BookManager.Service.Dto_s;

namespace BookManager.Service.Interfaces
{
    public interface IBookService
    {
        Task<List<GetBookDto>> GetAllBooksAsync();

        Task<GetBookDto> GetBookByIdAsync(int id);

        Task<int> AddBookAsync(CreateBookDto newBook);
    }
}