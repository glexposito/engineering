using Design;
using FluentAssertions;

namespace Tests;

public class LruCacheTests
{
    [Fact]
    public void Test()
    {
        var cache = new LruCache(2);
        cache.Put(1, 1); // cache is {1=1}
        cache.Put(2, 2); // cache is {1=1, 2=2}
        cache.Get(1).Should().Be(1);    // return 1
        cache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
        cache.Get(2).Should().Be(-1);    // returns -1 (not found)
        cache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
        cache.Get(1).Should().Be(-1);    // return -1 (not found)
        cache.Get(3).Should().Be(3);    // return 3
        cache.Get(4).Should().Be(4);    // return 4
    }
}