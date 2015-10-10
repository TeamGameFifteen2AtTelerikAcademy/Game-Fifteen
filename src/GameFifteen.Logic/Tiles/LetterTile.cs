namespace GameFifteen.Logic.Tiles
{
    using Common;
    using Tiles.Contracts;

    /// <summary>
    /// The class represents the model of the LetterTile.
    /// </summary>
    public class LetterTile : Tile, ITile
    {
        public LetterTile(int id) : base(id)
        {
        }

        public override string Label
        {
            get { return Converter.ConvertNumberToLetters(this.Id); }
        }
    }
}
