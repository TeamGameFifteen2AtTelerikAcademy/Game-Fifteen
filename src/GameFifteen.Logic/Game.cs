namespace GameFifteen.Logic
{
    using System;
    using System.Text;

    using Common;
    using Frames.Contracts;

    public class Game
    {
        public int emptyRow = 3;
        public int emptyCol = 3;
        public int[,] currentMatrix = {
                                        { 1, 2, 3, 4 },
                                        { 5, 6, 7, 8 },
                                        { 9, 10, 11, 12 },
                                        { 13, 14, 15, 16 }
                                      };
        private readonly IFrame frame;
        public Game(IFrame frame)
        {
           this.frame = frame;
        }

        public void ShuffleMatrix()
        {
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
            if (row >= this.currentMatrix.GetLength(0) || row < 0 || col < 0 || col >= this.currentMatrix.GetLength(1))
            {
                return true;
            }

            return false;
        }

        public void MoveEmptyCell(int newRow, int newCol)
        {
            int swapValue = currentMatrix[newRow, newCol];
            currentMatrix[newRow, newCol] = 16;
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
                    if (currentMatrix[i, j] != matrixElements[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}