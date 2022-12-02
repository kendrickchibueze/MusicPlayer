using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    internal class Music
    {

        

        public int Id{ get; set; }
        public string MusicName { get; set; }
        public string  ArtistName { get; set; }



        public Music()
        {

        }

        public Music(int id, string songName, string artistName)
        {
            Id = id;
            MusicName = songName;
            ArtistName = artistName;    
        }



      
    }
}
