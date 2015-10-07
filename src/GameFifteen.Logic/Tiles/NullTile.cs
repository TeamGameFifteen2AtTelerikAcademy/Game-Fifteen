namespace GameFifteen.Logic.Tiles
{
    using System;
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
                // TODO: change with null if needed
                return string.Empty;
            }
        }
    }
}
