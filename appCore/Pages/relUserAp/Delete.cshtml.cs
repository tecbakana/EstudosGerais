using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using appCore.Models;

namespace appCore.Pages.relUserAp
{
    public class DeleteModel : PageModel
    {
        private readonly appCore.Models.CmsxDbContext _context;

        public DeleteModel(appCore.Models.CmsxDbContext context)
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

            var relusuarioaplicacao = await _context.Relusuarioaplicacaos.FirstOrDefaultAsync(m => m.Relacaoid == id);

            if (relusuarioaplicacao == null)
            {
                return NotFound();
            }
            else 
            {
                Relusuarioaplicacao = relusuarioaplicacao;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Relusuarioaplicacaos == null)
            {
                return NotFound();
            }
            var relusuarioaplicacao = await _context.Relusuarioaplicacaos.FindAsync(id);

            if (relusuarioaplicacao != null)
            {
                Relusuarioaplicacao = relusuarioaplicacao;
                _context.Relusuarioaplicacaos.Remove(Relusuarioaplicacao);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
