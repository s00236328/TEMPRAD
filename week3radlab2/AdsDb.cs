using static week3radlab2.Ads;
using Microsoft.EntityFrameworkCore;
namespace week3radlab2
{
    public class AdsDb : DbContext
    {
        public string DbPath { get; }

        public DbSet<Ads> Ads { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Seller> Sellers { get; set; }

        public AdsDb()
        {
            DbPath = "ads.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
