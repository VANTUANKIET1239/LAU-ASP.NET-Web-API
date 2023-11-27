using DoAnLau_API.Models;
using System;
using System.Diagnostics.CodeAnalysis;

namespace DoAnLau_API.FF
{
    class PromotionDetailComparer : IEqualityComparer<PromotionDetail>
    {


        public bool Equals(PromotionDetail? x, PromotionDetail? y)
        {
            return x.promotionDetail_Id == y.promotionDetail_Id;
        }

   
        public int GetHashCode([DisallowNull] PromotionDetail obj)
        {
            return obj.promotionDetail_Id.GetHashCode();
        }
    }
}
