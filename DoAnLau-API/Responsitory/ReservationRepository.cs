using DoAnLau_API.Data;
using DoAnLau_API.Interface;
using DoAnLau_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnLau_API.Responsitory
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DataContext _dataContext;
        private readonly ISYS_INDEX _sYS_INDEX;

        public ReservationRepository(DataContext dataContext, ISYS_INDEX sYS_INDEX)
        {
            this._dataContext = dataContext;
            this._sYS_INDEX = sYS_INDEX;
        }
        public async Task<Reservation> GetReservation_ById(string reservationId)
        {
            return await _dataContext.Reservations.Where(x => x.reservation_Id == reservationId && x.state).Include(x => x.branch).Include(x => x.reservationTime).Include(x => x.customerSize).FirstOrDefaultAsync();
        }

        public async Task<bool> IsReservationExists(string reservationId)
        {
            return await _dataContext.Reservations.AnyAsync(x => x.reservation_Id == reservationId && x.state);
        }

        public async Task<bool> Reservation_Del(Reservation reservation)
        {
            reservation.state = false;
            _dataContext.Update(reservation);
            return await _dataContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> Reservation_Ins(Reservation reservation, string branchId, string customerSizeId, string reservationtimeId)
        {
            var getReservationCount = await _sYS_INDEX.GetIndex_ByName("RESERVATION");
            string newReservationId = getReservationCount.prefix + (++getReservationCount.currentIndex).ToString("00000000000");
            reservation.reservation_Id = newReservationId;
            reservation.branch = await _dataContext.Branches.Where(x => x.branch_Id == branchId).FirstOrDefaultAsync();
            reservation.customerSize = await _dataContext.CustomerSizes.Where(x => x.customerSize_Id == customerSizeId).FirstOrDefaultAsync();
            reservation.reservationTime = await _dataContext.ReservationTimes.Where(x => x.reservationTime_Id == reservationtimeId).FirstOrDefaultAsync();
            var rs3 = await _sYS_INDEX.SysIndex_Upd(getReservationCount.currentIndex, "RESERVATION");
            var rs1 = await _dataContext.Reservations.AddAsync(reservation);
            //  var rs4 = await _dataContext.SaveChangesAsync() > 0 ? true : false;
            return await _dataContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<ICollection<Reservation>> Reservation_List()
        {
           return await _dataContext.Reservations.Where(x => x.state).Include(x => x.branch).Include(x => x.reservationTime).Include(x => x.customerSize).ToListAsync();
        }

        public async Task<ICollection<Reservation>> Reservation_Search(string? branchId, string? teamSizeId, string timeId, DateTime? dateTime)
        {
            var Reservations = _dataContext.Reservations.Include(x => x.branch).Include(x => x.reservationTime).Include(x => x.customerSize);
            if (dateTime != null)
            {
                Reservations.Where(x => x.reservationDate.ToString("dd/MM/yyyy") == (dateTime ?? DateTime.Now).ToString("dd/MM/yyyy"));
            }
            if (branchId != null)
            {
                Reservations.Where(x => x.branch.branch_Id == branchId);
            }
            if (teamSizeId != null)
            {
                Reservations.Where(x => x.customerSize.customerSize_Id == teamSizeId);
            }
            if (timeId != null)
            {
                Reservations.Where(x => x.reservationTime.reservationTime_Id == timeId);
            }
            return await Reservations.ToListAsync();
        }

        public async Task<bool> Reservation_Upd(Reservation reservation, string branchId, string customerSizeId, string reservationtimeId)
        {
            var editBranch = _dataContext.Reservations.Where(x => x.reservation_Id == reservation.reservation_Id).FirstOrDefault();
            editBranch.reservationDate = reservation.reservationDate;
            editBranch.branch = await _dataContext.Branches.Where(x => x.branch_Id == branchId).FirstOrDefaultAsync();
            editBranch.customerSize = await _dataContext.CustomerSizes.Where(x => x.customerSize_Id == customerSizeId).FirstOrDefaultAsync();
            editBranch.reservationTime = await _dataContext.ReservationTimes.Where(x => x.reservationTime_Id == reservationtimeId).FirstOrDefaultAsync();
            editBranch.state = reservation.state;
            _dataContext.Update(editBranch);
            return await _dataContext.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
