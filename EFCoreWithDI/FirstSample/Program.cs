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


            controller.ReadBooks();

        }

        private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=BooksSample3;trusted_connection=true";

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddDbContext<BooksContext>(options =>
            {
                options.UseSqlServer(ConnectionString);
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
