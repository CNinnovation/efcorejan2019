using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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


        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override EntityEntry Update(object entity)
        {
            return base.Update(entity);
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
    }
}
