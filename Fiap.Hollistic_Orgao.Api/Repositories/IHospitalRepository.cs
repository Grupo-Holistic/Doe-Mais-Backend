using Fiap.Hollistic.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Hollistic_Orgao.Web.Repositories
{
    public interface IHospitalRepository
    {
        void Cadastrar(Hospital hospital);
        void Atualizar(Hospital hospital);
        void Remover(int codigo);
        Hospital Pesquisar(int codigo);
        List<Hospital> Listar();
        List<Hospital> BuscarPor(Expression<Func<Hospital, bool>> filtro);
        void Salvar();
    }
}
