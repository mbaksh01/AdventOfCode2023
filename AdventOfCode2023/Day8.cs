using System.Runtime.InteropServices;

namespace AdventOfCode2023;

public class Day8
{
    private static string _moves = string.Empty;
    private static Dictionary<string, (string Left, string Right)> _map = new();
    private static List<string> _startingPositions = new();
    private static int loopCount = 0;

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

    public static int Part2(string[] rows)
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

        int steps = FindAllEndInZCount(0, CollectionsMarshal.AsSpan(_startingPositions));
        
        return steps;
    }

    private static int GetStepsToZZZ(string startingPosition, int movePosition)
    {
        if (movePosition == _moves.Length)
        {
            movePosition = 0;
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

    private static int FindAllEndInZCount(int movePosition, Span<string> startingPositionsSpan)
    {
        int stepCount = 1;

        while (true)
        {
            if (movePosition == _moves.Length)
            {
                movePosition = 0;
                loopCount++;
                Console.WriteLine(loopCount);
            }
            
            bool shouldRepeat = false;
            
            for (int i = 0; i < startingPositionsSpan.Length; i++)
            {
                string startingPosition = startingPositionsSpan[i];
                
                if (_moves[movePosition] == 'L')
                {
                    startingPositionsSpan[i] = _map[startingPosition].Left;
                }
                else
                {
                    startingPositionsSpan[i] = _map[startingPosition].Right;
                }
                
                if (startingPositionsSpan[i][^1] != 'Z')
                {
                    shouldRepeat = true;
                }
            }

            if (shouldRepeat == false)
            {
                break;
            }

            stepCount++;
            movePosition++;
        }
        
        return stepCount;
    }

    private static void AddRowToDictionary(string row)
    {
        string[] miniMap = row.Split("=");

        string[] leftAndRight = miniMap[1].Substring(2, 8).Split(',');

        string mapId = miniMap[0].Trim();

        _map.Add(mapId, (leftAndRight[0].Trim(), leftAndRight[1].Trim()));

        if (mapId[^1] == 'A')
        {
            _startingPositions.Add(mapId);
        }
    }
}