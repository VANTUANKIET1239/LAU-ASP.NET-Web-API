using DoAnLau_API.Data;
using DoAnLau_API.Interface;
using DoAnLau_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnLau_API.Responsitory
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext _dataContext;

        public CityRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public async Task<ICollection<TinhThanhPho>> GetCities()
        {
            return await _dataContext.TinhThanhPho.ToListAsync();
        }

        public async Task<TinhThanhPho> GetCity_ById(int cityId)
        {
            return await _dataContext.TinhThanhPho.Where(x => x.ID == cityId).FirstOrDefaultAsync();
        }
    }
}
