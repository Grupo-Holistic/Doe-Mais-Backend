using Fiap.Hollistic.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Hollistic_Orgao.Web.Repositories
{
    public interface IExameRepository
    {
        void Cadastrar(Exame exame);
        void Atualizar(Exame exame);
        void Remover(int codigo);
        Exame Pesquisar(int codigo);
        Exame PesquisarDetalhes(int codigo);
        List<Exame> Listar();
        List<Exame> BuscarPor(Expression<Func<Exame, bool>> filtro);
        void Salvar();
    }
}
