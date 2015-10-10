namespace GameFifteen.Logic.Frames
{
    using GameFifteen.Logic.Common;
    using GameFifteen.Logic.Frames.Contracts;
    using GameFifteen.Logic.Tiles.Contracts;
    
    /// <summary>
    /// The class is a proxy for the class Frame.
    /// </summary>
    public class ProxyFrame : IFrame
    {
        private readonly IFrame realFrame;

        public ProxyFrame(IFrame frame)
        {
            Validator.ValidateIsEqualOrGreaterThan(frame.Rows, Constants.FrameDimensionMin, "frame.Rows");
            Validator.ValidateIsEqualOrGreaterThan(frame.Cols, Constants.FrameDimensionMin, "frame.Cols");

            this.realFrame = frame;
        }

        public int Cols
        {
            get
            {
                return this.realFrame.Cols;
            }
        }

        public int Rows
        {
            get
            {
                return this.realFrame.Rows;
            }
        }

        public ITile[,] Tiles
        {
            get
            {
                return this.realFrame.Tiles;
            }
        }

        public IFrame Clone()
        {
            return this.realFrame.Clone();
        }

        /// <summary>
        /// Override method Equals to check equals between curent user frame and final frame.
        /// </summary>
        /// <param name="obj">Current user frame.</param>
        /// <returns>Result from comparison.</returns>
        public override bool Equals(object obj)
        {
            return this.realFrame.Equals(obj);
        }

        /// <summary>
        /// Мethod Equals to check equals between curent user frame and final frame.
        /// </summary>
        /// <param name="other">Current user frame.</param>
        /// <returns>Result from comparison.</returns>
        public bool Equals(IFrame other)
        {
            return this.realFrame.Equals(other);
        }

        /// <summary>
        /// The method overides the default ToStringMethod().
        /// </summary>
        /// <returns>Specific for the class string.</returns>
        public override string ToString()
        {
            return this.realFrame.ToString();
        }

        public override int GetHashCode()
        {
            return this.realFrame.GetHashCode();
        }
    }
}
