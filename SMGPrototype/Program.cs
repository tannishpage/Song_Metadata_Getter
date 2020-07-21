using System;
using System.Collections.Generic;

namespace SMGPrototype
{
    class Program
    {
        static void Main(string[] args)
        {

            AllMusicAPI am = new AllMusicAPI();
            Console.Write("Enter song name: ");
            string songName = Console.ReadLine();
            Console.Write("Enter artist name: ");
            string artistName = Console.ReadLine();
            Song s = am.GetInformation(songName, artistName);
            Console.Clear();
            Console.WriteLine(s.ToString());
            Console.WriteLine();
        }
    }
}