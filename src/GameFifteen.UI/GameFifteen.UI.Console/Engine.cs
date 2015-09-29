namespace GameFifteen.UI.Console
{
    using GameFifteen.Logic;
    using GameFifteen.Logic.Common;

    internal class Engine
    {
        //TODO: Create IGame interface
        private readonly GameFifteen gameFifteen;
        //TODO: Create IScoreboard interface
        private readonly Scoreboard scoreboard;
        private readonly IPrinter printer;
        private readonly IReader reader;

        public Engine(GameFifteen gameFifteen, Scoreboard scoreboard, IPrinter printer, IReader reader)
        {
            Validator.ValidateIsNotNull(gameFifteen, "gameFifteen");
            Validator.ValidateIsNotNull(scoreboard, "scoreboard");
            Validator.ValidateIsNotNull(printer, "printer");
            Validator.ValidateIsNotNull(reader, "reader");

            this.gameFifteen = gameFifteen;
            this.scoreboard = scoreboard;
            this.printer = printer;
            this.reader = reader;
        }

        public void Run()
        {
            this.gameFifteen.ShuffleMatrix();

            this.printer.PrintLine(Constants.WellcomeMessage);
            this.printer.PrintLine(this.gameFifteen);

            this.printer.Print(Constants.EnterCommandMessage);
            string inputString = this.reader.ReadLine();

            int moves = 0;
            while (inputString.CompareTo("exit") != 0)
            {
                switch (inputString)
                {
                    case "restart":
                        moves = 0;
                        this.gameFifteen.ShuffleMatrix();
                        this.printer.PrintLine(Constants.WellcomeMessage);
                        this.printer.PrintLine(this.gameFifteen.ToString());
                        break;

                    case "top":
                        this.printer.Print(this.scoreboard);
                        this.printer.PrintLine(this.gameFifteen);
                        break;

                    default:
                        int number = 0;
                        bool isNumber = int.TryParse(inputString, out number);

                        if (!isNumber)
                        {
                            this.printer.PrintLine(Constants.InvalidCommandMessage);
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
                                        this.printer.PrintLine(Constants.InvalidMoveMessage);
                                    }

                                    continue;
                                }

                                if (this.gameFifteen.currentMatrix[newRow, newCol] == number)
                                {
                                    this.gameFifteen.MoveEmptyCell(newRow, newCol);
                                    moves++;
                                    this.printer.PrintLine(this.gameFifteen);
                                    break;
                                }

                                if (i == 3)
                                {
                                    this.printer.PrintLine(Constants.InvalidMoveMessage);
                                }
                            }
                        }
                        else
                        {
                            this.printer.PrintLine(Constants.InvalidMoveMessage);
                            break;
                        }

                        break;
                }


                if (this.gameFifteen.IsEqualMatrix())
                {
                    this.printer.PrintLine(string.Format(Constants.CongratulationsMessageFormat, moves));
                    //this.gameFifteen.GameWon(moves, scoreboard);


                    if (this.scoreboard.scoreboard.Count == 5)
                    {
                        if (this.scoreboard.IsGoesOnBoard(moves))
                        {
                            this.scoreboard.RemoveLastScore();

                            this.printer.Print(Constants.EnterNameMessage);
                            string name = this.reader.ReadLine();
                            this.scoreboard.scoreboard.Add(moves, name);
                        }
                    }
                    else
                    {
                        this.printer.Print(Constants.EnterNameMessage);
                        string name = this.reader.ReadLine();
                        this.scoreboard.scoreboard.Add(moves, name);
                    }

                    this.printer.Print(this.scoreboard);

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