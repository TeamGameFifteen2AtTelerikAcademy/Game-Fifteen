namespace GameFifteen.Logic.Frames.Contracts
{
    using Common;
    using Tiles.Contracts;

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

        public abstract void FillFrameWithTiles();

        public IFrame GetFrame()
        {
            return this.Frame;
        }

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