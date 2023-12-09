namespace AdventOfCode2023;

public class Day9
{
    public static int Part1(string[] rows)
    {
        int total = 0;

        foreach (string row in rows)
        {
            total += GetNextValue(row);
        }
        
        return total;
    }
    
    public static int Part2(string[] rows)
    {
        int total = 0;

        foreach (string row in rows)
        {
            total += GetPreviousValue(row);
        }
        
        return total;
    }
    
    private static int GetNextValue(string row)
    {
        List<int> numbers = row.Split(' ').Select(int.Parse).ToList();

        Dictionary<int, List<int>> dictionary = new();

        dictionary.Add(0, numbers);

        int currentRow = 0;
        
        while (true)
        {
            dictionary.Add(currentRow + 1, new List<int>());
            
            for (int i = 0; i < dictionary[currentRow].Count - 1; i++)
            {
                dictionary[currentRow + 1].Add(dictionary[currentRow][i + 1] - dictionary[currentRow][i]);
            }

            currentRow++;
            
            if (dictionary[currentRow].Distinct().Count() == 1)
            {
                break;
            }
        }
        
        dictionary[currentRow].Add(dictionary[currentRow][^1]);
        
        for (int i = dictionary.Count - 2; i >= 0; i--)
        {
            dictionary[i].Add(dictionary[i][^1] + dictionary[i + 1][^1]);
        }
        
        return dictionary[0][^1];
    }
    
    private static int GetPreviousValue(string row)
    {
        List<int> numbers = row.Split(' ').Select(int.Parse).ToList();

        Dictionary<int, List<int>> dictionary = new();

        dictionary.Add(0, numbers);

        int currentRow = 0;
        
        while (true)
        {
            dictionary.Add(currentRow + 1, new List<int>());
            
            for (int i = 0; i < dictionary[currentRow].Count - 1; i++)
            {
                dictionary[currentRow + 1].Add(dictionary[currentRow][i + 1] - dictionary[currentRow][i]);
            }

            currentRow++;
            
            if (dictionary[currentRow].Distinct().Count() == 1)
            {
                break;
            }
        }
        
        dictionary[currentRow].Insert(0, dictionary[currentRow][^1]);
        
        for (int i = dictionary.Count - 2; i >= 0; i--)
        {
            dictionary[i].Insert(0, dictionary[i][0] - dictionary[i + 1][0]);
        }
        
        return dictionary[0][0];
    }
}