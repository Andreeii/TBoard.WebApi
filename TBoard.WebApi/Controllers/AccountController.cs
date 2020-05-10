
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
using AutoMapper;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace TBoard.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AuthOptions authenticationOptions;
        private readonly SignInManager<Player> signInManager;
        private readonly Microsoft.AspNetCore.Identity.UserManager<Player> userManager;
        private readonly IMapper mapper;


        public AccountController(IOptions<AuthOptions> authenticationOptions, SignInManager<Player> signInManager, Microsoft.AspNetCore.Identity.UserManager<Player> userManager, IMapper mapper)
        {
            this.authenticationOptions = authenticationOptions.Value;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.mapper = mapper;

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(PlayerForLoginDto userForLoginDto)
        {
            var user = await userManager.FindByNameAsync(userForLoginDto.UserName);
            try
            {
                var checkingPasswordResult = await signInManager.PasswordSignInAsync(userForLoginDto.UserName, userForLoginDto.Password, false, false);

                if (checkingPasswordResult.Succeeded)
                {
                    var role = await userManager.GetRolesAsync(user);
                    IdentityOptions options = new IdentityOptions();

                    var signinCredentials = new SigningCredentials(authenticationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
                    var jwtSecurityToken = new JwtSecurityToken(
                         issuer: authenticationOptions.Issuer,
                         audience: authenticationOptions.Audience,
                         claims: new List<Claim>()
                         {
                             new Claim(options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault()),
                             new Claim(options.ClaimsIdentity.UserIdClaimType,user.Id.ToString())
                         },
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
            string playerRole;
            if (player.Role != null)
            {
                playerRole = player.Role;
            }
            else
            {
                playerRole = "user";
            }
            var user = new Player
            {
                Name = player.Name,
                Surname = player.Surname,
                UserName = player.UserName,
                Email = player.Email
            };
            try
            {
                var result = await userManager.CreateAsync(user, player.Password);
                await userManager.AddToRoleAsync(user,playerRole);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("edit")]
        public async Task<IActionResult> EditPlayer(PlayerForCreationDto player)
        {
            var userId = User.Identity.GetUserId();
            var user = await userManager.FindByIdAsync(userId);

            user.Name = player.Name;
            user.Surname = player.Surname;
            user.UserName = player.UserName;
            user.Email = player.Email;

            var result = await userManager.UpdateAsync(user);

            return Ok(result);
           
        }



    }
}
