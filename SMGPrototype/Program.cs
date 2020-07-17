using System;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace SMGPrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            const int START_OF_HREF = 9; // This is the index where the url in href starts
            String search_string = "Despacito";
            // Example to download a webpage
            WebClient x = new WebClient();
            String y = x.DownloadString("https://www.allmusic.com/search/all/" + search_string);
            String[] ss = y.Split("\n");
            List<string> links = new List<string>();
            foreach (string t in ss)
            {
                //Console.WriteLine("Hi");
                string b = t.Trim();
                if (b.StartsWith("<a href=\"https://www.allmusic.com/song/")){
                    links.Add(b.Substring(START_OF_HREF, (b.IndexOf(">") - 1) - START_OF_HREF)); // Getting all the links for the songs with the name that was searched for
                    Console.WriteLine(b.Substring(START_OF_HREF, (b.IndexOf(">") - 1) - START_OF_HREF));
                }
            }

            // The next step from here would be to use those links to retrieve album information, like Artist name, album name, track number, album art, etc. 
            // Now since we will be getting multiple links, we need to be able to eliminate links if they don't contain certain information. For example if the name of the song
            // is not an exact match of the given name in the search field then the link should be eliminated. Similarly if there are any inconsistancies with the information
            // given to the program from the file to the information on the website we should eliminate the links.


            // Now we should be able to write something like this for soundcloud and spotify to retrieve album covers oncee we have information about album and artist
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}