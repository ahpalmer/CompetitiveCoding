using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CompetitiveProgramming.CodeForces
{
    public class Problem231B
    {
        public static void Main(string[] args)
        {
            List<int> inputs = GetInput();
            List<int> cards = new List<int>();
            int currentTotal = 0;
            bool secondToLast = false;

            for (int i = 0; i < inputs[0]; i++)
            {
                if (i == inputs[0] - 2)
                {
                    secondToLast = true;
                }

                if (i % 2 == 0)
                {
                    cards.Add(OddCalculation(inputs, cards, currentTotal, secondToLast));
                    currentTotal = AddCards(cards);
                    secondToLast = false;
                }
                else
                {
                    cards.Add(EvenCalculation(inputs, cards, currentTotal, secondToLast));
                    currentTotal = AddCards(cards);
                    secondToLast = false;
                }
            }
            int finalTotal = AddCards(cards);
            if (cards.Any(i => i < 1))
            {
                Console.WriteLine("-1");
            }
            else if (finalTotal == inputs[1])
            {
                string result = string.Join(" ", cards);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("-1");
            }
        }

        public static int OddCalculation(List<int> inputs, List<int> cards, int currentTotal, bool secondToLast)
        {
            int finalValue = inputs[1];
            int maxValue = inputs[2];
            if (currentTotal + 1 <= finalValue && finalValue <= currentTotal + maxValue)
            {
                int nextCard = finalValue - currentTotal;
                if (secondToLast && (currentTotal + nextCard) == finalValue)
                {
                    if (nextCard >= maxValue)
                    {
                        nextCard--;
                    }
                    else
                    {
                        nextCard++;
                    }
                }
                return nextCard;
            }
            else if (currentTotal + 1 > finalValue)
            {
                return 1;
            }
            else if (currentTotal + maxValue < finalValue)
            {
                return maxValue;
            }
            else
            {
                return 0;
            }
        }

        public static int EvenCalculation(List<int> inputs, List<int> cards, int currentTotal, bool secondToLast)
        {
            int finalValue = inputs[1];
            int maxValue = inputs[2];
            if (currentTotal - 1 >= finalValue && finalValue >= currentTotal - maxValue)
            {
                int nextCard = currentTotal - finalValue;
                if (secondToLast && (currentTotal - nextCard) == finalValue)
                {
                    if (nextCard >= maxValue)
                    {
                        nextCard--;
                    }
                    else
                    {
                        nextCard++;
                    }
                }
                return nextCard;
            }
            else if (currentTotal - 1 < finalValue)
            {
                return 1;
            }
            else if (currentTotal - maxValue > finalValue)
            {
                return maxValue;
            }
            else
            {
                return 0;
            }
        }

        public static int AddCards(List<int> cards)
        {
            int total = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                if (i % 2 == 0)
                {
                    total = total + cards[i];
                }
                else
                {
                    total = total - cards[i];
                }
            }

            return total;
        }

        public static List<int> GetInput()
        {
            string inputRaw = Console.ReadLine().ToString();
            List<int> finalInputs = new List<int>();

            finalInputs = inputRaw.Split().Select(int.Parse).ToList();

            return finalInputs;
        }
    }
}
