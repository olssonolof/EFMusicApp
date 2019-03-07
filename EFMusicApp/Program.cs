
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EFMusicApp
{
    class Program
    {

        public static AppDbContext DataBase;
        static void Main(string[] args)
        {
            using (DataBase = new AppDbContext())
            {
                LoadDB.LoadDbOnStart();

                while (true)
                {
                    string option = Menu.MainMenu();

                    if (option == "List songs A-Z") ListItems.ListSongAtoZ();
                    else if (option == "List all songs") ListItems.ListSongs();
                    else if (option == "List songs, longest first") ListItems.ListSongsLongestFirst();
                    else if (option == "List songs beetween 3-4 minutes") ListItems.ListSongs3To4Min();
                    else if (option == "Search song title") ListItems.ListSongsSearchName();
                    else if (option == "List all songs with album and artist") ListItems.ListSongsWithAlbum();



                    else if (option == "List all artists") ListItems.ListArtists();
                    else if (option == "List artists from selected country") ListItems.ListArtistsFromSelectedList();


                    else if (option == "Show Albums") ListItems.ListAlbums();


                    else if (option == "Add New Artist") AddItem.AddArtist();
                    else if (option == "Add New Album") AddItem.AddAlbum();
                    else if (option == "Add New Song") AddItem.AddSong();

                    else if (option == "Remove Artist") RemoveItem.RemoveArtist();
                    else if (option == "Remove Album") RemoveItem.RemoveAlbum();
                    else if (option == "Remove Song") RemoveItem.RemoveSong();
                    else if (option == "Populate Database from file")
                    {
                        ReadFromFile.ReadAll();
                    }

                    else Environment.Exit(0);

                    Console.WriteLine();
                }
            }
        }
    }
}
