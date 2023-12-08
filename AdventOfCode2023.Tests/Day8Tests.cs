﻿namespace AdventOfCode2023.Tests;

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

    [Fact]
    public void Part2()
    {
        string[] rows =
        {
            "LR",
            "",
            "11A = (11B, XXX)",
            "11B = (XXX, 11Z)",
            "11Z = (11B, XXX)",
            "22A = (22B, XXX)",
            "22B = (22C, 22C)",
            "22C = (22Z, 22Z)",
            "22Z = (22B, 22B)",
            "XXX = (XXX, XXX)",
        };

        int result = Day8.Part2(rows);
        
        Assert.Equal(6, result);
    }
}