namespace GameFifteen.UI.Console
{
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

            EngineTemplate engine = new Engine(game, scoreboard, printer, reader, commandManager);

            engine.Run();
        }
    }
}