using Fiap.Hollistic.Web.Model;
using Fiap.Hollistic_Orgao.Web.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Hollistic_Orgao.Web.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private DoacaoContext _context;
        public PacienteRepository(DoacaoContext context)
        {
            _context = context;
        }

        public void Atualizar(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
        }

        public List<Paciente> BuscarPor(Expression<Func<Paciente, bool>> filtro)
        {
            return _context.Pacientes.Where(filtro).ToList();
        }

        public void Cadastrar(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
        }

        public List<Paciente> Listar()
        {
            return _context.Pacientes.ToList();
        }

        public Paciente Pesquisar(int codigo)
        {
            return _context.Pacientes.Find(codigo);
        }

        public Paciente PesquisarDetalhes(int codigo)
        {
            return _context.Pacientes
                .Include(e => e.Endereco)
                .Include(e => e.Hospital)
                .Where(e => e.PacienteId == codigo)
                .FirstOrDefault();
        }

        public void Remover(int codigo)
        {
            var paciente = _context.Pacientes.Find(codigo);
            _context.Pacientes.Remove(paciente);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
