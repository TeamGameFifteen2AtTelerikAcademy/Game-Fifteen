// <copyright file="ColumnsPatternFrameBuilder.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// ColumnsPatternFrameBuilder class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Frames
{
    using Frames.Contracts;
    using Tiles.Contracts;

    /// <summary>
    /// The class is used to build frames first columns then rows.
    /// </summary>
    public class ColumnsPatternFrameBuilder : FrameBuilder
    {
        /// <summary>
        /// Initializes a new instance of the ColumnsPatternFrameBuilder class.
        /// </summary>
        /// <param name="tileFactory">TileFactory parameter.</param>
        public ColumnsPatternFrameBuilder(TileFactory tileFactory) : base(tileFactory)
        {
        }

        /// <summary>
        /// Method fill frame with tiles column pattern.
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
