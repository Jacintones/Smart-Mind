using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Mind.Application.DTOs.Request
{
    public class AlternativaDTO
    {
        public int Id { get; set; }

        public string Texto { get; set; } = null!;

        public bool Correta { get; set; }
    }
}
