using Fiap.Hollistic.Web.Model;
using Fiap.Hollistic_Orgao.Web.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Hollistic_Orgao.Web.Repositories
{
    public class ExameRepository : IExameRepository
    {
        private DoacaoContext _context;
        public ExameRepository(DoacaoContext context)
        {
            _context = context;
        }

        public void Atualizar(Exame exame)
        {
            _context.Exames.Update(exame);
        }

        public List<Exame> BuscarPor(Expression<Func<Exame, bool>> filtro)
        {
            return _context.Exames.Where(filtro).ToList();
        }

        public void Cadastrar(Exame exame)
        {
            _context.Exames.Add(exame);
        }

        public List<Exame> Listar()
        {
            return _context.Exames.ToList();
        }

        public Exame Pesquisar(int codigo)
        {
            return _context.Exames.Find(codigo);
        }

        public Exame PesquisarDetalhes(int codigo)
        {
            throw new NotImplementedException();
        }

        public void Remover(int codigo)
        {
            var exame = _context.Exames.Find(codigo);
            _context.Exames.Remove(exame);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
