using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Hollistic.Web.Model
{
    [Table("TB_USUARIO")]
    public class Usuario
    {
        [Column("Id"), HiddenInput]
        public int UsuarioId { get; set; }

        public Hospital Hospital { get; set; }
        public int HospitalId { get; set; }
        [Required]
        public string Tipo { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Login { get; set; }

        [DataType(DataType.Password), Required]
        public string Senha { get; set; }
    }
}
