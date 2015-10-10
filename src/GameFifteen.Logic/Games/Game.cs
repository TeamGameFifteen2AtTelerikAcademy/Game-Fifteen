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
        private readonly IFrame framePrototype;
        private readonly IMover mover;
        private IFrame frame;
        
        public Game(IFrame frame, IMover mover)
        {
            this.Frame = frame;
            this.framePrototype = this.Frame.Clone();

            Validator.ValidateIsNotNull(mover, "mover");
            this.mover = mover;
        }

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

        public IFrame FramePrototype
        {
            get
            {
                return this.framePrototype.Clone();
            }
        }

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