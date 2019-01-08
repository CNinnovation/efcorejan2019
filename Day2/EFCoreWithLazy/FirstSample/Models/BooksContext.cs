using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstSample.Models
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().ToTable("MyBooks").Property(b => b.Publisher).IsRequired(false).HasMaxLength(20);


            var books = new[]
            {
                 new Book { BookId=1, Title = "Professional C# 7", Publisher = "Wrox Press" },
                 new Book { BookId=2, Title = "Enterprise Services", Publisher = "AWL" },
            };
            modelBuilder.Entity<Book>().HasData(books);
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Chapter> Chapters { get; set; }
    }
}
