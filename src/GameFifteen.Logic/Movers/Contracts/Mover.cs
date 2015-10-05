namespace GameFifteen.Logic.Movers.Contracts
{
    using System;
    using System.Collections.Generic;

    using GameFifteen.Logic.Frames.Contracts;

    public abstract class Mover : IMover
    {
        protected readonly Position NotFoundPosition = new Position(-1, -1);

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

        protected void SwapTwoTilesInFrameByPosition(IFrame frame, Position firstTilePosition, Position secondTilePosition)
        {
            var firstTile = frame.Tiles[firstTilePosition.Row, firstTilePosition.Col];

            frame.Tiles[firstTilePosition.Row, firstTilePosition.Col] =
                frame.Tiles[secondTilePosition.Row, secondTilePosition.Col];

            frame.Tiles[secondTilePosition.Row, secondTilePosition.Col] = firstTile;
        }

        protected abstract List<string> GetCurrentMovableTileLabels(IFrame frame);

        protected class Position
        {
            public Position(int row, int col)
            {
                this.Row = row;
                this.Col = col;
            }

            public int Row
            {
                get; private set;
            }

            public int Col
            {
                get; private set;
            }

            public static bool operator ==(Position firstPosition, Position secondPosition)
            {
                return object.Equals(firstPosition, secondPosition);
            }

            public static bool operator !=(Position firstPosition, Position secondPosition)
            {
                return !object.Equals(firstPosition, secondPosition);
            }

            public override bool Equals(object obj)
            {
                var other = obj as Position;
                return this.Equals(other);
            }

            public bool Equals(Position other)
            {
                if (other == null)
                {
                    return false;
                }

                return this.Row == other.Row && this.Col == other.Col;
            }

            public override int GetHashCode()
            {
                return (this.Row ^ (this.Col << 16)).GetHashCode();
            }
        }
    }
}