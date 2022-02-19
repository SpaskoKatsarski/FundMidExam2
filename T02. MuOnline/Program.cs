using System;

namespace T02._MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dungeonArr = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

            int initialHealth = 100;
            int bitcoins = 0;

            for (int i = 0; i < dungeonArr.Length; i++)
            {
                string[] cmdArgs = dungeonArr[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string challenge = cmdArgs[0];

                if (challenge == "potion")
                {
                    int heal = int.Parse(cmdArgs[1]);

                    // 70 + 40 = 110
                    // heal = 100 - 70 => 30
                    if (initialHealth + heal > 100)
                    {
                        heal = 100 - initialHealth;
                    }

                    // 70 + 120 = 190
                    // heal = 100 - 190 => -90
                    // Heal must be assigned to be 0.
                    if (heal < 0)
                    {
                        heal = 0;
                    }

                    initialHealth += heal;

                    Console.WriteLine($"You healed for {heal} hp.");
                    Console.WriteLine($"Current health: {initialHealth} hp.");
                }
                else if (challenge == "chest")
                {
                    int bitcoinsFound = int.Parse(cmdArgs[1]);
                    Console.WriteLine($"You found {bitcoinsFound} bitcoins.");

                    bitcoins += bitcoinsFound;
                }
                else
                {
                    int monsterAttack = int.Parse(cmdArgs[1]);
                    initialHealth -= monsterAttack;

                    if (initialHealth > 0)
                    {
                        Console.WriteLine($"You slayed {challenge}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {challenge}.\nBest room: {i + 1}");
                        return;
                    }
                }
            }

            Console.WriteLine($"You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {initialHealth}");
        }
    }
}
