using DoAnLau_API.Data;
using DoAnLau_API.Interface;
using DoAnLau_API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AutoMapper;

namespace DoAnLau_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountResponsitory _accountResponsitory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AccountController(IAccountResponsitory accountResponsitory,
                                    IHttpContextAccessor httpContextAccessor,
                                    UserManager<ApplicationUser> userManager,
                                    IMapper mapper
                )
        {
            this._accountResponsitory = accountResponsitory;
            this._httpContextAccessor = httpContextAccessor;
            this._userManager = userManager;
            this._mapper = mapper;
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            var result = await _accountResponsitory.SignIn(model);
            if (string.IsNullOrEmpty(result))
            {
                return BadRequest(result);
            }
            // var currentUser = await _accountResponsitory.GetUser(httpContextAccessor.HttpContext?.User);
            var kiet = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var kiet2 = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);

            return Ok(new { success = true , token = result });
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            var result = await _accountResponsitory.SignUp(model);
            if(result.Succeeded)
            {
                return Ok(new { success = result.Succeeded });
            }
            return BadRequest();

        }
        [HttpGet("CurrentUser"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetUserInfo()
        {
            var identity = HttpContext.User.Identity; 
            if (identity != null)
            {
                //var userclaims = identity.Claims;
                var user = await _accountResponsitory.GetCurrentUser();
                var userView = _mapper.Map<UserDTO>(user);
                var image = Convert.ToBase64String(user.userImage);
                userView.userImage = Convert.ToBase64String(user.userImage);
                return Ok(userView);
            }
            return BadRequest();

        }

    }
}
