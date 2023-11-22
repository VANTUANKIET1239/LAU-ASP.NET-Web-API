using DoAnLau_API.Models;

namespace DoAnLau_API.Interface
{
    public interface ICityRepository
    {
        public Task<ICollection<TinhThanhPho>> GetCities();

        public Task<TinhThanhPho> GetCity_ById(int cityId);
    }
}
