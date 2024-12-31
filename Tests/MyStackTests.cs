using DataStructures;
using Design;
using FluentAssertions;

namespace Tests
{
    public class MyStackTests
    {
        private readonly MyStack<int> _stack = new();

        [Fact]
        public void Push_ShouldAddElementsToStack()
        {
            // Act
            _stack.Push(15);
            _stack.Push(25);
            _stack.Push(75);

            // Assert
            _stack.Count.Should().Be(3);
            _stack.Peek().Should().Be(75);
            _stack.IsEmpty().Should().BeFalse();
        }

        [Fact]
        public void Pop_ShouldRemoveElementsFromStack()
        {
            // Arrange
            _stack.Push(15);
            _stack.Push(25);
            _stack.Pop();
            _stack.Push(35);
            _stack.Pop();

            // Assert
            _stack.Peek().Should().Be(15);
            _stack.Count.Should().Be(1);
            _stack.IsEmpty().Should().BeFalse();
            _stack.Pop().Should().Be(15);
        }
    }
}