using Design;
using FluentAssertions;

namespace Tests;

public class TokenRateLimiterTests
{
    [Fact]
    public void RateLimit_ShouldReturnFalse()
    {
        var rateLimiter = new TokenRateLimiter(5, TimeSpan.FromSeconds(1));

        rateLimiter.RateLimit(1);
        rateLimiter.RateLimit(1);
        rateLimiter.RateLimit(1);
        rateLimiter.RateLimit(1);
        rateLimiter.RateLimit(1).Should().BeTrue();
        rateLimiter.RateLimit(1).Should().BeFalse();
    }
    
    [Fact]
    public async Task RateLimit_WhenRefilling_ShouldReturnTrue()
    {
        var rateLimiter = new TokenRateLimiter(5, TimeSpan.FromSeconds(1));

        rateLimiter.RateLimit(1);
        rateLimiter.RateLimit(1);
        rateLimiter.RateLimit(1);
        rateLimiter.RateLimit(1);
        rateLimiter.RateLimit(1);

        await Task.Delay(200);
        
        rateLimiter.RateLimit(1).Should().BeTrue();
    }
}