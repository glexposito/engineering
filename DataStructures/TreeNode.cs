namespace DataStructures;

public class TreeNode(int value)
{
    public int Value { get; private set; } = value;
    public TreeNode? Left { get; set; }
    public TreeNode? Right { get; set; }
}