namespace GameFifteen.Logic.Frames
{
    using Common;
    using Frames.Contracts;

    /// <summary>
    /// The class represents director of building frames.
    /// </summary>
    public class FrameDirector
    {
        private readonly FrameBuilder frameBuilder;

        public FrameDirector(FrameBuilder frameBuilder)
        {
            Validator.ValidateIsNotNull(frameBuilder, "frameBuilder");
            this.frameBuilder = frameBuilder;
        }

        /// <summary>
        /// Method construct the frame.
        /// </summary>
        /// <param name="row">Number of frame rows.</param>
        /// <param name="col">Number of frame rows.</param>
        /// <returns>Frame that will be build.</returns>
        public IFrame ConstructFrame(int row, int col)
        {
            this.frameBuilder.InitializeFrame(row, col);
            this.frameBuilder.FillFrameWithTiles();
            return this.frameBuilder.GetFrame();
        }
    }
}