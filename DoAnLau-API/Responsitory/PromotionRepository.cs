using DoAnLau_API.Data;
using DoAnLau_API.FF;
using DoAnLau_API.Interface;
using DoAnLau_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DoAnLau_API.Responsitory
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly DataContext _dataContext;
        private readonly ISYS_INDEX _sYS_INDEX;

        public PromotionRepository(DataContext dataContext, ISYS_INDEX sYS_INDEX)
        {
            this._dataContext = dataContext;
            this._sYS_INDEX = sYS_INDEX;
        }
        public async Task<bool> CreatePromotionCategory(Promotion promotion, List<PromotionDetail> promotionDetails)
        {
            var getPromotionCount = _dataContext.Promotions.Count();
            string newPromotionId = "PROM" + (getPromotionCount + 1).ToString("00000000000");
            promotion.promotion_Id = newPromotionId;
            await _dataContext.Promotions.AddAsync(promotion);
            if( await _dataContext.SaveChangesAsync() > 0)
            {
                if (await PromotionContent_Add(promotionDetails, newPromotionId))
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<Promotion> GetPromotion(string promotionId)
        {
            return await _dataContext.Promotions.Where(x => x.promotion_Id == promotionId && x.state).Include(x => x.promotionDetails).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Promotion>> GetPromotions()
        {
            return await _dataContext.Promotions.Include(x => x.promotionDetails).ToListAsync();
        }

        public async Task<ICollection<Promotion>> GetPromotions_ByUserId(string UserId)
        {
           var result = await _dataContext.PromotionUsers.Where(x => x.user_Id == UserId)
                .Include(x => x.promotion)
                .Select(x => x.promotion).ToListAsync();
            return result;
        }

        public async Task<bool> IsPromotionExists(string promotionId)
        {
            return await _dataContext.Promotions.AnyAsync(x => x.promotion_Id == promotionId && x.state);
        }

        public async Task<bool> PromotionContent_Add(List<PromotionDetail> promotionDetail,string newPromotionId)
        {
            var getPromotionCount = await _sYS_INDEX.GetIndex_ByName("PROMOTION_DETAIL");
            var promotion = await _dataContext.Promotions.Where(x => x.promotion_Id == newPromotionId).FirstOrDefaultAsync();
            int i = 1;
            promotionDetail.ForEach(async x =>
            {
                x.promotion = promotion;
                string newPromotionId = getPromotionCount.prefix + (getPromotionCount.currentIndex + i).ToString("00000000000");
                x.promotionDetail_Id = newPromotionId;
                ++i;
                await _dataContext.PromotionDetails.AddAsync(x);
                _dataContext.SaveChanges();
                
            });
                
            return true;
        }

        public async Task<bool> PromotionContent_Upd(List<PromotionDetail> promotionDetail, string promotionId)
        {
            List<PromotionDetail> allPromotion = await _dataContext.PromotionDetails.Include(x => x.promotion).Where(x => x.promotion.promotion_Id == promotionId).ToListAsync();
            var RemovePromotion = allPromotion.Except(promotionDetail, new PromotionDetailComparer());
            if (RemovePromotion.Count() > 0)
            {
                _dataContext.PromotionDetails.RemoveRange(RemovePromotion);
                await _dataContext.SaveChangesAsync();
            }
            foreach (var detail in promotionDetail)
            {
                var promotionDetailItem = await _dataContext.PromotionDetails
                    .Where(p => p.promotionDetail_Id == detail.promotionDetail_Id)
                    .FirstOrDefaultAsync();

                if (promotionDetailItem != null)
                {
                    promotionDetailItem.content = detail.content;
                    _dataContext.PromotionDetails.Update(promotionDetailItem);
                    await _dataContext.SaveChangesAsync();
                }
            }

            return true;
        }

        public async Task<bool> RemovePromotionCategory(Promotion promotion)
        {
            promotion.state = false;
            _dataContext.Update(promotion);
            if (await _dataContext.SaveChangesAsync() > 0)
            {
                //var promotionDetail = await _dataContext.PromotionDetails.Include(x => x.promotion).Where(x => x.promotion.promotion_Id == promotion.promotion_Id).ToListAsync();
                var promotionDetail = promotion.promotionDetails.ToList();
                _dataContext.PromotionDetails.RemoveRange(promotionDetail);
                return await _dataContext.SaveChangesAsync() > 0 ? true : false;
            }
            return false;
        }

        public async Task<bool> UpdatePromotionCategory(Promotion promotion, List<PromotionDetail> promotionDetails)
        {
            _dataContext.Update(promotion);
            if (await _dataContext.SaveChangesAsync() > 0)
            {
                var promotionDetail = promotionDetails;
                if (await PromotionContent_Upd(promotionDetail,promotion.promotion_Id))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
