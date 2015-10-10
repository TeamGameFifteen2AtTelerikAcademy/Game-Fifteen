namespace GameFifteen.Logic.Tiles.Contracts
{
    public abstract class Tile : ITile
    {
        protected Tile(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }

        public abstract string Label { get; }

        public override bool Equals(object obj)
        {
            var other = obj as ITile;

            return this.Equals(other);
        }

        public bool Equals(ITile other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return this.Label;
        }
    }
}
