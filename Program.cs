using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CompetitiveProgramming
{
    public class Program
    {
        static void ProgrammingTeamEntryPoint()
        {
            // Check Memory 
            long memoryBefore = GC.GetTotalMemory(false);
            Console.WriteLine($"Memory before: {memoryBefore} bytes");

            // Check Time
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Run the program
            ProgrammingTeam();

            // Measure memory usage after allocation
            long memoryAfter = GC.GetTotalMemory(false);
            Console.WriteLine($"Memory after: {memoryAfter} bytes");

            // Stop time, get elapsed time
            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;

            // Calculate memory difference
            long memoryUsed = memoryAfter - memoryBefore;

            Console.WriteLine($"Memory used: {memoryUsed / 1048576.0:F6} MB\nElapsed Time: {elapsed.TotalSeconds:F2} seconds");

            // To trigger garbage collection (if needed):
            GC.Collect();
            ProgrammingTeam();
        }

        public static List<string> GetInput()
        {
            int n = Int32.Parse(Console.ReadLine()); // First line tells how many more lines to read
            List<string> inputs = new List<string>();
            for (int i = 0; i < n; i++)
            {
                // Read exactly n lines
                inputs.Add(Console.ReadLine().ToString());
            }

            return inputs;
        }

        public static void ProgrammingTeam()
        {
            List<string> inputs = GetInput();
            int count = 0;
            foreach (string input in inputs)
            {
                List<int> confidenceList = input.Split().Select(int.Parse).ToList();
                if (confidenceList.Where(i => i > 0).Count() > 1)
                {
                    count++;
                }
            }

            Console.WriteLine(count.ToString());
        }

        //public static List<string> GetTestInput()
        //{
        //    return new List<string>
        //    {
        //        "1 1 0",
        //        "1 1 1",
        //        "1 0 0"
        //    };
        //}
    }
}