using System.Numerics;

namespace MusicPlayer
{
    public static class Utility
    {



        private static string _title = @"
            .__   __.      ___      .______     _______.___________. _______ .______      .______
            |  \ |  |     /   \     |   _  \   /       |           ||   ____||   _  \     |   _  \
            |   \|  |    /  ^  \    |  |_)  | |   (----`---|  |----`|  |__   |  |_)  |    |  |_)  |
            |  . `  |   /  /_\  \   |   ___/   \   \       |  |     |   __|  |      /     |      /
            |  |\   |  /  _____  \  |  |   .----)   |      |  |     |  |____ |  |\  \----.|  |\  \----.
            |__| \__| /__/     \__\ | _|   |_______/       |__|     |_______|| _| `._____|| _| `._____|  tm

            ";
        



        public static void MainMenu()
        {

            PrintColorMessage(ConsoleColor.Cyan, _title);


        }

        public static void NextMenu()
        {
            PrintColorMessage(ConsoleColor.Yellow, "Controls: " +
               "\n1.See all current songs" +
               "\n2.Add new song" +
               "\n3.Edit song" +
               "\n4.Delete song" +
               "\n5.Create playlist" +
               "\n6.View playlist" +
               "\n7.Shuffle" +
               "\n8.Quit player");

        }

        public static void OptionSelectMenu()
        {

            PrintColorMessage(ConsoleColor.Cyan, _title);
            NextMenu();
            

        }

        public static void printDotAnimation(int timer = 10)
        {
            for (var x = 0; x < timer; x++)
            {
                //PrintColorMessage(ConsoleColor.Yellow, ".");
                Console.Write("...");

                Thread.Sleep(100);
            }
            Console.WriteLine();
        }

        // print color message
        public static void PrintColorMessage(ConsoleColor color, string message)
        {

            Console.ForegroundColor = color;

            //tell user its not a number
            Console.WriteLine(message);

            //reset text color
            Console.ResetColor();
        }
    }
}