using API.DTOs;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly TokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager, TokenService tokenService)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null) return Unauthorized();
            var result = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (result)
            {
                return CreateObjectDTO(user);
            }
            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            if (await _userManager.Users.AnyAsync(a => a.UserName == registerDTO.UserName))
            {
                ModelState.AddModelError("userName","Username is already taken");
                // return BadRequest(ModelState);
                return ValidationProblem();
            }
            if (await _userManager.Users.AnyAsync(a => a.Email == registerDTO.Email))
            {
                ModelState.AddModelError("userName","Email is already taken");
                return ValidationProblem();
            }
            var user = new AppUser
            {
                DisplayName = registerDTO.DisplayName,
                Email = registerDTO.Email,
                UserName = registerDTO.UserName
            };
            var ret = await _userManager.CreateAsync(user, registerDTO.Password);
            if (ret.Succeeded)
            {
                return CreateObjectDTO(user);
            }
            return BadRequest(ret.Errors);
        }
        // [AllowAnonymous]

        [Authorize]
        // [HttpGet("GetCurrentUser")]
        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var userName = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByNameAsync(userName);
            // var user = await _userManager.FindByEmailAsync(ClaimTypes.Email);
            return CreateObjectDTO(user);
        }

        private UserDTO CreateObjectDTO(AppUser user)
        {
            return new UserDTO
            {
                DisplayName = user.DisplayName,
                Image = null,
                Token = _tokenService.CreateToken(user),
                UserName = user.UserName
            };
        }
    }
}