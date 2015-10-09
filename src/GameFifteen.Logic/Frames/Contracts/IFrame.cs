namespace GameFifteen.Logic.Frames.Contracts
{
    using Tiles.Contracts;

    public interface IFrame
    {
        ITile[,] Tiles { get; }

        int Rows { get; }

        int Cols { get; }

        IFrame Clone();

        bool Equals(IFrame other);
    }
}
