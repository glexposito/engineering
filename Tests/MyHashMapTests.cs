using Design;
using FluentAssertions;

namespace Tests;

public class MyHashMapTests
{
    [Fact]
    public void MyHashMap_ShouldPerformOperationsCorrectly()
    {
        // Arrange
        var myHashMap = new MyHashMap();

        // Act & Assert
        // Test: put(1, 1)
        myHashMap.Put(1, 1);
        myHashMap.Get(1).Should().Be(1); // The map should now be [[1,1]]

        // Test: put(2, 2)
        myHashMap.Put(2, 2);
        myHashMap.Get(2).Should().Be(2); // The map should now be [[1,1], [2,2]]

        // Test: get(1)
        myHashMap.Get(1).Should().Be(1); // The map should still be [[1,1], [2,2]]

        // Test: get(3) (non-existing key)
        myHashMap.Get(3).Should().Be(-1); // The map should still be [[1,1], [2,2]]

        // Test: put(2, 1) (update the existing value)
        myHashMap.Put(2, 1);
        myHashMap.Get(2).Should().Be(1); // The map should now be [[1,1], [2,1]]

        // Test: remove(2)
        myHashMap.Remove(2);
        myHashMap.Get(2).Should().Be(-1); // The map should now be [[1,1]]

        // Test: get(2) after removal (should return -1)
        myHashMap.Get(2).Should().Be(-1); // The map should now be [[1,1]]
    }
}