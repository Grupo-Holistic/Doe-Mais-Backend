using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Hollistic.Web.Model
{
    [Table("TB_ENDERECO")]
    public class Endereco
    {
        [Column("Id"), Required]
        public int EnderecoId { get; set; }

        public IList<Hospital> Hospitais { get; set; }
        public IList<Paciente> Pacientes { get; set; }

        [Required]
        public string Rua { get; set; }
        [Display(Name ="Número"), Required]
        public int Numero { get; set; }
        
        [Required]
        public string Cep { get; set; }
        
        [Required]
        public Estado Estado{ get; set; }
        
        [Required]
        public string Cidade { get; set; }
        
        [Required]
        public double Latitude { get; set; }
        
        [Required]
        public double Longitude { get; set; }
    }
}
