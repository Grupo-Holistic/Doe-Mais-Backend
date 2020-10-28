using Fiap.Hollistic.Web.Model;
using Fiap.Hollistic_Orgao.Web.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Hollistic_Orgao.Web.Repositories
{
    public class OrgaoRepository : IOrgaoRepository
    {
        private DoacaoContext _context;
        public OrgaoRepository(DoacaoContext context)
        {
            _context = context;
        }
        public void Atualizar(Orgao orgao)
        {
            _context.Orgaos.Update(orgao);

        }

        public List<Orgao> BuscarPor(Expression<Func<Orgao, bool>> filtro)
        {
            return _context.Orgaos.Where(filtro).ToList();
        }

        public void Cadastrar(Orgao orgao)
        {
            _context.Orgaos.Add(orgao);
        }

        public List<Orgao> Listar()
        {
            return _context.Orgaos.ToList();
        }

        public Orgao Pesquisar(int codigo)
        {
            return _context.Orgaos.Find(codigo);
        }

        public void Remover(int codigo)
        {
            var orgao = _context.Orgaos.Find(codigo);
            _context.Orgaos.Remove(orgao);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
