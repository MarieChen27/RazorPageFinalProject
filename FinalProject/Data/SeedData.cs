using System;
using System.Collections.Generic;
using System.Linq;
using FinalProject.Data;
using FinalProject.Models;


namespace FinalProject.Data
{
    public class SeedData
    {
        public static void Initialize(MusicContext context)
        {
            context.Database.EnsureCreated();
            {
                // Look for any artists.
                if (context.Artists.Any())
                {
                    return;   // DB has been seeded
                }

                context.Artists.AddRange(
                    new Artist
                    {
                        ArtistName = "Billie Eilish",
                        Birthday = DateTime.Parse("2001-12-18"),

                        Albums = new Album
                        {
                            Title = "When We All Fall Asleep, Where Do We Go?",
                            ReleaseDate = DateTime.Parse("2019-03-29"),
                            Genre = "Electropop, Pop",
                            Songs = new List<Song>
                                {
                                    new Song{SongName="Bad Guy", SongLength=new TimeSpan(0, 03, 14)},
                                    new Song{SongName="Wish You Were Gay", SongLength=new TimeSpan(0, 05, 26)},
                                }
                        }
                    },

                    

                    new Artist
                    {
                        ArtistName = "Shawn Mendes",
                        Birthday = DateTime.Parse("1998-08-08"),

                        Albums = new Album
                        {
                            Title = "Shawn Mendes: The Album",
                            ReleaseDate = DateTime.Parse("2018-05-25"),
                            Genre = "Pop, Pop-rock",
                            Songs = new List<Song>
                                {
                                    new Song{SongName="In My Blood", SongLength=new TimeSpan(0, 03, 31)},
                                    new Song{SongName="Lost In Japan", SongLength=new TimeSpan(0, 03, 21)},
                                }
                        }
                    },

 

                    new Artist
                    {
                        ArtistName = "Ed Sheeran",
                        Birthday = DateTime.Parse("1991-02-17"),

                        Albums = new Album
                        {
                            Title = "÷",
                            ReleaseDate = DateTime.Parse("2017-03-03"),
                            Genre = "Pop",
                            Songs = new List<Song>
                                {
                                    new Song{SongName="Perfect", SongLength=new TimeSpan(0, 04, 23)},
                                    new Song{SongName="Shape of You", SongLength=new TimeSpan(0, 03, 53)},
                                }
                        }
                    },
                            

                    new Artist
                    {
                        ArtistName = "Childish Gambino",
                        Birthday = DateTime.Parse("1983-09-25"),

                        Albums = new Album
                        {
                            Title = "Awaken, My Love!",
                            ReleaseDate = DateTime.Parse("2016-12-02"),
                            Genre = "Funk, R&B, Soul",
                            Songs = new List<Song>
                                {
                                    new Song{SongName="Redbone", SongLength=new TimeSpan(0, 04, 23)},
                                }
                        }
                    },

                    new Artist
                    {
                        ArtistName = "Alan Walker",
                        Birthday = DateTime.Parse("1997-08-24"),

                        Albums = new Album
                        {
                            Title = "Different World",
                            ReleaseDate = DateTime.Parse("2018-12-14"),
                            Genre = "Electro-house",
                            Songs = new List<Song>
                                {
                                    new Song{SongName="Faded", SongLength=new TimeSpan(0, 03, 32)},
                                    new Song{SongName="All Falls Down", SongLength=new TimeSpan(0, 03, 19)},
                                }
                            
                        }
                    }
                );

                context.SaveChanges();

            }
        }
    }
}

