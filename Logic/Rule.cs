using TictactToe.Domain.Enums;
using TictactToe.Domain.Interfaces;

namespace Logic
{
    public class Rule : IRule
    {
        private Player? currentPlayer;
        private readonly Player?[,] _board;

        public Rule(Player?[,] board)
        {
            _board = board;
        }

        public bool IsValid((int x, int y, Player symbol) input) =>
                ValidateCoordinate(input.x) && ValidateCoordinate(input.y)
                && ValidatePosition(input) && ValidatePlayerTurn(input.symbol);
        
        public bool HaveAWinner() => CheckingRows() || CheckingColumns() || CheckingDiagonal();
        
        private bool ValidatePosition((int x, int y, Player symbol) input) => _board[input.x, input.y] == null;

        private bool ValidateCoordinate(int coordinate) => coordinate >= 0 && coordinate <= 3;

        private bool ValidatePlayerTurn(Player symbol)
        {
            if (symbol != currentPlayer)
            {
                currentPlayer = symbol;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckingRows()
        {
            var winner = false;
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                winner = (_board[i, 0].HasValue && _board[i, 1].HasValue && _board[i, 2].HasValue)
                        && (_board[i, 0]!.Value == _board[i, 1]!.Value)
                        && (_board[i, 1]!.Value == _board[i, 2]!.Value);
                if (winner)
                {
                    break;
                }
            }

            return winner;
        }

        private bool CheckingColumns()
        {
            var winner = false;
            for (int i = 0; i < _board.GetLength(1); i++)
            {
                winner = (_board[0, i].HasValue && _board[1, i].HasValue && _board[2, i].HasValue)
                        && (_board[0, i]!.Value == _board[1, i]!.Value)
                        && (_board[1, i]!.Value == _board[2, i]!.Value);
                if (winner)
                {
                    break;
                }
            }

            return winner;
        }

        private bool CheckingDiagonal()
        {
            if ((_board[0, 0].HasValue && _board[1, 1].HasValue && _board[2, 2].HasValue)
                && (_board[0, 0]!.Value == _board[1, 1]!.Value)
                && (_board[1, 1]!.Value == _board[2, 2]!.Value))
            {
                return true;
            }
            else if ((_board[2, 0].HasValue && _board[1, 1].HasValue && _board[0, 2].HasValue)
                    && (_board[2, 0]!.Value == _board[1, 1]!.Value)
                    && (_board[1, 1]!.Value == _board[0, 2]!.Value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
