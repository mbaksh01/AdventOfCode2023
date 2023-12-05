using AdventOfCode2023;

StreamReader sr = new("Days/Day4.txt");

int result = Day4.Part2(sr.ReadToEnd().Split(Environment.NewLine));

Console.WriteLine(result);