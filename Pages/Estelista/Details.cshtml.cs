using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeluqueriaStar.Models;

namespace PeluqueriaStar.Pages_Estelista
{
    public class DetailsModel : PageModel
    {
        private readonly PeluqueriaPagesPersonaContext _context;

        public DetailsModel(PeluqueriaPagesPersonaContext context)
        {
            _context = context;
        }

      public Estelista Estelista { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Estelista == null)
            {
                return NotFound();
            }

            var estelista = await _context.Estelista.FirstOrDefaultAsync(m => m.Id == id);
            if (estelista == null)
            {
                return NotFound();
            }
            else 
            {
                Estelista = estelista;
            }
            return Page();
        }
    }
}
