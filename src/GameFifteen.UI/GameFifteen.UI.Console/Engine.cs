namespace GameFifteen.UI.Console
{
    using System;

    using Wintellect.PowerCollections;

    using GameFifteen.Logic;
    using GameFifteen.Logic.Common;

    internal class Engine
    {
        //TODO: Create IGame interface
        private readonly GameFifteen gameFifteen;
        private readonly IPrinter printer;
        private readonly IReader reader;

        public Engine(GameFifteen gameFifteen, IPrinter printer, IReader reader)
        {
            Validator.ValidateIsNotNull(gameFifteen, "gameFifteen");
            Validator.ValidateIsNotNull(printer, "printer");
            Validator.ValidateIsNotNull(reader, "reader");

            this.gameFifteen = gameFifteen;
            this.printer = printer;
            this.reader = reader;
        }

        public void Run()
        {
            this.gameFifteen.ShuffleMatrix();

            this.printer.PrintLine(Constants.WellcomeMessage);
            this.printer.PrintLine(this.gameFifteen.ToString());

            this.printer.Print(Constants.EnterCommandMessage);
            string inputString = this.reader.ReadLine();

            // TODO: extract class Scoreboard
            OrderedMultiDictionary<int, string> scoreboard = new OrderedMultiDictionary<int, string>(true);
            int moves = 0;

            while (inputString.CompareTo("exit") != 0)
            {
                // TODO: inline ExecuteComand method here and refactor it
                //this.gameFifteen.ExecuteComand(inputString, ref moves, scoreboard);


                switch (inputString)
                {
                    case "restart":
                        moves = 0;
                        this.gameFifteen.ShuffleMatrix();
                        this.gameFifteen.PrintWelcome();
                        Console.WriteLine(this.gameFifteen);
                        break;

                    case "top":
                        Console.Write(this.gameFifteen.PrintScoreboard(scoreboard));
                        Console.WriteLine(this.gameFifteen);
                        break;

                    default:
                        int number = 0;
                        bool isNumber = int.TryParse(inputString, out number);

                        if (!isNumber)
                        {
                            Console.WriteLine("Invalid comand!");
                            break;
                        }

                        if (number < 16 && number > 0)
                        {
                            int newRow = 0;
                            int newCol = 0;
                            int[] dirRow = new int[4] { -1, 0, 1, 0 };
                            int[] dirCol = new int[4] { 0, 1, 0, -1 };

                            for (int i = 0; i < 4; i++)
                            {
                                newRow = this.gameFifteen.emptyRow + dirRow[i];
                                newCol = this.gameFifteen.emptyCol + dirCol[i];

                                if (this.gameFifteen.IsOutOfMatrix(newRow, newCol))
                                {
                                    if (i == 3)
                                    {
                                        Console.WriteLine("Invalid move");
                                    }

                                    continue;
                                }

                                if (this.gameFifteen.currentMatrix[newRow, newCol] == number)
                                {
                                    this.gameFifteen.MoveEmptyCell(newRow, newCol);
                                    moves++;
                                    Console.WriteLine(this.gameFifteen);
                                    break;
                                }

                                if (i == 3)
                                {
                                    Console.WriteLine("Invalid move");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid move");
                            break;
                        }

                        break;
                }


                if (this.gameFifteen.IsEqualMatrix())
                {
                    this.printer.PrintLine(string.Format(Constants.CongratulationsMessageFormat, moves));
                    this.gameFifteen.GameWon(moves, scoreboard);

                    // TODO: this scoreboard string will come from another class, not gameFifteen
                    this.printer.Print(this.gameFifteen.PrintScoreboard(scoreboard));

                    this.gameFifteen.ShuffleMatrix();

                    this.printer.PrintLine(Constants.WellcomeMessage);

                    this.printer.PrintLine(this.gameFifteen.ToString());

                    moves = 0;
                }

                this.printer.Print(Constants.EnterCommandMessage);
                inputString = this.reader.ReadLine();
            }

            this.printer.PrintLine(Constants.GoodbyeMessage);
        }
    }
}