using FirstSample.Models;
using FirstSample.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace FirstSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            RegisterServices();

            var controller = Container.GetRequiredService<IMyBooksController>();
            await controller.CreateDatabaseAsync();

            var books = new[]
            {
                 new Book { Title = "Professional C# 7", Publisher = "Wrox Press" },
                 new Book { Title = "Enterprise Services", Publisher = "AWL" },
            };
            // await controller.AddBooksAsync(books);

            controller.ReadBooks();

        }

        private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=BooksSample2;trusted_connection=true";

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddDbContext<BooksContext>(options =>
            {
                options.UseSqlServer(ConnectionString);
            });
            services.AddTransient<IMyBooksController, MyBooksController>();

            Container = services.BuildServiceProvider();
        }

        public static IServiceProvider Container { get; private set; }
    }
}
