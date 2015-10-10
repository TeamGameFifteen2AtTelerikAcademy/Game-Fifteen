namespace GameFifteen.Logic.Tiles
{
    using Tiles.Contracts;

    /// <summary>
    /// The class represents the model of the LetterTileFactory.
    /// </summary>
    public class LetterTileFactory : TileFactory
    {
        public override ITile CreateTile()
        {
            return new LetterTile(this.GetNextId());
        }
    }
}
