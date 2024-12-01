namespace Design;

public class FixedWindowRateLimiter(int maxRequests, TimeSpan window)
{
    private readonly Dictionary<int, FixedWindowLimiter> _userLimiters = new();

    public bool RateLimit(int userId)
    {
        _userLimiters.TryAdd(userId, new FixedWindowLimiter(maxRequests, window));
        return _userLimiters[userId].IsRequestAllowed();
    }
}

public class FixedWindowLimiter(int maxRequests, TimeSpan window)
{
    private DateTime _firstRequestTime = DateTime.Now;
    private int _requests;

    public bool IsRequestAllowed()
    {
        var now = DateTime.Now;

        if (now - _firstRequestTime >= window)
        {
            _firstRequestTime = now;
            _requests = 0;
        }

        if (_requests == maxRequests)
        {
            return false;
        }

        _requests++;

        return true;
    }
}