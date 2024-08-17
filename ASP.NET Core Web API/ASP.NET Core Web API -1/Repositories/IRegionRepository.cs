using ASP.NET_Core_Web_API__1.Models.Domain;


namespace ASP.NET_Core_Web_API__1.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();

        Task<Region> GetAsync(Guid id);

        Task<Region> AddAsync(Region region);

        Task<Region>DeleteAsync(Guid id);

        Task<Region> UpdateAsync(Guid id,Region region);



    }
}
