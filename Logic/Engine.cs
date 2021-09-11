using System;
using TictactToe.Domain.Enums;
using TictactToe.Domain.Interfaces;

namespace Logic
{
    public class Engine : IEngine
    {
        private readonly Player?[,] _board;

        public Engine(Player?[,] board)
        {
            _board = board;
        }

        public Player?[,] GetBoard => _board;

        public void SetPlay((int x, int y, Player symbol) input) => _board[input.x, input.y] = input.symbol;

        public (int x, int y, Player symbol, string errorMessage) ParseInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return (0, 0, default, "Input cannot be null or empty");
            }

            var result = input.ToUpper().Split(",");
            if(result.Length == 3)
            {
                try
                {
                    var x = int.Parse(result[0]);
                    var y = int.Parse(result[1]);
                    var symbol = Enum.Parse<Player>(result[2]);
                    return (x, y, symbol, "");
                }
                catch (Exception)
                {
                    return (0, 0, default, "Cannot parse string formatted");
                }
            }
            else
            {
                return (0, 0, default, "Input should be separated by commas");
            }
        }
    }
}
