namespace GameFifteen.Logic.Frames.Contracts
{
    using Tiles.Contracts;

    /// <summary>
    /// Interface for IFrame
    /// </summary>
    public interface IFrame
    {
        /// <summary>
        /// The property should return two-dimensional array of ITile
        /// </summary>
        ITile[,] Tiles { get; }

        /// <summary>
        /// The property should return number of rows of the Tiles
        /// </summary>
        int Rows { get; }

        /// <summary>
        /// The property should return number of columns of the Tiles
        /// </summary>
        int Cols { get; }

        /// <summary>
        /// The method should return deep copy of itself
        /// </summary>
        /// <returns>IFram deep copy</returns>
        IFrame Clone();

        /// <summary>
        /// The method should determinate how to compare two IFrames
        /// </summary>
        /// <param name="other">acceprs IFrame to be compred with</param>
        /// <returns>bool</returns>
        bool Equals(IFrame other);
    }
}
