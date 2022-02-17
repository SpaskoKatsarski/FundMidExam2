using System;

namespace T01._Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());

            int wonBattles = 0;

            string command = Console.ReadLine();
            while (command != "End of battle")
            {
                int distance = int.Parse(command);
                
                if (initialEnergy < distance)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wonBattles} won battles and {initialEnergy} energy");
                    return;
                }

                initialEnergy -= distance;

                wonBattles++;

                if (wonBattles % 3 == 0)
                {
                    initialEnergy += wonBattles;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Won battles: {wonBattles}. Energy left: {initialEnergy}");
        }
    }
}
