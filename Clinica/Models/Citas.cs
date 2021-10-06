using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Models
{
    public class Citas
    {
        public string Operacion { get; set; }
        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public string Paciente { get; set; }
        public int IdMedico { get; set; }
        public string Medico { get; set; }
        public DateTime FechaCita { get; set; }
        public string Diagnostico { get; set; }
        public DateTime? FechaDiagnostico { get; set; }
    }
}