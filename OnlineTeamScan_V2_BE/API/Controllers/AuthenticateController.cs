using API.Validators.UserValidators;
using BL.Services.UserServices;
using Common.DTOs.Authentication;
using Common.DTOs.UserDTO;
using DAL.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        public IConfiguration _configuration;
        private readonly IUserService _service;

        public AuthenticateController(IUserService service, UserManager<User> userManager,
            RoleManager<IdentityRole<int>> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(24),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    id = user.Id,
                    langId = user.PreferredLanguageId
                });
            }
            return StatusCode(StatusCodes.Status401Unauthorized,
                    new Response
                    { Status = "Error", Message = "De e-mail en het wachtwoord komen niet overeen."});
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userName = $"{model.FirstName} {model.LastName}";
                
            var userExists = await _userManager.FindByEmailAsync(model.Email);

            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response
                    { Status = "Error", Message = "Er bestaat al een gebruiker met dezelfde e-mail." });
            }

            var user = new User()
            {
                UserName = userName,
                Email = model.Email,
                Firstname = model.FirstName,
                Lastname = model.LastName,
                PreferredLanguageId = 1
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response
                    {
                        Status = "Error",
                        Message = "Er is iets fout gegaan. Kijk de gegevens na en probeer opnieuw."
                    });
            }

            return Ok(new Response
            { Status = "Success", Message = $"Gebruiker succesvol aangemaakt. E-mail: {user.Email}" });

        }
    }
}
