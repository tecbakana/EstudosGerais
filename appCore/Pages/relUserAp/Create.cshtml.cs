using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using appCore.Models;

namespace appCore.Pages.relUserAp
{
    public class CreateModel : PageModel
    {
        private readonly appCore.Models.CmsxDbContext _context;

        public CreateModel(appCore.Models.CmsxDbContext context)
        {
            _context = context;
        }

        public SelectList appList { get; set; }
        public SelectList userList { get; set; }


        public IActionResult OnGet()
        {
            this.appList = new SelectList(this._context.Aplicacaos, "Aplicacaoid", "Nome");
            this.userList = new SelectList(this._context.Usuarios, "Userid", "Nome");
            return Page();
        }

        [BindProperty]
        public Relusuarioaplicacao Relusuarioaplicacao { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Relusuarioaplicacaos == null || Relusuarioaplicacao == null)
            {
                return Page();
            }

            _context.Relusuarioaplicacaos.Add(Relusuarioaplicacao);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
