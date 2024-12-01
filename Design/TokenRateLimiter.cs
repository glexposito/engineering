namespace Design;

public class TokenRateLimiter(int maxRequests, TimeSpan timeSpan)
{
    private readonly Dictionary<int, Bucket> _buckets = new();
    private readonly double _refillRate = maxRequests / timeSpan.TotalSeconds;
    
    public bool RateLimit(int userId)
    {
        _buckets.TryAdd(userId, new Bucket(maxRequests, _refillRate));

        return _buckets[userId].IsAllowed();
    }
}

public class Bucket(int maxRequests, double refillRate)
{
    private double _tokens = maxRequests;
    private DateTime _lastRequestTime = DateTime.Now;

    public bool IsAllowed()
    {
        var now = DateTime.Now;
        var newTokens = (now - _lastRequestTime).TotalSeconds * refillRate;
        _lastRequestTime = now;
        _tokens = Math.Min(maxRequests, _tokens + newTokens);

        if (_tokens < 1)
        {
            return false;
        }

        _tokens--;

        return true;
    }
}