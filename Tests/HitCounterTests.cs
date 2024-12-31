using Design;
using FluentAssertions;

namespace Tests;

public class HitCounterTests
{
    [Fact]
    public void Test()
    {
        var hitCounter = new HitCounter();
        hitCounter.Hit(1); // hit at timestamp 1.
        hitCounter.Hit(2); // hit at timestamp 2.
        hitCounter.Hit(3); // hit at timestamp 3.
        hitCounter.GetHits(4).Should().Be(3); // get hits at timestamp 4, return 3.
        hitCounter.Hit(300); // hit at timestamp 300.
        hitCounter.GetHits(300).Should().Be(4); // get hits at timestamp 300, return 4.
        hitCounter.GetHits(301).Should().Be(3); // get hits at timestamp 301, return 3.
    }
}