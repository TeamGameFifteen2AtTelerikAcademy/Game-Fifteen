namespace GameFifteen.UI.Console
{
    using System;

    using GameFifteen.Logic.Common;
    using GameFifteen.Logic.Contracts;
    using GameFifteen.Logic.Games.Contracts;
    using Logic.Commands;
    using Logic;

    internal class Engine
    {
        private readonly IGame game;
        private readonly Logic.IPrinter printer;
        private readonly IReader reader;
        private readonly ICommandManager commandManager;
        private readonly ICommandContext context;

        public Engine(IGame game,  IPrinter printer, IReader reader, ICommandManager commandManager)
        {
            Validator.ValidateIsNotNull(game, "gameFifteen");
            Validator.ValidateIsNotNull(game.Scoreboard, "scoreboard");
            Validator.ValidateIsNotNull(printer, "printer");
            Validator.ValidateIsNotNull(reader, "reader");

            this.game = game;
            this.printer = printer;
            this.reader = reader;
            this.commandManager = commandManager;
            this.context = new CommandContext(this.game, this.printer);
        }

        public void Run()
        {
            // TODO: Totally refactor this old logic. Think after a good sleep which sub methods Run will call and how
            this.game.Shuffle();

            this.printer.PrintLine(Constants.WellcomeMessage);
            this.printer.PrintLine(this.game);

            this.printer.Print(Constants.EnterCommandMessage);
            string playerCommand = this.reader.ReadLine();
            Console.WriteLine("Run");
            int playerMovesCount = 0;
            while (!this.game.IsSolved)
            {
                // TODO: Command - Mariya
                this.context.SelectedTileLabel = playerCommand;
                this.commandManager.GetCommand(playerCommand).Execute(this.context);
            

                if (this.game.IsSolved)
                {
                    this.printer.PrintLine(string.Format(Constants.CongratulationsMessageFormat, playerMovesCount));

                    if (this.game.Scoreboard.IsInTopScores(playerMovesCount))
                    {
                        this.printer.Print(Constants.EnterNameMessage);
                        string name = this.reader.ReadLine();
                        this.game.Scoreboard.Add(playerMovesCount, name);
                    }

                    this.printer.Print(this.game.Scoreboard);

                    this.game.Shuffle();

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