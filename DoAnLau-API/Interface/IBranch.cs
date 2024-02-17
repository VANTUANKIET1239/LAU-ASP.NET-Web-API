using DoAnLau_API.Models;

namespace DoAnLau_API.Interface
{
    public interface IBranch
    {
        public Task<ICollection<Branch>> Branch_List();

      //  public Task<Address> Branch_Default(string UserId);

        public Task<Branch> Branch_ById(string branchId);

         public Task<bool> IsBranchExists(string branchId);

        public Task<bool> Branch_Ins(Branch branch);

        public Task<bool> Branch_Upd(Branch branch);

        public Task<bool> Branch_Del(Branch branch);

        public Task<ICollection<Branch>> Branch_ListExcept(string promotionId);

        public Task<ICollection<Branch>> Branch_ByPromotionId(string promotionId);

        //public Task<bool> IsAddressExists(string addressId);
    }
}
