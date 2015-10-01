namespace GameFifteen.Logic.Contracts
{
    using System;

    public interface IScore : IComparable
    {
        int Moves { get; set; }

        string PlayerNeme { get; set; }
    }
}