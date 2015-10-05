﻿namespace GameFifteen.UI.Console
{
    using Logic.Memento;
    using GameFifteen.Logic.Scoreboards;

    internal class Program
    {
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