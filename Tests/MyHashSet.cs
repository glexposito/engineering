namespace Tests;

public class MyHashSet
{
    private readonly bool[] _set = new bool[1000001];

    public void Add(int key)
    {
        _set[key] = true;
    }

    public void Remove(int key)
    {
        _set[key] = false;
    }

    public bool Contains(int key)
    {
        return _set[key];
    }
}