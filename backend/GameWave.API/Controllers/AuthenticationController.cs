using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

using GameWave.API.DTO;
using GameWave.ObjectModel;

namespace GameWave.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticationController(
            IConfiguration configuration,
            ILogger<AuthenticationController> logger,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _configuration = configuration;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Login(LoginAttemptDTO dto)
        {
            try
            {
                ApplicationUser user = await _userManager.FindByNameAsync(dto.UserName);

                if (user == null)
                {
                    return Unauthorized();
                }

                var passwordHasher = new PasswordHasher<ApplicationUser>();
                var verificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

                if (verificationResult == PasswordVerificationResult.Failed)
                {
                    return Unauthorized();
                }

                var token = GenerateJwtToken(user);

                return Ok(token);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var token = new JwtSecurityToken(
                _configuration["TokenIssuer"],
                _configuration["TokenAudience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            return tokenHandler.WriteToken(token);
        }
    }
}