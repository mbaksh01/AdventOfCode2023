namespace AdventOfCode2023;

public class Day6
{
    public static int Part1(string[] rows)
    {
        (int length, int distance)[] values = GetValuesFromRow(rows);

        int total = 1;
        
        foreach ((int length, int distance) in values)
        {
            total *= GetWinningCombinationCount(length, distance);
        }

        return total;
    }

    public static int Part2(string[] rows)
    {
        (long length, long distance) = GetValuesFromRow2(rows);

        return GetWinningCombinationCount(length, distance);
    }

    private static (int length, int distance)[] GetValuesFromRow(string[] rows)
    {
        string[] times = rows[0].Substring(rows[0].IndexOf(":") + 1).Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] distances = rows[1].Substring(rows[1].IndexOf(":") + 1).Split(' ', StringSplitOptions.RemoveEmptyEntries);

        List<(int length, int distance)> pairs = new();
        
        for (int i = 0; i < times.Length; i++)
        {
            pairs.Add((int.Parse(times[i]), int.Parse(distances[i])));
        }

        return pairs.ToArray();
    }
    
    private static (long length, long distance) GetValuesFromRow2(string[] rows)
    {
        string[] times = rows[0].Substring(rows[0].IndexOf(":") + 1).Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] distances = rows[1].Substring(rows[1].IndexOf(":") + 1).Split(' ', StringSplitOptions.RemoveEmptyEntries);

        string length = string.Empty;
        string distance = string.Empty;
        
        for (int i = 0; i < times.Length; i++)
        {
            length += times[i];
            distance += distances[i];
        }

        return (long.Parse(length), long.Parse(distance));
    }

    private static int GetWinningCombinationCount(long length, long distance)
    {
        int winningCombinationsCount = 0;

        for (int i = 1; i <= length; i++)
        {
            if (i * (length - i) > distance)
            {
                winningCombinationsCount++;
            }
        }

        return winningCombinationsCount;
    }
}