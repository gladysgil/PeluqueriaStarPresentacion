using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeluqueriaStar.Models;

namespace PeluqueriaStar.Pages_ServiciosOfrecer
{
    public class DeleteModel : PageModel
    {
        private readonly PeluqueriaPagesPersonaContext _context;

        public DeleteModel(PeluqueriaPagesPersonaContext context)
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

            var serviciosofrecer = await _context.ServiciosOfrecer.FirstOrDefaultAsync(m => m.Id == id);

            if (serviciosofrecer == null)
            {
                return NotFound();
            }
            else 
            {
                ServiciosOfrecer = serviciosofrecer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ServiciosOfrecer == null)
            {
                return NotFound();
            }
            var serviciosofrecer = await _context.ServiciosOfrecer.FindAsync(id);

            if (serviciosofrecer != null)
            {
                ServiciosOfrecer = serviciosofrecer;
                _context.ServiciosOfrecer.Remove(ServiciosOfrecer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
