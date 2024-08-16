using ASP.NET_Core_Web_API__1.Models.Domain;
using ASP.NET_Core_Web_API__1.Models.DTO;
using ASP.NET_Core_Web_API__1.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Web_API__1.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository , IMapper mapper)
        {

            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        

       

        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionRepository.GetAllAsync();

            //Return DTO Regions

            //var regionsDTO = new List<Models.DTO.Region>();

            //    regions.ToList().ForEach(region =>
            //    {
            //        var regionDTO = new Models.DTO.Region();
            //        {
            //            regionDTO.Id = region.Id;
            //            regionDTO.Name = region.Name;
            //            regionDTO.Area = region.Area;
            //            regionDTO.Code = region.Code;
            //            regionDTO.Lat = region.Lat;
            //            regionDTO.Long = region.Long;
            //            regionDTO.Population = region.Population;

            //        }

            //        regionsDTO.Add(regionDTO);

            //    });

            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);

            return Ok(regionsDTO);

        }









        //var regions = new List<Region>()
        //{
        //    new Region
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "Mumbai ",
        //        Code ="MUM",
        //        Area = 224455,
        //        Lat = -5.4546,
        //        Long = 45.54544,
        //        Population = 40000000
        //    },

        //     new Region
        //    {
        //        Id = Guid.NewGuid(),
        //        Name = "Banglore",
        //        Code ="BANG",
        //        Area = 224455,
        //        Lat = -5.4546,
        //        Long = 45.54544,
        //        Population = 40000000
        //    }


        //};



        //return View();

        //public IActionResult Index()
        //{
        //    var region = new List<Region>();
        //    {
        //        new Region
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Mumbai ",
        //            Code = "MUM",
        //            Area = 224455
        //        };
        //    }
        //    return Ok(region);
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
