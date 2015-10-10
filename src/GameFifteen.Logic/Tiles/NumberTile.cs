namespace GameFifteen.Logic.Tiles
{
    using Tiles.Contracts;

    /// <summary>
    /// The class represents the model of the NullTile.
    /// </summary>
    public class NumberTile : Tile, ITile
    {
        public NumberTile(int id) : base(id)
        {
        }

        public override string Label
        {
            get { return this.Id.ToString(); }
        }
    }
}
