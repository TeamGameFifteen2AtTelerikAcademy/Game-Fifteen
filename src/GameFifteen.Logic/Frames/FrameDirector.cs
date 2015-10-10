// <copyright file="FrameDirector.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// FrameDirector class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Frames
{
    using Common;
    using Frames.Contracts;

    /// <summary>
    /// The class represents director of building frames.
    /// </summary>
    public class FrameDirector
    {
        /// <summary>
        /// Private field frameBuilder of type FrameBuilder;
        /// Holds FrameDirector FrameBuilder.
        /// </summary>
        private readonly FrameBuilder frameBuilder;

        /// <summary>
        /// Initializes a new instance of the FrameDirector class.
        /// </summary>
        /// <param name="frameBuilder">An object of type FrameBuilder.</param>
        public FrameDirector(FrameBuilder frameBuilder)
        {
            Validator.ValidateIsNotNull(frameBuilder, "frameBuilder");
            this.frameBuilder = frameBuilder;
        }

        /// <summary>
        /// Method construct the frame.
        /// </summary>
        /// <param name="row">Number of frame rows.</param>
        /// <param name="col">Number of frame cols.</param>
        /// <returns>Frame that will be build.</returns>
        public IFrame ConstructFrame(int row, int col)
        {
            this.frameBuilder.InitializeFrame(row, col);
            this.frameBuilder.FillFrameWithTiles();
            return this.frameBuilder.GetFrame();
        }
    }
}