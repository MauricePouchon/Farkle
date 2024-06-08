using System.Diagnostics.Metrics;

namespace Farkle
{
    internal class Calculator
    {
        List<int> sortedDice = new List<int>();

        private int selectedScore;

        public int Calculate(List<Dice> dice)
        {
            selectedScore = 0;
            sortedDice.Clear();

            foreach (Dice d in dice)
            {
                if (d.isSelected)
                {
                    sortedDice.Add(d.value);
                }
            }

            sortedDice.Sort();
            selectedScore += StraightRow();
            selectedScore += SameOfKind();

            if (!sortedDice.All(d => (d == 1 || d == 5)))
            {
                return 0;
            }
            foreach (int i in sortedDice)
            {
                if (i == 1)
                {
                    selectedScore += 100;
                }
                else if (i == 5)
                {
                    selectedScore += 50;
                }
            }
            return selectedScore;
        }

        private int SameOfKind()
        {
            int result = 0;
            var groups = sortedDice.GroupBy(d => d);
            foreach (var group in groups)
            {
                if (group.Count() >= 3)
                {
                    result += CalculateSameOfKind(group.Key, group.Count());
                    sortedDice = sortedDice.Where(d => d != group.Key).ToList();
                };
            }
            return result;
        }

        private int CalculateSameOfKind(int number, int count) => (int)(number * (number == 1 ? 1000 : 100) * Math.Pow(2, count - 3));

        private int StraightRow()
        {
            int lastNumber = -1;
            int counter = 1;

            var unique = sortedDice.Distinct().ToList();
            foreach (int number in unique)
            {
                if (number == lastNumber + 1)
                {
                    counter++;
                }
                lastNumber = number;
            }
            if (counter >= 5)
            {
                sortedDice = sortedDice.Except(unique).ToList();
                if (unique.Contains(1))
                {
                    if (counter == 6)
                    {
                        return 1500;
                    }
                    return 500;
                }
                return 750;
            }
            return 0;
        }
    }
}