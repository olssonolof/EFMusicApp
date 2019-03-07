using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFMusicApp
{
    class RemoveItem
    {
        internal static void RemoveArtist()
        {
            string artist = Menu.DrawMenu("Wich artist to remove? ", Program.DataBase.Artist.Select(x => x.Name).ToArray());
            Program.DataBase.Remove(Program.DataBase.Artist.Where(x => x.Name == artist).First());
            Program.DataBase.SaveChanges();
        }

        internal static void RemoveSong()
        {
            string song = Menu.DrawMenu("Wich song to remove? ", Program.DataBase.Song.Select(x => x.Title).ToArray());
            Program.DataBase.Remove(Program.DataBase.Song.Where(x => x.Title == song).First());
            Program.DataBase.SaveChanges();
        }

        internal static void RemoveAlbum()
        {
            string album = Menu.DrawMenu("Wich album to remove? ", Program.DataBase.Album.Select(x => x.Title).ToArray());
            Program.DataBase.Remove(Program.DataBase.Album.Where(x => x.Title == album).First());
            Program.DataBase.SaveChanges();
        }
    }
}
