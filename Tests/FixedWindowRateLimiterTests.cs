using Design;
using FluentAssertions;

namespace Tests;

public class FixedWindowLimiterTests
{
    [Fact]
    public void RateLimit_ShouldReturnFalse()
    {
        var rateLimiter = new FixedWindowRateLimiter(5, TimeSpan.FromSeconds(1));

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
        var rateLimiter = new FixedWindowRateLimiter(5, TimeSpan.FromSeconds(1));

        rateLimiter.RateLimit(1);
        rateLimiter.RateLimit(1);
        rateLimiter.RateLimit(1);
        rateLimiter.RateLimit(1);
        rateLimiter.RateLimit(1);

        await Task.Delay(1500);
        
        rateLimiter.RateLimit(1).Should().BeTrue();
    }
}