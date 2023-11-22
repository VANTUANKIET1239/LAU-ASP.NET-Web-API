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
    public class WardController : ControllerBase
    {
        private readonly IWardRepository _wardRepository;
        private readonly IMapper _mapper;

        public WardController(IWardRepository wardRepository
                                ,IMapper mapper
            )
        {
            this._wardRepository = wardRepository;
            this._mapper = mapper;
        }
        [HttpGet("GetWards")]
        public async Task<IActionResult> GetWards()
        {
            var result = await _wardRepository.GetWards();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<List<WardDTO>>(result));
        }
        [HttpGet("GetWards/{districtId}")]
        public async Task<IActionResult> GetWards_ByDistrictId(int districtId)
        {
            var result = await _wardRepository.GetWards_ByDistrictId(districtId);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<List<WardDTO>>(result));
        }
    }
}
