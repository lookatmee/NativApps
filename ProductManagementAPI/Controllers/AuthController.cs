using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NativApps.Products.Core.Models;
using NativApps.Products.Core.Services;
using ProductManagementAPI.Common;
using ProductManagementAPI.Dtos;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;
        private IMapper Mapper { get; }

        public AuthController(IConfiguration config, ILogger<AuthController> logger, IAuthService authService, IMapper mapper)
        {
            _config = config;
            _logger = logger;
            _authService = authService;
            Mapper = mapper;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto userLogin)
        {
            if (userLogin is null)
            {
                _logger.LogWarning(Constants.ErrorMessages.UserNull);
                return BadRequest(Constants.ErrorMessages.InvalidClientRequest);
            }

            try
            {
                var response = _authService.ValidateUser(Mapper.Map<User>(userLogin));
                var user = Mapper.Map<UserResponseDto>(response);

                if (user != null)
                {
                    var tokenString = GenerateJWT(user.Role);
                    return Ok(new { token = tokenString });
                }

                _logger.LogWarning("Invalid login attempt for user: {Username}", userLogin.UserName);
                return Unauthorized("Invalid credentials");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the login request for user: {Username}", userLogin.UserName);
                return StatusCode(500, "Internal server error");
            }
        }

        private string GenerateJWT(string role)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, "usuario"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, role) 
        };

                var token = new JwtSecurityToken(
                    issuer: _config["Jwt:Issuer"],
                    audience: _config["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while generating the JWT.");
                throw;
            }
        }

    }
}
