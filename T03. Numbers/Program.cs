using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();

            double avg = Queryable.Average(sequence.AsQueryable());

            List<int> topNumbers = new List<int>();

            foreach (var element in sequence)
            {
                if (element > avg)
                {
                    topNumbers.Add(element);
                }
            }

            topNumbers.Sort();

            if (topNumbers.Count >= 5)
            {
                while (topNumbers.Count != 5)
                {
                    topNumbers.RemoveAt(0);
                }
            }

            topNumbers.Reverse();

            if (topNumbers.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(string.Join(' ', topNumbers));
            }
        }
    }
}
