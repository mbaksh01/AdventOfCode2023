namespace AdventOfCode2023;

public static class Day1
{
    private static Dictionary<string, int> _numbersAsStrings = new()
    {
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 },
    };
    
    public static string Part1(string[] rows)
    {
        return rows
            .Sum(row => int.Parse($"{GetFirstNumber(row)}{GetLastNumber(row)}"))
            .ToString();
    }

    public static string Part2(string[] rows)
    {
        int total = 0;
        
        foreach (string row in rows)
        {
            int val = int.Parse($"{GetFirstNumber(row)}{GetLastNumber(row)}");
            total += val;
        }

        return total.ToString();
    }

    private static int GetFirstNumber(string row)
    {
        string numberAsWord = string.Empty;
        
        foreach (char character in row)
        {
            if (int.TryParse(character.ToString(), out int num))
            {
                return num;
            }

            numberAsWord += character;
            
            if (_numbersAsStrings.Keys.Any(k => numberAsWord.Contains(k)))
            {
                return _numbersAsStrings[_numbersAsStrings.Keys.First(k => numberAsWord.Contains(k))];
            }
        }

        throw new InvalidOperationException("No number found in sequence.");
    }

    private static int GetLastNumber(string row)
    {
        string numberAsWord = string.Empty;
        
        for (int i = row.Length - 1; i >= 0; i--)
        {
            if (int.TryParse(row[i].ToString(), out int num))
            {
                return num;
            }

            numberAsWord = numberAsWord.Insert(0, row[i].ToString());
            
            if (_numbersAsStrings.Keys.Any(k => numberAsWord.Contains(k)))
            {
                return _numbersAsStrings[_numbersAsStrings.Keys.First(k => numberAsWord.Contains(k))];
            }
        }
        
        throw new InvalidOperationException("No number found in sequence.");
    }
}