// <copyright file="Frame.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Frame class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Frames
{
    using System;
    using System.Text;
    using Frames.Contracts;

    using GameFifteen.Logic.Common;

    using Tiles.Contracts;

    /// <summary>
    /// The class represents the model of Frame.
    /// </summary>
    public class Frame : IFrame
    {
        /// <summary>
        /// Initializes a new instance of the Frame class.
        /// </summary>
        /// <param name="tiles">Two dimensional array of ITile.</param>
        public Frame(ITile[,] tiles)
        {
            this.Tiles = tiles;
        }

        /// <summary>
        /// Gets Two dimensional array of ITile.
        /// </summary>
        /// <value>Two dimensional array of ITile.</value>
        public ITile[,] Tiles { get; private set; }

        /// <summary>
        /// Gets Frame's rows.
        /// </summary>
        /// <value>Rows of type integer.</value>
        public int Rows
        {
            get { return this.Tiles.GetLength(0); }
        }

        /// <summary>
        /// Gets Frame's columns.
        /// </summary>
        /// <value>Columns of type integer.</value>
        public int Cols
        {
            get { return this.Tiles.GetLength(1); }
        }

        /// <summary>
        /// The method returns deep copy of the Frame itself.
        /// </summary>
        /// <returns>IFrame copy.</returns>
        public IFrame Clone()
        {
            return new Frame((ITile[,])this.Tiles.Clone());
        }

        /// <summary>
        /// The method overrides default Equals method.
        /// </summary>
        /// <param name="obj">Object to compare with.</param>
        /// <returns>Returns true or false.</returns>
        public override bool Equals(object obj)
        {
            var other = obj as IFrame;

            return this.Equals(other);
        }

        /// <summary>
        /// The method overrides default Equals method.
        /// </summary>
        /// <param name="other">IFrame to compare with.</param>
        /// <returns>Returns true or false.</returns>
        public bool Equals(IFrame other)
        {
            if (other == null)
            {
                return false;
            }

            if (this.Rows != other.Rows || this.Cols != other.Cols)
            {
                return false;
            }

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    if (!this.Tiles[row, col].Equals(other.Tiles[row, col]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Override method ToString with frame that will be rendering.
        /// </summary>
        /// <returns>Result that will be drown to the console.</returns>
        public override string ToString()
        {
            int spaceNeededPerTile = (this.Rows * this.Cols).ToString().Length + 1;

            string topBottomBorder = new string(Constants.HorizontalBorder, (spaceNeededPerTile * this.Cols) + 2);

            var result = new StringBuilder(topBottomBorder);

            string tileStringFormater = Constants.TileStringFormatterLeft + spaceNeededPerTile + Constants.TileStringFormatterRight;

            for (int row = 0; row < this.Rows; row++)
            {
                result.Append(Environment.NewLine);

                result.Append(Constants.VerticalBorder);

                for (int col = 0; col < this.Cols; col++)
                {
                    result.Append(string.Format(tileStringFormater, this.Tiles[row, col]));
                }

                result.Append(Constants.VerticalBorder);
            }

            result.Append(Environment.NewLine);

            result.Append(topBottomBorder);

            return result.ToString();
        }
    }
}