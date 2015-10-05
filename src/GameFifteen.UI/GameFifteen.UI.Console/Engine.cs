namespace GameFifteen.UI.Console
{
    using System;

    using GameFifteen.Logic;
    using GameFifteen.Logic.Common;
    using GameFifteen.Logic.Games.Contracts;
    using GameFifteen.Logic.Scoreboards.Contracts;
    using Logic.Commands;
    using System.Globalization;
    using Logic.Memento;

    internal class Engine : EngineTemplate
    {
        private readonly IGame game;
        private readonly IScoreboard scoreboard;
        private readonly IPrinter printer;
        private readonly IReader reader;
        private readonly ICommandManager commandManager;
        private readonly ICommandContext context;
        private readonly IMemento boardHistory;

        public Engine(IGame game, IScoreboard scoreboard, IPrinter printer, IReader reader, ICommandManager commandManager, IMemento boardHistory)
        {
            Validator.ValidateIsNotNull(game, "gameFifteen");
            Validator.ValidateIsNotNull(scoreboard, "scoreboard");
            Validator.ValidateIsNotNull(printer, "printer");
            Validator.ValidateIsNotNull(reader, "reader");

            this.game = game;
            this.scoreboard = scoreboard;
            this.printer = printer;
            this.reader = reader;
            this.commandManager = commandManager;
            this.context = new CommandContext(this.game, this.scoreboard, boardHistory);           
           
        }

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
                this.printer.PrintLine(this.game.Frame);

                if (this.game.IsSolved)
                {
                    GameOver(currentMovesCount);
                    Play(); // This recursion will cause a bug - the player will have to execute exit command multiple times - for each call.
                }
                
                this.printer.Print(Constants.EnterCommandMessage);

                string userInput = this.reader.ReadLine();
                // Capitalize the first letter to meet restrictions from the enum...
                userInput = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(userInput);
                this.context.SelectedTileLabel = userInput;

                // If we want to catch the exeption in default state in CommandManager, 
                // we need to change the command for moving e.g. "move 14", "move ab" 
                // and split parameters. 
                try
                {
                    this.commandManager.GetCommand(userInput).Execute(this.context);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    printer.PrintLine(Constants.InvalidCommandMessage);
                }

                this.printer.PrintLine(this.context.Message);
            }
        }

        private void GameOver(int currentMovesCount)
        {
            this.printer.PrintLine(string.Format(Constants.CongratulationsMessageFormat, currentMovesCount));

            if (this.scoreboard.IsInTopScores(currentMovesCount))
            {
                this.printer.Print(Constants.EnterNameMessage);
                string userName = this.reader.ReadLine();
                this.scoreboard.Add(currentMovesCount, userName);
                this.printer.Print(this.scoreboard);
            }
        }

        protected override void Goodbye()
        {
            this.printer.PrintLine(Constants.GoodbyeMessage);
        }
    }
}