// <copyright file="NullTile.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Class NullTile.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Tiles
{
    using Contracts;

    /// <summary>
    /// The class represents the model of the NullTile.
    /// </summary>
    public class NullTile : Tile, ITile
    {
        /// <summary>
        /// Initializes a new instance of the NullTile class.
        /// </summary>
        /// <param name="id">Tile's Id.</param>
        public NullTile(int id) : base(id)
        {
        }

        /// <summary>
        /// Gets ITile's Label.
        /// </summary>
        /// <value>TIle's Label string.</value>
        public override string Label
        {
            get
            {                
                return string.Empty;
            }
        }
    }
}
