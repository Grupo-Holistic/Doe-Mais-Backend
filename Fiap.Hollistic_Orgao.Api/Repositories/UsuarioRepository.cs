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
    public class UsuarioRepository : IUsuarioRepository
    {
        private DoacaoContext _context;
        public UsuarioRepository(DoacaoContext context)
        {
            _context = context;
        }
        public void Atualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }

        

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario Pesquisar(int codigo)
        {
            return _context.Usuarios.Find(codigo);
        }

        public Usuario PesquisarDetalhes(int codigo)
        {
            return _context.Usuarios
                .Include(e => e.Hospital)
                .Where(e => e.UsuarioId == codigo)
                .FirstOrDefault();
        }

        public Usuario PesquisarLogin(string email, string senha)
        {
            return _context.Usuarios.Where(u => (u.Email == email) && (u.Senha == senha)).FirstOrDefault();
        }

        public void Remover(int codigo)
        {
            var usuario = _context.Usuarios.Find(codigo);
            _context.Usuarios.Remove(usuario);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
