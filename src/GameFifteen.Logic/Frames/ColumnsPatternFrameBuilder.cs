namespace GameFifteen.Logic.Frames
{
    using Frames.Contracts;
    using Tiles.Contracts;

    /// <summary>
    /// The class is used to build frames first columns then rows
    /// </summary>
    public class ColumnsPatternFrameBuilder : FrameBuilder
    {
        public ColumnsPatternFrameBuilder(TileFactory tileFactory) : base(tileFactory)
        {
        }

        /// <summary>
        /// Method fill frame with tiles column pattern
        /// </summary>
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
