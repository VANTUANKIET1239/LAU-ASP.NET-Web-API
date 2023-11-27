using DoAnLau_API.Models;

namespace DoAnLau_API.Interface
{
    public interface ISYS_INDEX
    {
        public Task<SYS_INDEX> GetIndex_ByName(string name);
    }
}
