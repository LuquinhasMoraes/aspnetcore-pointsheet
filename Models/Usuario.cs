using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pointsheet_api.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Senha { get; set; }
    }
}
