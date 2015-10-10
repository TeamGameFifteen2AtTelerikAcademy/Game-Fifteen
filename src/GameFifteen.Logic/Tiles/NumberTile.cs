// <copyright file="NumberTile.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Class NumberTile.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Tiles
{
    using Tiles.Contracts;

    /// <summary>
    /// The class represents the model of the NullTile.
    /// </summary>
    public class NumberTile : Tile, ITile
    {
        /// <summary>
        /// Initializes a new instance of the NumberTile class.
        /// </summary>
        /// <param name="id">Tile's Id.</param>
        public NumberTile(int id) : base(id)
        {
        }

        /// <summary>
        /// Gets ITile's Label.
        /// </summary>
        /// <value>TIle's Label string.</value>
        public override string Label
        {
            get { return this.Id.ToString(); }
        }
    }
}
