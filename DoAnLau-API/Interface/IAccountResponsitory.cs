using DoAnLau_API.Data;
using DoAnLau_API.Models;
using DoAnLau_API.Responsitory;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DoAnLau_API.Interface
{
    public interface IAccountResponsitory
    {
        public Task<IdentityResult> SignUp(SignUpModel model);
        
        public Task<string> SignIn(SignInModel model);

        public  Task<ApplicationUser> GetCurrentUser();

        public Task<bool> EditUser(UserDTO user);

    }
}
