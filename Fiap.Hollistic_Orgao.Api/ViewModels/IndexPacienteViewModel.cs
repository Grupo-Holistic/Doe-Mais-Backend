using Fiap.Hollistic.Web.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Fiap.Hollistic_Orgao.Web.ViewModels
{
    public class IndexPacienteViewModel
    {
        public Paciente Paciente { get; set; }
        public int PacienteId { get; set; }
        public bool Doador { get; set; }
        public bool Receptor { get; set; }
        
        public Exame Exame { get; set; }
        public SelectList Exames { get; set; }
        public Orgao Orgao { get; set; }
        public SelectList Orgaos { get; set; }
        public IList<Paciente> Pacientes { get; set; }

    }
}
