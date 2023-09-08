using LibraryMIS.Web.Models;
using LibraryMIS.Web.Service.IService;
using LibraryMIS.Web.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LibraryMIS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthService _authService;
        private readonly ITokenProvider _tokenProvider;

        public HomeController(ILogger<HomeController> logger, IAuthService authService, ITokenProvider tokenProvider)
        {
            _logger = logger;
            _authService = authService;
            _tokenProvider = tokenProvider;
        }

        [HttpGet]
        public IActionResult Index()
        {
            LoginRequestDto loginRequestDto = new();

            return View(loginRequestDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginRequestDto loginDto)
        {
            ResponseDto responseDto = await _authService.LoginAsync(loginDto);

            if (responseDto != null && responseDto.IsSuccess)
            {
                LoginResponseDto loginResponseDto = 
                    JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result));

                await SignInUser(loginResponseDto);
                _tokenProvider.SetToken(loginResponseDto.Token);
                return RedirectToAction("BookIndex", "Book");
            }
            else
            {
                TempData["error"] = responseDto!.Message;
                return View(loginDto);
            }
        }

        public async Task<IActionResult> UserIndex()
        {
            List<UserDto?> list = new();

            ResponseDto? response = await _authService.GetAllUsersAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<UserDto>>(Convert.ToString(response.Result)!)!;
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>
            {
                new SelectListItem{Text = StaticDetails.RoleManagement, Value=StaticDetails.RoleManagement },
                new SelectListItem{Text = StaticDetails.RoleFrontOffice, Value=StaticDetails.RoleFrontOffice },
                new SelectListItem{Text = StaticDetails.RoleBackOffice, Value=StaticDetails.RoleBackOffice },
            };

            ViewBag.RoleList = roleList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDto registration)
        {
            ResponseDto? result = await _authService.RegisterAsync(registration);
            ResponseDto? assignRole;

            if(result != null && result.IsSuccess)
            {
                if (string.IsNullOrEmpty(registration.Role))
                {
                    registration.Role = StaticDetails.RoleFrontOffice;
                }
                assignRole = await _authService.AssignRoleAsync(registration);
                if(assignRole != null && assignRole.IsSuccess) 
                {
                    TempData["Success"] = "Registration of user is Successful";
                    return RedirectToAction(nameof(Index));
                }

            }
            else
            {
                TempData["error"] = result!.Message;
            }
            var roleList = new List<SelectListItem>
            {
                new SelectListItem{Text = StaticDetails.RoleManagement, Value=StaticDetails.RoleManagement },
                new SelectListItem{Text = StaticDetails.RoleFrontOffice, Value=StaticDetails.RoleFrontOffice },
                new SelectListItem{Text = StaticDetails.RoleBackOffice, Value=StaticDetails.RoleBackOffice },
            };

            ViewBag.RoleList = roleList;

            return View(registration);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _tokenProvider.ClearToken();
            return RedirectToAction("Index","Home");
        }

        private async Task SignInUser(LoginResponseDto loginResponse)
        {
            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(loginResponse.Token);

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
                  jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));

            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
                 jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));

            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
                 jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));

            identity.AddClaim(new Claim(ClaimTypes.Name,
                 jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));

            identity.AddClaim(new Claim(ClaimTypes.Role,
                 jwt.Claims.FirstOrDefault(u => u.Type == "role").Value));



            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}