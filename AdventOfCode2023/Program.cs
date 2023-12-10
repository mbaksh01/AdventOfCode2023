using AdventOfCode2023;

ThreadPool.SetMinThreads(50, 50);
StreamReader sr = new("Days/Day10.txt");

long result = Day10.Part1(sr.ReadToEnd().Split(Environment.NewLine));

Console.WriteLine(result);

Console.ReadLine();