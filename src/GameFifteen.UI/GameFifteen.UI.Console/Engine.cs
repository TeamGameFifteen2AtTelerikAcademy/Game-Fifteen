namespace GameFifteen.UI.Console
{
    using System;

    using GameFifteen.Logic;
    using GameFifteen.Logic.Common;
    using GameFifteen.Logic.Games.Contracts;
    using GameFifteen.Logic.Scoreboards.Contracts;

    internal class Engine : EngineTemplate
    {
        private readonly IGame game;
        private readonly IScoreboard scoreboard;
        private readonly IPrinter printer;
        private readonly IReader reader;
        //private readonly ICommandManager commandManager;
        //private readonly ICommandContext context;

        public Engine(IGame game, IScoreboard scoreboard, IPrinter printer, IReader reader)
        {
            Validator.ValidateIsNotNull(game, "gameFifteen");
            Validator.ValidateIsNotNull(scoreboard, "scoreboard");
            Validator.ValidateIsNotNull(printer, "printer");
            Validator.ValidateIsNotNull(reader, "reader");

            this.game = game;
            this.scoreboard = scoreboard;
            this.printer = printer;
            this.reader = reader;
            //this.commandManager = commandManager;
            //this.context = new CommandContext(this.game, this.printer);
        }

        //public void Run()
        //{
        //    // TODO: Totally refactor this old logic. Think after a good sleep which sub methods Run will call and how
        //    this.game.Shuffle();

        //    this.printer.PrintLine(Constants.WellcomeMessage);
        //    this.printer.PrintLine(this.game);

        //    this.printer.Print(Constants.EnterCommandMessage);
        //    string playerCommand = this.reader.ReadLine();
        //    Console.WriteLine("Run");
        //    int playerMovesCount = 0;
        //    while (!this.game.IsSolved)
        //    {
        //        // TODO: Command - Mariya
        //        this.context.SelectedTileLabel = playerCommand;
        //        this.commandManager.GetCommand(playerCommand).Execute(this.context);


        //        if (this.game.IsSolved)
        //        {
        //            this.printer.PrintLine(string.Format(Constants.CongratulationsMessageFormat, playerMovesCount));

        //            if (this.game.Scoreboard.IsInTopScores(playerMovesCount))
        //            {
        //                this.printer.Print(Constants.EnterNameMessage);
        //                string name = this.reader.ReadLine();
        //                this.game.Scoreboard.Add(playerMovesCount, name);
        //            }

        //            this.printer.Print(this.game.Scoreboard);

        //            this.game.Shuffle();

        //            this.printer.PrintLine(Constants.WellcomeMessage);

        //            this.printer.PrintLine(this.game.ToString());

        //            playerMovesCount = 0;
        //        }

        //        this.printer.Print(Constants.EnterCommandMessage);
        //        playerCommand = this.reader.ReadLine();
        //    }

        //    this.printer.PrintLine(Constants.GoodbyeMessage);
        //}

        protected override void Welcome()
        {
            this.printer.PrintLine(Constants.WellcomeMessage);
        }

        protected override void Play()
        {
            this.game.Shuffle();
            int currentMovesCount = 0;
            while (true)
            {
                this.printer.PrintLine(this.game);

                if (this.game.IsSolved)
                {
                    this.printer.PrintLine(string.Format(Constants.CongratulationsMessageFormat, currentMovesCount));

                    if (this.scoreboard.IsInTopScores(currentMovesCount))
                    {
                        this.printer.Print(Constants.EnterNameMessage);
                        string userName = this.reader.ReadLine();
                        this.scoreboard.Add(currentMovesCount, userName);
                        this.printer.Print(this.scoreboard);
                    }

                    this.game.Shuffle();
                    currentMovesCount = 0;
                    continue;
                }

                this.printer.Print(Constants.EnterCommandMessage);

                string userInput = this.reader.ReadLine();
                if (Enum.IsDefined(typeof(UserCommands), userInput))
                {
                    var userCommand = (UserCommands)Enum.Parse(typeof(UserCommands), userInput);
                    switch (userCommand)
                    {
                        case UserCommands.Top:
                            this.printer.PrintLine(this.scoreboard);
                            break;
                        case UserCommands.Restart:
                            this.game.Shuffle();
                            currentMovesCount = 0;
                            break;
                        case UserCommands.Exit:
                            return;
                    }
                }
                else if (this.game.Move(userInput))
                {
                    currentMovesCount++;
                }
                else
                {
                    this.printer.PrintLine(Constants.InvalidMoveMessage);                    
                }
            }
        }

        protected override void Goodbye()
        {
            this.printer.PrintLine(Constants.GoodbyeMessage);
        }
    }
}