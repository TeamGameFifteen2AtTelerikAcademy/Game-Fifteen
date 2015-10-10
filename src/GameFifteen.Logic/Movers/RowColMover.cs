// <copyright file="RowColMover.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Class RowColMover.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Movers
{
    using System.Collections.Generic;

    using GameFifteen.Logic.Frames.Contracts;
    using GameFifteen.Logic.Movers.Contracts;

    /// <summary>
    /// The class represents the model of the RowColMover.
    /// </summary>
    public class RowColMover : Mover
    {
        /// <summary>
        /// Override method Move in RowCol game.
        /// </summary>
        /// <param name="tileLabel">Tile that will be move.</param>
        /// <param name="frame">Frame to be moved.</param>
        /// <returns>Boolean by operation.</returns>
        public override bool Move(string tileLabel, IFrame frame)
        {
            if (!base.Move(tileLabel, frame))
            {
                return false;
            }

            var tilePosition = this.FindTilePosition(tileLabel, frame);
            var nullTilePosition = this.FindTilePosition(string.Empty, frame);

            if (nullTilePosition.Row == tilePosition.Row)
            {
                this.MoveTilesOnRow(frame, nullTilePosition, tilePosition);
                return true;
            }

            if (nullTilePosition.Col == tilePosition.Col)
            {
                this.MoveTilesOnCol(frame, nullTilePosition, tilePosition);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Override method GetCurrentMovableTileLabels in RowCol game.
        /// </summary>
        /// <param name="frame">The Frame.</param>
        /// <returns>Result by selection of tile.</returns>
        protected override List<string> GetCurrentMovableTileLabels(IFrame frame)
        {
            var result = new List<string>();

            var nullTilePosition = this.FindTilePosition(string.Empty, frame);

            if (this.NotFoundPosition == nullTilePosition)
            {
                return result;
            }

            for (int row = 0; row < frame.Rows; row++)
            {
                if (row == nullTilePosition.Row)
                {
                    continue;
                }

                result.Add(frame.Tiles[row, nullTilePosition.Col].Label);
            }

            for (int col = 0; col < frame.Cols; col++)
            {
                if (col == nullTilePosition.Col)
                {
                    continue;
                }

                result.Add(frame.Tiles[nullTilePosition.Row, col].Label);
            }

            return result;
        }

        /// <summary>
        /// The method moves tiles on row.
        /// </summary>
        /// <param name="frame">The Frame.</param>
        /// <param name="nullTilePosition">The null position of null tile.</param>
        /// <param name="tilePosition">The position of the tile.</param>
        private void MoveTilesOnRow(IFrame frame, Position nullTilePosition, Position tilePosition)
        {
            if (nullTilePosition.Col < tilePosition.Col)
            {
                this.MoveTilesLeft(frame, nullTilePosition, tilePosition);
            }
            else
            {
                this.MoveTilesRight(frame, nullTilePosition, tilePosition);
            }
        }

        /// <summary>
        /// The method moves tiles on column.
        /// </summary>
        /// <param name="frame">The Frame.</param>
        /// <param name="nullTilePosition">The null position of null tile.</param>
        /// <param name="tilePosition">The position of the tile.</param>
        private void MoveTilesOnCol(IFrame frame, Position nullTilePosition, Position tilePosition)
        {
            if (nullTilePosition.Row < tilePosition.Row)
            {
                this.MoveTilesUp(frame, nullTilePosition, tilePosition);
            }
            else
            {
                this.MoveTilesDown(frame, nullTilePosition, tilePosition);
            }
        }

        /// <summary>
        /// The method moves tiles left.
        /// </summary>
        /// <param name="frame">The Frame.</param>
        /// <param name="nullTilePosition">The null position of null tile.</param>
        /// <param name="tilePosition">The position of the tile.</param>
        private void MoveTilesLeft(IFrame frame, Position nullTilePosition, Position tilePosition)
        {
            while (nullTilePosition != tilePosition)
            {
                var rightTilePosition = new Position(nullTilePosition.Row, nullTilePosition.Col + 1);
                this.SwapTwoTilesInFrameByPosition(frame, nullTilePosition, rightTilePosition);
                nullTilePosition = rightTilePosition;
            }
        }

        /// <summary>
        /// The method moves tiles on right.
        /// </summary>
        /// <param name="frame">The Frame.</param>
        /// <param name="nullTilePosition">The null position of null tile.</param>
        /// <param name="tilePosition">The position of the tile.</param>
        private void MoveTilesRight(IFrame frame, Position nullTilePosition, Position tilePosition)
        {
            while (nullTilePosition != tilePosition)
            {
                var leftTilePosition = new Position(nullTilePosition.Row, nullTilePosition.Col - 1);
                this.SwapTwoTilesInFrameByPosition(frame, nullTilePosition, leftTilePosition);
                nullTilePosition = leftTilePosition;
            }
        }

        /// <summary>
        /// The method moves tiles on up.
        /// </summary>
        /// <param name="frame">The Frame.</param>
        /// <param name="nullTilePosition">The null position of null tile.</param>
        /// <param name="tilePosition">The position of the tile.</param>
        private void MoveTilesUp(IFrame frame, Position nullTilePosition, Position tilePosition)
        {
            while (nullTilePosition != tilePosition)
            {
                var downTilePosition = new Position(nullTilePosition.Row + 1, nullTilePosition.Col);
                this.SwapTwoTilesInFrameByPosition(frame, nullTilePosition, downTilePosition);
                nullTilePosition = downTilePosition;
            }
        }

        /// <summary>
        /// The method moves tiles on down.
        /// </summary>
        /// <param name="frame">The Frame.</param>
        /// <param name="nullTilePosition">The null position of null tile.</param>
        /// <param name="tilePosition">The position of the tile.</param>
        private void MoveTilesDown(IFrame frame, Position nullTilePosition, Position tilePosition)
        {
            while (nullTilePosition != tilePosition)
            {
                var upTilePosition = new Position(nullTilePosition.Row - 1, nullTilePosition.Col);
                this.SwapTwoTilesInFrameByPosition(frame, nullTilePosition, upTilePosition);
                nullTilePosition = upTilePosition;
            }
        }
    }
}
