using FirstSample.Models;
using System;

namespace FirstSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book { Title = "Professional C# 7", Publisher = "Wrox Press" };
            var context = new BooksContext();
            bool created = context.Database.EnsureCreated();
            Console.WriteLine($"database created? {created}");
            context.Books.Add(book);
            int changed = context.SaveChanges();
            Console.WriteLine($"records {changed} changed");
        }
    }
}
