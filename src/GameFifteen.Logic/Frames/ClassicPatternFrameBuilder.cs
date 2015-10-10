namespace GameFifteen.Logic.Frames
{
    using Frames.Contracts;
    using Tiles.Contracts;

    /// <summary>
    /// The class is used to build frames first rows then columns
    /// </summary>
    public class ClassicPatternFrameBuilder : FrameBuilder
    {
        public ClassicPatternFrameBuilder(TileFactory tileFactory) : base(tileFactory)
        {
        }

        /// <summary>
        /// Method fill frame with tiles classic pattern
        /// </summary>
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
