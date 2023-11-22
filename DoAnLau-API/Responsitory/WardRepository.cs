using DoAnLau_API.Data;
using DoAnLau_API.Interface;
using DoAnLau_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnLau_API.Responsitory
{
    public class WardRepository : IWardRepository
    {
        private readonly DataContext _dataContext;

        public WardRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<ICollection<XaPhuong>> GetWards()
        {
           return  await _dataContext.XaPhuong.ToListAsync();
        }

        public async Task<ICollection<XaPhuong>> GetWards_ByDistrictId(int districtId)
        {
            return await _dataContext.XaPhuong.Where(x => x.quanHuyenId == districtId).ToListAsync();
        }

        public async Task<XaPhuong> GetWard_ById(int wardId)
        {
            return await _dataContext.XaPhuong.Where(x => x.ID == wardId).FirstOrDefaultAsync();
        }
    }
}
