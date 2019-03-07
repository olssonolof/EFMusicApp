using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFMusicApp
{
    class ListItems
    {
        public static void ListArtists()
        {
            if (Program.DataBase.Artist.Count() == 0)
            {
                Console.WriteLine("There are no artists in the database.");
            }
            else
            {
                Console.WriteLine("Artists in database:");
                Program.DataBase.Artist.ToList().ForEach(x => Console.WriteLine($"{x.Name}, ({x.Country}, {x.YearStarted})"));
            }
        }

        public static void ListAlbums()
        {
            if (Program.DataBase.Artist.Count() == 0)
            {
                Console.WriteLine("There are no Albums in the database.");
            }
            else
            {
                Console.WriteLine("Albums in database:");
                Program.DataBase.Album.Include(x => x.Artists).ToList().ForEach(x => Console.WriteLine($"{x.Title}, ({x.ReleaseDate}) (Artist: {x.Artists.Name})"));
            }
        }

        internal static void ListArtistsFromSelectedList()
        {
            if (Program.DataBase.Artist.Count() == 0) Console.WriteLine("There are no artists in the database");

            else
            {


                Program.DataBase.Artist.Where(x => x.Country == Menu.DrawMenu("Wich country? ",
                    Program.DataBase.Artist.Select(y => y.Country).Distinct().ToArray())).ToList().
                    ForEach(x => Console.WriteLine($"{ x.Name}, ({ x.Country}, { x.YearStarted})"));
            }

        }

        internal static void ListSongsSearchName()
        {
            if (Program.DataBase.Artist.Count() == 0)
            {
                Console.WriteLine("There are no Albums in the database.");
            }
            else
            {
                Program.DataBase.Song.Include(a => a.Albums.Artists).Where(z => z.Title.ToLower().Contains(ReadInput.ReadString("Song title? ").ToLower()))
                    .ToList()
                    .ForEach(x => Console.WriteLine($"{x.Title}, Length: {x.Length / 60:00}:{x.Length % 60:00}," +
                    $" has music video: {(x.HasMusicVideo == true ? "Yes" : "No")}\nLyrics:\n{x.Lyrics} \nby {x.Albums.Artists.Name}\n==============================================="));
            }
        }

        internal static void ListSongs3To4Min()
        {
            if (Program.DataBase.Song.Count() == 0)
            {
                Console.WriteLine("There are no songs in the database.");
            }
            else
            {
                Console.WriteLine("Songs in database:");
                Program.DataBase.Song.Where(s => s.Length > 180 && s.Length < 240).OrderByDescending(s => s.Length).ToList().ForEach(x => Console.WriteLine($"{x.Title}, Length: {x.Length / 60:00}:{x.Length % 60:00}," +
                   $" has music video: {(x.HasMusicVideo == true ? "Yes" : "No")}\nLyrics:\n{x.Lyrics}"));
            }
        }

        internal static void ListSongsLongestFirst()
        {

            if (Program.DataBase.Song.Count() == 0)
            {
                Console.WriteLine("There are no songs in the database.");
            }
            else
            {
                Console.WriteLine("Songs in database:");
                Program.DataBase.Song.OrderByDescending(s => s.Length).ToList().ForEach(x => Console.WriteLine($"{x.Title}, Length: {x.Length / 60:00}:{x.Length % 60:00}," +
                    $" has music video: {(x.HasMusicVideo == true ? "Yes" : "No")}\nLyrics:\n{x.Lyrics}"));
            }
        }

        public static void ListSongs()
        {
            if (Program.DataBase.Song.Count() == 0)
            {
                Console.WriteLine("There are no songs in the database.");
            }
            else
            {
                Console.WriteLine("Songs in database:");
                Program.DataBase.Song.ToList().ForEach(x => Console.WriteLine($"{x.Title}, Length: {x.Length / 60:00}:{x.Length % 60:00}," +
                    $" has music video: {(x.HasMusicVideo == true ? "Yes" : "No")}\nLyrics:\n{x.Lyrics}"));
            }
        }
        public static void ListSongsWithAlbum()
        {
            if (Program.DataBase.Song.Count() == 0)
            {
                Console.WriteLine("There are no songs in the database.");
            }
            else
            {
                Console.WriteLine("Songs in database:");
                Program.DataBase.Song.Include(s => s.Albums).ThenInclude(a => a.Artists).ToList().ForEach(x => Console.WriteLine($"{x.Title}, Length: {x.Length / 60:00}:{x.Length % 60:00}," +
                        $" on album: {x.Albums.Title} by {x.Albums.Artists.Name}"));

            }
        }

        public static void ListSongAtoZ()
        {
            if (Program.DataBase.Song.Count() == 0)
            {
                Console.WriteLine("There are no songs in the database.");
            }
            else
            {
                Console.WriteLine("Songs in database:");
                Program.DataBase.Song.OrderBy(s => s.Title).ToList().ForEach(x => Console.WriteLine($"{x.Title}, Length: {x.Length / 60:00}:{x.Length % 60:00}," +
                    $" has music video: {(x.HasMusicVideo == true ? "Yes" : "No")}\nLyrics:\n{x.Lyrics}"));
            }
        }

    }
}
