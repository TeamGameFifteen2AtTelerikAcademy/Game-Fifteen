namespace GameFifteen.Logic.Movers
{
    using System;
    using System.Collections.Generic;

    using GameFifteen.Logic.Frames.Contracts;
    using GameFifteen.Logic.Movers.Contracts;

    public class RowColMover : Mover
    {
        public override void Move(string tileLabel, IFrame frame)
        {
            // TODO: consider throwing in these checks and catch the exception in the caller in order to prevent playerMoves incrementation.
            // Prevent moving the null tile.
            if (string.IsNullOrWhiteSpace(tileLabel))
            {
                return;
            }

            var nullTilePosition = this.FindTilePosition(string.Empty, frame);

            // If there isn't null tile in the frame we cannot move anything.
            if (this.NotFoundPosition == nullTilePosition)
            {
                return;
            }

            var tilePosition = this.FindTilePosition(tileLabel, frame);

            // If the tile is not found in the frame we cannot move it.
            if (this.NotFoundPosition == tilePosition)
            {
                return;
            }
           
            if (nullTilePosition.Row == tilePosition.Row)
            {
               
                this.MoveTilesOnRow(frame, nullTilePosition, tilePosition);
                return;
            }

            if (nullTilePosition.Col == tilePosition.Col)
            {                
                this.MoveTilesOnCol(frame, nullTilePosition, tilePosition);
                return;
            }
        }

        public override void Shuffle(IFrame frame)
        {
            var random = new Random();
            int randomMoves = frame.Rows * frame.Cols;
            for (int i = 0; i < randomMoves; i++)
            {
                var movableTileLabels = this.GetCurrentMovableTileLabels(frame);
                var tileToMove = movableTileLabels[random.Next(movableTileLabels.Count)];
                this.Move(tileToMove, frame);
            }
        }

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

        private void MoveTilesLeft(IFrame frame, Position nullTilePosition, Position tilePosition)
        {
            while (nullTilePosition != tilePosition)
            {
                var rightTilePosition = new Position(nullTilePosition.Row, nullTilePosition.Col + 1);
                this.SwapTwoTilesInFrameByPosition(frame, nullTilePosition, rightTilePosition);
                nullTilePosition = rightTilePosition;
            }
        }

        private void MoveTilesRight(IFrame frame, Position nullTilePosition, Position tilePosition)
        {
            while (nullTilePosition != tilePosition)
            {
                var leftTilePosition = new Position(nullTilePosition.Row, nullTilePosition.Col - 1);
                this.SwapTwoTilesInFrameByPosition(frame, nullTilePosition, leftTilePosition);
                nullTilePosition = leftTilePosition;
            }
        }

        private void MoveTilesUp(IFrame frame, Position nullTilePosition, Position tilePosition)
        {
            while (nullTilePosition != tilePosition)
            {
                var downTilePosition = new Position(nullTilePosition.Row + 1, nullTilePosition.Col);
                this.SwapTwoTilesInFrameByPosition(frame, nullTilePosition, downTilePosition);
                nullTilePosition = downTilePosition;
            }
        }

        private void MoveTilesDown(IFrame frame, Position nullTilePosition, Position tilePosition)
        {
            while (nullTilePosition != tilePosition)
            {
                var upTilePosition = new Position(nullTilePosition.Row - 1, nullTilePosition.Col);
                this.SwapTwoTilesInFrameByPosition(frame, nullTilePosition, upTilePosition);
                nullTilePosition = upTilePosition;
            }
        }

        private List<string> GetCurrentMovableTileLabels(IFrame frame)
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
    }
}
