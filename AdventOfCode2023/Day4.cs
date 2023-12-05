namespace AdventOfCode2023;

public class Day4
{
    private static Dictionary<string, int> _cardCount = new();
    
    public static int Part1(string[] cards)
    {
        int total = 0;

        foreach (string row in cards)
        {
            total += GetRowPoints(row);
        }
        
        return total;
    }

    public static int Part2(string[] cards)
    {
        foreach (string card in cards)
        {
            _cardCount.Add(GetCardId(card), 1);
        }
        
        for (int i = 0; i < cards.Length; i++)
        {
            string card = cards[i];
            int[] winningNumbers = GetRowWinningNumbers(card);

            for (int j = 1; j <= winningNumbers.Length; j++)
            {
                string cardId = _cardCount.ElementAt(i + j).Key;
                _cardCount[cardId] += 1 * _cardCount[GetCardId(card)];
            }
        }
        
        return _cardCount.Values.Sum();
    }

    private static string GetCardId(string card)
    {
        return card.Substring(0, card.IndexOf(':'));
    }
    
    private static int GetRowPoints(string card)
    {
        int[] winningNumbers = GetRowWinningNumbers(card);

        if (winningNumbers.Length == 1)
        {
            return 1;
        }

        return (int)(1 * Math.Pow(2, winningNumbers.Length - 1));
    }

    private static int[] GetRowWinningNumbers(string card)
    {
        card = card.Substring(card.IndexOf(':') + 2);

        string[] numbers = card.Split('|');

        List<int> winningNumbers = new List<int>();
        List<int> myNumbers = new List<int>();

        foreach (string number in numbers[0].Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            myNumbers.Add(int.Parse(number));
        }
        
        foreach (string winningNumber in numbers[1].Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            winningNumbers.Add(int.Parse(winningNumber));
        }

        return myNumbers.Where(n => winningNumbers.Contains(n)).ToArray();
    }
}