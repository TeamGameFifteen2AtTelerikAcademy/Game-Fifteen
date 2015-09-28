namespace GameFifteen.UI.Console
{
    using System;
    using Wintellect.PowerCollections;
    using GameFifteen.Logic;
    internal class Engine
    {
        public void Run()
        {
            var gameFifteen = new GameFifteen();

            gameFifteen.ShuffleMatrix();
            gameFifteen.PrintWelcome();
            gameFifteen.PrintMatrix();

            int moves = 0;
            Console.Write("Enter a number to move: ");
            string inputString = Console.ReadLine();

            // TODO: extract class Scoreboard
            OrderedMultiDictionary<int, string> scoreboard = new OrderedMultiDictionary<int, string>(true);
            while (inputString.CompareTo("exit") != 0)
            {
                gameFifteen.ExecuteComand(inputString, ref moves, scoreboard);
                if (gameFifteen.IsEqualMatrix())
                {
                    gameFifteen.GameWon(moves, scoreboard);
                    gameFifteen.PrintScoreboard(scoreboard);
                    gameFifteen.ShuffleMatrix();
                    gameFifteen.PrintWelcome();
                    gameFifteen.PrintMatrix();
                    moves = 0;
                }

                Console.Write("Enter a number to move: ");
                inputString = Console.ReadLine();
            }

            Console.WriteLine("Good bye!");
        }
    }
}