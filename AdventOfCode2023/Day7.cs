namespace AdventOfCode2023;

public class Day7
{
    private static Dictionary<Group, List<string>> _cardGroups = new()
    {
        [Group.HighCard] = new List<string>(),
        [Group.OnePair] = new List<string>(),
        [Group.TwoPair] = new List<string>(),
        [Group.ThreeOfAKind] = new List<string>(),
        [Group.FullHouse] = new List<string>(),
        [Group.FourOfAKind] = new List<string>(),
        [Group.FiveOfAKind] = new List<string>(),
    };
    
    private static Dictionary<string, int> _cardBids = new();
    
    public static int Part1(string[] rows)
    {
        foreach (string row in rows)
        {
            SetBidAndGroup(row);
        }

        foreach (Group group in _cardGroups.Keys)
        {
            OrderGroup(group);
        }

        int total = 0;

        int rank = 1;
        
        foreach (var kvp in _cardGroups)
        {
            foreach (var hand in kvp.Value)
            {
                total += _cardBids[hand] * rank;
                rank++;
            }
        }
        
        return total;
    }

    private static void SetBidAndGroup(string row)
    {
        string[] parts = row.Split(' ');
        string hand = parts[0];
        
        _cardBids.Add(hand, int.Parse(parts[1]));

        List<IGrouping<char, char>> handValues = hand.GroupBy(c => c).ToList();

        if (handValues.Count == 1)
        {
            _cardGroups[Group.FiveOfAKind].Add(hand);
            return;
        }

        if (handValues.Count == 2)
        {
            if (handValues[0].Count() is 1 or 4)
            {
                _cardGroups[Group.FourOfAKind].Add(hand);
                return;
            }
            
            if (handValues[1].Count() is 2 or 3)
            {
                _cardGroups[Group.FullHouse].Add(hand);
                return;
            }
        }

        if (handValues.Count == 3)
        {
            if (handValues[0].Count() == 3)
            {
                if (handValues[1].Count() == 1 && handValues[2].Count() == 1)
                {
                    _cardGroups[Group.ThreeOfAKind].Add(hand);
                    return;
                }
            }
            
            if (handValues[1].Count() == 3)
            {
                if (handValues[0].Count() == 1 && handValues[2].Count() == 1)
                {
                    _cardGroups[Group.ThreeOfAKind].Add(hand);
                    return;
                }
            }
            
            if (handValues[2].Count() == 3)
            {
                if (handValues[0].Count() == 1 && handValues[1].Count() == 1)
                {
                    _cardGroups[Group.ThreeOfAKind].Add(hand);
                    return;
                }
            }
            
            if (handValues[0].Count() == 1)
            {
                if (handValues[1].Count() == 2 && handValues[2].Count() == 2)
                {
                    _cardGroups[Group.TwoPair].Add(hand);
                    return;
                }
            }
            
            if (handValues[1].Count() == 1)
            {
                if (handValues[0].Count() == 2 && handValues[2].Count() == 2)
                {
                    _cardGroups[Group.TwoPair].Add(hand);
                    return;
                }
            }
            
            if (handValues[2].Count() == 1)
            {
                if (handValues[0].Count() == 2 && handValues[1].Count() == 2)
                {
                    _cardGroups[Group.TwoPair].Add(hand);
                    return;
                }
            }
        }

        if (handValues.Count == 4)
        {
            _cardGroups[Group.OnePair].Add(hand);
            return;
        }
        
        _cardGroups[Group.HighCard].Add(hand);
    }

    private static void OrderGroup(Group group)
    {
        List<string> hands = _cardGroups[group];

        bool swapped = false;

        do
        {
            swapped = false;
            
            for (int i = 0; i < hands.Count - 1; i++)
            {
                if (IsBigger(hands[i], hands[i + 1]))
                {
                    (hands[i], hands[i + 1]) = (hands[i + 1], hands[i]);
                    swapped = true;
                }
            }
        } while (swapped);
        
    }

    private static bool IsBigger(string hand1, string hand2)
    {
        List<char> order = new()
            { 'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2' };
        
        for (int i = 0; i < hand1.Length; i++)
        {
            if (order.IndexOf(hand1[i]) < order.IndexOf(hand2[i]))
            {
                return true;
            }
            
            if (order.IndexOf(hand1[i]) > order.IndexOf(hand2[i]))
            {
                return false;
            }
        }

        return false;
    }

    enum Group
    {
        FiveOfAKind,
        FourOfAKind,
        ThreeOfAKind,
        TwoPair,
        OnePair,
        FullHouse,
        HighCard,
    }
}