using Design;
using FluentAssertions;

namespace Tests;

public class SnakeGameTests
{
    [Fact]
    public void SnakeGame_Should_Behave_As_Expected()
    {
        // Arrange
        var snakeGame = new SnakeGame(3, 2, [[1, 2], [0, 1]]);

        // Act & Assert
        snakeGame.Move("R").Should().Be(0, "the snake moves right and does not eat food");
        snakeGame.Move("D").Should().Be(0, "the snake moves down and does not eat food");
        snakeGame.Move("R").Should().Be(1, "the snake eats the first piece of food at (1, 2)");
        snakeGame.Move("U").Should().Be(1, "the snake moves up without eating food");
        snakeGame.Move("L").Should().Be(2, "the snake eats the second piece of food at (0, 1)");
        snakeGame.Move("U").Should().Be(-1, "the snake collides with the border, causing game over");
    }
}