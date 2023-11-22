using DoAnLau_API.Data;
using DoAnLau_API.Interface;
using DoAnLau_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DoAnLau_API.Responsitory
{
    public class AddressRepository : IAddresssRepository
    {
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public AddressRepository(DataContext dataContext
                                ,IHttpContextAccessor httpContextAccessor
                                , UserManager<ApplicationUser> userManager
            ) 
        {
            this._dataContext = dataContext;
            this._httpContextAccessor = httpContextAccessor;
            this._userManager = userManager;
        }

        public async Task<bool> Address_Del(Address address)
        {
            address.state = false;
            _dataContext.Update(address);
            return await _dataContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> Address_Ins(Address address)
        {
            var getMenuCategoriesCount = _dataContext.Addresses.Count();
            string email = _httpContextAccessor.HttpContext?.User.FindFirst(x => x.Type == ClaimTypes.Email)?.Value;
            var user = await _userManager.FindByEmailAsync(email);
            address.user = user;
            if (address.isDefault)
            {
                var getAddDefault = await _dataContext.Addresses.Where(x => x.user.Id == user.Id && x.isDefault && x.state).FirstOrDefaultAsync();
                if (getAddDefault != null)
                {
                    getAddDefault.isDefault = false;
                    _dataContext.Update(getAddDefault);
                    _dataContext.SaveChanges();
                }
            }
            string newAddressId = "ADDR" + (getMenuCategoriesCount + 1).ToString("00000000000");
            address.address_Id = newAddressId;
            _dataContext.Addresses.Add(address);
            return await _dataContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> Address_Upd(Address address)
        {
            string email = _httpContextAccessor.HttpContext?.User.FindFirst(x => x.Type == ClaimTypes.Email)?.Value;
            var user = await _userManager.FindByEmailAsync(email);
            if (address.isDefault)
            {
                var getAddDefault = await _dataContext.Addresses.Where(x => x.user.Id == user.Id && x.isDefault && x.state).FirstOrDefaultAsync();
                if (getAddDefault != null)
                {
                    getAddDefault.isDefault = false;
                    _dataContext.Update(getAddDefault);
                    _dataContext.SaveChanges();
                }
            }
            var editAddress = _dataContext.Addresses.Where(x => x.address_Id == address.address_Id).FirstOrDefault();
            editAddress.phone = address.phone;
            editAddress.email = address.email;
            editAddress.name = address.name;
            editAddress.addressDetail = address.addressDetail;
            editAddress.city = address.city;
            editAddress.ward = address.ward;
            editAddress.district = address.district;
            editAddress.isDefault = address.isDefault;
            _dataContext.Update(editAddress);
            return await _dataContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<Address> GetAddress_ById(string addressId)
        {
            return await _dataContext.Addresses.Where(x => x.address_Id == addressId && x.state).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Address>> GetAddress_ByUserId(string UserId)
        {
            return await _dataContext.Addresses.Where(x => x.user.Id == UserId && x.state).OrderByDescending(x => x.isDefault).ToListAsync();
        }

        public async Task<Address> GetAddress_Default(string UserId)
        {
            return await _dataContext.Addresses.Where(x => x.user.Id == UserId && x.isDefault && x.state).FirstOrDefaultAsync();
        }

        public async Task<bool> IsAddressExists(string addressId)
        {
            return await _dataContext.Addresses.AnyAsync(x => x.address_Id == addressId && x.state);
        }
    }
}
