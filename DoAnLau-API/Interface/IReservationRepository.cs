using DoAnLau_API.Models;

namespace DoAnLau_API.Interface
{
    public interface IReservationRepository
    {
        /*    public Task<ICollection<Address>> GetAddress_ByUserId(string UserId);

            public Task<Address> GetAddress_Default(string UserId);*/

        public Task<Reservation> GetReservation_ById(string reservationId);

        public Task<ICollection<Reservation>> Reservation_List();

        public Task<ICollection<Reservation>> Reservation_Search(string? branchId, string? teamSizeId, string timeId, DateTime? dateTime);

        // public Task<bool> IsMenuCategoryExists(string MenuCategoryId);

        public Task<bool> Reservation_Ins(Reservation reservation, string branchId, string customerSizeId, string reservationtimeId);

        public Task<bool> Reservation_Upd(Reservation reservation, string branchId, string customerSizeId, string reservationtimeId);

        public Task<bool> Reservation_Del(Reservation reservation);

        public Task<bool> IsReservationExists(string reservationId);
    }
}
