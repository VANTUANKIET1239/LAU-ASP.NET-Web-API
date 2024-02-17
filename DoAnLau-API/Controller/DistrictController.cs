using AutoMapper;
using DoAnLau_API.Data;
using DoAnLau_API.Interface;
using DoAnLau_API.Models;
using DoAnLau_API.Responsitory;
using Microsoft.AspNetCore.Mvc;

namespace DoAnLau_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;

        public DistrictController(IDistrictRepository districtRepository
                                    , IMapper mapper
            )
        {
            this._districtRepository = districtRepository;
            this._mapper = mapper;
        }
        [HttpGet("GetDistricts")]
        public async Task<IActionResult> GetDistricts()
        {
            var result = await _districtRepository.GetDistricts();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<List<DistrictDTO>>(result));
        }
        [HttpGet("GetDistricts/{CityId}")]
        public async Task<IActionResult> GetDistrict_ByCityId(int CityId)
        {
            
            var result = await _districtRepository.GetDistrict_ByCityId(CityId);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<List<DistrictDTO>>(result));
        }
    }
}
