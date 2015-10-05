namespace GameFifteen.UI.WPF.ViewModels
{
    using Logic.Frames.Contracts;
    using Logic.Movers.Contracts;
    using Logic.Games.Contracts;
    using Logic.Common;

    public class GameWPFViewModel : IGame
    {
        private readonly IFrame framePrototype;
        private IFrame frame;
        private readonly IMover mover;

        public GameWPFViewModel(IFrame frame, IMover mover)
        {
            Validator.ValidateIsNotNull(frame, "frame");
            Validator.ValidateIsNotNull(mover, "mover");

            this.framePrototype = frame;
            this.Frame = this.framePrototype.Clone();
            this.mover = mover;
        }

        public IFrame Frame
        {
            get
            {
                return this.frame;
            }

            private set
            {
                this.frame = value;
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

        public override string ToString()
        {
            return this.frame.ToString();
        }
    }
}