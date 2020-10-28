using Fiap.Hollistic.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Hollistic_Orgao.Web.Repositories
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Remover(int codigo);
        Usuario Pesquisar(int codigo);
        Usuario PesquisarDetalhes(int codigo);
    
        List<Usuario> Listar();

        Usuario PesquisarLogin(string email, string senha);
        void Salvar();
    }
}
