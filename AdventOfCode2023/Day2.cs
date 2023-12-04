namespace AdventOfCode2023;

public static class Day2
{
    public static int Part1(string[] games)
    {
        int total = 0;

        foreach (string game in games)
        {
            if (IsGameValid(game))
            {
                total += GetGameId(game);
            }
        }
        
        return total;
    }

    public static int Part2(string[] games)
    {
        int total = 0;

        foreach (string game in games)
        {
            total += GetMinCubesProduct(game);
        }
        
        return total;
    }

    private static int GetGameId(string game)
    {
        int start = game.IndexOf(' ') + 1;
        int length = game.IndexOf(':') - start;
        
        return int.Parse(game.Substring(start, length));
    }

    private static bool IsGameValid(string game)
    {
        game = game[(game.IndexOf(':') + 2)..];

        bool isValid = true;
        
        foreach (string combination in game.Split("; "))
        {
            string[] numberAndKey = combination.Trim().Split(", ");

            foreach (var numAndKey in numberAndKey)
            {
                if (isValid == false)
                {
                    return false;
                }
                
                int count = int.Parse(numAndKey.Split(" ")[0]);
                string cube = numAndKey.Split(" ")[1];

                switch (cube)
                {
                    case "blue":
                        isValid = count <= 14;
                        continue;
                    case "red":
                        isValid = count <= 12;
                        continue;
                    case "green":
                        isValid = count <= 13;
                        break;
                }
            }
        }

        return isValid;
    }

    private static int GetMinCubesProduct(string game)
    {
        game = game[(game.IndexOf(':') + 2)..];

        int minRed = 0;
        int minBlue = 0;
        int minGreen = 0;

        foreach (string combination in game.Split(';', ','))
        {
            string trimmedCombination = combination.Trim(); 
            
            int count = int.Parse(trimmedCombination.Split(' ')[0]);
            string cube = trimmedCombination.Split(' ')[1];

            if (cube == "blue" && minBlue < count)
            {
                minBlue = count;
            }
            
            if (cube == "red" && minRed < count)
            {
                minRed = count;
            }
            
            if (cube == "green" && minGreen < count)
            {
                minGreen = count;
            }
        }

        return minRed * minBlue * minGreen;
    }
}