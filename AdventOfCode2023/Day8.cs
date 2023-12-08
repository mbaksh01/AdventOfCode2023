namespace AdventOfCode2023;

public class Day8
{
    private static string _moves = string.Empty;
    private static Dictionary<string, (string Left, string Right)> _map = new();
    private static int positionResetCount = 0;

    public static int Part1(string[] rows)
    {
        bool isMap = false;
        
        foreach (string row in rows)
        {
            if (string.IsNullOrWhiteSpace(row))
            {
                isMap = true;
                continue;
            }

            if (isMap)
            {
                AddRowToDictionary(row);
            }
            else
            {
                _moves += row;
            }
        }

        int steps = GetStepsToZZZ("AAA", 0);
        
        return steps;
    }

    private static int GetStepsToZZZ(string startingPosition, int movePosition)
    {
        if (movePosition == _moves.Length)
        {
            movePosition = 0;
            positionResetCount++;
        }

        char step = _moves[movePosition];

        string nextPosition;

        int stepCount = 1;

        if (step == 'L')
        {
            nextPosition = _map[startingPosition].Left;
        }
        else
        {
            nextPosition = _map[startingPosition].Right;
        }

        if (nextPosition == "ZZZ")
        {
            return stepCount;
        }

        movePosition++;
        
        stepCount += GetStepsToZZZ(nextPosition, movePosition);

        return stepCount;
    }

    private static void AddRowToDictionary(string row)
    {
        string[] miniMap = row.Split("=");

        string[] leftAndRight = miniMap[1].Substring(2, 8).Split(',');
        
        _map.Add(miniMap[0].Trim(), (leftAndRight[0].Trim(), leftAndRight[1].Trim()));
    }
}