namespace AdventOfCode2023.Tests;

public class Day3Tests
{
    [Fact]
    public void Part1()
    {
        string[] rows =
        {
            "467..114..",
            "...*......",
            "..35...633",
            ".......#..",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$....*.",
            ".664.598..",
        };

        int result = Day3.Part1(rows);
        
        Assert.Equal(4361, result);
    }
    
    [Fact]
    public void Part2()
    {
        string[] rows =
        {
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598..",
        };

        int result = Day3.Part2(rows);
        
        Assert.Equal(467835, result);
    }
}