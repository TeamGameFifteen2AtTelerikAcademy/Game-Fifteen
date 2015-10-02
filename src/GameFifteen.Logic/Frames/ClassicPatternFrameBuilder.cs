namespace GameFifteen.Logic.Frames
{
    using Frames.Contracts;
    using Tiles.Contracts;

    public class ClassicPatternFrameBuilder : FrameBuilder
    {
        public ClassicPatternFrameBuilder(TileFactory tileFactory) : base(tileFactory)
        {
        }

        public override void FillFrameWithTiles()
        {
            for (int row = 0; row < this.Frame.Rows; row++)
            {
                for (int col = 0; col < this.Frame.Cols; col++)
                {
                    this.FillTileInFrame(row, col);
                }
            }
        }
    }
}
