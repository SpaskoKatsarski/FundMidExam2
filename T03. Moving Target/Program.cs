using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> movingTargets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = cmdArgs[0];
                int index = int.Parse(cmdArgs[1]);

                if (action == "Shoot")
                {
                    if (!CheckIfIndexIsValid(index, movingTargets))
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    
                    int power = int.Parse(cmdArgs[2]);
                    movingTargets[index] -= power;

                    if (movingTargets[index] == 0)
                    {
                        movingTargets.RemoveAt(index);
                    }
                }
                else if (action == "Add")
                {
                    if (!CheckIfIndexIsValid(index, movingTargets))
                    {
                        Console.WriteLine("Invalid placement!");

                        command = Console.ReadLine();
                        continue;
                    }

                    int value = int.Parse(cmdArgs[2]);
                    movingTargets.Insert(index, value);
                }
                else if (action == "Strike")
                {
                    int range = int.Parse(cmdArgs[2]);

                    // 11 22 33 44 55 66 77 88 99
                    // Remove 3 2

                    // index = 3
                    // range = 2

                    // Remove Range from index - range and Remove Range from index + range
                    // Remove At (1 to 3) Remove at (3 to 5)

                    // index = 3, radius = 2
                    // 1 2 3 4 5 6 7 8

                    int leftIndexCount = index - range; // 1
                    int rightIndexCount = index + range; // 5

                    if (!CheckIfIndexIsValid(rightIndexCount, movingTargets) || !CheckIfIndexIsValid(leftIndexCount, movingTargets))
                    {
                        Console.WriteLine("Strike missed!");

                        command = Console.ReadLine();
                        continue;
                    }

                    //movingTargets.RemoveRange(leftIndexCount, rightIndexCount - 1);


                    // 11 22 33 44
                    // leftIndex = 1

                    for (int i = leftIndexCount; i <= index; i++)
                    {
                        movingTargets.RemoveAt(leftIndexCount);
                    }

                    for (int i = leftIndexCount; i < index; i++)
                    {
                        movingTargets.RemoveAt(index - 1);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join('|', movingTargets));
        }

        static bool CheckIfIndexIsValid(int index, List<int> list)
        {
            if (index < 0 || index >= list.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
