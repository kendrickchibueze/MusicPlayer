namespace MusicPlayer
{
    internal class CreatePlayList
    {
        //public static List<Music> MusicList { get; set; } = new List<Music>();

        public static Dictionary<string, PlayListModel> PlaylistDictionary = new Dictionary<string, PlayListModel>();




        public static void CreatePlaylist()
        {
            Console.WriteLine("Enter playlist name");
            var playlistName = Console.ReadLine();
            Console.WriteLine();

            while (string.IsNullOrWhiteSpace(playlistName))
            {
                Console.WriteLine("Playlist name cannot be null or empty space");
                Console.WriteLine("Enter prefered playlist name");
                playlistName = Console.ReadLine();
            }


            while (PlaylistDictionary.ContainsKey(playlistName))
            {
                Console.WriteLine($"Playlist with name: {playlistName} exits. Try another!!!");
                playlistName = Console.ReadLine();
            }

            var newPlaylist = new PlayListModel
            {
                PlaylistName = playlistName,
                PlaylistMusics = SelectedPlaylistSongs()
            };

            PlaylistDictionary.Add(playlistName, newPlaylist);

            Console.WriteLine($"{playlistName} playlist created");
            ShowAllPlaylist();
            Console.WriteLine();

            return;


        }

        static List<Music> SelectedPlaylistSongs()
        {


            var availableSongs = PlayList.AllSongs().ToList();
            var playlist = new List<Music>();


        DataEnry:
            Console.WriteLine("Choose number corresponding to music you'd like to add to playlist and press Enter key to add \n" +
            "Press q to quit\n");

            ShowMusic();

            var choice = Console.ReadLine();
            Console.WriteLine();

            if (string.IsNullOrWhiteSpace(choice)) goto DataEnry;

            while (!string.IsNullOrWhiteSpace(choice))
            {

                if (choice == "q") return playlist;

                if (!int.TryParse(choice, out _))
                {
                    Console.WriteLine("Choose a number corresponding to music and press Enter key.");
                    Console.WriteLine();
                    goto DataEnry;
                }

                var numberChoice = int.Parse(choice);


                playlist.Add(availableSongs[numberChoice]);
                Console.WriteLine("Music added");

                Console.WriteLine();
                availableSongs.RemoveAt(numberChoice);

                goto DataEnry;
            }

            return null;



            void ShowMusic()
            {
                int counter = 0;
                foreach (var songs in availableSongs)
                {
                    Console.WriteLine($"{counter}. {songs.MusicName}");
                    counter++;
                }

                Console.WriteLine();
            }
        }


        public static void ShowAllPlaylist()
        {

            if (PlaylistDictionary.Count <= 0)
            {
                Console.WriteLine("You don't have any playlist");
                Console.WriteLine();
                return;
            }

        ChoosePlaylist:

            Console.WriteLine("Available playlist(s)");

            var counter = 1;
            foreach (var kvp in PlaylistDictionary)
            {
                Console.WriteLine($"{counter}. {kvp.Key}");
                Console.WriteLine();
                counter++;
            }

            Console.WriteLine("Choose playlist to see songs, q to quit");
            var choice = Console.ReadLine();
            Console.WriteLine();

            if (string.IsNullOrWhiteSpace(choice)) goto ChoosePlaylist;


            while (!string.IsNullOrWhiteSpace(choice))
            {
                if (choice.Equals("Q") || choice.Equals("q")) break;

                if (!int.TryParse(choice, out int _))
                {
                    Console.WriteLine("Choose a number corresponding to a Playlist.");
                    Console.WriteLine();
                    goto ChoosePlaylist;
                }

                int intChoice = int.Parse(choice);
                int playlistIndex = int.Parse(choice);

                Console.WriteLine($"Music in playlist {PlaylistDictionary.ElementAt(--playlistIndex).Key}: ");

                var playlist = PlaylistDictionary.ElementAt(--intChoice);


                //PlayListModel playModel = new PlayListModel();
                //playlist.PlaylistMusics

                foreach (var kvp in PlayList.AllSongs())
                {
                    Console.WriteLine($"Artist: {kvp.ArtistName}\n Music Title: {kvp.MusicName}");
                    Console.WriteLine();
                }

                goto ChoosePlaylist;
            }

        }
    }
}
