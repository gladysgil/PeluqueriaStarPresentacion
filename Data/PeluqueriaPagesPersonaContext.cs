using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PeluqueriaStar.Models;

    public class PeluqueriaPagesPersonaContext : DbContext
    {
        public PeluqueriaPagesPersonaContext (DbContextOptions<PeluqueriaPagesPersonaContext> options)
            : base(options)
        {
        }

        public DbSet<PeluqueriaStar.Models.Persona> Persona { get; set; } = default!;

        public DbSet<PeluqueriaStar.Models.Administrador>? Administrador { get; set; }

        public DbSet<PeluqueriaStar.Models.Cliente>? Cliente { get; set; }

        public DbSet<PeluqueriaStar.Models.Estelista>? Estelista { get; set; }

        public DbSet<PeluqueriaStar.Models.HorarioEstelista>? HorarioEstelista { get; set; }

        public DbSet<PeluqueriaStar.Models.ServiciosOfrecer>? ServiciosOfrecer { get; set; }

       
    }
