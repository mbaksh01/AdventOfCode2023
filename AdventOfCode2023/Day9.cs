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
    
    // private static int GetNextValue(string row)
    // {
    //     List<int> numbers = row.Split(' ').Select(int.Parse).ToList();
    //
    //     Dictionary<int, List<int>> dictionary = new();
    //
    //     dictionary.Add(0, numbers);
    //
    //     int currentRow = 0;
    //     
    //     // repeat
    //     while (true)
    //     {
    //         dictionary.Add(currentRow + 1, new List<int> { dictionary[currentRow][1] - dictionary[currentRow][0], dictionary[currentRow][2] - dictionary[currentRow][1] });
    //
    //         if (dictionary[currentRow + 1][0] == dictionary[currentRow + 1][1])
    //         {
    //             break;
    //         }
    //
    //         foreach (int key in dictionary.Keys.Skip(1))
    //         {
    //             int diffPosition;
    //             
    //             if (key == 1)
    //             {
    //                 diffPosition = dictionary[1].Count + 1;
    //             }
    //             else
    //             {
    //                 diffPosition = dictionary[key - 1].Count - 1;
    //             }
    //             
    //             dictionary[key].Add(dictionary[key - 1][diffPosition] - dictionary[key - 1][diffPosition - 1]);
    //         }
    //         
    //         // dictionary[currentRow + 1].Add(dictionary[currentRow][3] - dictionary[currentRow][2]);
    //
    //         currentRow++;
    //     }
    //
    //     bool addToBaseList = false;
    //     
    //     while (true)
    //     {
    //         dictionary[dictionary.Count - 1].Add(dictionary[dictionary.Count - 1][^1]);
    //
    //         if (dictionary[1].Count == numbers.Count - 1)
    //         {
    //             addToBaseList = true;
    //         }
    //         
    //         for (int i = dictionary.Count - 2; i >= (addToBaseList ? 0 : 1); i--)
    //         {
    //             dictionary[i].Add(dictionary[i][^1] + dictionary[i + 1][^1]);
    //         }
    //
    //         if (addToBaseList)
    //         {
    //             break;
    //         }
    //     }
    //     
    //     return dictionary[0][^1];
    // }
    
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
}