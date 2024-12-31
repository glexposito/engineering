namespace Design;

public class TopVotedCandidate
{
    private readonly Dictionary<int, int> _timeline = [];
    private readonly int[] _times;

    public TopVotedCandidate(int[] persons, int[] times)
    {
        _times = times;
        Dictionary<int, int> votes = [];
        var topVotedCandidate = persons[0];
        votes[topVotedCandidate] = 1;
        _timeline[times[0]] = topVotedCandidate;

        for (var i = 1; i < persons.Length; i++)
        {
            var votedCandidate = persons[i];
            var time = times[i];

            if (!votes.TryAdd(votedCandidate, 1))
            {
                votes[votedCandidate]++;
            }

            if (votes[votedCandidate] >= votes[topVotedCandidate])
            {
                topVotedCandidate = votedCandidate;
            }

            _timeline[time] = topVotedCandidate;
        }
    }

    public int Q(int t)
    {
        var index = SearchBinaryIndex(t);
        var time = _times[index];
        return _timeline[time];
    }

    private int SearchBinaryIndex(int t)
    {
        var left = 0;
        var right = _times.Length - 1;

        while (left <= right)
        {
            var mid = (left + right) / 2;

            if (_times[mid] == t)
            {
                return mid;
            }

            if (t > _times[mid])
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return Math.Min(left, right);
    }
}