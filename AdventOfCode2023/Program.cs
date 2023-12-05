using AdventOfCode2023;

StreamReader sr = new("Days/Day5.txt");

long result = Day5.Part1(sr.ReadToEnd().Split(Environment.NewLine));

Console.WriteLine(result);

// Dest Src Offset
// Delta = destination - source
// Range = src..src + offset - 1

// Take seed
// Get range
// Get delta
// Add delta