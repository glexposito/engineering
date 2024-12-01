namespace Design;

public class SlidingWindowRateLimiter(int maxRequests, TimeSpan window)
{
    private readonly Dictionary<int, SlidingWindowLimiter> _userLimiters = new();

    public bool RateLimit(int userId)
    {
        _userLimiters.TryAdd(userId, new SlidingWindowLimiter(maxRequests, window));
        return _userLimiters[userId].IsRequestAllowed();
    }
}

public class SlidingWindowLimiter(int maxRequests, TimeSpan window)
{
    private readonly Queue<DateTime> _requests = [];

    public bool IsRequestAllowed()
    {
        var now = DateTime.UtcNow;

        while (_requests.Count > 0 && now - _requests.Peek() >= window)
        {
            _requests.Dequeue();
        }

        if (_requests.Count == maxRequests)
        {
            return false;
        }
        
        _requests.Enqueue(now);
        
        return true;
    }
}