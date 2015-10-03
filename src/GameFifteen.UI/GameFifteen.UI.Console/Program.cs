namespace GameFifteen.UI.Console
{
    using GameFifteen.Logic;
    using GameFifteen.Logic.Movers;
    using GameFifteen.Logic.Frames;
    using GameFifteen.Logic.Games;
    using GameFifteen.Logic.Tiles;

    internal class Program
    {
        public static void Main()
        {
            var factory = new NumberTileFactory();
            var builder = new ClassicPatternFrameBuilder(factory);
            var director = new FrameDirector(builder);
            var frame = director.ConstructFrame(4, 4);

            var mover = new RowColMover();
            // TODO: GameInitializator class needs to be introduced
            var gameFifteen = new Game(frame, mover);
            var scoreboard = new Scoreboard();
            var printer = new Printer();
            var reader = new Reader();
            // TODO: Create abstract Engine class to implement the Template Method Pattern -> Run method
            new Engine(gameFifteen, scoreboard, printer, reader).Run();
        }
    }
}