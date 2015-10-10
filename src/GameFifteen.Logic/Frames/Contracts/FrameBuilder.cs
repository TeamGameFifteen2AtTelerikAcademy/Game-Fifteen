namespace GameFifteen.Logic.Frames.Contracts
{
    using Common;
    using Tiles.Contracts;

    /// <summary>
    /// Abstrac class FrameBuilder that defines main need of its successors
    /// </summary>
    public abstract class FrameBuilder
    {
        private TileFactory tileFactory;

        protected FrameBuilder(TileFactory tileFactory)
        {
            this.TileFactory = tileFactory;
        }

        protected TileFactory TileFactory
        {
            get
            {
                return this.tileFactory;
            }

            private set
            {
                Validator.ValidateIsNotNull(value, "TileFactory");
                this.tileFactory = value;
            }
        }

        protected IFrame Frame
        {
            get; private set;
        }

        /// <summary>
        /// The method initialize frame by given rows and golumns
        /// </summary>
        /// <param name="rows">the rows of the fram</param>
        /// <param name="cols">the columns of the frame</param>
        public void InitializeFrame(int rows, int cols)
        {
            IFrame proxyFrame;

            try
            {
                proxyFrame = new ProxyFrame(new Frame(new ITile[rows, cols]));
            }
            catch
            {
                proxyFrame = new ProxyFrame(new Frame(new ITile[Constants.FrameDimensionMin, Constants.FrameDimensionMin]));
            }

            this.Frame = proxyFrame;

        }

        /// <summary>
        /// Abstract method to be implemented in the concrete builder
        /// </summary>
        public abstract void FillFrameWithTiles();

        /// <summary>
        /// Returns IFrame with 
        /// </summary>
        /// <returns>IFrame</returns>
        public IFrame GetFrame()
        {
            return this.Frame;
        }

        /// <summary>
        /// The method creates new tile in given position in the frame
        /// </summary>
        /// <param name="row">the row of the tile</param>
        /// <param name="col">the column of the tile</param>
        protected virtual void FillTileInFrame(int row, int col)
        {
            bool isThisMostBottomRightPosition = row == this.Frame.Rows - 1 && col == this.Frame.Cols - 1;
            if (isThisMostBottomRightPosition)
            {
                this.Frame.Tiles[row, col] = this.TileFactory.CreateNullTile();
                return;
            }

            this.Frame.Tiles[row, col] = this.TileFactory.CreateTile();
        }
    }
}