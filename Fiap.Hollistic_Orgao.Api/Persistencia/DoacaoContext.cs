using Fiap.Hollistic.Web.Model;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Hollistic_Orgao.Web.Persistencia
{
    public class DoacaoContext : DbContext
    {
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<Hospital> Hospitais { get; set; }
        public DbSet<Orgao> Orgaos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            base.OnModelCreating(modelBuilder);
        }
        public DoacaoContext(DbContextOptions options) : base(options)
        {

        }
    }
}
