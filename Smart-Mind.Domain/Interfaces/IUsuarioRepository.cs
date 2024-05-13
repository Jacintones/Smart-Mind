using Smart_Mind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<bool> RegisterAsync(Usuario usuario);   

        Task<Usuario> GetUserByEmail(string email);

        Task<Usuario> GetUserByLogin(string login);

        Task<Usuario> Update(Usuario usuario);

    }
}
