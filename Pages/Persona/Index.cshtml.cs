using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeluqueriaStar.Models;

namespace PeluqueriaStar.Pages_Persona
{
    public class IndexModel : PageModel
    {
        private readonly PeluqueriaPagesPersonaContext _context;

        public IndexModel(PeluqueriaPagesPersonaContext context)
        {
            _context = context;
        }

        public IList<Persona> Persona { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Persona != null)
            {
                Persona = await _context.Persona.ToListAsync();
            }
        }
    }
}
