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
    public class EnderecoRepository : IEnderecoRepository
    {

        private DoacaoContext _context;

        public EnderecoRepository(DoacaoContext context)
        {
            _context = context;
        }
        public void Atualizar(Endereco endereco)
        {
            _context.Enderecos.Update(endereco);
        }

        public List<Endereco> BuscarPor(Expression<Func<Endereco, bool>> filtro)
        {
            return _context.Enderecos.Where(filtro).ToList();
        }

        public void Cadastrar(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
        }

        public List<Endereco> Listar()
        {
            return _context.Enderecos.ToList();
        }

        public Endereco Pesquisar(int codigo)
        {
            return _context.Enderecos.Find(codigo);
        }

        public Endereco PesquisarDetalhes(int codigo)
        {
            throw new NotImplementedException();
        }

        public void Remover(int codigo)
        {
            var endereco = _context.Enderecos.Find(codigo);
            _context.Enderecos.Remove(endereco);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
