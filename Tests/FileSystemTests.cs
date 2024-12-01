using Design;
using FluentAssertions;

namespace Tests;

public class FileSystemTests
{
    [Fact]
    public void CreatePath_WhenValidPath_ShouldReturnTrue()
    {
        var fileSystem = new FileSystem();

        fileSystem.CreatePath("a", 1).Should().BeTrue();
    }

    [Fact]
    public void CreatePath_WhenPathAlreadyExists_ShouldReturnFalse()
    {
        var fileSystem = new FileSystem();

        fileSystem.CreatePath("a", 1).Should().BeTrue();

        fileSystem.CreatePath("a", 1).Should().BeFalse();
    }

    [Fact]
    public void Get_WhenPathExists_ShouldReturnPathValue()
    {
        var fileSystem = new FileSystem();

        fileSystem.CreatePath("/a", 1).Should().BeTrue();

        fileSystem.Get("/a").Should().Be(1);
    }

    [Fact]
    public void Get_WhenPathDoesNotExists_ShouldReturnMinusOne()
    {
        var fileSystem = new FileSystem();

        fileSystem.CreatePath("/a", 1).Should().BeTrue();

        fileSystem.Get("/B").Should().Be(-1);
    }

    [Fact]
    public void Get_NestedPathExists_ShouldReturnPathValue()
    {
        var fileSystem = new FileSystem();

        fileSystem.CreatePath("/a", 1).Should().BeTrue();

        fileSystem.CreatePath("/a/b", 2).Should().BeTrue();

        fileSystem.Get("/a/b").Should().Be(2);
    }
}