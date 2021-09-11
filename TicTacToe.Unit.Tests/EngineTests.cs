using Logic;
using System;
using System.Collections.Generic;
using TictactToe.Domain.Enums;
using TictactToe.Domain.Interfaces;
using Xunit;

namespace TicTacToe.Unit.Tests
{
    public class EngineTests
    {
        private readonly IEngine _engine;
        private readonly Player?[,] _board;

        public EngineTests()
        {
            _board = new Player?[3, 3];
            _engine = new Engine(_board);
        }

        [Theory, MemberData(nameof(InputExampleData))]
        public void ShouldParseValidInputs(string input, (int x, int y, Player symbol) expectedInput)
        {
            var output = _engine.ParseInput(input);
            Assert.Equal(expectedInput.x, output.x);
            Assert.Equal(expectedInput.y, output.y);
            Assert.Equal(expectedInput.symbol, output.symbol);
        }

        [Theory]
        [InlineData("sadfasdfasfd")]
        [InlineData("")]
        [InlineData("1,2,asdfasdf")]
        [InlineData("asfdasdf,asfdasdf,asdfasd")]
        public void ShouldDealWithInvalidInputs(string input)
        {
            var result = _engine.ParseInput(input);
            Assert.True(!string.IsNullOrEmpty(result.errorMessage));
        }

        [Fact]
        public void ShouldMakeAPlayBoard()
        {
            _engine.SetPlay((0, 0, Player.X));
            Assert.True(_board[0, 0].HasValue);
            Assert.Equal(Player.X, _board[0, 0].Value);
        }

        public static IEnumerable<object[]> InputExampleData =>
           new List<object[]>
           {
                new object[] { "0,0,x", (0, 0, Player.X) },
                new object[] { "0,0,X", (0, 0, Player.X) },
                new object[] { "0,0,o", (0, 0, Player.O) },
                new object[] { "0,0,O", (0, 0, Player.O) },
           };

    }
}
