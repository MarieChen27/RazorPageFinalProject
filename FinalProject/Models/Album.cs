using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace FinalProject.Models
{
    public class Album
    {
        public int AlbumID { get; set; }

        [Display(Name = "Album"), Required]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; }

        //Album has "has-a" relationship with Song
        public List<Song> Songs { get; set; }

        
    }
}
