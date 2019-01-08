using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstSample.Models
{
    public class BooksContext : DbContext
    {
        // private const string ConnectionString = @"server=(localdb)\mssqllocaldb;database=BooksSample;trusted_connection=true";
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    optionsBuilder.UseSqlServer(ConnectionString);


        //}

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
    }
}
