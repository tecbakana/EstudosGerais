using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using appCore.Models;

namespace appCore.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly appCore.Models.CmsxDbContext _context;

        public DetailsModel(appCore.Models.CmsxDbContext context)
        {
            _context = context;
        }

      public Aplicacao Aplicacao { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Aplicacaos == null)
            {
                return NotFound();
            }

            var aplicacao = await _context.Aplicacaos.FirstOrDefaultAsync(m => m.Aplicacaoid == id);
            if (aplicacao == null)
            {
                return NotFound();
            }
            else 
            {
                Aplicacao = aplicacao;
            }
            return Page();
        }
    }
}
