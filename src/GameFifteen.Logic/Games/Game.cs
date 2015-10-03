namespace GameFifteen.Logic.Games
{
    using GameFifteen.Logic.Frames.Contracts;
    using GameFifteen.Logic.Games.Contracts;
    using GameFifteen.Logic.Movers.Contracts;

    public class Game : IGame
    {
        //public int emptyRow;
        //public int emptyCol;
        //public int[,] currentMatrix = {
        //                                { 1, 2, 3, 4 },
        //                                { 5, 6, 7, 8 },
        //                                { 9, 10, 11, 12 },
        //                                { 13, 14, 15, 16 }
        //                              };

        //public ITile[,] currentMatrix;
        //public ITile[,] solvedMatrix;

        private readonly IFrame framePrototype;
        private readonly IFrame frame;
        private readonly IMover mover;

        public Game(IFrame frame, IMover mover)
        {
            this.framePrototype = frame;
            this.frame = this.framePrototype.Clone();

            this.mover = mover;

            //this.currentMatrix = this.frame.Tiles;
            //this.solvedMatrix = (ITile[,])this.frame.Tiles.Clone();
            //this.emptyRow = this.frame.Rows -1;
            //this.emptyCol =  this.frame.Cols-1;
        }

        public bool IsSolved
        {
            get
            {
                return this.frame.Equals(this.framePrototype);
            }
        }

        public void Move(string tileLabel)
        {
            this.mover.Move(tileLabel, this.frame);
        }

        public void Shuffle()
        {
            do
            {
                this.mover.Shuffle(this.frame);
            }
            while (this.IsSolved);
        }

        public override string ToString()
        {
            return this.frame.ToString();
        }

        //public bool IsOutOfMatrix(int row, int col)
        //{
        //    if (row >= this.frame.Rows || row < 0 || col < 0 || col >= this.frame.Cols)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        //public void MoveEmptyCell(int newRow, int newCol)
        //{
        //    var swapValue = currentMatrix[newRow, newCol];
        //    currentMatrix[newRow, newCol] = currentMatrix[emptyRow, emptyCol];
        //    currentMatrix[emptyRow, emptyCol] = swapValue;
        //    emptyRow = newRow;
        //    emptyCol = newCol;
        //}

        //public bool IsEqualMatrix()
        //{
        //    int[,] matrixElements = {
        //                                { 1, 2, 3, 4 },
        //                                { 5, 6, 7, 8 },
        //                                { 9, 10, 11, 12 },
        //                                { 13, 14, 15, 16 }
        //                            };

        //    for (int i = 0; i < this.currentMatrix.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < this.currentMatrix.GetLength(1); j++)
        //        {
        //            if (currentMatrix[i, j].Label !=this.solvedMatrix[i, j].Label)
        //            {
        //                return false;
        //            }
        //        }
        //    }

        //    return true;
        //}
    }
}