using System;
using System.Net;
using System.IO;

namespace SMGPrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example to download a webpage
            WebClient x = new WebClient();
            String y = x.DownloadString("http://google.com");
            Console.WriteLine(y);
            Console.ReadKey();
        }
    }
}
