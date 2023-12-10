namespace AdventOfCode2023.Tests;

public class Day10Tests
{
    [Fact]
    public void Part1_0()
    {
        string[] rows =
        {
            "-L|F7",
            "7S-7|",
            "L|7||",
            "-L-J|",
            "L|-JF",
        };

        int result = Day10.Part1(rows);
        
        Assert.Equal(4, result);
    }
    
    [Fact]
    public void Part1_1()
    {
        string[] rows =
        {
            "7-F7-",
            ".FJ|7",
            "SJLL7",
            "|F--J",
            "LJ.LJ",
        };

        int result = Day10.Part1(rows);
        
        Assert.Equal(8, result);
    }
}