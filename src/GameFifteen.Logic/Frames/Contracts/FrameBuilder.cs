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
            // TODO: With negative numbers, the next line will throw an exeption and validation in any implementation of 
            // IFrame is useless :/ 
            var tiles = new ITile[rows, cols];

            this.Frame = new ProxyFrame(tiles);
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