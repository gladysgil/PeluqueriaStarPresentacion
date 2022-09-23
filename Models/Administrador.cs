using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeluqueriaStar.Models
{
    public class Administrador : Persona
    {
       public Estelista? Estelista { get; set; }       public Cliente?  Cliente { get; set; }
       public ServiciosOfrecer? ServiciosOfrecer { get; set; }
       public HorarioEstelista? HorarioEstelista { get; set; }
   }
}