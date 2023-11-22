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
using System.Text.RegularExpressions;
using System.Text.Json;

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
        private Dictionary<bool, string> EmptyValueChecking(SignUpModel model)
        {
            if (model.name.Trim() == "" || string.IsNullOrEmpty(model.name))
            {
                return new Dictionary<bool, string> { { true, "Họ tên đang để trống" } };
            }
            else if (model.Phone.Trim() == "" || string.IsNullOrEmpty(model.Phone))
            {
                return new Dictionary<bool, string> { { true, "Số điện thoại đang để trống" } };
            }
            else if (model.email.Trim() == "" || string.IsNullOrEmpty(model.email))
            {
                return new Dictionary<bool, string> { { true, "Email đang để trống" } };
            }
            else if (model.password.Trim() == "" || string.IsNullOrEmpty(model.password))
            {
                return new Dictionary<bool, string> { { true, "Mật khẩu đang để trống" } };
            }
            else if (model.confirmPassword.Trim() == "" || string.IsNullOrEmpty(model.confirmPassword))
            {
                return new Dictionary<bool, string> { { true, "Xác nhận mật khẩu đang để trống" } };
            }
            return new Dictionary<bool, string>
                {
                    { false, "Không lỗi" }
                };
        }
        private Dictionary<bool, string> ValueChecking(SignUpModel model)
        {

            if (EmptyValueChecking(model).ContainsKey(true))
            {
                return EmptyValueChecking(model);
            }


            if (model.confirmPassword != model.confirmPassword)
            {
                var result = new Dictionary<bool, string>
                {
                    { true, "Mật khẩu và xác nhận mật khẩu không khớp" }
                };
                return result;
            }
          
            else if (model.password.Length < 6 || model.confirmPassword.Length < 6)
            {
                var result = new Dictionary<bool, string>
                {
                    { true, "Mật khẩu và xác nhận mật khẩu chưa đủ 6 ký tự" }
                };
                return result;
            }
            else if (ContainsAToZ(model.password))
            {
                var result = new Dictionary<bool, string>
                {
                    { true, "Mật khẩu bao gồm các ký tự từ a đến z" }
                };
                return result;
            }
            else if (CheckForSpecialCharacters(model.password))
            {
                var result = new Dictionary<bool, string>
                {
                    { true, "Mật khẩu bao gồm các ký tự đặc biệt" }
                };
                return result;
            }
            else if (CheckForUppercase(model.password))
            {
                var result = new Dictionary<bool, string>
                {
                    { true, "Mật khẩu bao gồm các ký tự in hoa" }
                };
                return result;
            }


            return new Dictionary<bool, string>
            {
                { false, "Không lỗi" }
            };
        }
        private bool CheckForUppercase(string input)
        {
            // Check for uppercase characters
            foreach (char c in input)
            {
                if (char.IsUpper(c))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool ContainsAToZ(string input)
        {
            foreach (char c in input)
            {
                if (c >= 'a' && c <= 'z')
                {
                    return true;
                }
            }
            return false;
        }
        private bool CheckForSpecialCharacters(string input)
        {
            // Check for special characters using a regular expression
            Regex regex = new Regex(@"[^a-zA-Z0-9\s]");
            return regex.IsMatch(input);
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            var result = await _accountResponsitory.SignIn(model);
            if (string.IsNullOrEmpty(result))
            {
                var error = new { success = false, message = "Tài khoản hoặc mật khẩu không đúng" };
                return Ok(error);
            }
            // var currentUser = await _accountResponsitory.GetUser(httpContextAccessor.HttpContext?.User);
            return Ok(new { success = true , token = result });
        }
      
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
           /* if (!ModelState.IsValid)
            {
                return Ok(new { success = false, message = "Định dạng Email không đúng" });
            }*/
            if (ValueChecking(model).ContainsKey(true))
            {
                return Ok(new { success = false, message = ValueChecking(model)[true]});
            }
            
            var result = await _accountResponsitory.SignUp(model);
            if (result == null)
            {

            }
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
              //  var image = Convert.ToBase64String(user.userImage);
                userView.userImage = user.userImage;
                return Ok(userView);
            }
            return BadRequest();

        }
        [HttpPost("EditUser"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> EditUser([FromForm] string userDto, [FromForm] IFormFile? imageUpload)
        {
            if (userDto == null || userDto.Trim() == "")
            {
                return Ok(new {success = false, message = "Chỉnh sửa thông tin thất bại" });
            }
            var userObject = JsonSerializer.Deserialize<UserDTO>(userDto);
            if (imageUpload != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    imageUpload.CopyTo(memoryStream);
                    userObject.userImage = memoryStream.ToArray();
                }
            }
            if (!await _accountResponsitory.EditUser(userObject))
            {
                return Ok(new { success = false, message = "Chỉnh sửa thông tin thất bại" });
            };
            return Ok(new { success = true, message = "Chỉnh sửa thông tin thành công" });
        }

    }
}
