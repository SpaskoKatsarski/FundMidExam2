using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Heart_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int HeartsDecrease = 2;

            List<int> neighbourhoodList = Console.ReadLine()
                .Split('@', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int lastPosition = 0;

            string jumpCommand = Console.ReadLine();

            int currentHouseIndex = 0;
            bool hasPassed = true;
            // Jump {length}
            while (jumpCommand != "Love!")
            {
                if (hasPassed)
                {
                    string[] cmdArgs = jumpCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    int houseIndex = int.Parse(cmdArgs[1]);

                    currentHouseIndex += houseIndex;
                }

                hasPassed = true;

                if (currentHouseIndex < 0 || currentHouseIndex >= neighbourhoodList.Count)
                {
                    currentHouseIndex = 0;
                    hasPassed = false;
                    continue;
                }

                if (neighbourhoodList[currentHouseIndex] == 0)
                {
                    Console.WriteLine($"Place {currentHouseIndex} already had Valentine's day.");
                }
                else
                {
                    neighbourhoodList[currentHouseIndex] -= HeartsDecrease;

                    if (neighbourhoodList[currentHouseIndex] == 0)
                    {
                        Console.WriteLine($"Place {currentHouseIndex} has Valentine's day.");
                    }
                }

                jumpCommand = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {currentHouseIndex}.");

            int counter = 0;
            bool hasFailed = false;

            foreach (var element in neighbourhoodList)
            {
                if (element != 0)
                {
                    counter++;
                    hasFailed = true;
                }
            }

            if (hasFailed)
            {
                Console.WriteLine($"Cupid has failed {counter} places.");
            }
            else
            {
                Console.WriteLine("Mission was successful.");
            }
        }
    }
}
