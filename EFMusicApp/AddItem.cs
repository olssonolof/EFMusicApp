using EFMusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFMusicApp
{
    class AddItem
    {


        public static void AddArtist()
        {
            var artist = new Artist()
            {
                Name = ReadInput.ReadString("Artist name: "),
                Country = ReadInput.ReadString("Country of origin: "),
                YearStarted = ReadInput.ReadInt("Year formed: ")
            };

            Program.DataBase.Add(artist);
            Program.DataBase.SaveChanges();
        }

        public static void AddAlbum()
        {
            var album = new Album()
            {
                Title = ReadInput.ReadString("Title of album: "),
                ReleaseDate = ReadInput.ReadInt("Year of release: "),

            };
            string artist = Menu.DrawMenu("Wich artist?", Program.DataBase.Artist.Select(z => z.Name).ToArray());
            album.Artists = Program.DataBase.Artist.Where(x => x.Name == artist).First();
            Program.DataBase.Add(album);
            Program.DataBase.SaveChanges();
        }

        public static void AddSong()
        {
            var song = new Song()
            {
                Title = ReadInput.ReadString("Title of track: "),
                Length = ReadInput.ReadInt("Length in seconds: "),
                TrackNumber = ReadInput.ReadInt("Tracknumber on album: "),
                HasMusicVideo = ReadInput.ReadString("Has music video(Y/N):").ToLower() == ("y") ? true : false,               

            };
            
            string artist = Menu.DrawMenu("Wich artist? ", Program.DataBase.Artist.Select(n => n.Name).ToArray());
            
            string album = Menu.DrawMenu("Wich album?", Program.DataBase.Album.Where(n => n.Artists.Name == artist).Select(y => y.Title).ToArray());
            song.Albums = Program.DataBase.Album.Where(x => x.Title == album).First();
            

            Program.DataBase.Add(song);
            Program.DataBase.SaveChanges();
        }



    }
}
