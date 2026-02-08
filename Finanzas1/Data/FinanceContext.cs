using Microsoft.EntityFrameworkCore;
using Finanzas1.Models;


namespace Finanzas1.Data
{
  public class FinanceContext : DbContext
    {
        public DbSet<Movement> Movements { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlite("Data Source = finanzas.db");
        }
    }
}
