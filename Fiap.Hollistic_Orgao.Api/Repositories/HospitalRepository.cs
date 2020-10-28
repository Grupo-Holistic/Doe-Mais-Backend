using Fiap.Hollistic.Web.Model;
using Fiap.Hollistic_Orgao.Web.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Hollistic_Orgao.Web.Repositories
{
    public class HospitalRepository : IHospitalRepository
    {
        private DoacaoContext _context;
        public HospitalRepository(DoacaoContext context)
        {
            _context = context;
        }
        public void Atualizar(Hospital hospital)
        {
            _context.Hospitais.Update(hospital);
        }

        public List<Hospital> BuscarPor(Expression<Func<Hospital, bool>> filtro)
        {
            return _context.Hospitais.Where(filtro).ToList();
        }

        public void Cadastrar(Hospital hospital)
        {
            _context.Hospitais.Add(hospital);
        }

        public List<Hospital> Listar()
        {
            return _context.Hospitais.ToList();
        }

        public Hospital Pesquisar(int codigo)
        {
            return _context.Hospitais.Find(codigo);
        }

        public void Remover(int codigo)
        {
            var hospital = _context.Hospitais.Find(codigo);
            _context.Hospitais.Remove(hospital);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
