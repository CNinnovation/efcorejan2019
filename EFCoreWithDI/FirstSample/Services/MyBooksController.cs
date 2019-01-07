using FirstSample.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FirstSample.Services
{
    public class MyBooksController : IMyBooksController
    {
        private readonly BooksContext _booksContext;
        public MyBooksController(BooksContext booksContext)
        {
            _booksContext = booksContext ?? throw new ArgumentNullException(nameof(booksContext));
        }

        public async Task CreateDatabaseAsync()
        {
            await _booksContext.Database.EnsureCreatedAsync();
        }

        public async Task AddBooksAsync(IEnumerable<Book> books)
        {
            await _booksContext.Books.AddRangeAsync(books);
            await _booksContext.SaveChangesAsync();
        }
    }
}
