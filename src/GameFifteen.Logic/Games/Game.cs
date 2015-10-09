namespace GameFifteen.Logic.Games
{
    using System;
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
        
        /// <summary>
        /// Method move tile by lable
        /// </summary>
        /// <param name="tileLabel">Tile that will be move</param>
        /// <returns>Result by moves</returns>
        public bool Move(string tileLabel)
        {
            return this.mover.Move(tileLabel, this.frame);
        }


        /// <summary>
        /// Method shuffle the frame
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