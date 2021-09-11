using Logic;
using Presentation;
using TictactToe.Domain.Enums;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Player?[3, 3];
            var engine = new Engine(board);
            var rule = new Rule(board);
            var console = new CustomConsole();
            var renderer = new Render(engine, rule, console);
            renderer.RunGame();
        }

    }

}
