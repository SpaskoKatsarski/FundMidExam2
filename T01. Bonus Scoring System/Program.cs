using System;

namespace T01._Bonus_Scoring_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            sbyte students = sbyte.Parse(Console.ReadLine());
            sbyte numberOfLectures = sbyte.Parse(Console.ReadLine());
            sbyte additionalBonus = sbyte.Parse(Console.ReadLine());

            decimal mostAttendances = decimal.MinValue;

            for (int i = 0; i < students; i++)
            {
                uint attendances = uint.Parse(Console.ReadLine());

                if (attendances > mostAttendances)
                {
                    mostAttendances = attendances;
                }
            }

            decimal totalBonus = mostAttendances / numberOfLectures * (5 + additionalBonus);

            Console.WriteLine($"Max Bonus: {Math.Ceiling(totalBonus)}.\nThe student has attended {mostAttendances} lectures.");
        }
    }
}
