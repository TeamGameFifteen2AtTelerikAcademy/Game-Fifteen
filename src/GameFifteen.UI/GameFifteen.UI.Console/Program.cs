namespace GameFifteen.UI.Console
{
    using GameFifteen.Logic;

    internal class Program
    {
        public static void Main()
        {
            var gameFifteen = new GameFifteen();
            var printer = new Printer();
            var reader = new Reader();

            new Engine(gameFifteen, printer, reader).Run();
        }
    }
}