using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using appCore.Models;

namespace appCore.Pages.usuario
{
    public class IndexModel : PageModel
    {
        private readonly appCore.Models.CmsxDbContext _context;

        public IndexModel(appCore.Models.CmsxDbContext context)
        {
            _context = context;
        }

        public IList<Usuario> Usuario { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Usuarios != null)
            {
                Usuario = await _context.Usuarios.ToListAsync();
            }
        }
    }
}
