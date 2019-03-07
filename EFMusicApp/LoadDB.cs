using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EFMusicApp
{
    class LoadDB
    {
        public static void LoadDbOnStart()
        {
            Task x = DrawLoadingAsync("Loading database...");
            
        }

      

        public static async Task LoadDBAsync()
        {

            await Program.DataBase.Artist.FindAsync(1);
            
        }


        public static async Task DrawLoadingAsync(string prompt)
        {
            var loadDb = Task.Run(() => LoadDBAsync());
            int i = 0;
            string[] load = new[] { "|", @"/", "-", @"\" };
            Console.WriteLine(prompt);
            while(!loadDb.IsCompleted)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = 1;
                Console.Write(load[i]);
                Thread.Sleep(100);
                i++;
                if (i == load.Length) i = 0;

            }
            Console.Clear();
            await loadDb;
            
        }

    }
}
