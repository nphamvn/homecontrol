using System.Threading.Tasks;
using HomeControl.Api.Models;
using HomeControl.Api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HomeControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<FamilyMember> _userManager;
        private readonly TokenService _tokenService;

        public UsersController(UserManager<FamilyMember> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest register)
        {
            if (ModelState.IsValid)
            {
                var userExist = await _userManager.FindByEmailAsync(register.Email);

                if (userExist != null)
                {
                    return BadRequest(new RequestResponse<object>
                    {
                        Success = false,
                        ErrorMessage = "Email existing",
                        Data = register
                    });
                }

                FamilyMember member = new FamilyMember
                {
                    Email = register.Email,
                    UserName = register.UserName,
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    Nickname = register.Nickname
                };

                var result = await _userManager.CreateAsync(member);
                if (result.Succeeded)
                {
                    return Ok(new RequestResponse<object>
                    {
                        Success = true,
                        ErrorMessage = "Family member registed successful",
                        Data = register
                    });
                }
                else
                {
                    return Ok(new RequestResponse<object>
                    {
                        Success = false,
                        ErrorMessage = "Family member registed error",
                        Data = register
                    });
                }
            }
            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            if (login.Email == "nam@homecontrol.io")
            {
                var token = await _tokenService.GenerateToken(new FamilyMember());
                return Ok(new RequestResponse<LoginResponse>
                {
                    Success = true,
                    ErrorMessage = "",
                    Data = new LoginResponse { Token = token.Token }
                });
            }
            else
            {
                return Unauthorized(new RequestResponse<LoginResponse>
                {
                    Success = false,
                    ErrorMessage = "Email or password is not match",
                    //Data = new LoginResponse { Token = "ABC123" }
                });
            }
        }
    }
}