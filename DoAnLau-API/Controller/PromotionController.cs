using AutoMapper;
using DoAnLau_API.Data;
using DoAnLau_API.Interface;
using DoAnLau_API.Models;
using DoAnLau_API.Responsitory;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DoAnLau_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PromotionController(IPromotionRepository promotionRepository
                                    ,IMapper mapper,
                                    IHttpContextAccessor httpContextAccessor
            )
        {
            this._promotionRepository = promotionRepository;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
        }
        [HttpPost("CreatePromotionCategory"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreatePromotionCategory([FromForm] string promotion, [FromForm] IFormFile? fromFile)
        {
            if (promotion == null || promotion.Trim() == "")
            {
                return Ok(new { success = false, message = "Tạo ưu đãi thất bại" });
            }
            var promotionObject = JsonSerializer.Deserialize<PromotionDTO>(promotion);
            if (fromFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    fromFile.CopyTo(memoryStream);
                    promotionObject.PromotionImage = memoryStream.ToArray();
                }
            }
            var promotionDTMap = _mapper.Map<List<PromotionDetail>>(promotionObject.promotionDetails);
            var promotionMap = _mapper.Map<Promotion>(promotionObject);
            if (!await _promotionRepository.CreatePromotionCategory(promotionMap, promotionDTMap))
            {
                return Ok(new { success = false, message = "Tạo ưu đãi thất bại" });
            };
            return Ok(new { success = true, message = "Tạo ưu đãi thành công" });
        }
        [HttpGet("GetPromotion/{promotionId}")]
        public async Task<IActionResult> GetPromotion(string promotionId)
        {
            if (!await _promotionRepository.IsPromotionExists(promotionId))
            {
                return BadRequest();
            }
            var result = await _promotionRepository.GetPromotion(promotionId);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<PromotionDTO>(result));
        }
        /* [HttpGet("GetPromotions_ByUserId")]
         public async Task<IActionResult> GetPromotions_ByUser()
         {

            *//* var result = await _promotionRepository.GetPromotions_ByUserId();
             if (result == null)
             {
                 return BadRequest();
             }
             return Ok(_mapper.Map<List<PromotionDTO>>(result));*//*
         }*/

        [HttpGet("GetPromotions")]
        public async Task<IActionResult> GetPromotions()
        {

            var result = await _promotionRepository.GetPromotions();
             if (result == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<List<PromotionDTO>>(result)); 
         }

        [HttpPost("RemovePromotionCategory"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> RemovePromotionCategory([FromForm] string promotionId)
        {
            if (promotionId == null)
            {
                return BadRequest();
            }
            var promotionCate = await _promotionRepository.GetPromotion(promotionId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _promotionRepository.RemovePromotionCategory(promotionCate))
            {
                return StatusCode(500, ModelState);
            }
            return Ok(new { success = true });
        }
        [HttpPost("UpdatePromotionCategory"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdatePromotionCategory([FromForm] string promotion, [FromForm] IFormFile? fromFile)
        {
            if (promotion == null || promotion.Trim() == "")
            {
                return Ok(new { success = false, message = "Chỉnh sửa ưu đãi thất bại" });
            }   
            var promotionObject = JsonSerializer.Deserialize<PromotionDTO>(promotion);
            if (fromFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    fromFile.CopyTo(memoryStream);
                    promotionObject.PromotionImage = memoryStream.ToArray();
                }
            }
            var promotionDTMap = _mapper.Map<List<PromotionDetail>>(promotionObject.promotionDetails);
            var promotionMap = _mapper.Map<Promotion>(promotionObject);
            if (!await _promotionRepository.UpdatePromotionCategory(promotionMap, promotionDTMap))
            {
                return Ok(new { success = false, message = "Chỉnh sửa ưu đãi thất bại" });
            };
            return Ok(new { success = true, message = "Chỉnh sửa ưu đãi thành công" });
        }
            
    }
}
