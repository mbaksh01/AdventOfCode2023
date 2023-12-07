namespace AdventOfCode2023.Tests;

public class Day7Tests
{
    [Fact]
    public void Part1()
    {
        string[] rows =
        {
            "32T3K 765",
            "QQQJA 483",
            "T55J5 684",
            "KK677 28",
            "KTJJT 220",
        };
        
        int result = Day7.Part1(rows);
        
        Assert.Equal(6440, result);
    }
}