namespace AdventOfCode2023.Tests;

public class Day6Tests
{
    [Fact]
    public void Part1()
    {
        string[] rows =
        {
            "Time:      7  15   30",
            "Distance:  9  40  200",
        };

        int result = Day6.Part1(rows);
        
        Assert.Equal(288, result);
    }
}