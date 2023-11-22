using DoAnLau_API.Models;

namespace DoAnLau_API.Interface
{
    public interface IPromotionRepository
    {
        public Task<ICollection<Promotion>> GetPromotions_ByUserId(string UserId);


        public Task<ICollection<Promotion>> GetPromotions();

        public Task<Promotion> GetPromotion(string promotionId);

        public Task<bool> IsPromotionExists(string promotionId);

        public Task<bool> CreatePromotionCategory(Promotion promotion,List<PromotionDetail> promotionDetails);

        public Task<bool> UpdatePromotionCategory(Promotion promotion);

        public Task<bool> RemovePromotionCategory(Promotion promotion);

        public Task<bool> PromotionContent_Add(List<PromotionDetail> promotionDetail,string newPromotionId);

        public Task<bool> PromotionContent_Upd(List<PromotionDetail> promotionDetail);

       // public Task<bool> PromotionContent_Del(List<PromotionDetail> promotionDetail);


    }
}
