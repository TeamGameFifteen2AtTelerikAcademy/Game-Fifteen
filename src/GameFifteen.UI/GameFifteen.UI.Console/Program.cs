// <copyright file="Program.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Program class - let the fun begin.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.Console
{
    using GameFifteen.Logic.Scoreboards;
    using Logic.Memento;

    /// <summary>
    /// Program class - let the fun begin.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main method of the Console UI of the game.
        /// </summary>
        public static void Main()
        {
            var printer = new Printer();

            var reader = new Reader();

            var gameInitializator = new GameInitializator(printer, reader);

            var game = gameInitializator.Initialize();

            var scoreboard = new Scoreboard();

            var commandManager = new CommandManager();

            var boardHistory = new BoardHistory();

            EngineTemplate engine = new Engine(game, scoreboard, printer, reader, commandManager, boardHistory);

            engine.Run();
        }
    }
}