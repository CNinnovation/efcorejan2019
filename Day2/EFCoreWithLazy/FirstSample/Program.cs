using FirstSample.Models;
using FirstSample.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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

            var book = controller.GetFirstBook();
            var chapters = new[]
            {
                new Chapter() { Title = "Core C#", Pages = 42, Book = book},
                new Chapter() { Title = "Dependency Injection", Pages = 48, Book = book}

            };


            await controller.AddChaptersAsync(chapters);

            // controller.EagerLoadingSample();
            controller.LazyLoadingSample();

            controller.ReadBooks();

        }

        private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=BooksReferences2;trusted_connection=true";

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            // services.AddEntityFrameworkProxies();
            services.AddDbContext<BooksContext>(options =>
            {
                options.UseSqlServer(ConnectionString);
                options.UseLazyLoadingProxies();
            });
            services.AddTransient<IMyBooksController, MyBooksController>();

            services.AddLogging(options =>
            {
                options.AddConsole().AddDebug().AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Debug);
            });

            Container = services.BuildServiceProvider();
        }

        public static IServiceProvider Container { get; private set; }
    }
}
