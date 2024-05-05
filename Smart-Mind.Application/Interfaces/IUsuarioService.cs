using Smart_Mind.Application.DTOs.Authentication;
using Smart_Mind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<RegistrationResponse> RegisterAsync(RegisterModel model);

        Task<LoginResponse> LoginAsync(LoginModel model);

        Task<Usuario> GetUserByEmail(string email);

        Task<Usuario> GetUserByLogin(string login);
    }
}
