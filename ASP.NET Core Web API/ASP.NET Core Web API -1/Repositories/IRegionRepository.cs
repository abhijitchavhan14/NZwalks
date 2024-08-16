using ASP.NET_Core_Web_API__1.Models.Domain;


namespace ASP.NET_Core_Web_API__1.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
    }
}
