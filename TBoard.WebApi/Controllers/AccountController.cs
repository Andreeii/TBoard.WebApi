
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using TBoard.Dto;
using TBoard.Entities;
using TBoard.Infrastructure.Configurations;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using AllowAnonymousAttribute = Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute;

namespace TBoard.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AuthOptions authenticationOptions;
        private readonly SignInManager<Player> signInManager;
        private readonly UserManager<Player> userManager;

        public AccountController(IOptions<AuthOptions> authenticationOptions, SignInManager<Player> signInManager,UserManager<Player> userManager)
        {
            this.authenticationOptions = authenticationOptions.Value;
            this.signInManager = signInManager;
            this.userManager = userManager;

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(PlayerForLoginDto userForLoginDto)
        {
            try
            {
                var checkingPasswordResult = await signInManager.PasswordSignInAsync(userForLoginDto.UserName, userForLoginDto.Password, false, false);

                if (checkingPasswordResult.Succeeded)
                {
                    var signinCredentials = new SigningCredentials(authenticationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
                    var jwtSecurityToken = new JwtSecurityToken(
                         issuer: authenticationOptions.Issuer,
                         audience: authenticationOptions.Audience,
                         claims: new List<Claim>(),
                         expires: DateTime.Now.AddDays(30),
                         signingCredentials: signinCredentials
                    );

                    var tokenHandler = new JwtSecurityTokenHandler();

                    var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);

                    return Ok(new { AccessToken = encodedToken });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> CreatePlayer(PlayerForCreationDto player)
        {
            var user = new Player
            {
                Name = player.Name,
                Surname = player.Surname,
                UserName = player.UserName,
                Email = player.Email
            };
            var result = await userManager.CreateAsync(user, player.Password);
            return Ok(result);
        }

    }
}
