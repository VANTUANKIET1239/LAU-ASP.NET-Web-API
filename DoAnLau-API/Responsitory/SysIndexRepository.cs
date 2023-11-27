using DoAnLau_API.Data;
using DoAnLau_API.Interface;
using DoAnLau_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnLau_API.Responsitory
{
    public class SysIndexRepository : ISYS_INDEX
    {
        private readonly DataContext _dataContext;

        public SysIndexRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public async Task<SYS_INDEX> GetIndex_ByName(string name)
        {
            return await _dataContext.SYS_INDices.Where(x => x.nameIndex == name).FirstOrDefaultAsync();
        }
    }
}
