﻿namespace AdventOfCode2023.Tests;

public class Day9Tests
{
    [Fact]
    public void Part1()
    {
        string[] rows =
        {
            "0 3 6 9 12 15",
            "1 3 6 10 15 21",
            "10 13 16 21 30 45",
        };

        int result = Day9.Part1(rows);
        
        Assert.Equal(114, result);
    }
    
    [Fact]
    public void Part2()
    {
        string[] rows =
        {
            "0 3 6 9 12 15",
            "1 3 6 10 15 21",
            "10 13 16 21 30 45",
        };

        int result = Day9.Part2(rows);
        
        Assert.Equal(2, result);
    }
}