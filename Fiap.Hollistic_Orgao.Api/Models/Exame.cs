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
    [Table("TB_EXAME")]
    public class Exame
    {
        [Column("Id"), HiddenInput]
        public int ExameId { get; set; }
        public Paciente Paciente { get; set; }
        public int PacienteId { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Display(Name = "Descrição"), Required]
        public string Descricao { get; set; }

        [Display(Name = "Data do Exame"), DataType(DataType.Date)]
        public DateTime DataExame { get; set; }


    }
}
