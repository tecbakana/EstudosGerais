using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using appCore.Models;

namespace appCore.Pages.relUserAp
{
    public class EditModel : PageModel
    {
        private readonly appCore.Models.CmsxDbContext _context;

        public EditModel(appCore.Models.CmsxDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Relusuarioaplicacao Relusuarioaplicacao { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Relusuarioaplicacaos == null)
            {
                return NotFound();
            }

            var relusuarioaplicacao =  await _context.Relusuarioaplicacaos.FirstOrDefaultAsync(m => m.Relacaoid == id);
            if (relusuarioaplicacao == null)
            {
                return NotFound();
            }
            Relusuarioaplicacao = relusuarioaplicacao;
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

            _context.Attach(Relusuarioaplicacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RelusuarioaplicacaoExists(Relusuarioaplicacao.Relacaoid))
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

        private bool RelusuarioaplicacaoExists(Guid id)
        {
          return (_context.Relusuarioaplicacaos?.Any(e => e.Relacaoid == id)).GetValueOrDefault();
        }
    }
}
