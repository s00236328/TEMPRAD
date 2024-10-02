using static week3radlab2.Ads;
using Microsoft.EntityFrameworkCore;
namespace week3radlab2
{
    public class AdsDb : DbContext
    {
        public AdsDb(DbContextOptions<AdsDb> options)
       : base(options) { }

        public DbSet<Ads> Todos => Set<Ads>();
        public DbSet<Categories> Categories => Set<Categories>();
        public DbSet<Seller> Sellers => Set<Seller>();

    }
}
