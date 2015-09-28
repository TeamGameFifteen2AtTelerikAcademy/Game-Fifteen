using System;
using System.Linq;
using System.Text;
using GameFifteen.Logic.Common;
using Wintellect.PowerCollections;

namespace GameFifteen.Logic
{
    public class GameFifteen
    {
        private int emptyRow = 3;
        private int emptyCol = 3;
        private int[,] currentMatrix = new int[Constants.MatrixLength, Constants.MatrixLength]
                                                {
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

        public void PrintMatrix()
        {
            Console.WriteLine(Constants.HorizontalBorder);

            for (int i = 0; i < Constants.MatrixLength; i++)
            {
                Console.Write(Constants.VerticalBorder);

                for (int j = 0; j < Constants.MatrixLength; j++)
                {
                    if (currentMatrix[i, j] <= 9)
                    {
                        Console.Write("  {0}", currentMatrix[i, j]);
                    }
                    else
                    {
                        if (currentMatrix[i, j] == 16)
                        {
                            Console.Write("   ");
                        }
                        else
                        {
                            Console.Write(" {0}", currentMatrix[i, j]);
                        }
                    }

                    if (j == Constants.MatrixLength - 1)
                    {
                        Console.WriteLine(Constants.VerticalBorder);
                    }
                }
            }

            Console.WriteLine(Constants.HorizontalBorder);
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

            result.AppendLine(Constants.HorizontalBorder);

            return result.ToString();
        }

        public void PrintWelcome()
        {
            Console.WriteLine("Welcome to the game “15”. Please try to arrange the numbers sequentially.\n" +
            "Use 'top' to view the top scoreboard, 'restart' to start a new game and \n'exit' to quit the game.");
        }

        private bool IsOutOfMatrix(int row, int col)
        {
            if (row >= Constants.MatrixLength || row < 0 || col < 0 || col >= Constants.MatrixLength)
            {
                return true;
            }

            return false;
        }

        private void MoveEmptyCell(int newRow, int newCol)
        {
            int swapValue = currentMatrix[newRow, newCol];
            currentMatrix[newRow, newCol] = 16;
            currentMatrix[emptyRow, emptyCol] = swapValue;
            emptyRow = newRow;
            emptyCol = newCol;
        }

        public bool IsEqualMatrix()
        {
            int[,] matrixElements = new int[Constants.MatrixLength, Constants.MatrixLength] 
                                                { 
                                                { 1, 2, 3, 4 },
                                                { 5, 6, 7, 8 }, 
                                                { 9, 10, 11, 12 },
                                                { 13, 14, 15, 16 } 
                                                };

            for (int i = 0; i < Constants.MatrixLength; i++)
            {
                for (int j = 0; j < Constants.MatrixLength; j++)
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
            Console.WriteLine("Congratulations! You won the game in {0} moves.", moves);
            int scorersCount = 0;

            foreach (var scorer in scoreboard)
            {
                scorersCount += scorer.Value.Count;
            }

            if (scorersCount == 5)
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

        public void PrintScoreboard(OrderedMultiDictionary<int, string> scoreboard)
        {
            if (scoreboard.Count == 0)
            {
                Console.WriteLine("Scoreboard is empty");
                return;
            }

            Console.WriteLine("Scoreboard:");
            int i = 1;

            foreach (var score in scoreboard)
            {
                foreach (var value in score.Value)
                {
                    Console.WriteLine("{0}. {1} --> {2} moves", i, value, score.Key);
                    i++;
                }
            }

            Console.WriteLine();
        }

        public void ExecuteComand(string inputString, ref int moves, OrderedMultiDictionary<int, string> scoreboard)
        {
            switch (inputString)
            {
                case "restart":
                    moves = 0;
                    ShuffleMatrix();
                    PrintWelcome();
                    // PrintMatrix();
                    Console.WriteLine(this);
                    break;

                case "top":
                    PrintScoreboard(scoreboard);
                    // PrintMatrix();
                    Console.WriteLine(this);
                    break;

                default:
                    int number = 0;
                    bool isNumber = int.TryParse(inputString, out number);

                    if (!isNumber)
                    {
                        Console.WriteLine("Invalid comand!");
                        break;
                    }

                    if (number < 16 && number > 0)
                    {
                        int newRow = 0;
                        int newCol = 0;
                        int[] dirRow = new int[4] { -1, 0, 1, 0 };
                        int[] dirCol = new int[4] { 0, 1, 0, -1 };

                        for (int i = 0; i < 4; i++)
                        {
                            newRow = emptyRow + dirRow[i];
                            newCol = emptyCol + dirCol[i];

                            if (IsOutOfMatrix(newRow, newCol))
                            {
                                if (i == 3)
                                {
                                    Console.WriteLine("Invalid move");
                                }

                                continue;
                            }

                            if (currentMatrix[newRow, newCol] == number)
                            {
                                MoveEmptyCell(newRow, newCol);
                                moves++;
                                //PrintMatrix();
                                Console.WriteLine(this);
                                break;
                            }

                            if (i == 3)
                            {
                                Console.WriteLine("Invalid move");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid move");
                        break;
                    }

                    break;
            }
        }
    }
}
