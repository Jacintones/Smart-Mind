using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Smart_Mind.Application.DTOs.Authentication;
using Smart_Mind.Application.DTOs.Request;
using Smart_Mind.Application.Interfaces;
using Smart_Mind.Domain.Entities;
using Smart_Mind.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Smart_Mind.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _repository;

        private readonly IMapper _mapper;

        private IConfiguration _config;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _config = configuration;
        }

        public async Task<LoginResponse> LoginAsync(LoginModel model)
        {
            //Pega o usuário pelo repositório
            var getUser = await _repository.GetUserByEmail(model.Email!);

            //Compara as senhas do dto com o do repositório
            var check = BCrypt.Net.BCrypt.Verify(model.Senha, getUser.Senha);

            if (check)
            {
                //Se for true, retorna um token de autenticação
                return new LoginResponse(true, "Login feito com sucesso", GenerateJWTToken(getUser));
            }
            else
            {
                //Retorna falso
                return new LoginResponse(false, "Credenciais inválidas");

            }
        }

        private string GenerateJWTToken(Usuario user)
        {
            //Senha do application json
            var senhaSecreta = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecretKey"]!));
            var credenciais = new SigningCredentials(senhaSecreta, SecurityAlgorithms.HmacSha256);

            //Cria as claims
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Nome!),
                new Claim(ClaimTypes.Email, user.Email!)
            };

            //Cria o token
            var token = new JwtSecurityToken(
                issuer: _config.GetSection("JWT").GetValue<string>("ValidIssuer"),
                audience: _config.GetSection("JWT").GetValue<string>("ValidAudience"),
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(_config.GetSection("JWT").GetValue<double>("TokenValidityInMinutes")),
                signingCredentials: credenciais
                );

            //Retorna o token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<RegistrationResponse> RegisterAsync(RegisterModel registerDTO)
        {
            //Converte os dados do dto para uma instância de usuário
            var usuario = _mapper.Map<Usuario>(registerDTO);

            if (await _repository.RegisterAsync(usuario))
            {
                //Retorna a resposta do registro com mensagens positivas
                return new RegistrationResponse(true, "Usuário criado com sucesso");
            }
            else
            {
                //Retorna a resposta do registro com mensagens negativas
                return new RegistrationResponse(false, "Usuário já existe");
            }
        }

        public async Task<Usuario> GetUserByEmail(string email)
        {
            //Pega o usuário pelo repositório
            var usuario = await _repository.GetUserByEmail(email);

            //Retorna o usuário, caso não exista, o repositório lidará com isso
            return usuario;
        }

        public async Task<Usuario> GetUserByLogin(string login)
        {
            //Pega o usuário pelo repositório
            var usuario = await _repository.GetUserByLogin(login);

            //Retorna o usuário, caso não exista, o repositório lidará com isso
            return usuario;
        }

        public async Task<string> UploadImagemAsync(IFormFile imagem, string email)
        {
            var usuario = await _repository.GetUserByEmail(email);

            if (usuario != null)
            {
                if (imagem != null && imagem.Length > 0)
                {
                    var nomeArquivo = Path.GetFileName(imagem.FileName);
                    var caminhoRelativo = Path.Combine("Imagens", nomeArquivo);
                    var caminhoFisico = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", caminhoRelativo);

                    using (var stream = new FileStream(caminhoFisico, FileMode.Create))
                    {
                        await imagem.CopyToAsync(stream);
                    }

                    // Atualizar a propriedade ImagemUrl do usuário
                    usuario.ImagemUrl = nomeArquivo; 

                    // Salvar as alterações no usuário
                    await _repository.Update(usuario);

                    // Retornar o caminho relativo da imagem
                    return usuario.ImagemUrl;
                }
                throw new ArgumentException("Nenhuma imagem selecionada.");
            }

            throw new Exception("Usuário não encontrado.");
        }

        public async Task Update(Usuario usuario)
        {
           await _repository.Update(usuario);
        }
    }
}
