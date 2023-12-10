namespace AdventOfCode2023;

public class Day10
{
    private static Dictionary<char, (int X, int Y)[]> _pipeDirections = new()
    {
        ['|'] = new[] { (1, 0), (-1, 0) },
        ['-'] = new[] { (0, 1), (0, -1) },
        ['L'] = new[] { (-1, 0), (0, 1) },
        ['J'] = new[] { (0, -1), (-1, 0) },
        ['7'] = new[] { (1, 0), (0, -1) },
        ['F'] = new[] { (1, 0), (0, 1) },
    };
    
    public static int Part1(string[] rows)
    {
        char[,] map = CovertToMap(rows, out (int X, int Y) startingPosition);

        int result = GetStepsToS(map, startingPosition);
        
        return result / 2;
    }
    
    private static char[,] CovertToMap(IReadOnlyList<string> rows, out (int X, int Y) startingPosition)
    {
        char[,] map = new char[rows.Count, rows[0].Length];
        startingPosition = (0, 0);

        for (int i = 0; i < rows.Count; i++)
        {
            string row = rows[i];
            
            for (int j = 0; j < row.Length; j++)
            {
                map[i, j] = row[j];

                if (row[j] == 'S')
                {
                    startingPosition = (i, j);
                }
            }
        }

        return map;
    }

    private static (int X, int Y) GetValidDirection(char[,] map, (int X, int Y) startingPosition)
    {
        if (map[startingPosition.X - 1,
                startingPosition.Y] is '|' or '7' or 'F')
        {
            return (startingPosition.X - 1, startingPosition.Y);
        }
        
        if (map[startingPosition.X + 1,
                startingPosition.Y] is '|' or 'L' or 'J')
        {
            return (startingPosition.X + 1, startingPosition.Y);
        }
        
        if (map[startingPosition.X,
                startingPosition.Y - 1] is '-' or 'L' or 'F')
        {
            return (startingPosition.X, startingPosition.Y - 1);
        }
        
        if (map[startingPosition.X,
                startingPosition.Y + 1] is '-' or 'J' or '7')
        {
            return (startingPosition.X, startingPosition.Y + 1);
        }

        throw new Exception("Could not find valid direction to move.");
    }

    private static int GetStepsToS(char[,] map, (int X, int Y) startingPosition)
    {
        int steps = 1;
        (int x, int y) currentPosition = GetValidDirection(map, startingPosition);
        (int x, int y) lastDirection = (currentPosition.x - startingPosition.X, currentPosition.y - startingPosition.Y);
        
        while (true)
        {
            steps++;

            char currentPipe = map[currentPosition.x, currentPosition.y];
            
            if (currentPipe == 'S')
            {
                break;
            }

            (int X, int Y)[] directions = _pipeDirections[currentPipe];
            
            if ((lastDirection.x + directions[0].X,
                    lastDirection.y + directions[0].Y) == (0, 0))
            {
                currentPosition.x += directions[1].X;
                currentPosition.y += directions[1].Y;
                lastDirection = (directions[1].X, directions[1].Y);
                continue;
            }
            
            currentPosition.x += directions[0].X;
            currentPosition.y += directions[0].Y;
            lastDirection = (directions[0].X, directions[0].Y);
        }
        
        return steps;
    }
}