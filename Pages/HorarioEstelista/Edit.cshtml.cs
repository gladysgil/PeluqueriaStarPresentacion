using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PeluqueriaStar.Models;

namespace PeluqueriaStar.Pages_HorarioEstelista
{
    public class EditModel : PageModel
    {
        private readonly PeluqueriaPagesPersonaContext _context;

        public EditModel(PeluqueriaPagesPersonaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HorarioEstelista HorarioEstelista { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.HorarioEstelista == null)
            {
                return NotFound();
            }

            var horarioestelista =  await _context.HorarioEstelista.FirstOrDefaultAsync(m => m.Id == id);
            if (horarioestelista == null)
            {
                return NotFound();
            }
            HorarioEstelista = horarioestelista;
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

            _context.Attach(HorarioEstelista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorarioEstelistaExists(HorarioEstelista.Id))
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

        private bool HorarioEstelistaExists(int id)
        {
          return (_context.HorarioEstelista?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
