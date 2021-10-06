using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Models
{
    public class Medicos
    {
        public string Operacion { get; set; }
        public int IdMedico { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Especialidad { get; set; }
    }
}