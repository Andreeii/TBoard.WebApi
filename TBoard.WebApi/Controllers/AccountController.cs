
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
using System.Linq;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;

namespace TBoard.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AuthOptions authenticationOptions;
        private readonly SignInManager<Player> signInManager;
        private readonly Microsoft.AspNetCore.Identity.UserManager<Player> userManager;

        public AccountController(IOptions<AuthOptions> authenticationOptions,
            SignInManager<Player> signInManager,
            Microsoft.AspNetCore.Identity.UserManager<Player> userManager)
        {
            this.authenticationOptions = authenticationOptions.Value;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [Route("/[action]")]
        public IActionResult Denied()
        {
            return Content("You need to allow this application access in Google order to be able to login");
        }

        [AllowAnonymous]
        [Route("googleLogin")]
        public IActionResult SignInWithGoogle()
        {
            var authenticationProperties = signInManager.ConfigureExternalAuthenticationProperties("Google", Url.Action(nameof(HandleExternalLogin)));
            return Challenge(authenticationProperties, "Google");
        }

        public async Task<IActionResult> HandleExternalLogin()
        {
            var info = await signInManager.GetExternalLoginInfoAsync();
            var result = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);

            if (!result.Succeeded)
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                var newUser = new Player
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };
                var createResult = await userManager.CreateAsync(newUser);
                if (!createResult.Succeeded)
                    throw new Exception(createResult.Errors.Select(e => e.Description).Aggregate((errors, error) => $"{errors}, {error}"));

                await userManager.AddLoginAsync(newUser, info);
                var newUserClaims = info.Principal.Claims.Append(new Claim("userId", newUser.Id.ToString()));
                await userManager.AddClaimsAsync(newUser, newUserClaims);
                await signInManager.SignInAsync(newUser, isPersistent: false);
                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            }

            return Redirect("http://localhost:4200");
        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("http://localhost:4200");
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(PlayerForLoginDto userForLoginDto)
        {
            var user = await userManager.FindByNameAsync(userForLoginDto.UserName);

            var checkingPasswordResult = await signInManager.PasswordSignInAsync(userForLoginDto.UserName, userForLoginDto.Password, false, false);

            if (checkingPasswordResult.Succeeded)
            {
                var encodedToken = CreateJwtSecurityToken(user).Result;
                return Ok(new { AccessToken = encodedToken });
            }
            return Unauthorized();
        }

        private async Task<string> CreateJwtSecurityToken(Player user)
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
            return encodedToken;
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
            var dbPath = "http://localhost:60907/ProfileImage/" + player.ProfileImage;


            var user = new Player
            {
                Name = player.Name,
                Surname = player.Surname,
                UserName = player.UserName,
                Email = player.Email,
                ProfileImage = dbPath
            };

            try
            {
                var result = await userManager.CreateAsync(user, player.Password);
                await userManager.AddToRoleAsync(user, playerRole);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("editPlayer")]
        public async Task<IActionResult> EditPlayer(PlayerForUpdateDto player)
        {
            var userId = User.Identity.GetUserId();
            var user = await userManager.FindByIdAsync(userId);
            var dbPath = "http://localhost:60907/ProfileImage/" + player.ProfileImage;

            user.Name = player.Name;
            user.Surname = player.Surname;
            user.UserName = player.UserName;
            user.Email = player.Email;
            user.ProfileImage = dbPath;

            var result = await userManager.UpdateAsync(user);
            return Ok(result);

        }

        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto passwordDto)
        {
            var userId = User.Identity.GetUserId();
            var user = await userManager.FindByIdAsync(userId);
            var result = await userManager.ChangePasswordAsync(user, passwordDto.CurentPassword, passwordDto.NewPassword);
            return Ok(result);

        }
        [AllowAnonymous]
        [HttpPost("uploadImage"), DisableRequestSizeLimit]
        public IActionResult UploadImage()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "ProfileImage");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

        }
    }

}

