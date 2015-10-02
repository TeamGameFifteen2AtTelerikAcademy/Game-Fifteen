namespace GameFifteen.Logic.Tiles
{
    using Tiles.Contracts;

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
