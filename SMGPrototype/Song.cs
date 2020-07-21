using System;
using System.Collections.Generic;
using System.Text;

namespace SMGPrototype
{
    /// <summary>
    /// Holds information about the song. Like album name, link to album art, etc. 
    /// </summary>
    class Song
    {
        string Name { get; set; }
        string Artist { get; set; }
        string Genre { get; set; }
        string Year { get; set; }
        string Album { get; set; }
        string AlbumArt { get; set; }

        public Song(string Name = null,
        string Artist = null,
        string Genre = null,
        string Year = null,
        string Album = null,
        string AlbumArt = null)
        {
            this.Name = Name;
            this.Artist = Artist;
            this.Genre = Genre;
            this.Year = Year;
            this.Album = Album;
            this.AlbumArt = AlbumArt;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}\nArtist: {1}\nGenre: {2}\nYear: {3}\nAlbum: {4}\nAlbum Art: {5}\n",
                this.Name, this.Artist, this.Genre, this.Year, this.Album, this.AlbumArt);
        }


    }
}
