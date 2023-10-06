using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using appCore.Models;

namespace appCore.Pages
{
    public class CreateModel : PageModel
    {
        private readonly appCore.Models.CmsxDbContext _context;

        public CreateModel(appCore.Models.CmsxDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Aplicacao Aplicacao { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Aplicacaos == null || Aplicacao == null)
            {
                return Page();
            }

            _context.Aplicacaos.Add(Aplicacao);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
