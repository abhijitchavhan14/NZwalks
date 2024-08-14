using Microsoft.EntityFrameworkCore;
using ASP.NET_Core_Web_API__1.Models.Domain;

namespace ASP.NET_Core_Web_API__1.Data
{
    public class WebAPI1DbContext:DbContext
    {
        public WebAPI1DbContext(DbContextOptions<WebAPI1DbContext> options):base(options)
        {
            
        }


        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        public DbSet<WalkDifficulty> WalksDifficulty { get; set; }
    }
}
