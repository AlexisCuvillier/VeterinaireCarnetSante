using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenService tokenService)
        {
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("login")]


        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {

            /* Checking if the user exists in the database. */
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            /* Checking if the user is null. If it is null, it returns an unauthorized response. */

            if (user == null) return Unauthorized();


            /* Checking if the password is correct. */
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            /* This is returning a UserDto object if the result is successful. */
            if (result.Succeeded)
            {
                return new UserDto
                {
                    DisplayName = user.DisplayName,
                    Image = null,
                    Token = _tokenService.CreateToken(user),
                    Username = user.UserName

                };
            }
            return Unauthorized();
        }
    }
}