using DoAnLau_API.Models;

namespace DoAnLau_API.Interface
{
    public interface IDistrictRepository
    {
        public Task<ICollection<QuanHuyen>> GetDistricts();

        public Task<ICollection<QuanHuyen>> GetDistrict_ByCityId(int CityId);

        public Task<QuanHuyen> GetDistrict_ById(int districtId);
    }
}
