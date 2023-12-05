using System.Buffers;
using System.Reflection.Metadata.Ecma335;

namespace AdventOfCode2023;

public static class Day5
{
    private static Dictionary<string, Dictionary<Range, long>?> _mapNames = new()
    {
        { "seed-to-soil", null },
        { "soil-to-fertilizer", null },
        { "fertilizer-to-water", null },
        { "water-to-light", null },
        { "light-to-temperature", null },
        { "temperature-to-humidity", null },
        { "humidity-to-location", null },
    };
    
    public static long Part1(string[] rows)
    {
        IEnumerable<long> positions = rows[0].Substring(rows[0].IndexOf(':') + 2).Split(' ')
            .Select(num => long.Parse(num));

        long lowestLocation = long.MaxValue;

        foreach (long position in positions)
        {
            long location = GetLocationFromPosition(rows, "seed-to-soil", position);

            if (location < lowestLocation)
            {
                lowestLocation = location;
            }
        }

        return lowestLocation;
    }

    public static long Part2(string[] rows)
    {
        ArraySegment<long> positions = GetLocations(rows[0]);

        long lowestLocation = long.MaxValue;

        long count = 1;
        
        foreach (long position in positions)
        {
            long location = GetLocationFromPosition(rows, "seed-to-soil", position);
            
            if (location < lowestLocation)
            {
                lowestLocation = location;
                Console.WriteLine(lowestLocation);
            }
        }

        return lowestLocation;
    }

    private static ArraySegment<long> GetLocations(string row)
    {
        string[] positionRanges =
            row.Substring(row.IndexOf(':') + 2).Split(' ');

        int totalPositions = 0;
        
        for (int i = 1; i < positionRanges.Length; i+=2)
        {
            totalPositions += int.Parse(positionRanges[i]);
        }

        long[] positions = ArrayPool<long>.Shared.Rent(totalPositions);

        int position = 0;
        
        for (int i = 0; i < positionRanges.Length; i+=2)
        {
            long start = long.Parse(positionRanges[i]);
            long range = long.Parse(positionRanges[i + 1]);

            for (long j = start; j < start + range; j++)
            {
                positions[position] = j;
                position++;
            }
        }

        Console.WriteLine($"Total positions: {positions.Length}");
        
        return new ArraySegment<long>(positions, 0, totalPositions);
    }

    private static Dictionary<Range, long> CreateMap(string mapName, IReadOnlyList<string> rows)
    {
        Dictionary<Range, long> map = new();

        bool mapFound = false;
        
        foreach (string row in rows)
        {
            if (row == $"{mapName} map:")
            {
                mapFound = true;
                continue;
            }
            
            if (string.IsNullOrWhiteSpace(row) && mapFound)
            {
                break;
            }

            if (mapFound == false)
            {
                continue;
            }
            
            KeyValuePair<Range, long> kvp = ConvertRowToMapRow(row);
            map.Add(kvp.Key, kvp.Value);
        }
        
        return map;
    }

    private static KeyValuePair<Range, long> ConvertRowToMapRow(string row)
    {
        string[] values = row.Split(' ');
        
        long destination = long.Parse(values[0]);
        long source = long.Parse(values[1]);
        long offset = long.Parse(values[2]);

        return new KeyValuePair<Range, long>(
            new Range(source, source + offset - 1),
            destination - source);
    }

    private static long GetLocationFromPosition(IReadOnlyList<string> rows, string mapName, long position)
    {
        Dictionary<Range, long> map = GetOrCreateMap(mapName, rows);

        // for (int i = 0; i < map.Keys.Count; i++)
        // {
        //     var key = map.Keys.ElementAt(i);
        //     bool inRange = key.IsInRange(position);
        //
        //     if (inRange)
        //     {
        //         Console.WriteLine($"Match found: {i}/{map.Keys.Count}");
        //         position += map[key];
        //         break;
        //     }
        // }
        
        long delta = map.FirstOrDefault(kvp => kvp.Key.IsInRange(position),
                new(new Range(0, 1), 0))
            .Value;
        
        position += delta;

        if (mapName == "humidity-to-location")
        {
            return position;
        }

        return GetLocationFromPosition(rows, GetNextMapName(mapName), position);
    }

    private static string GetNextMapName(string mapName)
    {
        return mapName switch
        {
            "seed-to-soil" => "soil-to-fertilizer",
            "soil-to-fertilizer" => "fertilizer-to-water",
            "fertilizer-to-water" => "water-to-light",
            "water-to-light" => "light-to-temperature",
            "light-to-temperature" => "temperature-to-humidity",
            "temperature-to-humidity" => "humidity-to-location",
            _ => string.Empty,
        };
    }

    private static Dictionary<Range, long> GetOrCreateMap(string mapName, IReadOnlyList<string> rows)
    {
        return _mapNames[mapName] ??= CreateMap(mapName, rows);
    }

    private readonly record struct Range(long Start, long End)
    {
        public bool IsInRange(long value)
        {
            return value >= Start && value <= End;
        } 
    }
}