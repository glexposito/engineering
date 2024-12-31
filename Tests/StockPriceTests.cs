using Design;
using FluentAssertions;

namespace Tests;

public class StockPriceTests
{
    [Fact]
    public void Test()
    {
        var stockPrice = new StockPrice();

        stockPrice.Update(1, 10); // Timestamps are [1] with corresponding prices [10].
        stockPrice.Current().Should().Be(10, "because it's the latest price after the first update");
        stockPrice.Maximum().Should().Be(10, "because it's the only price");

        stockPrice.Update(2, 5); // Timestamps are [1, 2] with corresponding prices [10, 5].
        stockPrice.Current().Should().Be(5, "because it's the latest price");
        stockPrice.Maximum().Should().Be(10, "because it's still the highest price");

        stockPrice.Update(1, 3); // The previous timestamp 1 had the wrong price, so it is updated to 3.
        // Timestamps are [1, 2] with corresponding prices [3, 5].
        stockPrice.Current().Should().Be(5, "because it's still the latest price");
        stockPrice.Maximum().Should().Be(5, "because the new price 3 is less than 5");

        stockPrice.Update(4, 2); // Timestamps are [1, 2, 4] with corresponding prices [3, 5, 2].
        stockPrice.Current().Should().Be(2, "because it's the latest price after the update");
        stockPrice.Maximum().Should().Be(5, "because 5 is the highest price so far");
        stockPrice.Minimum().Should().Be(2, "because it's the lowest price at timestamp 4");
    }
}