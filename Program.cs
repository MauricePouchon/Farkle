using Farkle;
using System.Threading;
using static System.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        Cup cup = new Cup();

        Title = "Farkle";

        PrintTitle();

        ConsoleKey pressedButton = Console.ReadKey().Key;
        if (pressedButton == ConsoleKey.R)
        {
            Console.Clear();
            PrintRules();
        }

        cup.ThrowDice();
        cup.DrawScreen();
    }

    private static void PrintTitle()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" ______         _    _      " +
            "\r\n|  ____|       | |  | |     " +
            "\r\n| |__ __ _ _ __| | _| | ___ " +
            "\r\n|  __/ _` | '__| |/ / |/ _ \\" +
            "\r\n| | | (_| | |  |   <| |  __/" +
            "\r\n|_|  \\__,_|_|  |_|\\_\\_|\\___|" +
            "\r\nBy Maurice Pouchon\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Press 'R' to view the rules!");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Press any other Key to start!");
    }

    private static void PrintRules()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Rules:\n");
        Console.WriteLine("- At the beginning of each turn, all the dice are thrown at once.");
        Console.WriteLine("- After each throw, one or more scoring dice must be set aside.");
        Console.WriteLine("- The player may then either end their turn and bank the score accumulated so far, \n  or continue to throw the remaining dice.");
        Console.WriteLine("- If none of the dice score in any given throw, all points for that turn are lost.");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nScoring:\n");
        Console.WriteLine("- A single 1 is worth 100 points");
        Console.WriteLine("- A single 5 is worth 50 points");
        Console.WriteLine("- Three of a kind is worth 100 points multiplied by the given number");
        Console.WriteLine("- Four or more of a kind is worth double the points of the previous 'same of a kind'");
        Console.WriteLine("- Partial straight (1-5) is worth 500 points");
        Console.WriteLine("- Partial straight (2-6) is worth 750 points");
        Console.WriteLine("- Full straight (1-6) is worth 1500 points");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nPress any key to start the game!");
        Console.ReadKey();
    }
}