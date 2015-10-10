// <copyright file="Mover.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Abstract class Mover.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Movers.Contracts
{
    using System;
    using System.Collections.Generic;

    using GameFifteen.Logic.Frames.Contracts;

    /// <summary>
    /// The class represents the model of the Mover.
    /// </summary>
    public abstract class Mover : IMover
    {
        /// <summary>
        /// Holds object of class Position.
        /// </summary>
        protected readonly Position NotFoundPosition = new Position(-1, -1);

        /// <summary>
        /// Moves tile in frame by given tile label. And returns if move is successful.
        /// </summary>
        /// <param name="tileLabel">Tile of type ITile.</param>
        /// <param name="frame">Frame of type IFrame.</param>
        /// <returns>True or false.</returns>
        public virtual bool Move(string tileLabel, IFrame frame)
        {
            var tilePosition = this.FindTilePosition(tileLabel, frame);
            var nullTilePosition = this.FindTilePosition(string.Empty, frame);

            // Prevent moving the null tile.
            // If the tile is not found in the frame we cannot move it.
            // If there isn't null tile in the frame we cannot move anything.
            return !(string.IsNullOrWhiteSpace(tileLabel) ||
                this.NotFoundPosition == tilePosition ||
                this.NotFoundPosition == nullTilePosition);
        }

        /// <summary>
        /// Shuffles the frame.
        /// </summary>
        /// <param name="frame">Frame to  be shuffled.</param>
        public void Shuffle(IFrame frame)
        {
            var random = new Random();
            int tilesCount = frame.Rows * frame.Cols;

            // Make odd number of random moves in order to have shuffled frame for sure.
            int randomMoves = tilesCount % 2 == 0 ? tilesCount - 1 : tilesCount;
            for (int i = 0; i < randomMoves; i++)
            {
                var movableTileLabels = this.GetCurrentMovableTileLabels(frame);
                var tileToMove = movableTileLabels[random.Next(movableTileLabels.Count)];
                this.Move(tileToMove, frame);
            }
        }

        /// <summary>
        /// Finds tile position.
        /// </summary>
        /// <param name="tileLabel">Tile label.</param>
        /// <param name="frame">The frame.</param>
        /// <returns>Founded Position.</returns>
        protected Position FindTilePosition(string tileLabel, IFrame frame)
        {
            for (int row = 0; row < frame.Rows; row++)
            {
                for (int col = 0; col < frame.Cols; col++)
                {
                    if (tileLabel == frame.Tiles[row, col].Label)
                    {
                        return new Position(row, col);
                    }
                }
            }

            return this.NotFoundPosition;
        }

        /// <summary>
        /// Swaps to tiles by their positions.
        /// </summary>
        /// <param name="frame">Frame that holds the tiles.</param>
        /// <param name="firstTilePosition">First tile.</param>
        /// <param name="secondTilePosition">Second tile.</param>
        protected void SwapTwoTilesInFrameByPosition(IFrame frame, Position firstTilePosition, Position secondTilePosition)
        {
            var firstTile = frame.Tiles[firstTilePosition.Row, firstTilePosition.Col];

            frame.Tiles[firstTilePosition.Row, firstTilePosition.Col] =
                frame.Tiles[secondTilePosition.Row, secondTilePosition.Col];

            frame.Tiles[secondTilePosition.Row, secondTilePosition.Col] = firstTile;
        }

        /// <summary>
        /// Abstract method that returns current movable tiles labels.
        /// </summary>
        /// <param name="frame">Frame of type IFrame.</param>
        /// <returns>List of strings.</returns>
        protected abstract List<string> GetCurrentMovableTileLabels(IFrame frame);

        /// <summary>
        /// The class represents the model of the protected Position.
        /// </summary>
        protected class Position
        {
            /// <summary>
            /// Initializes a new instance of the Position class.
            /// </summary>
            /// <param name="row">The position row.</param>
            /// <param name="col">The position column.</param>
            public Position(int row, int col)
            {
                this.Row = row;
                this.Col = col;
            }

            /// <summary>
            /// Gets the row.
            /// </summary>
            /// <value>Row of type integer.</value>
            public int Row
            {
                get; private set;
            }

            /// <summary>
            /// Gets the column.
            /// </summary>
            /// <value>Column of type integer.</value>
            public int Col
            {
                get; private set;
            }

            /// <summary>
            /// Override the default operator == behavior.
            /// </summary>
            /// <param name="firstPosition">First Position.</param>
            /// <param name="secondPosition">Second Position.</param>
            /// <returns>True or false.</returns>
            public static bool operator ==(Position firstPosition, Position secondPosition)
            {
                return object.Equals(firstPosition, secondPosition);
            }

            /// <summary>
            /// Override the default operator != behavior.
            /// </summary>
            /// <param name="firstPosition">First Position.</param>
            /// <param name="secondPosition">Second Position.</param>
            /// <returns>True or false.</returns>
            public static bool operator !=(Position firstPosition, Position secondPosition)
            {
                return !object.Equals(firstPosition, secondPosition);
            }

            /// <summary>
            /// Override the default Equals method.
            /// </summary>
            /// <param name="obj">The object to be compared with.</param>
            /// <returns>True or false.</returns>
            public override bool Equals(object obj)
            {
                var other = obj as Position;
                return this.Equals(other);
            }

            /// <summary>
            /// Override the default Equals method.
            /// </summary>
            /// <param name="other">The object to be compared with.</param>
            /// <returns>True or false.</returns>
            public bool Equals(Position other)
            {
                if (other == null)
                {
                    return false;
                }

                return this.Row == other.Row && this.Col == other.Col;
            }

            /// <summary>
            /// Override the default GetHashCode method.
            /// </summary>
            /// <returns>Unique integer number.</returns>
            public override int GetHashCode()
            {
                return (this.Row ^ (this.Col << 16)).GetHashCode();
            }
        }
    }
}