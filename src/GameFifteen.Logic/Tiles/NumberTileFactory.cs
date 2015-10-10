namespace GameFifteen.Logic.Tiles
{
    using Tiles.Contracts;

    /// <summary>
    /// The class represents the model of the NumberTileFactory.
    /// </summary>
    public class NumberTileFactory : TileFactory
    {
        public override ITile CreateTile()
        {
            return new NumberTile(this.GetNextId());
        }
    }
}
