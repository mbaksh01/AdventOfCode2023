using AdventOfCode2023;

ThreadPool.SetMinThreads(50, 50);
StreamReader sr = new("Days/Day6.txt");

long result = Day6.Part2(sr.ReadToEnd().Split(Environment.NewLine));

Console.WriteLine(result);

// Dest Src Offset
// Delta = destination - source
// Range = src..src + offset - 1

// Take seed
// Get range
// Get delta
// Add delta