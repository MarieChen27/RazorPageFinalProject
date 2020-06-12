using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Pages.Artists
{
    public class EditModel : PageModel
    {
        private readonly MusicContext _context;

        public EditModel(MusicContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var artistToUpdate = await _context.Artists
                .Include(a => a.Albums)
                .ThenInclude(b => b.Songs)
                .FirstOrDefaultAsync(m => m.ArtistID == id);


            if (artistToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Artist>(
                artistToUpdate,
                "artist",
                a => a.ArtistName, a => a.Birthday))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();

        }

        private bool ArtistExists(int id)
        {
            return _context.Artists.Any(e => e.ArtistID == id);
        }

    }
}
