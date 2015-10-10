// <copyright file="ProxyFrame.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// ProxyFrame class.
// </summary>
// <author>GameFifteen2Team</author>

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
        /// <summary>
        /// Private field that holds realFrame of type IFrame.
        /// </summary>
        private readonly IFrame realFrame;

        /// <summary>
        /// Initializes a new instance of the ProxyFrame class.
        /// </summary>
        /// <param name="frame">Frame of type IFrame.</param>
        public ProxyFrame(IFrame frame)
        {
            Validator.ValidateIsEqualOrGreaterThan(frame.Rows, Constants.FrameDimensionMin, "frame.Rows");
            Validator.ValidateIsEqualOrGreaterThan(frame.Cols, Constants.FrameDimensionMin, "frame.Cols");

            this.realFrame = frame;
        }

        /// <summary>
        /// Gets Frame's columns.
        /// </summary>
        /// <value>Columns of type integer.</value>
        public int Cols
        {
            get
            {
                return this.realFrame.Cols;
            }
        }

        /// <summary>
        /// Gets Frame's rows.
        /// </summary>
        /// <value>Rows of type integer.</value>
        public int Rows
        {
            get
            {
                return this.realFrame.Rows;
            }
        }

        /// <summary>
        /// Gets Two dimensional array of ITile.
        /// </summary>
        /// <value>Two dimensional array of ITile.</value>
        public ITile[,] Tiles
        {
            get
            {
                return this.realFrame.Tiles;
            }
        }

        /// <summary>
        /// The method returns deep copy of the Frame itself.
        /// </summary>
        /// <returns>IFrame copy.</returns>
        public IFrame Clone()
        {
            return this.realFrame.Clone();
        }

        /// <summary>
        /// Override method Equals to check equals between current user frame and final frame.
        /// </summary>
        /// <param name="obj">Current user frame.</param>
        /// <returns>Result from comparison.</returns>
        public override bool Equals(object obj)
        {
            return this.realFrame.Equals(obj);
        }

        /// <summary>
        /// Method Equals to check equals between current user frame and final frame.
        /// </summary>
        /// <param name="other">Current user frame.</param>
        /// <returns>Result from comparison.</returns>
        public bool Equals(IFrame other)
        {
            return this.realFrame.Equals(other);
        }

        /// <summary>
        /// The method overrides the default ToStringMethod().
        /// </summary>
        /// <returns>Specific for the class string.</returns>
        public override string ToString()
        {
            return this.realFrame.ToString();
        }

        /// <summary>
        /// The method overrides the default GetHashCode().
        /// </summary>
        /// <returns>Unique integer number.</returns>
        public override int GetHashCode()
        {
            return this.realFrame.GetHashCode();
        }
    }
}
