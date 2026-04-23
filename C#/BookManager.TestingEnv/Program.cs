using BookManager.Repository;
using BookManager.Repository.Models;

namespace BookManager.TestingEnv
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var repo = await BookRepository.CreateAsync(@"../../../../BookManager.Data/Books.json");

            var result = await repo.AddBook(new Book
            {
                Title = "Test Book",
                Author = "Test Author",
                PublicationDate = new DateOnly(2024, 2, 1)
            });
        }
    }
}