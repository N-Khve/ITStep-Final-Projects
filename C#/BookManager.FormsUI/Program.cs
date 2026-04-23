using BookManager.Repository;
using BookManager.Repository.Interfaces;
using BookManager.Service;
using BookManager.Service.Interfaces;
using BookManager.UI;
using Microsoft.Extensions.DependencyInjection;

namespace BookManager.FormsUI
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var mainForm = ServiceProvider.GetRequiredService<Form1>();

            Application.Run(mainForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            const string filePath = @"../../../../BookManager.Data/books.json";

            services.AddSingleton<IBookRepository>(options =>
            {
                return BookRepository.CreateAsync(filePath)
                .GetAwaiter()
                .GetResult();
            });

            services.AddTransient<IBookService, BookService>();

            services.AddTransient<Form1>();
            services.AddTransient<Form2>();
        }
    }
}