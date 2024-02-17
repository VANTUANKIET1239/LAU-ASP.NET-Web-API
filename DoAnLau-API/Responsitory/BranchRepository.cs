using DoAnLau_API.Data;
using DoAnLau_API.FF;
using DoAnLau_API.Interface;
using DoAnLau_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DoAnLau_API.Responsitory
{
    public class BranchRepository : IBranch
    {
        private readonly DataContext _dataContext;
        private readonly ISYS_INDEX _sYS_INDEX;

        public BranchRepository(DataContext dataContext, ISYS_INDEX sYS_INDEX) 
        {
            this._dataContext = dataContext;
            this._sYS_INDEX = sYS_INDEX;
        }
        public async Task<Branch> Branch_ById(string branchId)
        {
            return await _dataContext.Branches.Where(x => x.branch_Id == branchId && x.state).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Branch>> Branch_ByPromotionId(string promotionId)
        {
            return await _dataContext.PromotionBranchs.Where(x => x.promotion_Id == promotionId).Include(x => x.branch).Select(x => x.branch).ToListAsync();
        }

        public async Task<bool> Branch_Del(Branch branch)
        {
            branch.state = false;
            _dataContext.Update(branch);
            return await _dataContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> Branch_Ins(Branch branch)
        {
            var getPromotionCount = await _sYS_INDEX.GetIndex_ByName("BRANCH");
            string newBranchId = getPromotionCount.prefix + (++getPromotionCount.currentIndex).ToString("00000000000");
            branch.branch_Id = newBranchId;
            var rs3 = await _sYS_INDEX.SysIndex_Upd(getPromotionCount.currentIndex, "BRANCH");
            var rs1 = await _dataContext.Branches.AddAsync(branch);
          //  var rs4 = await _dataContext.SaveChangesAsync() > 0 ? true : false;
            return await _dataContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<ICollection<Branch>> Branch_List()
        {
            var r = await _dataContext.Branches.Where(x => x.state).ToListAsync(); 
            return r;
        }

        public async Task<ICollection<Branch>> Branch_ListExcept(string promotionId)
        {
            var checkedBranch = await _dataContext.PromotionBranchs.Where(x => x.promotion_Id == promotionId).Include(x => x.branch).Select(x => x.branch).ToListAsync();
            if (checkedBranch.Count == 0)
            {
                return await _dataContext.Branches.Where(x => x.state).ToListAsync();
            }
           var ListBranchNonChecking = (await _dataContext.Branches.Where(x => x.state).ToListAsync()).Except(checkedBranch, new BranchComparer()).ToList();
            return ListBranchNonChecking;

        }

        public async Task<bool> Branch_Upd(Branch branch)
        {
         
            var editBranch = _dataContext.Branches.Where(x => x.branch_Id == branch.branch_Id).FirstOrDefault();
            editBranch.branchName = branch.branchName;
            editBranch.email = branch.email;
            editBranch.openingTime = branch.openingTime;
            editBranch.addressDetail = branch.addressDetail;
            editBranch.city = branch.city;
            editBranch.ward = branch.ward;
            editBranch.district = branch.district;
            editBranch.phone = branch.phone;
            _dataContext.Update(editBranch);
            return await _dataContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> IsBranchExists(string branchId)
        {
            return await _dataContext.Branches.AnyAsync(x => x.branch_Id == branchId && x.state);
        }
    }
}
