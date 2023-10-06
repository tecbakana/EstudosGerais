using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using appCore.Models;

namespace appCore.Pages
{
    public class EditModel : PageModel
    {
        private readonly appCore.Models.CmsxDbContext _context;

        public EditModel(appCore.Models.CmsxDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Aplicacao Aplicacao { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Aplicacaos == null)
            {
                return NotFound();
            }

            var aplicacao =  await _context.Aplicacaos.FirstOrDefaultAsync(m => m.Aplicacaoid == id);
            if (aplicacao == null)
            {
                return NotFound();
            }
            Aplicacao = aplicacao;
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

            _context.Attach(Aplicacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AplicacaoExists(Aplicacao.Aplicacaoid))
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

        private bool AplicacaoExists(Guid id)
        {
          return (_context.Aplicacaos?.Any(e => e.Aplicacaoid == id)).GetValueOrDefault();
        }
    }
}
