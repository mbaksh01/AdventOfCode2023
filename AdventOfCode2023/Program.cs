// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using AdventOfCode2023;

StreamReader sr = new("Days/Day2Part1.txt");

int result = Day2.Part2(sr.ReadToEnd().Split('\n'));

Console.WriteLine(result);