namespace GameFifteen.Logic.Tiles
{
    using Tiles.Contracts;

    public class NumberTileFactory : TileFactory
    {
        public override ITile CreateTile()
        {
            return new NumberTile(this.GetNextId());
        }
    }
}
