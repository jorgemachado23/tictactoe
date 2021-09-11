using Logic;
using System.Collections.Generic;
using TictactToe.Domain.Enums;
using TictactToe.Domain.Interfaces;
using Xunit;

namespace TicTacToe.Unit.Tests
{
    public class RuleTests
    {
        private readonly IRule _rule;
        private readonly Player?[,] _board;

        public RuleTests()
        {
            _board = new Player?[3, 3];
            _rule = new Rule(_board);
        }

        [Theory, MemberData(nameof(InputExampleData))]
        public void ShouldValidateCoordinates((int x, int y, Player symbol) input, bool output)
        {
            //Act 
            var result = _rule.IsValid(input);

            //Assert
            Assert.Equal(output, result);
        }

        [Fact]
        public void ShouldNotAllowPlayInAalredyPlayedPosition()
        {
            //Arrange
            _board[0, 0] = Player.X;
            
            //Act
            var result = _rule.IsValid((0, 0, Player.O));
            
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void ShouldValidateWinnerByRow()
        {
            //Arrange
            _board[0, 0] = Player.X;
            _board[0, 1] = Player.X;
            _board[0, 2] = Player.X;

            //
            var result = _rule.HaveAWinner();
            Assert.True(result);
        }

        [Fact]
        public void ShouldValidateWinnerByColumn()
        {
            //Arrange
            _board[0, 0] = Player.X;
            _board[1, 0] = Player.X;
            _board[2, 0] = Player.X;

            //Act
            var result = _rule.HaveAWinner();

            //Assert
            Assert.True(result);
        }

        public static IEnumerable<object[]> InputExampleData =>
           new List<object[]>
           {
                new object[] {(0, 0, Player.X), true },
                new object[] {(0, 0, Player.O), true },
                new object[] {(1, 1, Player.X), true },
                new object[] {(1, 1, Player.O), true },
                new object[] {(-1, -1, Player.O), false},
                new object[] {(-1, -1, Player.X), false},
                new object[] {(4, 4, Player.O), false},
                new object[] {(4, 4, Player.X), false},
                new object[] {(1, -4, Player.O), false},
                new object[] {(-4, 1, Player.X), false},
           };
    }
}
