// <copyright file="Tile.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Class Tile.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Tiles.Contracts
{
    /// <summary>
    /// The class represents the model of the Tile.
    /// </summary>
    public abstract class Tile : ITile
    {
        /// <summary>
        /// Initializes a new instance of the Tile class.
        /// </summary>
        /// <param name="id">The Id of the tile.</param>
        protected Tile(int id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets ITile's Id.
        /// </summary>
        /// <value>TIle's Id integer.</value>
        public int Id { get; private set; }

        /// <summary>
        /// Gets ITile's Label.
        /// </summary>
        /// <value>TIle's Label string.</value>
        public abstract string Label { get; }

        /// <summary>
        /// The method overrides default Equals method.
        /// </summary>
        /// <param name="obj">Object to compare with.</param>
        /// <returns>Returns true or false.</returns>
        public override bool Equals(object obj)
        {
            var other = obj as ITile;

            return this.Equals(other);
        }

        /// <summary>
        /// The method overrides default Equals method.
        /// </summary>
        /// <param name="other">Object to compare with.</param>
        /// <returns>Returns true or false.</returns>
        public bool Equals(ITile other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Id == other.Id;
        }

        /// <summary>
        /// The method overrides default GetHashCode method.
        /// </summary>
        /// <returns>Unique integer number.</returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        /// <summary>
        /// The method overrides default ToString method.
        /// </summary>
        /// <returns>Returns Tile's string.</returns>
        public override string ToString()
        {
            return this.Label;
        }
    }
}
