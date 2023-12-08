namespace AdventOfCode2023.Tests;

public class Day8Tests
{
    [Fact]
    public void Part1_0()
    {
        string[] rows =
        {
            "RL",
            "",
            "AAA = (BBB, CCC)",
            "BBB = (DDD, EEE)",
            "CCC = (ZZZ, GGG)",
            "DDD = (DDD, DDD)",
            "EEE = (EEE, EEE)",
            "GGG = (GGG, GGG)",
            "ZZZ = (ZZZ, ZZZ)",
        };

        int result = Day8.Part1(rows);
        
        Assert.Equal(2, result);
    }
    
    [Fact]
    public void Part1_1()
    {
        string[] rows =
        {
            "LLR",
            "",
            "AAA = (BBB, BBB)",
            "BBB = (AAA, ZZZ)",
            "ZZZ = (ZZZ, ZZZ)",
        };

        int result = Day8.Part1(rows);
        
        Assert.Equal(6, result);
    }
}