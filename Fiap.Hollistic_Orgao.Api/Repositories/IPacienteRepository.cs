using Fiap.Hollistic.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Hollistic_Orgao.Web.Repositories
{
    public interface IPacienteRepository
    {

        void Cadastrar(Paciente paciente);
        void Atualizar(Paciente paciente);
        void Remover(int codigo);
        Paciente Pesquisar(int codigo);
        Paciente PesquisarDetalhes(int codigo);
        List<Paciente> Listar();
        List<Paciente> BuscarPor(Expression<Func<Paciente, bool>> filtro);
        void Salvar();
    }
}
