using System;
using System.Linq;
using System.Text;
using GameFifteen.Logic.Common;
using Wintellect.PowerCollections;

namespace GameFifteen.Logic
{
    public class GameFifteen
    {
        public int emptyRow = 3;
        public int emptyCol = 3;
        public int[,] currentMatrix = {
                                        { 1, 2, 3, 4 },
                                        { 5, 6, 7, 8 },
                                        { 9, 10, 11, 12 },
                                        { 13, 14, 15, 16 }
                                      };

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
            var result = new StringBuilder();
            result.AppendLine(Constants.HorizontalBorder);
            for (int i = 0; i < this.currentMatrix.GetLength(0); i++)
            {
                result.Append(Constants.VerticalBorder);
                for (int j = 0; j < this.currentMatrix.GetLength(1); j++)
                {
                    if (this.currentMatrix[i, j] <= 9)
                    {
                        result.Append(string.Format("  {0}", currentMatrix[i, j]));
                    }
                    else
                    {
                        if (this.currentMatrix[i, j] == 16)
                        {
                            result.Append("   ");
                        }
                        else
                        {
                            result.Append(string.Format(" {0}", currentMatrix[i, j]));
                        }
                    }
                }
                result.AppendLine(Constants.VerticalBorder);
            }

            result.Append(Constants.HorizontalBorder);

            return result.ToString();
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

        private bool IsGoesOnBoard(int moves, OrderedMultiDictionary<int, string> scoreboard)
        {
            foreach (var score in scoreboard)
            {
                if (moves < score.Key)
                {
                    return true;
                }
            }

            return false;
        }

        private void RemoveLastScore(OrderedMultiDictionary<int, string> scoreboard)
        {
            if (scoreboard.Last().Value.Count > 0)
            {
                string[] values = new string[scoreboard.Last().Value.Count];
                scoreboard.Last().Value.CopyTo(values, 0);
                scoreboard.Last().Value.Remove(values.Last());
            }
            else
            {
                int[] keys = new int[scoreboard.Count];
                scoreboard.Keys.CopyTo(keys, 0);
                scoreboard.Remove(keys.Last());
            }
        }

        public void GameWon(int moves, OrderedMultiDictionary<int, string> scoreboard)
        {
            if (scoreboard.Count == 5)
            {
                if (IsGoesOnBoard(moves, scoreboard))
                {
                    RemoveLastScore(scoreboard);
                    Points(moves, scoreboard);
                }
            }
            else
            {
                Points(moves, scoreboard);
            }
        }

        private void Points(int moves, OrderedMultiDictionary<int, string> scoreboard)
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();
            scoreboard.Add(moves, name);
        }

        public string PrintScoreboard(OrderedMultiDictionary<int, string> scoreboard)
        {
            if (scoreboard.Count == 0)
            {
                return Constants.ScoreboardIsEmpty + Environment.NewLine;
            }

            var result = new StringBuilder();
            result.AppendLine(Constants.Scoreboard);

            int index = 1;
            foreach (var keyValuePair in scoreboard)
            {
                result.AppendLine(string.Format(Constants.ScoreboardFormat, index, keyValuePair.Value, keyValuePair.Key));
                index++;
            }

            return result.ToString();
        }
    }
}