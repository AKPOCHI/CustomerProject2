

using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=ANIBE;Integrated Security=True;database=CustomerPoject2;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Command Timeout=0",
                sqlServerOptionsAction: SqlOptions =>
                {
                    SqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5, // Number of retry attempts
                        maxRetryDelay: TimeSpan.FromSeconds(10), // Delay between retries
                        errorNumbersToAdd: null);  // Optionally specify SQL error numbers to consider as transient

                });
        }

        public virtual  DbSet<Customer>Customers { get; set; }
        public virtual DbSet<CustomerAccount>CustomerAccounts { get; set; }
        public virtual DbSet<StatementOfAccount> StatementOfAccounts { get; set; }
    }
}
