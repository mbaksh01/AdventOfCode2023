using AdventOfCode2023;

ThreadPool.SetMinThreads(50, 50);
StreamReader sr = new("Days/Day8.txt");

long result = Day8.Part1(sr.ReadToEnd().Split(Environment.NewLine));

Console.WriteLine(result);

// Dest Src Offset
// Delta = destination - source
// Range = src..src + offset - 1

// Take seed
// Get range
// Get delta
// Add delta