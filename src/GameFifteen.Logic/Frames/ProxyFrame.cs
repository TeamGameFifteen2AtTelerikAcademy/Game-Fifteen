namespace GameFifteen.Logic.Frames
{
    using GameFifteen.Logic.Common;
    using GameFifteen.Logic.Frames.Contracts;
    using GameFifteen.Logic.Tiles.Contracts;
    
    public class ProxyFrame : IFrame
    {
        private IFrame realFrame;
        private ITile[,] tiles;

        public ProxyFrame(ITile[,] tiles)
        {
            this.Tiles = tiles;
            this.realFrame = new Frame(this.Tiles);
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
                return this.tiles;
            }

            private set
            {
                try
                {
                    Validator.ValidateIsEqualOrGreaterThan(value.GetLength(0), Constants.FrameDimensionMin, "Tiles.Rows");
                    Validator.ValidateIsEqualOrGreaterThan(value.GetLength(1), Constants.FrameDimensionMin, "Tiles.Cols");

                    this.tiles = value;
                }
                catch
                {
                    this.tiles = new ITile[Constants.FrameDimensionMin, Constants.FrameDimensionMin];
                }
            }
        }

        public IFrame Clone()
        {
            return this.realFrame.Clone();
        }


        /// <summary>
        /// Override method Equals to check equals between curent user frame and final frame
        /// </summary>
        /// <param name="obj">Current user frame</param>
        /// <returns>Result from comparison</returns>
        public override bool Equals(object obj)
        {
            return this.realFrame.Equals(obj);
        }

        /// <summary>
        /// Мethod Equals to check equals between curent user frame and final frame
        /// </summary>
        /// <param name="other">Current user frame</param>
        /// <returns>Result from comparison</returns>
        public bool Equals(ProxyFrame other)
        {
            return this.realFrame.Equals(other);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
