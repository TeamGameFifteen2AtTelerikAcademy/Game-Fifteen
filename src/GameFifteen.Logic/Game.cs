namespace GameFifteen.Logic
{
    using System;

    using Frames.Contracts;
    using Tiles.Contracts;
    using GameFifteen.Logic.Movers.Contracts;

    public class Game
    {
        public int emptyRow;
        public int emptyCol;
        //public int[,] currentMatrix = {
        //                                { 1, 2, 3, 4 },
        //                                { 5, 6, 7, 8 },
        //                                { 9, 10, 11, 12 },
        //                                { 13, 14, 15, 16 }
        //                              };

        public ITile[,] currentMatrix;
        public ITile[,] solvedMatrix;

        private readonly IFrame framePrototype;
        private readonly IFrame frame;
        private readonly IMover mover;

        public Game(IFrame frame, IMover mover)
        {
            this.frame = frame;
            this.framePrototype = this.frame.Clone();

            this.mover = mover;

            this.currentMatrix = this.frame.Tiles;
            this.solvedMatrix = (ITile[,])this.frame.Tiles.Clone();
            this.emptyRow = this.frame.Rows -1;
            this.emptyCol =  this.frame.Cols-1;
        }

        public void ShuffleMatrix()
        {
            //this.mover.Schuffle(frame);

            var randomNumber = new Random();
            int randomMoves = randomNumber.Next(10, 21);
            int[] dirRow = new int[4] { -1, 0, 1, 0 };
            int[] dirCol = new int[4] { 0, 1, 0, -1 };

            for (int i = 0; i < randomMoves; i++)
            {
                int randomDirection = randomNumber.Next(4);
                int newRow = emptyRow + dirRow[randomDirection];
                int newCol = emptyCol + dirCol[randomDirection];

                if (IsOutOfMatrix(newRow, newCol))
                {
                    i--;
                    continue;
                }
                else
                {
                    MoveEmptyCell(newRow, newCol);
                }
            }

            if (IsEqualMatrix())
            {
                ShuffleMatrix();
            }
        }

        public override string ToString()
        {
            return this.frame.ToString();
        }

        public bool IsOutOfMatrix(int row, int col)
        {
            if (row >= this.frame.Rows || row < 0 || col < 0 || col >= this.frame.Cols)
            {
                return true;
            }

            return false;
        }

        public void MoveEmptyCell(int newRow, int newCol)
        {
            var swapValue = currentMatrix[newRow, newCol];
            currentMatrix[newRow, newCol] = currentMatrix[emptyRow, emptyCol];
            currentMatrix[emptyRow, emptyCol] = swapValue;
            emptyRow = newRow;
            emptyCol = newCol;
        }

        public bool IsEqualMatrix()
        {
            int[,] matrixElements = {
                                        { 1, 2, 3, 4 },
                                        { 5, 6, 7, 8 },
                                        { 9, 10, 11, 12 },
                                        { 13, 14, 15, 16 }
                                    };

            for (int i = 0; i < this.currentMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.currentMatrix.GetLength(1); j++)
                {
                    if (currentMatrix[i, j].Label !=this.solvedMatrix[i, j].Label)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}