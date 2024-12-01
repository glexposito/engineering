using Design;
using FluentAssertions;

namespace Tests;

public class SlidingWindowRateLimiterTests
{
    [Fact]
    public void RateLimit_ShouldReturnFalse()
    {
        var rateLimiter = new SlidingWindowRateLimiter(5, TimeSpan.FromSeconds(1));

        rateLimiter.RateLimit(1);
        rateLimiter.RateLimit(1);
        rateLimiter.RateLimit(1);
        rateLimiter.RateLimit(1);
        rateLimiter.RateLimit(1).Should().BeTrue();
        rateLimiter.RateLimit(1).Should().BeFalse();
    }

    [Fact]
    public async Task RateLimit_ShouldReturnTrue()
    {
        var rateLimiter = new SlidingWindowRateLimiter(5, TimeSpan.FromSeconds(1));

        rateLimiter.RateLimit(1);
        rateLimiter.RateLimit(1);
        rateLimiter.RateLimit(1);
        rateLimiter.RateLimit(1);
        rateLimiter.RateLimit(1);

        await Task.Delay(1500);

        rateLimiter.RateLimit(1).Should().BeTrue();
    }

    [Fact]
    public async Task RateLimit_WhenSliding_ShouldReturnTrue()
    {
        var rateLimiter = new SlidingWindowRateLimiter(5, TimeSpan.FromSeconds(1));

        rateLimiter.RateLimit(1).Should().BeTrue();
        rateLimiter.RateLimit(1).Should().BeTrue();

        await Task.Delay(500);

        rateLimiter.RateLimit(1).Should().BeTrue();
        rateLimiter.RateLimit(1).Should().BeTrue();
        rateLimiter.RateLimit(1).Should().BeTrue();

        await Task.Delay(500);

        rateLimiter.RateLimit(1).Should().BeTrue();
        rateLimiter.RateLimit(1).Should().BeTrue();

        rateLimiter.RateLimit(1).Should().BeFalse();
    }
}