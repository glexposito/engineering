namespace Design;

public class StockPrice
{
    private readonly Dictionary<int, int> _prices = [];
    private readonly SortedList<int, int> _sortedPrices = [];
    private int _latestTimestamp;

    public void Update(int timestamp, int price)
    {
        _latestTimestamp = Math.Max(_latestTimestamp, timestamp);

        if (_prices.TryGetValue(timestamp, out var currentPrice))
        {
            if (_sortedPrices.TryGetValue(currentPrice, out var value))
            {
                _sortedPrices[currentPrice] = --value;

                if (_sortedPrices[currentPrice] == 0)
                {
                    _sortedPrices.Remove(currentPrice);
                }
            }
        }

        if (!_sortedPrices.TryAdd(price, 1))
        {
            _sortedPrices[price]++;
        }

        _prices[timestamp] = price;
    }

    public int Current()
    {
        return _prices[_latestTimestamp];
    }

    public int Maximum()
    {
        return _sortedPrices.GetKeyAtIndex(_sortedPrices.Count - 1);
    }

    public int Minimum()
    {
        return _sortedPrices.GetKeyAtIndex(0);
    }
}