using FirstSample.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSample.Services
{
    public class MyBooksController : IMyBooksController
    {
        private readonly BooksContext _booksContext;
        private readonly ILogger<MyBooksController> _logger;
        public MyBooksController(BooksContext booksContext, ILogger<MyBooksController> logger)
        {
            _booksContext = booksContext ?? throw new ArgumentNullException(nameof(booksContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task CreateDatabaseAsync()
        {
            _logger.LogTrace("Create database");
            await _booksContext.Database.EnsureCreatedAsync();
        }

        public async Task AddBooksAsync(IEnumerable<Book> books)
        {
            await _booksContext.Books.AddRangeAsync(books);
            await _booksContext.SaveChangesAsync();
        }

        public void ReadBooks()
        {
            var q = from b in _booksContext.Books
                    where b.Publisher == "AWL"
                    select b;

            var q1 = _booksContext.Books.Where(b => b.Publisher == "AWL").Select(b => b);

            var books = _booksContext.Books.Where(b => b.Publisher == "Wrox Press");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title}");
            }
        }

        public void InMemoryBooks()
        {
            var books = new[]
            {
                 new Book { BookId=1, Title = "Professional C# 7", Publisher = "Wrox Press" },
                 new Book { BookId=2, Title = "Enterprise Services", Publisher = "AWL" },
            };

            var q1 = books.Where(b => b.Publisher == "AWL").Select(b => b);

            foreach (var b in q1)
            {
                Console.WriteLine(b);
            }
        }
    }
}
