using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NativApps.Products.Core.Models;
using NativApps.Products.Core.Services;
using ProductManagementAPI.Common;
using ProductManagementAPI.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductManagementAPI.Controllers;

/// <summary>
/// Controlador para la autenticación de usuarios.
/// </summary>
[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthService _authService;
    private IMapper Mapper { get; }

    /// <summary>
    /// Constructor del controlador AuthController.
    /// </summary>
    /// <param name="config">Instancia de IConfiguration para acceder a la configuración de la aplicación.</param>
    /// <param name="logger">Instancia de ILogger para el registro de eventos.</param>
    /// <param name="authService">Servicio de autenticación de usuarios.</param>
    /// <param name="mapper">Instancia de IMapper para el mapeo de objetos.</param>
    public AuthController(IConfiguration config, ILogger<AuthController> logger, IAuthService authService, IMapper mapper)
    {
        _config = config;
        _logger = logger;
        _authService = authService;
        Mapper = mapper;
    }

    /// <summary>
    /// Método para el inicio de sesión de un usuario.
    /// </summary>
    /// <param name="userLogin">Información de inicio de sesión del usuario.</param>
    /// <returns>Resultado de la autenticación con el token JWT si es exitosa.</returns>
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

    /// <summary>
    /// Método para generar un token JWT.
    /// </summary>
    /// <param name="role">Rol del usuario.</param>
    /// <returns>Token JWT generado.</returns>
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
