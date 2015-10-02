namespace GameFifteen.UI.Console
{
    using GameFifteen.Logic;
    using GameFifteen.Logic.Movers;
    using GameFifteen.Logic.Frames;
    using GameFifteen.Logic.Tiles;

    internal class Program
    {
        public static void Main()
        {
            var factory = new LetterTileFactory ();
            var builder = new ClassicPatternFrameBuilder(factory);
            var director = new FrameDirector(builder);
            var frame = director.ConstructFrame(8, 5);

            var mover = new RowColMover();

            var gameFifteen = new Game(frame, mover);
            var scoreboard = new Scoreboard();
            var printer = new Printer();
            var reader = new Reader();

            new Engine(gameFifteen, scoreboard, printer, reader).Run();
        }
    }
}