using Microsoft.EntityFrameworkCore;
using SuperMarket.Entities;

namespace SuperMarket.Persistence.EF
{
    public class EFDataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=SuperMarket;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Good> Goods { get; protected set; }
        public DbSet<GoodCategory> GoodCategories { get; protected set; }
    }
}
