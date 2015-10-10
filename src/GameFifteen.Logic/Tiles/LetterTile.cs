// <copyright file="LetterTile.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Class LetterTile.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Tiles
{
    using Common;
    using Tiles.Contracts;

    /// <summary>
    /// The class represents the model of the LetterTile.
    /// </summary>
    public class LetterTile : Tile, ITile
    {
        /// <summary>
        /// Initializes a new instance of the LetterTile class.
        /// </summary>
        /// <param name="id">Tile's Id.</param>
        public LetterTile(int id) : base(id)
        {
        }

        /// <summary>
        /// Gets ITile's Label.
        /// </summary>
        /// <value>TIle's Label string.</value>
        public override string Label
        {
            get { return Converter.ConvertNumberToLetters(this.Id); }
        }
    }
}
