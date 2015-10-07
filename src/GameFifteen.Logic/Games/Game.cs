namespace GameFifteen.Logic.Games
{
    using GameFifteen.Logic.Common;
    using GameFifteen.Logic.Frames.Contracts;
    using GameFifteen.Logic.Games.Contracts;
    using GameFifteen.Logic.Movers.Contracts;

    public class Game : IGame
    {
        private readonly IFrame framePrototype;
        private readonly IMover mover;
        private IFrame frame;
        
        public Game(IFrame frame, IMover mover)
        {
            Validator.ValidateIsNotNull(frame, "frame");
            Validator.ValidateIsNotNull(mover, "mover");

            this.framePrototype = frame;
            this.frame = this.framePrototype.Clone();
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

        public bool Move(string tileLabel)
        {
            return this.mover.Move(tileLabel, this.frame);
        }

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