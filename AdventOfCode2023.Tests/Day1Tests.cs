namespace AdventOfCode2023.Tests;

public class Day1Tests
{
    [Fact]
    public void Part1()
    {
        string[] rows =
        {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet",
        };

        var result = Day1.Part1(rows);
        
        Assert.Equal("142", result);
    }

    [Fact]
    public void Part2()
    {
        string[] rows =
        {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen",
        };

        var result = Day1.Part2(rows);
        
        Assert.Equal("281", result);
    }
}