using System;

namespace World.Humans
{
    internal sealed class Botan : Student
    {
        internal Botan(int age, string name, Sex sex, string patronymic, double averageMark) : base(age, name, sex, patronymic)
        {
            if ((averageMark < 0) && (averageMark > 5))
            {
                throw new ArgumentException("Invalid average mark");
            }
            AverageMark = averageMark;
        }

        internal double AverageMark { get; }

        internal override void PrintToConsole()
        {
            var foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Botan {0} {1}, {2}, age {3}, {4} average mark", Name, Patronymic, Sex, Age, AverageMark);
            Console.ForegroundColor = foregroundColor;
        }
    }
}