namespace Design;

public class HitCounter
{
    private readonly Queue<int> _hits = [];

    public void Hit(int timestamp)
    {
        _hits.Enqueue(timestamp);
    }

    public int GetHits(int timestamp)
    {
        var leftBound = Math.Max(0, timestamp - 300);

        while (_hits.Count > 0 && _hits.Peek() <= leftBound)
        {
            _hits.Dequeue();
        }

        return _hits.Count;
    }
}