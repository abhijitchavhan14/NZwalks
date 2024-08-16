using ASP.NET_Core_Web_API__1.Data;
using ASP.NET_Core_Web_API__1.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Web_API__1.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly WebAPI1DbContext nWebAPI1DbContext;

        //private readonly WebAPI1DbContext nwebAPI1DbContext;
        public RegionRepository(WebAPI1DbContext nWebAPI1DbContext)
        {
            this.nWebAPI1DbContext = nWebAPI1DbContext;
            //this.nwebAPI1DbContext = nwebAPI1DbContext;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await nWebAPI1DbContext.Regions.ToListAsync();
        }
    }
}
