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
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationController(IReservationRepository reservationRepository, IMapper mapper)
        {
            this._reservationRepository = reservationRepository;
            this._mapper = mapper;
        }
         [HttpGet("GetReservation_ById/{reservationId}")]
        public async Task<IActionResult> GetReservation_ById(string reservationId)
        {
            if (!await _reservationRepository.IsReservationExists(reservationId))
            {
                return BadRequest();
            }
            var result = await _reservationRepository.GetReservation_ById(reservationId);
            if (result == null)
            {
                return BadRequest();
            }
            var branchMap = _mapper.Map<ReservationDTO>(result);
            return Ok(branchMap);
        }
        [HttpPost("Reservation_Del")]
        public async Task<IActionResult> Reservation_Del([FromForm]string reservationId)
        {
            if (reservationId == null)
            {
                return BadRequest();
            }
            var addressCate = await _reservationRepository.GetReservation_ById(reservationId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!await _reservationRepository.Reservation_Del(addressCate))
            {
                return StatusCode(500, ModelState);
            }
            return Ok(new { success = true });
        }
        [HttpPost("Reservation_Ins")]
        public async Task<IActionResult> Reservation_Ins([FromBody]ReservationDTO reservation)
        {
            if (reservation == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addressMap = _mapper.Map<Reservation>(reservation);
            var rs = !await _reservationRepository.Reservation_Ins(addressMap,reservation.branchId, reservation.customerSizeId, reservation.reservationTimeId);
            if (rs)
            {
                return StatusCode(500, ModelState);
            }
            return Ok(new { success = true });
        }
        [HttpGet("Reservation_List")]
        public async Task<IActionResult> Reservation_List()
        {
            var result = await _reservationRepository.Reservation_List();
            if (result == null)
            {
                return BadRequest();
            }
            var Addmap = _mapper.Map<List<ReservationDTO>>(result);
            return Ok(Addmap);
        }
        [HttpPost("Reservation_Search")]
        public async Task<IActionResult> Reservation_Search([FromForm]string? branchId, [FromForm] string? teamSizeId, [FromForm] string timeId, [FromForm] DateTime? dateTime)
        {
            var result = await _reservationRepository.Reservation_Search(branchId, teamSizeId, timeId, dateTime);
            if (result == null)
            {
                return BadRequest();
            }
            var Addmap = _mapper.Map<List<ReservationDTO>>(result);
            return Ok(Addmap);
        }
        [HttpPost("Reservation_Upd")]
        public async Task<IActionResult> Reservation_Upd([FromBody] ReservationDTO reservation)
        {
            if (reservation == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addressMap = _mapper.Map<Reservation>(reservation);
            if (!await _reservationRepository.Reservation_Upd(addressMap, reservation.branchId, reservation.customerSizeId, reservation.reservationTimeId))
            {
                return StatusCode(500, ModelState);
            }
            return Ok(new { success = true });
        }
    }
}
