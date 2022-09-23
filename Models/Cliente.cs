using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeluqueriaStar.Models
{
    public class Cliente : Persona
    {
        public string Dirrecion { get; set; }  = string.Empty;
        
        public int  Edad { get; set; }

        public Genero Genero { get; set; }

        public bool Membresia { get; set; }

        public int CantidadCitas { get; set; }

        public Estelista? Estelista { get; set; }
        public HorarioEstelista? HorarioEstelista { get; set; }

        public ServiciosOfrecer?  ServiciosOfrecer { get; set; }
    }
}