namespace Design;

public class PopularityTracker
{
    private readonly Dictionary<int, int> _popularity = [];

    private readonly SortedList<int, HashSet<int>> _sortedPopularity =
        new(Comparer<int>.Create((x, y) => y.CompareTo(x)));

    public void IncreasePopularity(int contentId)
    {
        if (!_popularity.TryAdd(contentId, 1))
        {
            var previousRate = _popularity[contentId];

            RemoveSortedContent(contentId, previousRate);

            _popularity[contentId]++;
        }

        var rate = _popularity[contentId];

        if (!_sortedPopularity.TryAdd(rate, [contentId]))
        {
            _sortedPopularity[rate].Add(contentId);
        }
    }

    public void DecreasePopularity(int contentId)
    {
        if (_popularity.TryGetValue(contentId, out var previousRate))
        {
            if (previousRate == 0)
            {
                return;
            }

            RemoveSortedContent(contentId, previousRate);

            _popularity[contentId] = --previousRate;
        }

        var rate = _popularity[contentId];

        if (rate > 0
            && !_sortedPopularity.TryAdd(rate, [contentId]))
        {
            _sortedPopularity[rate].Add(contentId);
        }
    }

    public int MostPopular()
    {
        if (_sortedPopularity.Count == 0)
        {
            return -1;
        }

        var key = _sortedPopularity.Keys[0];

        return _sortedPopularity[key].First();
    }

    private void RemoveSortedContent(int contentId, int previousRate)
    {
        _sortedPopularity[previousRate].Remove(contentId);

        if (_sortedPopularity[previousRate].Count == 0)
        {
            _sortedPopularity.Remove(previousRate);
        }
    }
}