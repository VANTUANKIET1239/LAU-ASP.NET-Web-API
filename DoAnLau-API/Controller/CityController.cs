using AutoMapper;
using DoAnLau_API.Interface;
using DoAnLau_API.Responsitory;
using Microsoft.AspNetCore.Mvc;

namespace DoAnLau_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityController(ICityRepository  cityRepository
                               ,IMapper mapper
            )
        {
            this._cityRepository = cityRepository;
            this._mapper = mapper;
        }
        [HttpGet("GetCities")]
        public async Task<IActionResult> GetCities()
        {
            var result = await _cityRepository.GetCities();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<List<CityDTO>>(result));
        }
    }
}
