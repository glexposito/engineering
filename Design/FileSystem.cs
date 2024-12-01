namespace Design;

// https://leetcode.com/problems/design-file-system/description/
public class FileSystem
{
    private readonly TrieNode _root = new(0);

    public bool CreatePath(string path, int value)
    {
        var paths = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

        var node = _root;

        foreach (var p in paths[..^1])
        {
            if (!node.ContainsNode(p))
            {
                return false;
            }

            node = node.GetNode(p);
        }

        if (node.ContainsNode(paths[^1]))
        {
            return false;
        }

        node.AddNode(paths[^1], value);

        return true;
    }

    public int Get(string path)
    {
        var paths = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

        var node = _root;

        foreach (var p in paths)
        {
            if (!node.ContainsNode(p))
            {
                return -1;
            }

            node = node.GetNode(p);
        }

        return node.Value;
    }
}

public class TrieNode(int value)
{
    private readonly Dictionary<string, TrieNode> _nodes = [];
    public int Value { get; } = value;

    public bool ContainsNode(string path)
    {
        return _nodes.ContainsKey(path);
    }

    public TrieNode GetNode(string s)
    {
        return _nodes[s];
    }

    public void AddNode(string path, int value)
    {
        _nodes[path] = new TrieNode(value);
    }
}