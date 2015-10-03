namespace GameFifteen.UI.Console
{
    using System;

    using GameFifteen.Logic;
    using GameFifteen.Logic.Common;
    using GameFifteen.Logic.Contracts;

    internal class Engine
    {
        //TODO: Create IGame interface
        private readonly Game game;
        //TODO: Create IScoreboard interface
        private readonly IScoreboard scoreboard;
        private readonly IPrinter printer;
        private readonly IReader reader;

        public Engine(Game game, IScoreboard scoreboard, IPrinter printer, IReader reader)
        {
            Validator.ValidateIsNotNull(game, "gameFifteen");
            Validator.ValidateIsNotNull(scoreboard, "scoreboard");
            Validator.ValidateIsNotNull(printer, "printer");
            Validator.ValidateIsNotNull(reader, "reader");

            this.game = game;
            this.scoreboard = scoreboard;
            this.printer = printer;
            this.reader = reader;
        }

        public void Run()
        {
            this.game.ShuffleMatrix();

            this.printer.PrintLine(Constants.WellcomeMessage);
            this.printer.PrintLine(this.game);

            this.printer.Print(Constants.EnterCommandMessage);
            string playerCommand = this.reader.ReadLine();

            int playerMovesCount = 0;
            while (playerCommand != "exit")
            {
                // TODO: Command - Mariya
                switch (playerCommand)
                {
                    case "restart":
                        playerMovesCount = 0;
                        this.game.ShuffleMatrix();
                        this.printer.PrintLine(Constants.WellcomeMessage);
                        this.printer.PrintLine(this.game);
                        break;

                    case "top":
                        this.printer.Print(this.scoreboard);
                        this.printer.PrintLine(this.game);
                        break;

                    default:
                        try
                        {
                            // TODO: make Move throw when nothing to move.
                            this.game.Move(playerCommand);
                        }
                        catch (Exception)
                        {
                        }
                        //int number = 0;
                        //bool isNumber = int.TryParse(inputString, out number);

                        //if (!isNumber)
                        //{
                        //    this.printer.PrintLine(Constants.InvalidCommandMessage);
                        //    break;
                        //}

                        //// TODO: number depends on the size of the frame!
                        //if (number < this.gameFifteen.currentMatrix.GetLength(0) * this.gameFifteen.currentMatrix.GetLength(1)
                        //    && number > 0)
                        //{
                        //    int newRow = 0;
                        //    int newCol = 0;
                        //    int[] dirRow = new int[4] { -1, 0, 1, 0 };
                        //    int[] dirCol = new int[4] { 0, 1, 0, -1 };

                        //    for (int i = 0; i < 4; i++)
                        //    {
                        //        newRow = this.gameFifteen.emptyRow + dirRow[i];
                        //        newCol = this.gameFifteen.emptyCol + dirCol[i];

                        //        if (this.gameFifteen.IsOutOfMatrix(newRow, newCol))
                        //        {
                        //            if (i == this.gameFifteen.emptyRow)
                        //            {
                        //                this.printer.PrintLine(Constants.InvalidMoveMessage);
                        //            }

                        //            continue;
                        //        }

                        //        if (this.gameFifteen.currentMatrix[newRow, newCol].Label == number.ToString())
                        //        {
                        //            this.gameFifteen.MoveEmptyCell(newRow, newCol);
                        //            moves++;
                        //            this.printer.PrintLine(this.gameFifteen);
                        //            break;
                        //        }

                        //        if (i == this.gameFifteen.emptyRow)
                        //        {
                        //            this.printer.PrintLine(Constants.InvalidMoveMessage);
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    this.printer.PrintLine(Constants.InvalidMoveMessage);
                        //    break;
                        //}

                        break;
                }


                if (this.game.IsSolved)
                {
                    this.printer.PrintLine(string.Format(Constants.CongratulationsMessageFormat, playerMovesCount));

                    if (this.scoreboard.IsInTopScores(playerMovesCount))
                    {
                        this.printer.Print(Constants.EnterNameMessage);
                        string name = this.reader.ReadLine();
                        this.scoreboard.Add(playerMovesCount, name);
                    }

                    this.printer.Print(this.scoreboard);

                    this.game.ShuffleMatrix();

                    this.printer.PrintLine(Constants.WellcomeMessage);

                    this.printer.PrintLine(this.game.ToString());

                    playerMovesCount = 0;
                }

                this.printer.Print(Constants.EnterCommandMessage);
                playerCommand = this.reader.ReadLine();
            }

            this.printer.PrintLine(Constants.GoodbyeMessage);
        }
    }
}