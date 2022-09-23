using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeluqueriaStar.Models
{
    public class Estelista : Persona
    {
        public string TarjetaProfesional { get; set;}  = string.Empty;

        public List<HorarioEstelista>? HorarioEstelista { get; set; } 

        public List<ServiciosOfrecer>? ServiciosOfrecer { get; set; }
    }
}