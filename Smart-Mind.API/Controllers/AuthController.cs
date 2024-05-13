using Microsoft.AspNetCore.Mvc;
using Smart_Mind.Application.DTOs.Authentication;
using Smart_Mind.Application.Interfaces;


namespace Smart_Mind.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        private readonly string _imagensPath;

        public AuthController(IUsuarioService usuarioService, IConfiguration configuration)
        {
            _usuarioService = usuarioService;
            _imagensPath = configuration.GetValue<string>("Imagens");

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

        [HttpPut]
        [Route("upload/{email}")]
        public async Task<IActionResult> UploadImagem(IFormFile imagem, string email)
        {
            try
            {
                var caminho = await _usuarioService.UploadImagemAsync(imagem, email);
                return Ok($"Imagem enviada com sucesso! Caminho: {caminho}");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao processar a imagem: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("ObterImagem/{nome}")]
        public IActionResult GetImagem(string nome)
        {
            var imagePath = Path.Combine(_imagensPath, nome);
            if (System.IO.File.Exists(imagePath))
            {
                var image = System.IO.File.OpenRead(imagePath);
                return File(image, "image/jpeg"); 
            }
            else
            {
                return NotFound();
            }
        }
    }
}
