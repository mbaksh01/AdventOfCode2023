namespace AdventOfCode2023;

public class Day3
{
    private static Dictionary<Point, List<int>> _gearParts = new();
    
    public static int Part1(string[] rows)
    {
        char[,] map = CovertToMap(rows);
        int total = 0;

        int length = map.GetLength(0);
        
        for (int i = 0; i < length; i++)
        {
            total += GetRowPartNumberSum(map, i);
        }
        
        return total;
    }

    public static int Part2(string[] rows)
    {
        char[,] map = CovertToMap(rows);

        int length = map.GetLength(0);
        
        for (int i = 0; i < length; i++)
        {
            _ = GetRowPartNumberSum(map, i);
        }

        int total = 0;
        
        foreach (var list in _gearParts.Values.Where(l => l.Count == 2))
        {
            total += list[0] * list[1];
        }
        
        return total;
    }

    private static char[,] CovertToMap(IReadOnlyList<string> rows)
    {
        char[,] map = new char[rows.Count, rows[0].Length];

        for (int i = 0; i < rows.Count; i++)
        {
            string row = rows[i];
            
            for (int j = 0; j < row.Length; j++)
            {
                map[i, j] = row[j];

                if (row[j] == '*')
                {
                    _gearParts.Add(new Point(i, j), new List<int>());
                }
            }
        }

        return map;
    }

    private static int GetRowPartNumberSum(char[,] map, int rowToSearch)
    {
        string currentNumber = string.Empty;
        bool symbolFound = false;
        bool gearFound = false;
        Point gearPoint = new Point(-1, -1);
        int rowTotal = 0;

        for (int j = 0; j < map.GetLength(1); j++)
        {
            string value = map[rowToSearch, j].ToString();
            
            if (int.TryParse(value, out _))
            {
                currentNumber += value;

                if (symbolFound == false)
                {
                    symbolFound = IsSymbolNearby(map, rowToSearch, j);
                }
                
                if (gearFound == false)
                {
                    gearFound = IsGearNearby(map, rowToSearch, j, out gearPoint);
                }
                
                continue;
            }

            if (string.IsNullOrEmpty(currentNumber) == false && symbolFound)
            {
                int val = int.Parse(currentNumber);
                rowTotal += val;
                symbolFound = false;
                Console.WriteLine(val);

                if (gearFound)
                {
                    _gearParts[gearPoint].Add(val);
                    gearFound = false;
                    gearPoint = new Point(-1, -1);
                }
            }

            currentNumber = string.Empty;
        }
        
        if (string.IsNullOrEmpty(currentNumber) == false && symbolFound)
        {
            int val = int.Parse(currentNumber);
            rowTotal += val;
            Console.WriteLine(val);
            
            if (gearFound)
            {
                _gearParts[gearPoint].Add(val);
                gearFound = false;
                gearPoint = new Point(-1, -1);
            }
        }
        
        return rowTotal;
    }

    private static bool IsSymbolNearby(char[,] map, int x, int y)
    {
        char[] symbols = { '*', '#', '+', '$', '@', '%', '/', '&', '=', '-' };

        if (x + 1 < map.GetLength(0))
        {
            if (symbols.Contains(map[x + 1, y]))
            {
                return true;
            }

            if (y + 1 < map.GetLength(1))
            {
                if (symbols.Contains(map[x + 1, y + 1]))
                {
                    return true;
                }
            }
        }

        if (x - 1 > -1)
        {
            if (symbols.Contains(map[x - 1, y]))
            {
                return true;
            }

            if (y - 1 > -1)
            {
                if (symbols.Contains(map[x - 1, y - 1]))
                {
                    return true;
                }
            }
        }

        if (y + 1 < map.GetLength(1))
        {
            if (symbols.Contains(map[x, y + 1]))
            {
                return true;
            }
            
            if (x - 1 > -1)
            {
                if (symbols.Contains(map[x - 1, y + 1]))
                {
                    return true;
                }
            }
        }

        if (y - 1 > -1)
        {
            if (symbols.Contains(map[x, y - 1]))
            {
                return true;
            }

            if (x + 1 < map.GetLength(0))
            {
                if (symbols.Contains(map[x + 1, y - 1]))
                {
                    return true;
                }
            }
        }

        return false;
    }
    
    private static bool IsGearNearby(char[,] map, int x, int y, out Point point)
    {
        char[] symbols = { '*' };

        if (x + 1 < map.GetLength(0))
        {
            if (symbols.Contains(map[x + 1, y]))
            {
                point = new Point(x + 1, y);
                return true;
            }

            if (y + 1 < map.GetLength(1))
            {
                if (symbols.Contains(map[x + 1, y + 1]))
                {
                    point = new Point(x + 1, y + 1);
                    return true;
                }
            }
        }

        if (x - 1 > -1)
        {
            if (symbols.Contains(map[x - 1, y]))
            {
                point = new Point(x - 1, y);
                return true;
            }

            if (y - 1 > -1)
            {
                if (symbols.Contains(map[x - 1, y - 1]))
                {
                    point = new Point(x - 1, y - 1);
                    return true;
                }
            }
        }

        if (y + 1 < map.GetLength(1))
        {
            if (symbols.Contains(map[x, y + 1]))
            {
                point = new Point(x, y + 1);
                return true;
            }
            
            if (x - 1 > -1)
            {
                if (symbols.Contains(map[x - 1, y + 1]))
                {
                    point = new Point(x - 1, y + 1);
                    return true;
                }
            }
        }

        if (y - 1 > -1)
        {
            if (symbols.Contains(map[x, y - 1]))
            {
                point = new Point(x, y - 1);
                return true;
            }

            if (x + 1 < map.GetLength(0))
            {
                if (symbols.Contains(map[x + 1, y - 1]))
                {
                    point = new Point(x + 1, y - 1);
                    return true;
                }
            }
        }

        point = new Point(-1, -1);
        return false;
    }

    record struct Point(int X, int Y);
}