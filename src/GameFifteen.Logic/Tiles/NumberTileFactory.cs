// <copyright file="NumberTileFactory.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Class NumberTileFactory.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Tiles
{
    using Tiles.Contracts;

    /// <summary>
    /// The class represents the model of the NumberTileFactory.
    /// </summary>
    public class NumberTileFactory : TileFactory
    {
        /// <summary>
        /// The method overrides base CreateTile method.
        /// </summary>
        /// <returns>New ITile.</returns>
        public override ITile CreateTile()
        {
            return new NumberTile(this.GetNextId());
        }
    }
}
