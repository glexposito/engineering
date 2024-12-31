using Design;
using FluentAssertions;

namespace Tests;

public class TopVotedCandidateTests
{
    [Fact]
    public void TopVotedCandidate_ShouldReturnCorrectResults()
    {
        // Arrange
        int[] persons = [0, 1, 1, 0, 0, 1, 0];
        int[] times = [0, 5, 10, 15, 20, 25, 30];
        var topVotedCandidate = new TopVotedCandidate(persons, times);

        // Act & Assert
        topVotedCandidate.Q(3).Should().Be(0, "at time 3, the votes are [0], and 0 is leading");
        topVotedCandidate.Q(12).Should().Be(1, "at time 12, the votes are [0,1,1], and 1 is leading");
        topVotedCandidate.Q(25).Should().Be(1, "at time 25, the votes are [0,1,1,0,0,1], and 1 is leading");
        topVotedCandidate.Q(15).Should().Be(0, "at time 15, 0 is leading");
        topVotedCandidate.Q(24).Should().Be(0, "at time 24, 0 is leading");
        topVotedCandidate.Q(8).Should().Be(1, "at time 8, 1 is leading");
    }
}