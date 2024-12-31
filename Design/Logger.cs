namespace Design;

// 359. Logger Rate Limiter https://leetcode.com/problems/logger-rate-limiter
public class Logger
{
    private readonly Dictionary<string, int> _logs = new();

    public bool ShouldPrintMessage(int timestamp, string message)
    {
        if (!_logs.TryGetValue(message, out var value) || timestamp >= value)
        {
            value = timestamp + 10;
            _logs[message] = value;
            
            return true;
        }

        return false;
    }
}