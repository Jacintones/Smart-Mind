using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.Application.DTOs.Response
{
    public class UsuarioViewModel
    {
        public string Nome { get; set; } = null!;

        public int Idade { get; set; }

        public string Email { get; set; } = null!;

        public IFormFile Foto { get; set; } = null!;
    }
}
