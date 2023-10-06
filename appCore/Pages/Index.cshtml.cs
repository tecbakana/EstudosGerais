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
    public class IndexModel : PageModel
    {
        private readonly appCore.Models.CmsxDbContext _context;

        public IndexModel(appCore.Models.CmsxDbContext context)
        {
            _context = context;
        }

        public IList<Aplicacao> Aplicacao { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Aplicacaos != null)
            {
                Aplicacao = await _context.Aplicacaos.ToListAsync();
            }
        }
    }
}
