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
    public class DeleteModel : PageModel
    {
        private readonly MusicContext _context;

        public DeleteModel(MusicContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Artist Artist { get; set; }
        public Album Album { get; set; }
        public Song Song { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var artist = await _context.Artists.FindAsync(id);

            if (artist == null)
            {
                return NotFound();
            }

            try
            {
                _context.Artists.Remove(artist);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }

            
        }
    }
}
