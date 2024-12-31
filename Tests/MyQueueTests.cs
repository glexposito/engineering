using DataStructures;
using FluentAssertions;

namespace Tests;

public class QueueTests
{
    private readonly MyQueue<int> _queue = new();

    [Fact]
    public void Add_ShouldAddItemsToQueue()
    {
        // Act
        _queue.Add(5);
        _queue.Add(2);
        _queue.Add(21);

        // Assert
        _queue.Peek().Should().Be(5, because: "5 was the first item added to the queue");
        _queue.Count.Should().Be(3);
    }

    [Fact]
    public void Remove_ShouldRemoveItemsFromQueue()
    {
        // Arrange
        _queue.Add(8);
        _queue.Add(72);
        _queue.Add(11);

        // Act
        _queue.Remove(); // Removes 8
        _queue.Add(15);
        _queue.Add(35);
        _queue.Remove(); // Removes 72

        // Assert
        _queue.Peek().Should().Be(11, because: "11 is the next item in the queue after removals");
    }

    [Fact]
    public void IsEmpty_ShouldReturnTrueWhenQueueIsEmpty()
    {
        // Arrange
        _queue.Add(8);
        _queue.Remove(); // Removes the only item

        // Assert
        _queue.IsEmpty().Should().BeTrue(because: "all items have been removed from the queue");
    }
}