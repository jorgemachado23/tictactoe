using System.Text;
using TictactToe.Domain.Enums;
using TictactToe.Domain.Interfaces;

namespace Presentation
{
    public class Render
    {
        private readonly IEngine _engine;
        private readonly IConsole _console;
        private readonly IRule _rule;
        private readonly Player?[,] _board;

        public Render(IEngine engine, IRule rule, IConsole console)
        {
            _engine = engine;
            _rule = rule;
            _board = engine.GetBoard;
            _console = console;
        }

        public string PrintBoard()
        {
            var grid = new StringBuilder();
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    var output = !_board[i, j].HasValue ? "-" : _board[i, j].ToString();
                    grid.Append($"  {output}   ");
                }

                grid.AppendLine("\n");
            }

            return grid.ToString();
        }

        public bool RunGame()
        {
            _console.PrintLine(PrintBoard());
            var inGame = true;
            while (inGame)
            {
                _console.PrintLine("Print enter your play coordinates x,y,player ej (0,0,X) type exit for finish");

                var input = _console.ReadLine;
                
                if (input == "exit")
                {
                    break;
                }
                
                _console.Clear();

                var (x, y, symbol, errorMessage) = _engine.ParseInput(input!);

                if (_rule.IsValid((x, y, symbol)) && errorMessage == "")
                {
                    _engine.SetPlay((x, y, symbol));
                    inGame = !_rule.HaveAWinner();

                    if (!inGame)
                    {
                        _console.PrintLine("Winner");
                    }
                }
                else
                {
                    _console.PrintLine("Incorrect input");
                }

                _console.PrintLine(PrintBoard());
            }

            return true;
        }

    }
}
