namespace GameFifteen.Logic.Tiles
{
    using Tiles.Contracts;

    public class LetterTileFactory : TileFactory
    {
        public override ITile CreateTile()
        {
            return new LettersTile(this.GetNextId());
        }
    }
}
