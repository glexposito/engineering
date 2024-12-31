using Design;
using FluentAssertions;

namespace Tests;

public class TicTacToeTests
{
    [Fact]
    public void Test()
    {
        var game = new TicTacToe(3);
        game.Move(0, 0, 1);
        game.Move(0, 2, 2);
        game.Move(2, 2, 1);
        game.Move(1, 1, 2);
        game.Move(2, 0, 1);
        game.Move(2, 1, 1).Should().Be(1);
    }
}