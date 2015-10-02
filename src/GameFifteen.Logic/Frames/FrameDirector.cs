namespace GameFifteen.Logic.Frames
{
    using Frames.Contracts;
    using Common;

    public class FrameDirector
    {
        private readonly FrameBuilder frameBuilder;

        public FrameDirector(FrameBuilder frameBuilder)
        {
            Validator.ValidateIsNotNull(frameBuilder, "frameBuilder");
            this.frameBuilder = frameBuilder;
        }

        public IFrame ConstructFrame(int row, int col)
        {
            this.frameBuilder.InitializeFrame(row, col);
            this.frameBuilder.FillFrameWithTiles();
            return this.frameBuilder.GetFrame();
        }
    }
}
