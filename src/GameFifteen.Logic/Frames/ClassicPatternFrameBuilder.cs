// <copyright file="ClassicPatternFrameBuilder.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// ClassicPatternFrameBuilder class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Frames
{
    using Frames.Contracts;
    using Tiles.Contracts;

    /// <summary>
    /// The class is used to build frames first rows then columns.
    /// </summary>
    public class ClassicPatternFrameBuilder : FrameBuilder
    {
        /// <summary>
        /// Initializes a new instance of the ClassicPatternFrameBuilder class.
        /// </summary>
        /// <param name="tileFactory">TileFactory parameter.</param>
        public ClassicPatternFrameBuilder(TileFactory tileFactory) : base(tileFactory)
        {
        }

        /// <summary>
        /// Method fill frame with tiles classic pattern.
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
