using TictactToe.Domain.Enums;

namespace TictactToe.Domain.Interfaces
{
    public interface IEngine
    {
        Player?[,] GetBoard { get; }
        void SetPlay((int x, int y, Player symbol) input);
        (int x, int y, Player symbol, string errorMessage) ParseInput(string input);
    }
}
