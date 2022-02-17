using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int shotTargets = 0;

            string command = Console.ReadLine();
            while (command != "End")
            {
                int indexToShoot = int.Parse(command);

                if (indexToShoot < 0 || indexToShoot >= targets.Count)
                {
                    command = Console.ReadLine();
                    continue;
                }

                int shootingTarget = targets[indexToShoot];

                if (shootingTarget != -1)
                {
                    targets[indexToShoot] = -1;
                    shotTargets++;

                    for (int i = 0; i < targets.Count; i++)
                    {
                        if (targets[i] != -1)
                        {
                            if (targets[i] > shootingTarget)
                            {
                                targets[i] -= shootingTarget;
                            }
                            else
                            {
                                targets[i] += shootingTarget;
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Shot targets: {shotTargets} -> {string.Join(' ', targets)}");
        }
    }
}
