namespace GameFifteen.Logic.Tiles
{
    using Common;
    using Tiles.Contracts;

    public class LettersTile : Tile, ITile
    {
        public LettersTile(int id) : base(id)
        {
        }

        public override string Label
        {
            get { return Converter.ConvertNumberToLetters(this.Id); }
        }

        public override string ToString()
        {
            return this.Label;
        }
    }
}
