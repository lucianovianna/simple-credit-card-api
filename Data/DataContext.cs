using Microsoft.EntityFrameworkCore;
using creditCardApi.Models;

namespace creditCardApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<CreditCard> CreditCards { get; set; }
    }
}