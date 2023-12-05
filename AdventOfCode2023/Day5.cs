namespace AdventOfCode2023;

public static class Day5
{
    private static string[] _mapNames = 
    {
        "seed-to-soil",
        "soil-to-fertilizer",
        "fertilizer-to-water",
        "water-to-light",
        "light-to-temperature",
        "temperature-to-humidity",
        "humidity-to-location",
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

    private static long GetLocationFromPosition(string[] rows, string mapName, long position)
    {
        Dictionary<Range, long> map = CreateMap(mapName, rows);
        
        long delta = map.FirstOrDefault(kvp =>
                position >= kvp.Key.Start &&
                position <= kvp.Key.End, new(new Range(0, 1), 0))
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
        for (int i = 0; i < _mapNames.Length; i++)
        {
            if (_mapNames[i] == mapName)
            {
                return _mapNames[i + 1];
            }
        }

        return string.Empty;
    }

    record struct Range(long Start, long End);
}