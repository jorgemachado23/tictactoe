using TictactToe.Domain.Enums;

namespace TictactToe.Domain.Interfaces
{
    public interface IRule
    {
        bool IsValid((int x, int y, Player symbol) input);
        bool HaveAWinner();
    }
}
