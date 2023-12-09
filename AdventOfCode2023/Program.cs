using AdventOfCode2023;

ThreadPool.SetMinThreads(50, 50);
StreamReader sr = new("Days/Day9.txt");

long result = Day9.Part2(sr.ReadToEnd().Split(Environment.NewLine));

Console.WriteLine(result);

Console.ReadLine();

// Dest Src Offset
// Delta = destination - source
// Range = src..src + offset - 1

// Take seed
// Get range
// Get delta
// Add delta