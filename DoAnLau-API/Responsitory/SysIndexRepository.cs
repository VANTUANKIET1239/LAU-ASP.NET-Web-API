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

        public async Task<bool> SysIndex_Upd(int currentIndex,string nameIndex)
        {
            var indexObj =  await _dataContext.SYS_INDices.Where(x => x.nameIndex == nameIndex).FirstOrDefaultAsync();
            if (indexObj != null)
            {
                indexObj.currentIndex = currentIndex;
                _dataContext.SYS_INDices.Update(indexObj);
                return _dataContext.SaveChanges() > 0 ? true : false;
            }
            return false;
            
        }
    }
}
