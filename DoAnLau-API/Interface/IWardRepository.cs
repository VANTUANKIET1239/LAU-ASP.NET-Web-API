using DoAnLau_API.Data;
using DoAnLau_API.Models;

namespace DoAnLau_API.Interface
{
    public interface IWardRepository
    {
        public Task<ICollection<XaPhuong>> GetWards();

        public Task<ICollection<XaPhuong>> GetWards_ByDistrictId(int districtId);

        public Task<XaPhuong> GetWard_ById(int wardId);
        
    }
}
