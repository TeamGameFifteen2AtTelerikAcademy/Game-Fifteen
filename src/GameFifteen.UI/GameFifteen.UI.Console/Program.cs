namespace GameFifteen.UI.Console
{
    using GameFifteen.Logic;

    internal class Program
    {
        public static void Main()
        {
            var gameFifteen = new GameFifteen();
            var scoreboard = new Scoreboard();
            var printer = new Printer();
            var reader = new Reader();

            new Engine(gameFifteen, scoreboard, printer, reader).Run();
        }
    }
}