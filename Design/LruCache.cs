namespace Design;

// 146. LRU Cache https://leetcode.com/problems/lru-cache/description/
public class LruCache(int capacity)
{
    private readonly Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> _cache = new();
    private readonly LinkedList<KeyValuePair<int, int>> _list = [];

    public int Get(int key)
    {
        if (!_cache.TryGetValue(key, out var node))
        {
            return -1;
        }

        _list.Remove(node);
        _list.AddFirst(node);

        return node.Value.Value;
    }

    public void Put(int key, int value)
    {
        if (_cache.TryGetValue(key, out var node))
        {
            _list.Remove(node);
        }
        else if (_list.Count == capacity)
        {
            var nodeToRemove = _list.Last;
            _cache.Remove(nodeToRemove!.Value.Key);
            _list.Remove(nodeToRemove);
        }

        _cache[key] = new LinkedListNode<KeyValuePair<int, int>>(new KeyValuePair<int, int>(key, value));
        _list.AddFirst(_cache[key]);
    }
}