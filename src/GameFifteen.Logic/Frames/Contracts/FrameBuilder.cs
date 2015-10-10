// <copyright file="FrameBuilder.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Abstract class FrameBuilder.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Frames.Contracts
{
    using Common;
    using Tiles.Contracts;

    /// <summary>
    /// Abstract class FrameBuilder that defines main need of its successors.
    /// </summary>
    public abstract class FrameBuilder
    {
        /// <summary>
        /// Private TileFactory field.
        /// </summary>
        private TileFactory tileFactory;

        /// <summary>
        /// Initializes a new instance of the FrameBuilder class.
        /// </summary>
        /// <param name="tileFactory">TileFactory parameter.</param>
        protected FrameBuilder(TileFactory tileFactory)
        {
            this.TileFactory = tileFactory;
        }

        /// <summary>
        /// Gets TileFactory of type TileFactory.
        /// </summary>
        /// <value>TileFactory of type TileFactory.</value>
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

        /// <summary>
        /// Gets Frame of type IFrame.
        /// </summary>
        /// <value>Frame of type IFrame.</value>
        protected IFrame Frame
        {
            get; private set;
        }

        /// <summary>
        /// The method initialize frame by given rows and columns.
        /// </summary>
        /// <param name="rows">The rows of the frame.</param>
        /// <param name="cols">The columns of the frame.</param>
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
        /// Abstract method to be implemented in the concrete builder.
        /// </summary>
        public abstract void FillFrameWithTiles();

        /// <summary>
        /// Returns IFrame with.
        /// </summary>
        /// <returns>Returns IFrame.</returns>
        public IFrame GetFrame()
        {
            return this.Frame;
        }

        /// <summary>
        /// The method creates new tile in given position in the frame.
        /// </summary>
        /// <param name="row">The row of the tile.</param>
        /// <param name="col">The column of the tile.</param>
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