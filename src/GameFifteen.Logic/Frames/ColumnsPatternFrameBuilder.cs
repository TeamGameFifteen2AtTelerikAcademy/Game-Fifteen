namespace GameFifteen.Logic.Frames
{
    using Frames.Contracts;
    using Tiles.Contracts;

    public class ColumnsPatternFrameBuilder : FrameBuilder
    {
        public ColumnsPatternFrameBuilder(TileFactory tileFactory) : base(tileFactory)
        {
        }

        public override void FillFrameWithTiles()
        {
            for (int col = 0; col < this.Frame.Cols; col++)
            {
                for (int row = 0; row < this.Frame.Rows; row++)
                {
                    this.FillTileInFrame(row, col);
                }
            }
        }
    }
}
