

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



        public virtual  DbSet<Customer>Customers { get; set; }
        public virtual DbSet<CustomerAccount>CustomerAccounts { get; set; }
        public virtual DbSet<StatementOfAccount> StatementOfAccounts { get; set; }
    }
}
