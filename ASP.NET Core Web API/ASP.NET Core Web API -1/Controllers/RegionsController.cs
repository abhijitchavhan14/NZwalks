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

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
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

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]

        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionRepository.GetAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = mapper.Map<Models.DTO.Region>(region);

            return Ok(regionDTO);
        }


  

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(Models.DTO.AddRegionRequest addRegionRequest)
        {
            //request to Domain models

            var region = new Models.Domain.Region()
            {
                Code = addRegionRequest.Code,
                Area = addRegionRequest.Area,
                Name = addRegionRequest.Name,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Population = addRegionRequest.Population,
            };

            //pass details to Repository

           region = await regionRepository.AddAsync(region);


            //Region to DTO

            var regionDTO = mapper.Map<Models.DTO.Region>(region);
            //var regionDTO = new Models.DTO.Region
            //{
            //    Id = region.Id,
            //    Code = region.Code,
            //    Area = region.Area, 
            //    Name = region.Name,
            //    Lat = region.Lat,
            //    Long = region.Long,
            //    Population = region.Population,


            //};

            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDTO.Id},regionDTO);


        }

        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var region = await regionRepository.DeleteAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDTO);




        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync(Guid id, Models.DTO.UpdateRegionRequest updateRegionRequest)
        {
            
            var region = new Models.Domain.Region();
            {
                region.Code = updateRegionRequest.Code;
                region.Area = updateRegionRequest.Area;
                region.Name = updateRegionRequest.Name;
                region.Lat = updateRegionRequest.Lat;
                region.Long = updateRegionRequest.Long;
                region.Population = updateRegionRequest.Population;
            }

            region = await regionRepository.UpdateAsync(id,region);

            if (region == null)
            {
                return NotFound();

            }
            var regionDTO = mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDTO);



        }


    }


}

