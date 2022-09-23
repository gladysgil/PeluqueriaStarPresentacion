using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PeluqueriaStar.Models;

namespace PeluqueriaStar.Pages_ServiciosOfrecer
{
    public class EditModel : PageModel
    {
        private readonly PeluqueriaPagesPersonaContext _context;

        public EditModel(PeluqueriaPagesPersonaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ServiciosOfrecer ServiciosOfrecer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ServiciosOfrecer == null)
            {
                return NotFound();
            }

            var serviciosofrecer =  await _context.ServiciosOfrecer.FirstOrDefaultAsync(m => m.Id == id);
            if (serviciosofrecer == null)
            {
                return NotFound();
            }
            ServiciosOfrecer = serviciosofrecer;
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

            _context.Attach(ServiciosOfrecer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciosOfrecerExists(ServiciosOfrecer.Id))
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

        private bool ServiciosOfrecerExists(int id)
        {
          return (_context.ServiciosOfrecer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
