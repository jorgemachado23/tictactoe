using Logic;
using Moq;
using Presentation;
using System.IO;
using TictactToe.Domain.Enums;
using TictactToe.Domain.Interfaces;
using Xunit;

namespace TicTacToe.Unit.Tests
{
    public class PresentationTests
    {
        private readonly Render _render;
        private readonly IRule _rule;
        private readonly Mock<IConsole> _console;
        private readonly IEngine _engine;
        private readonly Player?[,] _board;

        public PresentationTests()
        {
            _console = new Mock<IConsole>();
            _board = new Player?[3, 3];
            _engine = new Engine(_board);
            _rule = new Rule(_board);
            _render = new Render(_engine, _rule , _console.Object);
        }

        [Theory]
        [InlineData("EmptyBoard")]
        public void ShouldPrintBoard(string board) 
        {
            //Arrange
            var expected = File.ReadAllText($@"..\..\..\Data\{board}.txt");

            //Act
            var actualBoard = _render.PrintBoard();

            //Assert
            Assert.Equal(expected, actualBoard);
        }

        [Fact]
        public void ShouldExitGame()
        {
            //Arrange
            _console.Setup(c => c.ReadLine).Returns("exit");

            //Act and Assert
            Assert.True(_render.RunGame());
        }

        [Fact]
        public void ShouldFinishTheGameWithAWinner()
        {
            //Arrange
            _board[0, 1] = Player.X;
            _board[0, 2] = Player.X;
            _console.Setup(c => c.ReadLine).Returns("0,0,x");
            
            //Act Assert
            Assert.True(_render.RunGame());
            
            _console.Verify(c => c.PrintLine("Winner"));
        }
    }
}
