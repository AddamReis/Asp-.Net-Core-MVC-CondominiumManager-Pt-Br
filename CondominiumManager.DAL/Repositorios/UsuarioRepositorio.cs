using CondominiumManager.BLL.Models;
using CondominiumManager.DAL.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumManager.DAL.Repositorio
{
    public class UsuarioRepositorio : RepositorioGenerico<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(Contexto contexto) : base(contexto)
        {
        }

        public Task AtualizarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public string CodificarSenha(Usuario usuario, string senha)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CriarUsuario(Usuario usuario, string senha)
        {
            throw new NotImplementedException();
        }

        public Task DeslogarUsuario()
        {
            throw new NotImplementedException();
        }

        public Task IncluirUsuarioEmFuncao(Usuario usuario, string funcao)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> IncluirUsuarioEmFuncoes(Usuario usuario, IEnumerable<string> funcoes)
        {
            throw new NotImplementedException();
        }

        public Task LogarUsuario(Usuario usuario, bool lembrar)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> PegarFuncoesUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> PegarUsuarioPeloEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> PegarUsuarioPeloId(string usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> PegarUsuarioPeloNome(ClaimsPrincipal usuario)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> RemoverFuncoesUsuario(Usuario usuario, IEnumerable<string> funcoes)
        {
            throw new NotImplementedException();
        }

        public int VerificarSeExisteRegistro()
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerificarSeUsuarioEstaEmFuncao(Usuario usuario, string funcao)
        {
            throw new NotImplementedException();
        }
    }
}
