namespace GameFifteen.Logic.Tiles
{
    using Contracts;

    /// <summary>
    /// The class represents the model of the NullTile.
    /// </summary>
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
