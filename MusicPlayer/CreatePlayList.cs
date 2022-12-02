using static MusicPlayer.PlayList;

namespace MusicPlayer
{
    internal class CreatePlayList
    {
       

        public static Dictionary<string, PlayListModel> PlaylistDictionary = new Dictionary<string, PlayListModel>();




        public static void CreatePlaylist()
        {
            Utility.PrintColorMessage(ConsoleColor.Yellow, "Enter playlist name :");

            var playlistName = Console.ReadLine();

            Console.WriteLine();

            while (string.IsNullOrWhiteSpace(playlistName))
            {
                Utility.PrintColorMessage(ConsoleColor.Red, "Playlist name cannot be null or empty space");

                Utility.PrintColorMessage(ConsoleColor.Yellow, "Enter prefered playlist name : ");

                playlistName = Console.ReadLine();
            }


            while (PlaylistDictionary.ContainsKey(playlistName))
            {
                Utility.PrintColorMessage(ConsoleColor.Red, $"Playlist with name: {playlistName} exits. Try another!!!");

                playlistName = Console.ReadLine();
            }

            var newPlaylist = new PlayListModel
            {
                PlaylistName = playlistName,

                PlaylistMusics = SelectedPlaylistSongs()
            };

            PlaylistDictionary.Add(playlistName, newPlaylist);

            Utility.PrintColorMessage(ConsoleColor.Cyan, $"{playlistName} playlist created");

            ShowAllPlaylist();

            Console.WriteLine();

            return;


        }

        static List<Music> SelectedPlaylistSongs()
        {


            var availableSongs = PlayList.AllSongs().ToList();

            var playlist = new List<Music>();


        DataEnry:
            Utility.PrintColorMessage(ConsoleColor.Cyan, "Choose number corresponding to music you'd like to add to playlist and press Enter key to add \n" +
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
                    Utility.PrintColorMessage(ConsoleColor.Cyan, "Choose a number corresponding to music and press Enter key.");

                    Console.WriteLine();

                    goto DataEnry;
                }

                var numberChoice = int.Parse(choice);


                playlist.Add(availableSongs[numberChoice]);

                Utility.PrintColorMessage(ConsoleColor.Green, "Music added");

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
                Utility.PrintColorMessage(ConsoleColor.Red, "You don't have any playlist");

                Console.WriteLine();

                return;
            }

        ChoosePlaylist:

            Utility.PrintColorMessage(ConsoleColor.Yellow, "Available playlist(s)");

            var counter = 1;

            foreach (var content in PlaylistDictionary)
            {
                Console.WriteLine($"{counter}. {content.Key}");

                Console.WriteLine();

                counter++;
            }

            Utility.PrintColorMessage(ConsoleColor.Cyan, "Choose playlist to see songs, q to quit");

            var choice = Console.ReadLine();

            Console.WriteLine();

            if (string.IsNullOrWhiteSpace(choice)) goto ChoosePlaylist;


            while (!string.IsNullOrWhiteSpace(choice))
            {
                if (choice.Equals("Q") || choice.Equals("q"))
                {
                    Console.Clear();
                    Application.Run();
                    
                }

                if (!int.TryParse(choice, out int _))
                {
                    Utility.PrintColorMessage(ConsoleColor.Yellow, "Choose a number corresponding to a Playlist.");

                    Console.WriteLine();

                    goto ChoosePlaylist;
                }

                int intChoice = int.Parse(choice);

                int playlistIndex = int.Parse(choice);

                Console.WriteLine($"Music in playlist {PlaylistDictionary.ElementAt(--playlistIndex).Key}: ");

                var playlist = PlaylistDictionary.ElementAt(--intChoice);

                foreach (var song in playlist.Value.PlaylistMusics)
                {
                    Utility.PrintColorMessage(ConsoleColor.Cyan, $"Artist: {song.ArtistName}\n Music Title: {song.MusicName}");
                    Console.WriteLine();
                }

                goto ChoosePlaylist;
            }

        }
    }
}
