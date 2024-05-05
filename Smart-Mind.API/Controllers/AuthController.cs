using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Smart_Mind.Application.DTOs.Authentication;
using Smart_Mind.Application.Interfaces;
using Smart_Mind.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Smart_Mind.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public AuthController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginModel loginModel)
        {
            var result = await _usuarioService.LoginAsync(loginModel);

            return Ok(result);
        }

        [HttpPost]
        [Route("cadastro")]
        public async Task<ActionResult<LoginResponse>> Register([FromBody] RegisterModel registerModel)
        {
            var result = await _usuarioService.RegisterAsync(registerModel);

            return Ok(result);
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<UsuarioResponse>> GetByEmail(string email)
        {
            var user = await _usuarioService.GetUserByEmail(email);

            return Ok(user);
        }
    }
}
