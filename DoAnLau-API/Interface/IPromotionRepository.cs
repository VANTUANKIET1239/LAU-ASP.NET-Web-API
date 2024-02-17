using DoAnLau_API.Data;
using DoAnLau_API.Models;
using Microsoft.AspNetCore.Identity;

namespace DoAnLau_API.Interface
{
    public interface IPromotionRepository
    {
        public Task<ICollection<Promotion>> GetPromotions_ByUserId(string UserId);


        public Task<ICollection<Promotion>> GetPromotions();

        public Task<Promotion> GetPromotion(string promotionId);

        public Task<bool> IsPromotionExists(string promotionId);

        public Task<bool> CreatePromotionCategory(Promotion promotion,List<PromotionDetail> promotionDetails);

        public Task<bool> UpdatePromotionCategory(Promotion promotion, List<PromotionDetail> promotionDetails);

        public Task<bool> RemovePromotionCategory(Promotion promotion);

        public Task<bool> PromotionContent_Add(List<PromotionDetail> promotionDetail,string newPromotionId);

        public Task<bool> PromotionContent_Upd(List<PromotionDetail> promotionDetail,string promotionId);

        public Task<bool> Promotion_AddToBranch(List<string> listBranchId, string promotionId);

        public Task<bool> Promotion_Redeem(string promotionId);

        public  Task<bool> CheckUserPoint(string promotionId);

        // public Task<bool> PromotionContent_Del(List<PromotionDetail> promotionDetail);


    }
}
