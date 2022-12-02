namespace MusicPlayer
{
    internal static class PlayList
    {
        
        private static int _userChoice;

        public static int _id;

        private static int _delId;
      
        






        public static List<Music> _musicList = new List<Music>
        {
               new Music{Id = 1, MusicName="Oh Emmanuel", ArtistName="Gostime Okorie" },

                new Music{Id = 2, MusicName= "Great is Thy Faithfulness", ArtistName="Blessing Anyanaele" },

                new Music{Id = 3, MusicName = "We wait on You",  ArtistName = "Steven Crown" },

                new Music{Id = 4, MusicName = "In obedience to Christ", ArtistName = "Chris Delvan" },

                new Music{Id = 5,  MusicName = "This is the way ",  ArtistName ="Isreal Oyedale" },

                new Music{Id = 6,  MusicName = "Olowun kpokporo ",  ArtistName ="Alex Ogubuike" }

        };


        public static List<Music> AllSongs()
        {
            return _musicList;
        }
        

        



        public static void SeeAllSongs()
        {
            //using lamda expressions
            AllSongs().ForEach(music => Utility.PrintColorMessage(ConsoleColor.Cyan, $"{music.Id}  {music.MusicName} By {music.ArtistName}"));

        }

        public static List<Music> ShuffleMusic()
        {
            var shuffleList = AllSongs().ToList();

            var musicCount = AllSongs().Count;

            var randomNumGen = new Random();

            //int n = list.Count;
            while (musicCount > 1)
            {
                musicCount--;

                int randNumber = randomNumGen.Next(musicCount + 1);

                var music = shuffleList[randNumber];

                shuffleList[randNumber] = shuffleList[musicCount];

                shuffleList[musicCount] = music;

            }
             
             Utility.printDotAnimation(15);
             

            return shuffleList;
        }


        static void PrintMusic(List<Music> musicList)
        {
            if (musicList == null) return;

            foreach (var music in musicList)
            {
                

                Utility.PrintColorMessage(ConsoleColor.Cyan, $"{music.Id}  {music.MusicName} By {music.ArtistName}");

                Console.WriteLine();
            }

            Console.WriteLine();
        }


        public static void AddSongs()
        {

                Console.Clear();

                Utility.MainMenu();

            Utility.PrintColorMessage(ConsoleColor.Cyan, "Enter the new song name");

                string newSongName = Console.ReadLine().Trim();

            Utility.PrintColorMessage(ConsoleColor.Cyan, "Enter Artist Name");

                string artistName = Console.ReadLine().Trim();

                foreach (Music song in AllSongs())
                {
                    if (song.Id != _id)
                    {
                        _id += 1;
                    }
                }


                AllSongs().Add(new Music() { Id = _id + 1, MusicName = newSongName, ArtistName = artistName });

                SeeAllSongs();

                Console.WriteLine("Press any key to return to main menu");

                Console.ReadKey();

                Console.Clear();

                Utility.OptionSelectMenu();
               

        }


      


        public static void DeleteMusic()
        {
            Utility.PrintColorMessage(ConsoleColor.Red, "Danger Zone, \nPlease enter the Id  of the song you want to delete");

            _delId = int.Parse(Console.ReadLine());


            var deleteresult = AllSongs().First(p => p.Id == _delId);

            AllSongs().Remove(deleteresult);

            Utility.PrintColorMessage(ConsoleColor.Green, "Song deleting successfully");

            Utility.printDotAnimation(15);

            SeeAllSongs();

            Utility.printDotAnimation(15);

            Console.WriteLine();

            Utility.NextMenu();
          


        }

        public static void EditMusic()
        {
            Utility.MainMenu();

            Console.WriteLine("Enter the Id of the music you want to Edit");

            int editId = int.Parse(Console.ReadLine());


            var result = AllSongs().SingleOrDefault(p => p.Id == editId); //lamda expression

            if (result !=null)
                {
                    Utility.PrintColorMessage(ConsoleColor.Cyan, "Enter the new song name that updates the former");

                    string updateSongName = Console.ReadLine().Trim();

                    Utility.PrintColorMessage(ConsoleColor.Cyan, "Enter the new Artist Name which updates the former");

                    string updateartistName = Console.ReadLine().Trim();

                    result.ArtistName = updateSongName;

                    result.ArtistName = updateartistName;

                    SeeAllSongs();
                }
                

              
            

        }

        public static void ExitProgram()
        {
            Utility.PrintColorMessage(ConsoleColor.Green, "Are you sure you want to exit? Type 1 to exit or 2 to continue");

            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Environment.Exit(0);
                    break;
                case 2:
                    Console.Clear();

                    Utility.OptionSelectMenu();
                    

                    break;


            }
          
        }






        public class Application
        {
            public static void Run()
            {


                Utility.OptionSelectMenu();

            start: Console.WriteLine("Please enter your choice from list above");
                _userChoice = int.Parse(Console.ReadLine());
                switch (_userChoice)
                {
                    case 1:
                        Console.Clear();

                        Utility.MainMenu();

                        SeeAllSongs();

                        Utility.printDotAnimation(15);

                        Utility.NextMenu();

                        goto start;
                        
                        break;
                    case 2:
                        Console.Clear();

                        AddSongs();

                        Utility.printDotAnimation(15);

                        goto start;
              
                        break;
                    case 3:

                        Console.Clear();

                        EditMusic();

                        break;
                    case 4:

                        DeleteMusic();

                        goto start;

                        break;
                    case 5:

                        CreatePlayList.CreatePlaylist();

                        break;
                    case 6:
                        CreatePlayList.CreatePlaylist();
                        break;
                    case 7:
                        Console.Clear();

                        Utility.MainMenu();

                        PrintMusic(ShuffleMusic());

                        Utility.NextMenu();

                        goto start;

                        break;
                    case 8:
                        ExitProgram();

                        goto start;

                        break;
                    default:
                        Console.WriteLine("Please enter a valid input");

                        goto start;

                        break;

                }
























            }
        }
    }
}

