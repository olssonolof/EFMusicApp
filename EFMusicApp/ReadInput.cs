using System;
using System.Collections.Generic;
using System.Text;

namespace EFMusicApp
{
    class ReadInput
    {
        public static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }


        public static int ReadInt(string prompt)
        {
            Console.Write(prompt + ": ");
            // The question marks allows a variable of a primitive data type to have the value null.
            int? number = null;
            while (number == null)
            {
                string input = Console.ReadLine();
                try
                {
                    number = int.Parse(input);
                }
                catch
                {
                    Console.Write("Please enter a valid integer: ");
                }
            }

            // Theoretically the value could be null, but our loop condition ensures this so we simply cast to a non-nullable integer.
            return (int)number;
        }

        public static void WriteUnderlined(string line)
        {
            Console.WriteLine(line);
            Console.WriteLine(new String('-', line.Length));
        }


    }
}
