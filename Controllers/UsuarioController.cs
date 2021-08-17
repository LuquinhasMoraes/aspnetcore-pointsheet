using Microsoft.AspNetCore.Mvc;
using pointsheet_api.Data.Interfaces;
using pointsheet_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pointsheet_api.Controllers
{
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        IUsuarioData _usuarioData;
        public UsuarioController(IUsuarioData usuarioData)
        {
            _usuarioData = usuarioData;
        }
        [HttpPost]
        public IActionResult CadastraUsuario([FromBody] Usuario usuario)
        {
            return null;
        }
    }
}
