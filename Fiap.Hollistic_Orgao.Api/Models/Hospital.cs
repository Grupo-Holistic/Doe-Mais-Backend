using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Hollistic.Web.Model
{
    [Table("TB_HOSPITAL")]
    public class Hospital
    {
        [Column("Id"), HiddenInput]
        public int HospitalId { get; set; }

        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }

        public IList<Paciente> Pacientes { get; set; }

        public IList<Usuario> Usuarios { get; set; }

        [Required, MaxLength(50)]
        public string Nome { get; set; }

        [Required, MaxLength(19)]
        public string Cnpj { get; set; }


    }

}
