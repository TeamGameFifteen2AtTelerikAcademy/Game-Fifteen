// <copyright file="TileFactory.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Abstract class TileFactory.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Tiles.Contracts
{
    /// <summary>
    /// The class represents the model of the TileFactory.
    /// </summary>
    public abstract class TileFactory
    {
        /// <summary>
        /// Holds current tile Id.
        /// </summary>
        private int currentTileId = 1;

        /// <summary>
        /// The method creates a ITile.
        /// </summary>
        /// <returns>New ITile.</returns>
        public abstract ITile CreateTile();

        /// <summary>
        /// The method creates a null ITile.
        /// </summary>
        /// <returns>New null ITile.</returns>
        public ITile CreateNullTile()
        {
            return new NullTile(0);
        }

        /// <summary>
        /// The returns Id for the nextITile.
        /// </summary>
        /// <returns>Integer number Id.</returns>
        protected int GetNextId()
        {
            return this.currentTileId++;
        }
    }
}
