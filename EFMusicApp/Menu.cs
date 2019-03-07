using System;
using System.Collections.Generic;
using System.Text;


namespace EFMusicApp
{
    public class Menu
    {
        // Use the Console class's features for moving the cursor in order to show a menu that can be controlled be selecting an option with the up and down arrows.
        public static string DrawMenu(string prompt, string[] options)
        {
            Console.WriteLine(prompt);

            int selected = 0;

            // Hide the cursor that will blink after calling ReadKey.
            Console.CursorVisible = false;

            ConsoleKey? key = null;
            while (key != ConsoleKey.Enter)
            {
                // If this is not the first iteration, move the cursor to the first line of the menu.
                if (key != null)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = Console.CursorTop - options.Length;
                }

                // Print all the options, highlighting the selected one.
                for (int i = 0; i < options.Length; i++)
                {
                    var option = options[i];
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine("- " + option);
                    Console.ResetColor();
                }

                // Read another key and adjust the selected value before looping to repeat all of this.
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.DownArrow)
                {
                    selected = Math.Min(selected + 1, options.Length - 1);
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    selected = Math.Max(selected - 1, 0);
                }
            }

            // Reset the cursor and return the selected option.
            Console.CursorVisible = true;
            Console.Clear();
            return options[selected];
        }



        public static string MainMenu()
        {
            string menu = DrawMenu("What do you want to do?", new[]
                {
                    "Add Something",
                    "Show Something",
                    "Remove Something",
                    "Populate Database from file",
                    "Quit"
                });
            if (menu == "Add Something") return AddMenu();
            else if (menu == "Show Something") return ShowMenu();
            else if (menu == "Populate Database from file") return menu;
            else if (menu == "Remove Something") return RemoveMenu();

            return menu;
        }

        private static string RemoveMenu()
        {
            string menu = DrawMenu("What do You wan't to remove? ", new[]
            {
                "Remove Artist",
                "Remove Album",
                "Remove Song",
                "Back"
            });
            if (menu != "Back") return menu;
            return MainMenu();
        }

        private static string ShowMenu()
        {
            string menu = DrawMenu("What do you want to Show?", new[]
{
                    "Show Artists",
                    "Show Albums",
                    "Show Songs",
                    "Back"
                });

            if (menu == "back") return MainMenu();
            else if (menu == "Show Songs") return ListSongChoice();
            else if (menu == "Show Artists") return ListArtistChoice();


            return menu;
        }

        private static string ListArtistChoice()
        {
            string menu = DrawMenu("What do you want to do?", new[]
                {
                   "List all artists",
                   "List artists from selected country",
                   "Back",
                });
            if (menu == "Back") return ShowMenu();


            return menu;


        }

        private static string ListSongChoice()
        {
            string menu = DrawMenu("What do you want to do?", new[]
                {
                   "List all songs",
                   "List songs A-Z",
                   "List songs, longest first",
                   "List songs beetween 3-4 minutes",
                   "Search song title",
                   "List all songs with album and artist",
                   "Back",
                });
            if (menu != "Back") return menu;
            return ShowMenu();

        }



        public static string AddMenu()
        {

            string addMenu = DrawMenu("What do you want to Add?", new[]
{
                    "Add New Artist",
                    "Add New Album",
                    "Add New Song",
                    "Back"
                });

            if (addMenu != "Back") return addMenu;


            return MainMenu();


        }







    }
}
