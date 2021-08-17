using pointsheet_api.Data.Interfaces;
using pointsheet_api.Models;
using pointsheet_api.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pointsheet_api.Data
{
    public class UsuarioData : IUsuarioData
    {
        CargaHorariaContext _context;

        public UsuarioData(CargaHorariaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Usuario>> CadastraUsuario(Usuario usuario)
        {
            try
            {
                var usuarios = _context.Usuario;
                await usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();
                return usuarios.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Usuario>> ObtemUsuarios()
        {
            IEnumerable<Usuario> usuarios = _context.Usuario.OrderBy(x => x.Nome).OrderBy(x => x.Sobrenome).ToList();
            return usuarios;
        }
        public async Task<Usuario> ObtemUsuarioPorId(int idUsuario)
        {
            Usuario usuario = _context.Usuario.FirstOrDefault(x => x.IdUsuario == idUsuario);
            return usuario;
        }

        public async Task<Usuario> ObtemUsuarioPorEmailESenha(string email, string senha)
        {
            Usuario usuario = _context.Usuario.FirstOrDefault(x => x.Email == email && x.Senha == senha);
            return usuario;
        }

        public async Task<Usuario> ObtemUsuarioPorNome(string nome)
        {
            Usuario usuario = _context.Usuario.FirstOrDefault(x => x.Nome == nome);
            return usuario;
        }

    }
}
