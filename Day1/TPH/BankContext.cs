using Microsoft.EntityFrameworkCore;

namespace TPHWithConventions
{
    public class BankContext : DbContext
    {
        private const string ConnectionString = @"server=(localdb)\MSSQLLocalDb;" +
            "Database=LocalBankTest4;Trusted_Connection=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<CreditcardPayment>().HasKey(p => p.PaymentId);
            //modelBuilder.Entity<CashPayment>().HasKey(p => p.PaymentId);
        }

        public DbSet<CreditcardPayment> CreditcardPayments { get; set; }
        public DbSet<CashPayment> CashPayments { get; set; }
    }
}
