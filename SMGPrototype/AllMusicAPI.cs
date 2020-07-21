using System;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace SMGPrototype
{
    class AllMusicAPI
    {

        // Instance Variables
        private const int START_OF_HREF = 9; // This is the index where the url in href starts (For the get_links method)
        private WebClient x = new WebClient();

        public AllMusicAPI()
        {

        }


        /// <summary>
        ///  This method will get all the links for the search results
        /// </summary>
        /// <param name="web_string">The string array (seperated at new lines) of html code from the search</param>
        /// <returns>A list of the links to the search results</returns>
        public List<string> GetLinks(string web_string)
        {
            List<string> links = GetFromHTML("<a href=\"https://www.allmusic.com/song/", 9, "<", "\"", web_string);
            return links;
        }

        /// <summary>
        /// Returns the search results for the given search string
        /// </summary>
        /// <param name="search_string">The string to be searched for</param>
        /// <returns>Returns a string with the page data</returns>
        public string Search(string search_string)
        {
            String web_string = x.DownloadString("https://www.allmusic.com/search/all/" + search_string);
            return web_string;
        }
        /// <summary>
        /// Gets the relevent song information given it's name and artist
        /// </summary>
        /// <param name="SongName">The name of the song</param>
        /// <param name="ArtistName">The artist for the given song name</param>
        /// <returns>A Song with the relevent information filled in</returns>
        public Song GetInformation(string SongName, string ArtistName)
        {
            if (SongName == null || SongName == "")
            {
                throw new System.ArgumentNullException("Can't find song info based on only artist");
            }

            string search = Search(SongName + " " + ArtistName);
            List<string> search_results = GetLinks(search);
            if (search_results == null)
            {
                return new Song();
            }
            string web_data = x.DownloadString(search_results[0]);
            string Name = SongName;
            if (ArtistName != null && ArtistName != "") {
                string Artist = ArtistName;
            }
            else
            {
                ArtistName = GetArtist(web_data);
            }
            string Genre = GetGenre(web_data);
            string Year = GetYear(web_data);
            string Album = GetAlbum(web_data);
            string AlbumArt = GetAlbumArt(web_data);
            return new Song(Name, ArtistName, Genre, Year, Album, AlbumArt);
        }

        private string GetArtist(string search_result)
        {
            List<string> Artists = GetFromHTML("<a href=\"https://www.allmusic.com/artist/", 1, ">", "<", search_result);
            if (Artists != null)
            {
                return Artists[0];
            }
            else
            {
                return null;
            }
        }
        private string GetGenre(string search_result)
        {
            List<string> albumArts = null;
            if (albumArts != null)
            {
                return albumArts[0];
            }
            else
            {
                return null;
            }
        }
        private string GetYear(string search_result)
        {
            List<string> Years = GetFromHTML("<td class=\"year\"", 4, "u", "-", search_result);
            if (Years != null)
            {
                return Years[0];
            }
            else
            {
                return null;
            }
        }
        private string GetAlbum(string search_result)
        {
            List<string> Albums = GetFromHTML("<a href=\"https://www.allmusic.com/album/", 1, ">", "<", search_result);
            if (Albums != null)
            {
                return Albums[0];
            }
            else
            {
                return null;
            }
        }

        private string GetAlbumArt(string search_result)
        {
            List<string> albumArts = GetFromHTML("<a href=\"/album/", 11, ">", "\"", search_result);
            if (albumArts != null) {
                return albumArts[0];
            }
            else
            {
                return null;
            }
            
        }

        private List<string> GetFromHTML(string starts_with, int off_set, string starting_char, string ending_char, string web_data)
        {
            List<string> DataList = new List<string>();
            foreach (string s in web_data.Split("\n"))
            {
                if (s.Trim().StartsWith(starts_with))
                {
                    int start = s.IndexOf(starting_char) + off_set;
                    string b = s.Substring(start);
                    int end = b.IndexOf(ending_char);
                    if (end <= 0)
                    {
                        DataList.Add("Unknown");
                        continue;
                    }
                    string data = s.Substring(start, end);
                    DataList.Add(data);
                }
            }

            if (DataList.Count <= 0)
            {
                return null;
            }
            return DataList;
        }

    }

}

