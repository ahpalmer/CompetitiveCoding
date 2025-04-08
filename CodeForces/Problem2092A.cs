using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitiveProgramming.CodeForces
{
    public class Problem2092A
    {
        public static void TestProblem2092A(string[] args)
        {
            List<List<int>> inputs = GetStandardInput();
            List<int> answers = new List<int>();
            for (int i = 1; i < inputs.Count / 2; i = i + 2)
            {
                answers.Add(inputs.Max() - inputs.Min());
            }
            foreach (int answer in answers)
            {
                Console.WriteLine(answer);
            }
        }

        public static List<List<int>> GetStandardInput()
        {
            // Input looks like this:
            // 4
            //2
            //1 3
            //5
            //5 4 3 2 1
            //3
            //5 6 7
            //3
            //1 11 10
            //int n = Int32.Parse(Console.ReadLine()); // First line tells how many more lines to read
            //List<string> inputs = new List<string>();
            //for (int i = 0; i < n; i++)
            //{
            //    // Read exactly n lines
            //    inputs.Add(Console.ReadLine().ToString());
            //}

            List<string> inputs = GetTestInput();

            List<List<int>> finalInputs = new List<List<int>>();
            foreach (string input in inputs)
            {
                finalInputs.Add(input.Split().Select(int.Parse).ToList());
            }

            return finalInputs;
        }

        public static List<string> GetTestInput()
        {
            return new List<string>
            {
                "2",
                "1 3",
                "5",
                "5 4 3 2 1",
                "3",
                "5 6 7",
                "3",
                "1 11 10"

            };
        }
    }
}
