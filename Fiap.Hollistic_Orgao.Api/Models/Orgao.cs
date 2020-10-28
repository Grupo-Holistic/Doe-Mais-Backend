using Fiap.Hollistic_Orgao.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Hollistic.Web.Model
{
    [Table("TB_ORGAO")]
    public class Orgao
    {
        [Column("Id"), HiddenInput]
        public int OrgaoId { get; set; }
        public Paciente Paciente { get; set; }
        public int PacienteId { get; set; }
        [Required]
        public TipoOrgao TipoOrgao { get; set; }

        [Required, Display(Name = "Condição")]
        public string Condicao { get; set; }

        [Required]
        public DateTime Isquemia { get; set; }


    }
}

