using DoAnLau_API.Models;

namespace DoAnLau_API.Interface
{
    public interface IAddresssRepository
    {
        public Task<ICollection<Address>> GetAddress_ByUserId(string UserId);

        public Task<Address> GetAddress_Default(string UserId);

        public Task<Address> GetAddress_ById(string MenuCategoryId);

    // public Task<bool> IsMenuCategoryExists(string MenuCategoryId);

        public Task<bool> Address_Ins(Address menuCategory);

        public Task<bool> Address_Upd(Address menuCategory);

        public Task<bool> Address_Del(Address menuCategory);

        public Task<bool> IsAddressExists(string addressId);
    }
}
