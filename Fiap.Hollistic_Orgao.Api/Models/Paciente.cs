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
    [Table("TB_PACIENTE")]
    public class Paciente
    {
        [Column("Id"), HiddenInput]
        public int PacienteId { get; set; }

        public Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }

        public Hospital Hospital { get; set; }
        public IList<Orgao> Orgaos { get; set; }

        public IList<Exame> Exames { get; set; }

        [Required, MaxLength(50)]
        public string Nome { get; set; }

        [Required, Display(Name = "CPF"), MaxLength(13)]
        public string Cpf { get; set; }

        [Required, Display(Name = "Data de Nascimento"), DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required, Display(Name = "Tipo Sanguineo")]
        public string TipoSanguineo { get; set; }

        [Required]
        public double Peso { get; set; }

        [Required]
        public double Altura { get; set; }


        [Required]
        public string Gravidade { get; set; }

        
        public bool Doador { get; set; }

        
        public bool Receptor { get; set; }


    }
}
