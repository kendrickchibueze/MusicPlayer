using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    internal  class PlayListModel
    {
        public string PlaylistName { get; set; }

        public List<Music> PlaylistMusics { get; set; } = new List<Music>();
        
    }
}
