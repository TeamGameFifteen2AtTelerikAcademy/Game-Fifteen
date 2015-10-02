namespace GameFifteen.UI.Console
{
    using GameFifteen.Logic;
    using Logic.Frames;
    using Logic.Tiles;

    internal class Program
    {
        public static void Main()
        {
            var factory = new LetterTileFactory();
            var builder = new ClassicPatternFrameBuilder(factory);
            var director = new FrameDirector(builder);
            var frame = director.ConstructFrame(5, 6);

            var gameFifteen = new Game(frame);
            var scoreboard = new Scoreboard();
            var printer = new Printer();
            var reader = new Reader();

            new Engine(gameFifteen, scoreboard, printer, reader).Run();
        }
    }
}