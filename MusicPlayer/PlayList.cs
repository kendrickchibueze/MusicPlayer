using System.Diagnostics.Metrics;

namespace MusicPlayer
{
    internal static class PlayList
    {
        
        private static int _userChoice;

        public static int _id;

        private static double _delId;

        private static bool _session;

        

        private static bool _success;








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
            try
            {
                while (!_session)
                {
                    double _value;

                Start: Utility.PrintColorMessage(ConsoleColor.Cyan, "Enter the new song name");

                    string newSongName = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(newSongName))
                    {
                        Utility.PrintColorMessage(ConsoleColor.Red, "The new song name is required");

                        goto Start;
                    }
                   _success = double.TryParse(newSongName, out _value);

                    if (_success)
                    {
                        Utility.PrintColorMessage(ConsoleColor.Red, "cannot use an integer");

                        goto Start;
                    }

                    StartTwo:  Utility.PrintColorMessage(ConsoleColor.Cyan, "Enter Artist Name");

                    string artistName = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(artistName))
                    {
                        Utility.PrintColorMessage(ConsoleColor.Red, "The new artist name is required");

                        goto StartTwo;
                    }

                    
                     _success = double.TryParse(artistName, out _value);

                    if (_success)
                    {
                        Utility.PrintColorMessage(ConsoleColor.Red, "cannot use an integer");

                        goto StartTwo;
                    }

                    foreach (Music song in AllSongs())
                    {
                        if (song.Id != _id)
                        {
                            _id += 1;
                        }
                    }


                    AllSongs().Add(new Music() { Id = _id + 1, MusicName = newSongName, ArtistName = artistName });


                    SeeAllSongs();

                    Utility.PrintColorMessage(ConsoleColor.Yellow, "Press any key to return to main menu");

                    Console.ReadKey();

                    Console.Clear();

                    Utility.OptionSelectMenu();
                    break;
                }

            }
            catch(FormatException)
            {
                Utility.PrintColorMessage(ConsoleColor.Red, "Input must not be an integer");

            }catch(ArgumentException)
            {
                Utility.PrintColorMessage(ConsoleColor.Red, "Input must not be an integer");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }

           
               

        }


      


        public static void DeleteMusic()
        {
            Utility.PrintColorMessage(ConsoleColor.Red, "Danger Zone, \nPlease enter the Id  of the song you want to delete");
            try
            {
                _delId = double.Parse(Console.ReadLine());
               

                var deleteresult = AllSongs().First(p => p.Id == _delId);

                AllSongs().Remove(deleteresult);

                Utility.PrintColorMessage(ConsoleColor.Green, "Song deleting successfully");

                Utility.printDotAnimation(15);

                SeeAllSongs();

                Utility.printDotAnimation(15);

                Console.WriteLine();

                Utility.NextMenu();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
           

        }

        public static void EditMusic()
        {
            Utility.MainMenu();

            startOne: Utility.PrintColorMessage(ConsoleColor.Cyan, "Enter the Id of the music you want to Edit");

            try
            {
                double _value;

                double editId = double.Parse(Console.ReadLine());

            
                var result = AllSongs().SingleOrDefault(p => p.Id == editId); //lamda expression

                if (result.Id !=editId)
                {
                    Utility.PrintColorMessage(ConsoleColor.Red, "Please enter a valid Id");
                    goto startOne;

                }



                if (result != null)
                {

                    start: Utility.PrintColorMessage(ConsoleColor.Cyan, "Enter the new song name that updates the former");

                    string updateSongName = Console.ReadLine().Trim();

                    _success = double.TryParse(updateSongName, out _value);

                    if (_success)
                    {
                        Console.WriteLine("cannot use an integer");

                        goto start;
                    }

                    Utility.PrintColorMessage(ConsoleColor.Cyan, "Enter the new Artist Name which updates the former");

                    string updateartistName = Console.ReadLine().Trim();

                    _success = double.TryParse(updateartistName, out _value);

                    if (_success)
                    {
                        Console.WriteLine("cannot use an integer");

                        goto start;
                    }

                    result.MusicName = updateSongName;

                    result.ArtistName = updateartistName;

                    SeeAllSongs();
                    Utility.printDotAnimation(15);
                    Utility.NextMenu();




                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto startOne;

            }

            

              
            

        }

        public static void ExitProgram()
        {
            start:  Utility.PrintColorMessage(ConsoleColor.Green, "Are you sure you want to exit? Type 1 to exit or 2 to continue");

            try
            {

                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    case 2:
                        Console.Clear();

                        Utility.OptionSelectMenu();


                        break;
                    default:
                        Console.WriteLine("please enter a valid input");
                        ExitProgram();
                        break;
                }
            }
            catch(FormatException)
            {
                Utility.PrintColorMessage(ConsoleColor.Red, "Invalid Input");
                goto start;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto start;
            }

         
          
        }






        public class Application
        {
            public static void Run()
            {
                Utility.Welcome();
                Thread.Sleep(1200);
                Console.Clear();

                Utility.OptionSelectMenu();

            startNext: Console.WriteLine("Please enter your choice from list above");

                try
                {
                    _userChoice = int.Parse(Console.ReadLine());

                    switch (_userChoice)
                    {
                        case 1:
                            Console.Clear();

                            Utility.MainMenu();

                            SeeAllSongs();

                            Utility.printDotAnimation(15);

                            Utility.NextMenu();

                            goto startNext;

                            break;
                        case 2:
                            Console.Clear();

                            AddSongs();

                            Utility.printDotAnimation(15);

                            goto startNext;

                            break;
                        case 3:

                            Console.Clear();

                            EditMusic();
                            goto startNext;

                            break;
                        case 4:

                            DeleteMusic();

                            goto startNext;

                            break;
                        case 5:

                            CreatePlayList.CreatePlaylist();

                            break;
                        case 6:
                            CreatePlayList.ShowAllPlaylist();

                            goto startNext;

                            break;
                        case 7:
                            Console.Clear();

                            Utility.MainMenu();

                            PrintMusic(ShuffleMusic());

                            Utility.NextMenu();

                            goto startNext;

                            break;
                        case 8:

                            ExitProgram();

                            goto startNext;

                            break;
                        default:
                            Utility.PrintColorMessage(ConsoleColor.Red, "Please enter a valid input");

                            goto startNext;

                            break;

                    }


                }
                catch(FormatException)
                {
                    Utility.PrintColorMessage(ConsoleColor.Red, "Please enter a valid input");
                    goto startNext;

                }
                catch (OverflowException)
                {
                    Utility.PrintColorMessage(ConsoleColor.Red, "please enter a valid input");
                    goto startNext;
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                























            }
        }
    }
}

