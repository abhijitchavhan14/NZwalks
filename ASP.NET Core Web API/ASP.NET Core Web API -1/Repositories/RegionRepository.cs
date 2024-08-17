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

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = new Guid();
            await nWebAPI1DbContext.Regions.AddAsync(region);
            await nWebAPI1DbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
           var region = await nWebAPI1DbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
            {
                return null;
            }
            nWebAPI1DbContext.Regions.Remove(region);
            await nWebAPI1DbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await nWebAPI1DbContext.Regions.ToListAsync();
        }

        public async Task<Region>GetAsync(Guid id)
        {
            return await nWebAPI1DbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var CurrentRegion = await nWebAPI1DbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (CurrentRegion == null)
            {
                return null;
            }

            CurrentRegion.Area = region.Area;
            CurrentRegion.Code = region.Code;
            CurrentRegion.Name = region.Name;
            CurrentRegion.Lat = region.Lat;
            CurrentRegion.Long = region.Long;
            CurrentRegion.Population = region.Population;

            await nWebAPI1DbContext.SaveChangesAsync();
            return CurrentRegion;



    }
}
}
