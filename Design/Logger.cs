namespace Design;

// 359. Logger Rate Limiter https://leetcode.com/problems/logger-rate-limiter
public class Logger
{
    private readonly Dictionary<string, int> _logs = new();

    public bool ShouldPrintMessage(int timestamp, string message)
    {
        if (!_logs.ContainsKey(message) || timestamp >= _logs[message] )
        {
            _logs[message] = timestamp + 10;
            return true;
        }

        return false;
    }
}