using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FinalProject.Models
{
    public class Artist
    {
        public int ArtistID { get; set; }

        [Display(Name = "Artist")]
        public string ArtistName { get; set; }

        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }


        //Artist has "has-a" relationship with Album
        public Album Albums { get; set; }

    }
}
