using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TheRealBooksWebApp
{
    public partial class BooksSampleContext : DbContext
    {
        public BooksSampleContext(DbContextOptions<BooksSampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Books> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BookId);
            });
        }
    }
}
