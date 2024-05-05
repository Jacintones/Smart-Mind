using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.Application.DTOs.Authentication
{
    public class TokenModel
    {
        public string? AcessToken { get; set; }

        public string? RefreshToken { get; set; }
    }
}
