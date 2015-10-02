namespace GameFifteen.Logic.Movers.Contracts
{
    using GameFifteen.Logic.Frames.Contracts;

    public abstract class Mover : IMover
    {
        protected readonly Position NotFoundPosition = new Position(-1, -1);

        public abstract void Move(string tileLabel, Frames.Contracts.IFrame frame);

        public abstract void Schuffle(Frames.Contracts.IFrame frame);

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

        protected class Position
        {
            public Position(int row, int col)
            {
                this.Row = row;
                this.Col = col;
            }

            public int Row { get; private set; }

            public int Col { get; private set; }

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
