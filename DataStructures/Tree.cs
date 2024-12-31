namespace DataStructures;

public static class Tree
{
    public static int CountNodes(TreeNode? root)
    {
        if (root is null)
        {
            return 0;
        }

        return 1 + CountNodes(root.Left) + CountNodes(root.Right);
    }

    public static int SumNodes(TreeNode? root)
    {
        if (root is null)
        {
            return 0;
        }

        return root.Value + SumNodes(root.Left) + SumNodes(root.Right);
    }

    public static int CountLeafs(TreeNode? root)
    {
        if (root is null)
        {
            return 0;
        }

        if (root.Left is null && root.Right is null)
        {
            return 1;
        }

        return CountLeafs(root.Left) + CountLeafs(root.Right);
    }

    public static IList<int> TraversePreorderIterative(TreeNode? root)
    {
        List<int> values = [];
        Stack<TreeNode> stack = [];
        stack.Push(root!);

        while (stack.Count > 0)
        {
            var current = stack.Pop();
            values.Add(current.Value);

            if (current.Right is not null)
            {
                stack.Push(current.Right);
            }

            if (current.Left is not null)
            {
                stack.Push(current.Left);
            }
        }

        return values;
    }

    public static IList<int> TraversePreorder(TreeNode? root)
    {
        List<int> values = [];
        TraversePreorderHelper(root, values);

        return values;
    }

    private static void TraversePreorderHelper(TreeNode? root, IList<int> values)
    {
        if (root is null)
        {
            return;
        }

        values.Add(root.Value);
        TraversePreorderHelper(root.Left, values);
        TraversePreorderHelper(root.Right, values);
    }

    public static string Serialize(TreeNode? root)
    {
        List<string> values = [];
        Stack<TreeNode?> stack = [];
        stack.Push(root);

        while (stack.Count > 0)
        {
            var current = stack.Pop();

            if (current is null)
            {
                values.Add("#");
            }
            else
            {
                values.Add(current.Value.ToString());
                stack.Push(current.Right);
                stack.Push(current.Left);
            }
        }

        return string.Join(",", values);
    }

    public static TreeNode? Deserialize(string s)
    {
        var index = 0;

        var array = s.Split(",");

        return DeserializeHelper(array, ref index);
    }

    private static TreeNode? DeserializeHelper(string[] array, ref int index)
    {
        if (array[index] == "#")
        {
            return null;
        }

        var root = new TreeNode(int.Parse(array[index]));
        index++;
        root.Left = DeserializeHelper(array, ref index);
        index++;
        root.Right = DeserializeHelper(array, ref index);

        return root;
    }

    public static bool IsSameTree(TreeNode? root1, TreeNode? root2)
    {
        if (root1 is null && root2 is null)
        {
            return true;
        }

        if (root1 is null || root2 is null)
        {
            return false;
        }

        return root1.Value == root2.Value 
               && IsSameTree(root1.Left, root2.Left) 
               && IsSameTree(root1.Right, root2.Right);
    }

    public static bool Exists(TreeNode? root, int target)
    {
        if (root is null)
        {
            return false;
        }

        if (root.Value == target)
        {
            return true;
        }

        if (target < root.Value)
        {
            return Exists(root.Left, target);
        }

        return Exists(root.Right, target);
    }

    public static int CalculateHeight(TreeNode? root)
    {
        if (root is null)
        {
            return 0;
        }

        return 1 + Math.Max(CalculateHeight(root.Left), CalculateHeight(root.Right));
    }

    public static IList<int> Bfs(TreeNode? root)
    {
        Queue<TreeNode> queue = [];
        queue.Enqueue(root!);
        List<int> values = [];

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            values.Add(current.Value);

            if (current.Left is not null)
            {
                queue.Enqueue(current.Left);
            }

            if (current.Right is not null)
            {
                queue.Enqueue(current.Right);
            }
        }

        return values;
    }
}