using Design;
using FluentAssertions;

namespace Tests;

public class LoggerTests
{
    [Fact]
    public void Test()
    {
        var logger = new Logger();
        logger.ShouldPrintMessage(1, "foo").Should().BeTrue();  // return true, next allowed timestamp for "foo" is 1 + 10 = 11
        logger.ShouldPrintMessage(2, "bar").Should().BeTrue();  // return true, next allowed timestamp for "bar" is 2 + 10 = 12
        logger.ShouldPrintMessage(3, "foo").Should().BeFalse();  // 3 < 11, return false
        logger.ShouldPrintMessage(8, "bar").Should().BeFalse();  // 8 < 12, return false
        logger.ShouldPrintMessage(10, "foo").Should().BeFalse(); // 10 < 11, return false
        logger.ShouldPrintMessage(11, "foo").Should().BeTrue(); // 11 >= 11, return true, next allowed timestamp for "foo" is 11 + 10 = 21
    }
}