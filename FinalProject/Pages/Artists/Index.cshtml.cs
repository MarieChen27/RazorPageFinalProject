using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Pages.Artists
{
    public class IndexModel : PageModel
    {
        private readonly MusicContext _context;

        public IndexModel(MusicContext context)
        {
            _context = context;
        }


        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string TitleSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }


        public IList<Artist> Artist { get; set; }


        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_asc" : "";


            IQueryable<Artist> artistsIQ = from s in _context.Artists
                                           select s;

            

            CurrentFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                artistsIQ = artistsIQ.Where(s => s.ArtistName.Contains(searchString));
            }

            
            switch (sortOrder)
            {
                case "Date": 
                    artistsIQ = artistsIQ.OrderBy(s => s.Birthday);
                    break;
                case "date_desc":
                    artistsIQ = artistsIQ.OrderByDescending(s => s.Birthday);
                    break;
                case "title_asc":
                    artistsIQ = artistsIQ.OrderBy(s => s.Albums.Title);
                    break;
                default:
                    artistsIQ = artistsIQ.OrderBy(s => s.ArtistName);
                    break;
            }

            Artist = await artistsIQ
                .Include(a => a.Albums)
                .ThenInclude(b => b.Songs)
                .AsNoTracking().ToListAsync();
        }
    }
}
