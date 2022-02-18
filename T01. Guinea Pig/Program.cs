using System;

namespace T01._Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int DaysInMonth = 30;
            const int EverydayFoodConsumation = 300;

            double foodKilograms = double.Parse(Console.ReadLine());
            double hayKilograms = double.Parse(Console.ReadLine());
            double coverKilograms = double.Parse(Console.ReadLine());

            double weight = double.Parse(Console.ReadLine());

            for (int i = 1; i <= DaysInMonth; i++)
            {
                foodKilograms -= 0.3;

                if (i % 2 == 0)
                {
                    hayKilograms -= 0.05 * foodKilograms;
                }

                if (i % 3 == 0)
                {
                    coverKilograms -= weight / 3;
                }

                if (foodKilograms < 0 || hayKilograms < 0 || coverKilograms < 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                }
            }

            Console.WriteLine($"Everything is fine! Puppy is happy! Food: {foodKilograms:f2}, Hay: {hayKilograms:f2}, Cover: {coverKilograms:f2}.");
        }
    }
}
