// <copyright file="Game.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Game class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Games
{
    using GameFifteen.Logic.Common;
    using GameFifteen.Logic.Frames.Contracts;
    using GameFifteen.Logic.Games.Contracts;
    using GameFifteen.Logic.Movers.Contracts;

    /// <summary>
    /// The class represents the model of the Game.
    /// </summary>
    public class Game : IGame
    {
        /// <summary>
        /// Private field that holds frame prototype of type IFrame.
        /// </summary>
        private readonly IFrame framePrototype;

        /// <summary>
        /// Private field that holds mover prototype of type IMover.
        /// </summary>
        private readonly IMover mover;

        /// <summary>
        /// Private field that holds game's frame of type IFrame.
        /// </summary>
        private IFrame frame;

        /// <summary>
        /// Initializes a new instance of the Game class.
        /// </summary>
        /// <param name="frame">Frame of type IFrame.</param>
        /// <param name="mover">Mover of type IMover.</param>
        public Game(IFrame frame, IMover mover)
        {
            this.Frame = frame;
            this.framePrototype = this.Frame.Clone();

            Validator.ValidateIsNotNull(mover, "mover");
            this.mover = mover;
        }

        /// <summary>
        /// Gets or sets game frame.
        /// </summary>
        /// <value>Frame of type IFrame.</value>
        public IFrame Frame
        {
            get
            {
                return this.frame;
            }

            set
            {
                Validator.ValidateIsNotNull(value, "Frame");
                this.frame = value;
            }
        }

        /// <summary>
        /// Gets game frame prototype.
        /// </summary>
        /// <value>Frame of type IFrame.</value>
        public IFrame FramePrototype
        {
            get
            {
                return this.framePrototype.Clone();
            }
        }

        /// <summary>
        /// Gets a value indicating whether if the game is solved.
        /// </summary>
        /// <value>True or false.</value>
        public bool IsSolved
        {
            get
            {
                return this.frame.Equals(this.framePrototype);
            }
        }
        
        /// <summary>
        /// Method move tile by label.
        /// </summary>
        /// <param name="tileLabel">Tile that will be move.</param>
        /// <returns>Result by moves.</returns>
        public bool Move(string tileLabel)
        {
            return this.mover.Move(tileLabel, this.frame);
        }

        /// <summary>
        /// Method shuffle the frame.
        /// </summary>
        public void Shuffle()
        {
            do
            {
                this.mover.Shuffle(this.frame);
            }
            while (this.IsSolved);
        }
    }
}