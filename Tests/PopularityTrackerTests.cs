using Design;
using FluentAssertions;

namespace Tests;

public class PopularityTrackerTests
{
    [Fact]
    public void MostPopularSortedList()
    {
        var popularityTracker = new PopularityTracker();
        
        popularityTracker.IncreasePopularity(7);

        popularityTracker.IncreasePopularity(7);

        popularityTracker.IncreasePopularity(8);

        popularityTracker.MostPopular().Should().Be(7);        // returns 7

        popularityTracker.IncreasePopularity(8);

        popularityTracker.IncreasePopularity(8);

        popularityTracker.MostPopular().Should().Be(8);

        popularityTracker.DecreasePopularity(8);

        popularityTracker.DecreasePopularity(8);

        popularityTracker.MostPopular().Should().Be(7);      // returns 7

        popularityTracker.DecreasePopularity(7);

        popularityTracker.DecreasePopularity(7);

        popularityTracker.DecreasePopularity(8);

        popularityTracker.MostPopular().Should().Be(-1);        // returns -1 since there is no content with popularity greater than 0*/
    }
    
    [Fact]
    public void MostPopularSortedDictionary()
    {
        var popularityTracker = new PopularityTracker();
        
        popularityTracker.IncreasePopularity(7);

        popularityTracker.IncreasePopularity(7);

        popularityTracker.IncreasePopularity(8);

        popularityTracker.MostPopular().Should().Be(7);        // returns 7

        popularityTracker.IncreasePopularity(8);

        popularityTracker.IncreasePopularity(8);

        popularityTracker.MostPopular().Should().Be(8);       // returns 8

        popularityTracker.DecreasePopularity(8);

        popularityTracker.DecreasePopularity(8);

        popularityTracker.MostPopular().Should().Be(7);      // returns 7

        popularityTracker.DecreasePopularity(7);

        popularityTracker.DecreasePopularity(7);

        popularityTracker.DecreasePopularity(8);

        popularityTracker.MostPopular().Should().Be(-1);        // returns -1 since there is no content with popularity greater than 0*/
    }
}