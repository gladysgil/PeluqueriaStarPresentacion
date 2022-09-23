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
    public class DeleteModel : PageModel
    {
        private readonly PeluqueriaPagesPersonaContext _context;

        public DeleteModel(PeluqueriaPagesPersonaContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Estelista == null)
            {
                return NotFound();
            }
            var estelista = await _context.Estelista.FindAsync(id);

            if (estelista != null)
            {
                Estelista = estelista;
                _context.Estelista.Remove(Estelista);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
