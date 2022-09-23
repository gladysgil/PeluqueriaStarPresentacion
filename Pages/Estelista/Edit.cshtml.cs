using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PeluqueriaStar.Models;

namespace PeluqueriaStar.Pages_Estelista
{
    public class EditModel : PageModel
    {
        private readonly PeluqueriaPagesPersonaContext _context;

        public EditModel(PeluqueriaPagesPersonaContext context)
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

            var estelista =  await _context.Estelista.FirstOrDefaultAsync(m => m.Id == id);
            if (estelista == null)
            {
                return NotFound();
            }
            Estelista = estelista;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Estelista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstelistaExists(Estelista.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EstelistaExists(int id)
        {
          return (_context.Estelista?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
