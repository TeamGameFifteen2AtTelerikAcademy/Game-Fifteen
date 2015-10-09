﻿namespace GameFifteen.Logic.Frames
{
    using System;
    using System.Text;
    using Common;
    using Frames.Contracts;
    using Tiles.Contracts;

    public class Frame : IFrame
    {
        private ITile[,] tiles;

        public Frame(ITile[,] tiles)
        {
            this.Tiles = tiles;
        }

        public ITile[,] Tiles
        {
            get
            {
                return this.tiles;
            }

            private set
            {
                Validator.ValidateIsNotNull(value, "Tiles");
                Validator.ValidateIsPositiveInteger(value.GetLength(0), "Tiles.Rows");
                Validator.ValidateIsPositiveInteger(value.GetLength(1), "Tiles.Cols");

                this.tiles = value;
            }
        }

        public int Rows
        {
            get { return this.Tiles.GetLength(0); }
        }

        public int Cols
        {
            get { return this.Tiles.GetLength(1); }
        }

        public IFrame Clone()
        {
            return new ProxyFrame((ITile[,])this.Tiles.Clone());
        }

        public override bool Equals(object obj)
        {
            var other = obj as ProxyFrame;

            return this.Equals(other);
        }

        public bool Equals(ProxyFrame other)
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
                    if (this.Tiles[row, col] != other.Tiles[row, col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Override method ToString with frame that will be rendering
        /// </summary>
        /// <returns>Result that will be drow to the console</returns>
        public override string ToString()
        {
            int spaceNeededPerTile = (this.Rows * this.Cols).ToString().Length + 1;

            string topBottomBorder = new string('-', (spaceNeededPerTile * this.Cols) + 2);
            string leftRightBorder = "|";

            var result = new StringBuilder(topBottomBorder);

            string tileStringFormater = "{0," + spaceNeededPerTile + "}";

            for (int row = 0; row < this.Rows; row++)
            {
                result.Append(Environment.NewLine);

                result.Append(leftRightBorder);

                for (int col = 0; col < this.Cols; col++)
                {
                    result.Append(string.Format(tileStringFormater, this.Tiles[row, col]));
                }

                result.Append(leftRightBorder);
            }

            result.Append(Environment.NewLine);

            result.Append(topBottomBorder);

            return result.ToString();
        }

        /// <summary>
        /// Override method GetHashCode
        /// </summary>
        /// <returns>Result from GetHashCode</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}