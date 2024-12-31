using DataStructures;
using FluentAssertions;

namespace Tests;

public class TreeTests
{
    [Fact]
    public void CountNodes_ShouldReturnSeven()
    {
        var root = GetRoot();

        Tree.CountNodes(root).Should().Be(7);
    }

    [Fact]
    public void SumNodes_ShouldReturnTwentyOne()
    {
        var root = GetRoot();

        Tree.SumNodes(root).Should().Be(21);
    }

    [Fact]
    public void CountLeafs_ShouldReturnFour()
    {
        var root = GetRoot();

        Tree.CountLeafs(root).Should().Be(4);
    }

    [Fact]
    public void TraversePreorderIterative()
    {
        var root = GetRoot();

        Tree.TraversePreorderIterative(root).Should().Equal([3, 1, 0, 2, 5, 4, 6]);
    }

    [Fact]
    public void TraversePreorder()
    {
        var root = GetRoot();

        Tree.TraversePreorder(root).Should().Equal([3, 1, 0, 2, 5, 4, 6]);
    }

    [Fact]
    public void Serialize()
    {
        var root = GetRoot();

        Tree.Serialize(root).Should().Be("3,1,0,#,#,2,#,#,5,4,#,#,6,#,#");
    }

    [Fact]
    public void Deserialize()
    {
        var root = GetRoot();

        var result = Tree.Deserialize("3,1,0,#,#,2,#,#,5,4,#,#,6,#,#");

        result!.Left!.Value.Should().Be(root.Left!.Value);
    }

    [Fact]
    public void IsSameTree_ShouldReturnTrue()
    {
        var root1 = GetRoot();
        var root2 = GetRoot();

        Tree.IsSameTree(root1, root2).Should().BeTrue();
    }

    [Fact]
    public void IsSameTree_ShouldReturnFalse()
    {
        var root1 = GetRoot();
        var root2 = GetRoot();
        root2.Left = null;

        Tree.IsSameTree(root1, root2).Should().BeFalse();
    }

    [Theory]
    [InlineData(6, true)]
    [InlineData(-1, false)]
    [InlineData(10, false)]
    public void Exists(int target, bool expected)
    {
        var root = GetRoot();

        var result = Tree.Exists(root, target);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(4, true)]
    [InlineData(5, true)]
    [InlineData(6, true)]
    [InlineData(-1, false)]
    [InlineData(10, false)]
    public void ExistsNbs(int target, bool expected)
    {
        var root = GetRoot();

        var result = Tree.Exists(root, target);

        result.Should().Be(expected);
    }

    [Fact]
    public void CalculateHeight()
    {
        var root = GetRoot();

        var result = Tree.CalculateHeight(root);

        result.Should().Be(3);
    }

    [Fact]
    public void Bfs()
    {
        var root = GetRoot();

        var result = Tree.Bfs(root);

        result.Should().Equal([3, 1, 5, 0, 2, 4, 6]);
    }

    private static TreeNode GetRoot()
    {
        var node0 = new TreeNode(0);
        var node1 = new TreeNode(1);
        var node2 = new TreeNode(2);
        var node3 = new TreeNode(3);
        var node4 = new TreeNode(4);
        var node5 = new TreeNode(5);
        var node6 = new TreeNode(6);

        node3.Left = node1;
        node3.Right = node5;

        node1.Left = node0;
        node1.Right = node2;

        node5.Left = node4;
        node5.Right = node6;

        return node3;
    }
}