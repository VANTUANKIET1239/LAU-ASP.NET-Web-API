using AutoMapper;
using DoAnLau_API.Data;
using DoAnLau_API.Interface;
using DoAnLau_API.Models;
using DoAnLau_API.Responsitory;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO.Pipelines;

namespace DoAnLau_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddresssRepository _addresssRepository;
        private readonly IWardRepository _wardRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public AddressController(IAddresssRepository addresssRepository,
                                  IWardRepository wardRepository,
                                  IDistrictRepository districtRepository ,
                                  ICityRepository cityRepository
                                , IMapper mapper
            )
        {
            this._addresssRepository = addresssRepository;
            this._wardRepository = wardRepository;
            this._districtRepository = districtRepository;
            this._cityRepository = cityRepository;
            this._mapper = mapper;
        }
        [HttpPost("Address_Del"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Address_Del([FromForm] string addressId)
        {
            if (addressId == null)
            {
                return BadRequest();
            }
            var addressCate = await _addresssRepository.GetAddress_ById(addressId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _addresssRepository.Address_Del(addressCate))
            {
                return StatusCode(500, ModelState);
            }
            return Ok(new { success = true });
        }
        [HttpPost("Address_Ins")]
        public async Task<IActionResult> Address_Ins([FromBody] AddressDTO address)
        {
            if (address == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addressMap = _mapper.Map<Address>(address);
            if (!await _addresssRepository.Address_Ins(addressMap))
            {
                return StatusCode(500, ModelState);
            }
            return Ok(new { success = true });
        }
        [HttpPost("Address_Upd"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Address_Upd([FromBody]AddressDTO address)
        {
            if (address == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addressMap = _mapper.Map<Address>(address);
            if (!await _addresssRepository.Address_Upd(addressMap))
            {
                return StatusCode(500, ModelState);
            }
            return Ok(new { success = true });
        }
        [HttpGet("GetAddressById/{addressId}")]
        public async Task<IActionResult> GetAddress_ById(string addressId)
        {
            if (!await _addresssRepository.IsAddressExists(addressId))
            {
                return BadRequest();
            }
            var result = await _addresssRepository.GetAddress_ById(addressId);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<AddressDTO>(result));
        }
        [HttpGet("GetAddressByUserId/{userId}")]
        public async Task<IActionResult> GetAddress_ByUserId(string userId)
        {
            var result = await _addresssRepository.GetAddress_ByUserId(userId);
            if (result == null)
            {
                return BadRequest();
            }
            var Addmap = _mapper.Map<List<AddressDTO>>(result);
            foreach (var address in Addmap)
            {
                address.cityName = (await _cityRepository.GetCity_ById(address.city)).tenTinhThanhPho;
                address.districtName = (await _districtRepository.GetDistrict_ById(address.district)).tenQuanHuyen;
                address.wardName = (await _wardRepository.GetWard_ById(address.ward)).tenXaPhuong;
            }
            return Ok(Addmap);
        }
        [HttpGet("GetAddressDefault/{userId}")]
        public async Task<IActionResult> GetAddress_Default(string userId)
        {
            var result = await _addresssRepository.GetAddress_Default(userId);
            if (result == null)
            {
                return Ok(new { success = false });
            }
            var Addmap = _mapper.Map<AddressDTO>(result);

            Addmap.cityName = (await _cityRepository.GetCity_ById(Addmap.city)).tenTinhThanhPho;
            Addmap.districtName = (await _districtRepository.GetDistrict_ById(Addmap.district)).tenQuanHuyen;
            Addmap.wardName = (await _wardRepository.GetWard_ById(Addmap.ward)).tenXaPhuong;
            return Ok(new { success = true, model = Addmap });
        }
    }
}
