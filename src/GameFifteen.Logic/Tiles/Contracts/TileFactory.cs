namespace GameFifteen.Logic.Tiles.Contracts
{
    public abstract class TileFactory
    {
        private int currentTileId = 1;

        public abstract ITile CreateTile();

        protected int GetNextId()
        {
            return this.currentTileId++;
        }
    }
}
