namespace GameFifteen.Logic.Tiles
{
    using Contracts;

    public class NullTile : Tile, ITile
    {
        public NullTile(int id) : base(id)
        {
        }

        public override string Label
        {
            get
            {                
                return string.Empty;
            }
        }
    }
}
