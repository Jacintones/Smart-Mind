using Microsoft.EntityFrameworkCore;
using Smart_Mind.Domain.Entities;
using Smart_Mind.Domain.Interfaces;
using Smart_Mind.infrastructure.Context;
using Smart_Mind.infrastructure.Migrations;

namespace Smart_Mind.infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUserByEmail(string email)
        {
            //Procura o usuário pelo e-mail incluind os testes
            var usuario =  await _context.Usuarios.Include(u => u.Testes).FirstOrDefaultAsync(u => u.Email == email);

            //Retorna uma exceção caso não ache
            return usuario;
        }

        public async Task<Usuario> GetUserByLogin(string login)
        {
            //Procura o usuario pelo login
             var usuario =  await _context.Usuarios.FirstOrDefaultAsync(u => u.Login == login);

            //Retorna uma exceção caso não ache
            return usuario ?? throw new ArgumentNullException($"Usuário com login : {login} não existe");
        }

        public async Task<bool> RegisterAsync(Usuario usuario)
        {
            //Busca o usuário pelo e-mail
            var getUser = await GetUserByEmail(usuario.Email!);

            //Se for diferente de null é porque ja existe usuário com esse e-mail
            if (getUser != null) return false;

            //Crio uma instância de usuário passando os atributos
            _context.Usuarios.Add(new Usuario
            {
                Login = usuario.Login,
                Nome = usuario.Nome,
                Sobrenome = usuario.Sobrenome,
                NomeCompleto = $"{usuario.Nome} {usuario.Sobrenome}",
                Email = usuario.Email,
                Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha),
                Idade = usuario.Idade
            });

            //Salvo no banco
            await _context.SaveChangesAsync();

            //Retorna true
            return true;
        }

        public async Task<Usuario> Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);

            await _context.SaveChangesAsync();

            return usuario;
        }
    }
}
