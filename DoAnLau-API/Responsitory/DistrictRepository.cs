using DoAnLau_API.Data;
using DoAnLau_API.Interface;
using DoAnLau_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnLau_API.Responsitory
{
    public class DistrictRepository : IDistrictRepository
    {
        private readonly DataContext _dataContext;

        public DistrictRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<ICollection<QuanHuyen>> GetDistricts()
        {
            return await _dataContext.QuanHuyen.ToListAsync();
        }

        public async Task<ICollection<QuanHuyen>> GetDistrict_ByCityId(int CityId)
        {
            return await _dataContext.QuanHuyen.Where(x => x.tinhThanhPhoId == CityId).ToListAsync();
        }

        public async Task<QuanHuyen> GetDistrict_ById(int districtId)
        {
            return await _dataContext.QuanHuyen.Where(x => x.ID == districtId).FirstOrDefaultAsync();
        }
    }
}
