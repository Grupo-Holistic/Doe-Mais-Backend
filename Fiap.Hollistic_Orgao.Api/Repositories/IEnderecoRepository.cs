using Fiap.Hollistic.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Hollistic_Orgao.Web.Repositories
{
    interface IEnderecoRepository
    {
        void Cadastrar(Endereco endereco);
        void Atualizar(Endereco endereco);
        void Remover(int codigo);
        Endereco Pesquisar(int codigo);
        Endereco PesquisarDetalhes(int codigo);
        List<Endereco> Listar();
        List<Endereco> BuscarPor(Expression<Func<Endereco, bool>> filtro);
        void Salvar();
    }
}
