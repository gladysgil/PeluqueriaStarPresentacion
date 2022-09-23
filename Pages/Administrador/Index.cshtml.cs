using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeluqueriaStar.Models;

namespace PeluqueriaStar.Pages_Administrador
{
    public class IndexModel : PageModel
    {
        private readonly PeluqueriaPagesPersonaContext _context;

        public IndexModel(PeluqueriaPagesPersonaContext context)
        {
            _context = context;
        }

        public IList<Administrador> Administrador { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Administrador != null)
            {
                Administrador = await _context.Administrador.ToListAsync();
            }
        }
    }
}
