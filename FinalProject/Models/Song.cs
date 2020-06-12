using System;
using System.ComponentModel.DataAnnotations;


namespace FinalProject.Models
{
    public class Song
    {
        public int SongID { get; set; }

        [Display(Name = "Song Name")]
        public string SongName { get; set; }

        [Display(Name = "Song Length")]
        [DataType(DataType.Time)]
        public TimeSpan SongLength { get; set; }

    }
}
