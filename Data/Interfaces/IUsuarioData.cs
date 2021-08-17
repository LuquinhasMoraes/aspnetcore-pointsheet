using pointsheet_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pointsheet_api.Data.Interfaces
{
    public interface IUsuarioData
    {
        Task<IEnumerable<Usuario>> CadastraUsuario(Usuario usuario);
        Task<IEnumerable<Usuario>> ObtemUsuarios();
        Task<Usuario> ObtemUsuarioPorId(int idUsuario);
        Task<Usuario> ObtemUsuarioPorEmailESenha(string email, string senha);
        Task<Usuario> ObtemUsuarioPorNome(string nome);
    }
}
