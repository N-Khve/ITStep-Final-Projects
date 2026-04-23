using BookManager.Repository;
using BookManager.Service;
using BookManager.Service.Dto_s;

namespace BookManager.TestingEnv
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            //var repo = await BookRepository.CreateAsync(@"../../../../BookManager.Data/Books.json");

            var service = new BookService(await BookRepository.CreateAsync(@"../../../../BookManager.Data/Books.json"));

            var result = await service.AddBookAsync(new CreateBookDto
            {
                Title = "Test Book",
                Author = "Test Author",
                PublicationDate = DateOnly.FromDateTime(DateTime.Now).ToString()
            });
        }
    }
}