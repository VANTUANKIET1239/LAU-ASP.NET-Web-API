using DoAnLau_API.Data;
using DoAnLau_API.FF;
using DoAnLau_API.Interface;
using DoAnLau_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace DoAnLau_API.Responsitory
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly DataContext _dataContext;
        private readonly ISYS_INDEX _sYS_INDEX;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public PromotionRepository(DataContext dataContext, ISYS_INDEX sYS_INDEX
                                  , IHttpContextAccessor httpContextAccessor
                                , UserManager<ApplicationUser> userManager
                        )
        {
            this._dataContext = dataContext;
            this._sYS_INDEX = sYS_INDEX;
            this._httpContextAccessor = httpContextAccessor;
            this._userManager = userManager;
        }
        public async Task<bool> CreatePromotionCategory(Promotion promotion, List<PromotionDetail> promotionDetails)
        {
            var getPromotionCount = await _sYS_INDEX.GetIndex_ByName("PROMOTION");
            string newPromotionId = getPromotionCount.prefix + (++getPromotionCount.currentIndex).ToString("00000000000");
            promotion.promotion_Id = newPromotionId;
            await _dataContext.Promotions.AddAsync(promotion);
            if (await _dataContext.SaveChangesAsync() > 0)
            {
                if (await PromotionContent_Add(promotionDetails, newPromotionId))
                {
                    return true;
                }
            }
            await _sYS_INDEX.SysIndex_Upd(getPromotionCount.currentIndex, "PROMOTION");
            return await _dataContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<Promotion> GetPromotion(string promotionId)
        {
            return await _dataContext.Promotions.Where(x => x.promotion_Id == promotionId && x.state).Include(x => x.promotionDetails).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Promotion>> GetPromotions()
        {
            return await _dataContext.Promotions.Where(x => x.state).Include(x => x.promotionDetails).ToListAsync();
        }

        public async Task<ICollection<Promotion>> GetPromotions_ByUserId(string UserId)
        {
            var result = await _dataContext.PromotionUsers
                 .Where(x => x.user_Id == UserId)
                 .Include(x => x.promotion)
                 .Select(x => new
                 {
                     Promotion = x.promotion,
                     RedeemCount = x.redeemCount
                 })
                 .ToListAsync();

            foreach (var item in result)
            {
                item.Promotion.redeemCount = item.RedeemCount;
            }
            return result.Select(x => x.Promotion).ToList();
        }

        public async Task<bool> IsPromotionExists(string promotionId)
        {
            return await _dataContext.Promotions.AnyAsync(x => x.promotion_Id == promotionId && x.state);
        }

        public async Task<bool> PromotionContent_Add(List<PromotionDetail> promotionDetail, string newPromotionId)
        {
            var getPromotionCount = await _sYS_INDEX.GetIndex_ByName("PROMOTION_DETAIL");
            var promotion = await _dataContext.Promotions.Where(x => x.promotion_Id == newPromotionId).FirstOrDefaultAsync();

            promotionDetail.ForEach(async x =>
            {
                x.promotion = promotion;
                ++getPromotionCount.currentIndex;
                string newPromotionId = getPromotionCount.prefix + (getPromotionCount.currentIndex).ToString("00000000000");
                x.promotionDetail_Id = newPromotionId;
                await _dataContext.PromotionDetails.AddAsync(x);
                _dataContext.SaveChanges();

            });
            await _sYS_INDEX.SysIndex_Upd(getPromotionCount.currentIndex, "PROMOTION_DETAIL");
            return _dataContext.SaveChanges() > 0 ? true : false;
        }

        public async Task<bool> PromotionContent_Upd(List<PromotionDetail> promotionDetail, string promotionId)
        {
            List<PromotionDetail> allPromotion = await _dataContext.PromotionDetails.Include(x => x.promotion).Where(x => x.promotion.promotion_Id == promotionId).ToListAsync();
            var promotion = await _dataContext.Promotions.Where(x => x.promotion_Id == promotionId).FirstOrDefaultAsync();
            var RemovePromotion = allPromotion.Except(promotionDetail, new PromotionDetailComparer());
            if (RemovePromotion.Count() > 0)
            {
                _dataContext.PromotionDetails.RemoveRange(RemovePromotion);
                await _dataContext.SaveChangesAsync();
            }
            foreach (var detail in promotionDetail)
            {
                if (detail.promotionDetail_Id == "")
                {
                    var getPromotionCount = await _sYS_INDEX.GetIndex_ByName("PROMOTION_DETAIL");
                    detail.promotion = promotion;
                    ++getPromotionCount.currentIndex;
                    string newPromotionId = getPromotionCount.prefix + (getPromotionCount.currentIndex).ToString("00000000000");
                    detail.promotionDetail_Id = newPromotionId;
                    await _dataContext.PromotionDetails.AddAsync(detail);
                    if (!(await _dataContext.SaveChangesAsync() > 0))
                    {
                        return false;
                    }
                }
                else
                {
                    var promotionDetailItem = await _dataContext.PromotionDetails
                    .Where(p => p.promotionDetail_Id == detail.promotionDetail_Id)
                    .FirstOrDefaultAsync();
                    if (promotionDetailItem != null)
                    {
                        promotionDetailItem.content = detail.content;
                        _dataContext.PromotionDetails.Update(promotionDetailItem);
                        if (!(await _dataContext.SaveChangesAsync() > 0))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;

        }

        public async Task<bool> Promotion_AddToBranch(List<string> listBranchId, string promotionId)
        {
            try
            {
                var promotion = await _dataContext.Promotions.Where(x => x.promotion_Id == promotionId).FirstOrDefaultAsync();
                foreach (string branchId in listBranchId)
                {
                    var branch = await _dataContext.Branches.Where(x => x.branch_Id == branchId).FirstOrDefaultAsync();
                    PromotionBranch promotionBranch = new PromotionBranch();
                    promotionBranch.branch = branch;
                    promotionBranch.promotion = promotion;
                    promotionBranch.branch_Id = branch.branch_Id;
                    promotionBranch.promotion_Id = promotion.promotion_Id;
                    promotionBranch.state = true;
                    await _dataContext.PromotionBranchs.AddAsync(promotionBranch);
                    /*if (!(await _dataContext.SaveChangesAsync() > 0))
                    {
                        return false;
                    }*/
                    await _dataContext.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }
        public async Task<bool> CheckFirstRedeem(string promotionId, string userId)
        {
            return await _dataContext.PromotionUsers.AnyAsync(x => x.user_Id == userId && x.promotion_Id == promotionId);
        }
        public async Task<bool> Promotion_Redeem(string promotionId)
        {
            string email = _httpContextAccessor.HttpContext?.User.FindFirst(x => x.Type == ClaimTypes.Email)?.Value;           
            var user = await _userManager.FindByEmailAsync(email);
            if (!(await CheckFirstRedeem(promotionId,user.Id)))
            {
                PromotionUser promotionUser = new PromotionUser();
                promotionUser.promotion_Id = promotionId;
                promotionUser.user_Id = user.Id;
                promotionUser.redeemCount = 1;
                promotionUser.state = true;
                await _dataContext.AddAsync(promotionUser);
            }
            else
            {
                var promotionUser = await _dataContext.PromotionUsers.Where(x => x.user_Id == user.Id && x.promotion_Id == promotionId).FirstOrDefaultAsync();
                promotionUser.redeemCount++;
                _dataContext.Update(promotionUser);
            }
            if (await _dataContext.SaveChangesAsync() > 0)
            {
                var promotion = await _dataContext.Promotions.Where(x => x.promotion_Id == promotionId && x.state).FirstOrDefaultAsync();
                user.rewardPoints -= promotion.discountValue ?? 0;
                var result = await _userManager.UpdateAsync(user);
                return true;
            }
            return false;
        }
        public async Task<bool> CheckUserPoint(string promotionId)
        {
            string email = _httpContextAccessor.HttpContext?.User.FindFirst(x => x.Type == ClaimTypes.Email)?.Value;
            var user = await _userManager.FindByEmailAsync(email);
            var promotionUserCheck = await _dataContext.Promotions.Where(x => x.promotion_Id == promotionId).FirstOrDefaultAsync();
            if (promotionUserCheck != null && user.rewardPoints < promotionUserCheck.discountValue)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> RemovePromotionCategory(Promotion promotion)
        {
            promotion.state = false;
            _dataContext.Update(promotion);
            /*    if (await _dataContext.SaveChangesAsync() > 0)
                {
                    //var promotionDetail = await _dataContext.PromotionDetails.Include(x => x.promotion).Where(x => x.promotion.promotion_Id == promotion.promotion_Id).ToListAsync();
                    var promotionDetail = promotion.promotionDetails.ToList();
                    _dataContext.PromotionDetails.RemoveRange(promotionDetail);
                    return await _dataContext.SaveChangesAsync() > 0 ? true : false;
                }*/
            return await _dataContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> UpdatePromotionCategory(Promotion promotion, List<PromotionDetail> promotionDetails)
        {
            var curPromotion =  await _dataContext.Promotions.Where(x => x.promotion_Id == promotion.promotion_Id).FirstOrDefaultAsync();
            curPromotion.promotionName = promotion.promotionName;
            if (promotion.PromotionImage.Length > 0)
            {
                curPromotion.PromotionImage = promotion.PromotionImage;
            }
            curPromotion.expirationDate = promotion.expirationDate;
            curPromotion.imagePath = promotion.imagePath;
            _dataContext.Update(curPromotion);
            if (await _dataContext.SaveChangesAsync() > 0)
            {
                var promotionDetail = promotionDetails;
                if (await PromotionContent_Upd(promotionDetail, promotion.promotion_Id))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
