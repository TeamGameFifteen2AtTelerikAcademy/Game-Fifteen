namespace GameFifteen.UI.Console
{
    using Wintellect.PowerCollections;

    using GameFifteen.Logic;
    using GameFifteen.Logic.Common;

    internal class Engine
    {
        private readonly IPrinter printer;
        private readonly IReader reader;

        public Engine(IPrinter printer, IReader reader)
        {
            Validator.ValidateIsNotNull(printer, "printer");
            Validator.ValidateIsNotNull(reader, "reader");

            this.printer = printer;
            this.reader = reader;
        }

        public void Run()
        {
            // TODO: Make gameFifteen private field of type some interface
            var gameFifteen = new GameFifteen();

            gameFifteen.ShuffleMatrix();

            this.printer.PrintLine(Constants.WellcomeMessage);

            this.printer.PrintLine(gameFifteen.ToString());

            this.printer.Print(Constants.EnterCommandMessage);
            string inputString = this.reader.ReadLine();

            // TODO: extract class Scoreboard
            OrderedMultiDictionary<int, string> scoreboard = new OrderedMultiDictionary<int, string>(true);
            int moves = 0;
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

                this.printer.Print(Constants.EnterCommandMessage);
                inputString = this.reader.ReadLine();
            }

            this.printer.PrintLine(Constants.GoodbyeMessage);
        }
    }
}