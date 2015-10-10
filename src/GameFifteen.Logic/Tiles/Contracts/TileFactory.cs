namespace GameFifteen.Logic.Tiles.Contracts
{
    /// <summary>
    /// The class represents the model of the TileFactory.
    /// </summary>
    public abstract class TileFactory
    {
        private int currentTileId = 1;

        public abstract ITile CreateTile();

        public ITile CreateNullTile()
        {
            return new NullTile(0);
        }

        protected int GetNextId()
        {
            return this.currentTileId++;
        }
    }
}
