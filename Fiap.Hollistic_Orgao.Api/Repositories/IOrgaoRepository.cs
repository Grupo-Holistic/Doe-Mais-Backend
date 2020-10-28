using Fiap.Hollistic.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Hollistic_Orgao.Web.Repositories
{
    public interface IOrgaoRepository
    {
        void Cadastrar(Orgao orgao);
        void Atualizar(Orgao orgao);
        void Remover(int codigo);
        Orgao Pesquisar(int codigo);
        List<Orgao> Listar();
        List<Orgao> BuscarPor(Expression<Func<Orgao, bool>> filtro);
        void Salvar();
    }
}
