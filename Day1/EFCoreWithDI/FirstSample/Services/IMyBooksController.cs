using System.Collections.Generic;
using System.Threading.Tasks;
using FirstSample.Models;

namespace FirstSample.Services
{
    public interface IMyBooksController
    {
        Task AddBooksAsync(IEnumerable<Book> books);
        Task CreateDatabaseAsync();

        void ReadBooks();
    }
}