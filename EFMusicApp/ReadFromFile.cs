using EFMusicApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMusicApp
{
    class ReadFromFile
    {

        public static void ReadAll()
        {
            ClearDatabase();
            var artists = ReadArtistFromFile();
            var albums = ReadAlbumFromFile(artists);
            var songs = ReadSongFromFile(albums);
            foreach (var item in songs)
            {
                Program.DataBase.Add(item.Value);
                Program.DataBase.SaveChanges();
            }
        }

        public static void ClearDatabase()
        {
            Program.DataBase.Song.RemoveRange(Program.DataBase.Song);
            Program.DataBase.Album.RemoveRange(Program.DataBase.Album);
            Program.DataBase.Artist.RemoveRange(Program.DataBase.Artist);
            Program.DataBase.SaveChanges();
        }

        public static Dictionary<int, Artist> ReadArtistFromFile()
        {
            var artistDic = new Dictionary<int, Artist>();
            string[] input = File.ReadAllLines(@"Files/Artists.csv").Skip(1).ToArray();
            foreach (var item in input)
            {

                try
                {
                    string[] values = item.Split('|').Select(v => v.Trim()).ToArray();

                    int id = int.Parse(values[0]);
                    string name = values[1];
                    string country = values[2];
                    int yearStarted = int.Parse(values[3]);
                    artistDic[id] = new Artist
                    {
                        Name = name,
                        Country = country,
                        YearStarted = yearStarted
                    };                   
                 

                }
                catch
                {
                    Console.WriteLine("Wrong File input for artist");
                }
            }
            Console.WriteLine("Artists added from file.");
            return artistDic;
        }





        public static Dictionary<int, Album> ReadAlbumFromFile(Dictionary<int, Artist> artists)
        {
            var albumsDic = new Dictionary<int, Album>();
            string[] input = File.ReadAllLines(@"Files/ALbums.csv").Skip(1).ToArray();
            foreach (var item in input)
            {
                try
                {
                    string[] values = item.Split('|').Select(v => v.Trim()).ToArray();

                    int id = int.Parse(values[0]);
                    string title = values[1];
                    DateTime releaseDate = DateTime.Parse(values[2]);
                    int artistId = int.Parse(values[3]);

                    albumsDic[id] = new Album
                    {
                        Title = title,
                        ReleaseDate = Convert.ToInt32(releaseDate.Year),
                        Artists = artists[artistId]
                    };
                

                }
                catch
                {
                    Console.WriteLine("Wrong File input for album");
                }
            }
            Console.WriteLine("Albums added from file.");
            return albumsDic;

        }

        public static Dictionary<int, Song> ReadSongFromFile(Dictionary<int, Album> albums)
        {
            var songDic = new Dictionary<int, Song>();
            string[] input = File.ReadAllLines(@"Files/Songs.csv").Skip(1).ToArray();
            foreach (var item in input)
            {
                try
                {
                    string[] values = item.Split('|').Select(v => v.Trim()).ToArray();


                    int id = int.Parse(values[0]);
                    int trackNumber = int.Parse(values[1]);
                    string title = values[2];
                    int length = (int.Parse(values[3].Substring(0, values[3].IndexOf(':'))) * 60) + int.Parse(values[3].Substring(values[3].IndexOf(':') + 1));
                    bool hasMusicVideo = values[4] == "Y" ? true : false;
                    int albumId = int.Parse(values[5]);
                    string lyrics = values.Length > 6 ? values[6] : "";



                    songDic[id] = new Song
                    {
                        TrackNumber = trackNumber,
                        Title = title,
                        Length = length,
                        HasMusicVideo = hasMusicVideo,
                        Lyrics = lyrics,
                        Albums = albums[albumId]
                    };

                }
                catch
                {
                    Console.WriteLine("Wrong File input for song");
                }
            }
            Console.WriteLine("Songs added from file.");
            return songDic;
        }
    }
}
