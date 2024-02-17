using AutoMapper;
using DoAnLau_API.Interface;
using DoAnLau_API.Models;
using DoAnLau_API.Responsitory;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DoAnLau_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranch _branch;
        private readonly IMapper _mapper;
        private readonly IWardRepository _wardRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ICityRepository _cityRepository;

        public BranchController(IBranch branch, 
                                IMapper mapper,
                                IWardRepository wardRepository,
                                IDistrictRepository districtRepository,
                                ICityRepository cityRepository

            )
        {
            this._branch = branch;
            this._mapper = mapper;
            this._wardRepository = wardRepository;
            this._districtRepository = districtRepository;
            this._cityRepository = cityRepository;
        }
        [HttpGet("Branch_ById/{branchId}")]
        public async Task<IActionResult> Branch_ById(string branchId)
        {
            if (!await _branch.IsBranchExists(branchId))
            {
                return BadRequest();
            }
            var result = await _branch.Branch_ById(branchId);
            if (result == null)
            {
                return BadRequest();
            }
            var branchMap = _mapper.Map<BranchDTO>(result);
            branchMap.cityName = (await _cityRepository.GetCity_ById(branchMap.city)).tenTinhThanhPho;
            branchMap.districtName = (await _districtRepository.GetDistrict_ById(branchMap.district)).tenQuanHuyen;
            branchMap.wardName = (await _wardRepository.GetWard_ById(branchMap.ward)).tenXaPhuong;
            return Ok(branchMap);
        }
        [HttpPost("Branch_Del")]
        public async Task<IActionResult> Branch_Del([FromForm] string branchId)
        {
            if (branchId == null)
            {
                return BadRequest();
            }
            var addressCate = await _branch.Branch_ById(branchId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _branch.Branch_Del(addressCate))
            {
                return StatusCode(500, ModelState);
            }
            return Ok(new { success = true });
        }
        [HttpPost("Branch_Ins")]
        public async Task<IActionResult> Branch_Ins([FromBody] BranchDTO branch)
        {
            if (branch == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addressMap = _mapper.Map<Branch>(branch);
            var rs = !await _branch.Branch_Ins(addressMap);
            if (rs)
            {
                return StatusCode(500, ModelState);
            }
            return Ok(new { success = true });
        }
        [HttpGet("Branch_List")]
        public async Task<IActionResult> Branch_List()
        {
            var result = await _branch.Branch_List();
            if (result == null)
            {
                return BadRequest();
            }
            var Addmap = _mapper.Map<List<BranchDTO>>(result);
            foreach (var address in Addmap)
            {
                address.cityName = (await _cityRepository.GetCity_ById(address.city)).tenTinhThanhPho;
                address.districtName = (await _districtRepository.GetDistrict_ById(address.district)).tenQuanHuyen;
                address.wardName = (await _wardRepository.GetWard_ById(address.ward)).tenXaPhuong;
            }
            return Ok(Addmap);
        }
        [HttpPost("Branch_Upd")]
        public async Task<IActionResult> Branch_Upd([FromBody] BranchDTO branch)
        {
            if (branch == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addressMap = _mapper.Map<Branch>(branch);
            if (!await _branch.Branch_Upd(addressMap))
            {
                return StatusCode(500, ModelState);
            }
            return Ok(new { success = true });
        }
        [HttpGet("Branch_ListExcept/{promotionId}")]
        public async Task<IActionResult> Branch_ListExcept(string promotionId)
        {
            var result = await _branch.Branch_ListExcept(promotionId);
            if (result == null)
            {
                return BadRequest();
            }
            var Addmap = _mapper.Map<List<BranchDTO>>(result);
            foreach (var address in Addmap)
            {
                address.cityName = (await _cityRepository.GetCity_ById(address.city)).tenTinhThanhPho;
                address.districtName = (await _districtRepository.GetDistrict_ById(address.district)).tenQuanHuyen;
                address.wardName = (await _wardRepository.GetWard_ById(address.ward)).tenXaPhuong;
            }
            return Ok(Addmap);
        }
        [HttpGet("Branch_ByPromotionId/{promotionId}")]
        public async Task<IActionResult> Branch_ByPromotionId(string promotionId)
        {
            var result = await _branch.Branch_ByPromotionId(promotionId);
            if (result == null)
            {
                return BadRequest();
            }
            var Addmap = _mapper.Map<List<BranchDTO>>(result);
            foreach (var address in Addmap)
            {
                address.cityName = (await _cityRepository.GetCity_ById(address.city)).tenTinhThanhPho;
                address.districtName = (await _districtRepository.GetDistrict_ById(address.district)).tenQuanHuyen;
                address.wardName = (await _wardRepository.GetWard_ById(address.ward)).tenXaPhuong;
            }
            return Ok(Addmap);
        }
    }
}
