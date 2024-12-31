namespace Design;

public class MyHashMap
{
    private readonly int?[] _map = new int?[1000001];
    
    public void Put(int key, int value)
    {
        _map[key] = value;
    }
    
    public int Get(int key)
    {
        int? value = _map[key];

        return value ?? -1;
    }
    
    public void Remove(int key) {
        _map[key] = null;
    }
}