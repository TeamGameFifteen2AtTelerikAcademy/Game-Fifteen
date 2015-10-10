// <copyright file="ClassicMover.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Class ClassicMover.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Movers
{
    using System.Collections.Generic;

    using GameFifteen.Logic.Frames.Contracts;
    using GameFifteen.Logic.Movers.Contracts;

    /// <summary>
    /// The class represents the model of the ClassicMover.
    /// </summary>
    public class ClassicMover : Mover
    {
        /// <summary>
        /// Override method Move in classic game.
        /// </summary>
        /// <param name="tileLabel">Tile of type ITile.</param>
        /// <param name="frame">Frame of type IFrame.</param>
        /// <returns>True or false.</returns>
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
                if (nullTilePosition.Col == tilePosition.Col + 1 ||
                    nullTilePosition.Col == tilePosition.Col - 1)
                {
                    this.SwapTwoTilesInFrameByPosition(frame, nullTilePosition, tilePosition);
                    return true;
                }
            }

            if (nullTilePosition.Col == tilePosition.Col)
            {
                if (nullTilePosition.Row == tilePosition.Row + 1 ||
                    nullTilePosition.Row == tilePosition.Row - 1)
                {
                    this.SwapTwoTilesInFrameByPosition(frame, nullTilePosition, tilePosition);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Override method GetCurrentMovableTileLabels in classic game.
        /// </summary>
        /// <param name="frame">Frame of type IFrame.</param>
        /// <returns>List of strings.</returns>
        protected override List<string> GetCurrentMovableTileLabels(IFrame frame)
        {
            var result = new List<string>();

            var nullTilePosition = this.FindTilePosition(string.Empty, frame);

            if (this.NotFoundPosition == nullTilePosition)
            {
                return result;
            }

            if (0 <= nullTilePosition.Row - 1)
            {
                result.Add(frame.Tiles[nullTilePosition.Row - 1, nullTilePosition.Col].Label);
            }

            if (nullTilePosition.Row + 1 < frame.Rows)
            {
                result.Add(frame.Tiles[nullTilePosition.Row + 1, nullTilePosition.Col].Label);                
            }

            if (0 <= nullTilePosition.Col - 1)
            {
                result.Add(frame.Tiles[nullTilePosition.Row, nullTilePosition.Col - 1].Label);
            }

            if (nullTilePosition.Col + 1 < frame.Cols)
            {
                result.Add(frame.Tiles[nullTilePosition.Row, nullTilePosition.Col + 1].Label);
            }

            return result;
        }
    }
}
