// <copyright file="Engine.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Engine class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.Console
{
    using System.Globalization;

    using GameFifteen.Logic.Common;
    using GameFifteen.Logic.Games.Contracts;
    using GameFifteen.Logic.Scoreboards.Contracts;
    using Logic.Commands;
    using Logic.Memento;

    /// <summary>
    /// Engine class - holds the magic.
    /// </summary>
    internal class Engine : EngineTemplate
    {
        /// <summary>
        /// Holds Engine's IGame.
        /// </summary>
        private readonly IGame game;

        /// <summary>
        /// Holds Engine's IScoreboard.
        /// </summary>
        private readonly IScoreboard scoreboard;

        /// <summary>
        /// Holds Engine's IPrinter.
        /// </summary>
        private readonly IPrinter printer;

        /// <summary>
        /// Holds Engine's IReader.
        /// </summary>
        private readonly IReader reader;

        /// <summary>
        /// Holds Engine's ICommandManager.
        /// </summary>
        private readonly ICommandManager commandManager;

        /// <summary>
        /// Holds Engine's ICommandContext.
        /// </summary>
        private readonly ICommandContext context;

        /// <summary>
        /// Holds Engine's IMemento.
        /// </summary>
        private readonly IMemento boardHistory;

        /// <summary>
        /// Initializes a new instance of the Engine class.
        /// </summary>
        /// <param name="game">Engine's IGame.</param>
        /// <param name="scoreboard">Engine's IScoreboard.</param>
        /// <param name="printer">Engine's IPrinter.</param>
        /// <param name="reader">Engine's IReader.</param>
        /// <param name="commandManager">Engine's ICommandManager.</param>
        /// <param name="boardHistory">Engine's IMemento.</param>
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

        /// <summary>
        /// The method prints welcome calls printer to print welcome message.
        /// </summary>
        protected override void Welcome()
        {
            this.printer.PrintLine(Constants.WellcomeMessage);
        }

        /// <summary>
        /// The method starts the game to play.
        /// </summary>
        protected override void Play()
        {
            this.game.Shuffle();
            this.printer.ClearBoard();

            while (!this.context.IsGameOver)
            {
                if (this.game.IsSolved)
                {
                    this.GameOver(this.context.Moves);
                    this.commandManager.GetCommand(UserCommands.Restart).Execute(this.context);
                }

                this.ExecuteStep();                
            }
        }

        /// <summary>
        /// The method calls printer to say goodbye.
        /// </summary>
        protected override void Goodbye()
        {
            this.printer.PrintLine(Constants.GoodbyeMessage);
        }

        /// <summary>
        /// The method executes game step.
        /// </summary>
        private void ExecuteStep()
        {
            this.printer.SetCursorTopBoard();
            this.printer.PrintLine(this.game.Frame);
            this.printer.ClearLine();
            this.printer.Print(Constants.EnterCommandMessage);

            string userInput = this.reader.ReadLine();

            var userCommandAndTarget = this.reader.ParseInput(userInput);
            var userCommand = userCommandAndTarget[0];
            var userTarget = userCommandAndTarget[1];

            // Capitalize the first letter to meet restrictions from the enum...
        
            this.context.SelectedTileLabel = userTarget;

            this.commandManager.GetCommand(userCommand).Execute(this.context);
            this.printer.SetCursorBottomBoard();
            this.printer.ClearMessages();
            this.printer.PrintLine(this.context.Message);
        }

        /// <summary>
        /// The method handles game over.
        /// </summary>
        /// <param name="currentMovesCount">Current moves.</param>
        private void GameOver(int currentMovesCount)
        {
            this.printer.SetCursorTopBoard();
            this.printer.PrintLine(this.game.Frame);
            this.printer.ClearLine();
            this.printer.PrintLine(string.Format(Constants.CongratulationsMessageFormat, currentMovesCount));

            if (this.scoreboard.IsInTopScores(currentMovesCount))
            {
                this.printer.Print(Constants.EnterNameMessage);
                string userName = this.reader.ReadLine();
                this.scoreboard.Add(currentMovesCount, userName);
                this.printer.Print(this.scoreboard);
            }

            this.printer.ClearBoard();
        }
    }
}