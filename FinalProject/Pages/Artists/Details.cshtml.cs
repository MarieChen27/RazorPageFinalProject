using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Pages.Artists
{
    public class DetailsModel : PageModel
    {
        private readonly MusicContext _context;

        public DetailsModel(MusicContext context)
        {
            _context = context;
        }

        public Artist Artist { get; set; }
        

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Artist = await _context.Artists
                .Include(a => a.Albums)
                .ThenInclude(b => b.Songs)
                .FirstOrDefaultAsync(m => m.ArtistID == id);

            if (Artist == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
