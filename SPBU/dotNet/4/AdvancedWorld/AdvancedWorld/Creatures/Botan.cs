using System;
using AdvancedWorld.Attributes;
using AdvancedWorld.Properties;

namespace AdvancedWorld.Creatures
{
    [Couple("Girl", 0.7, "SmartGirl")]
    [Couple("PrettyGirl", 1, "PrettyGirl")]
    [Couple("SmartGirl", 0.8, "Book")]
    public sealed class Botan : Student
    {
        internal Botan(int age, string name, string patronymic, double averageMark) :
            base(name, patronymic, age)
        {
            if ((averageMark < 0) && (averageMark > 5))
            {
                throw new ArgumentException(Resources.InvalidAverageMark);
            }
            AverageMark = averageMark;
            ConsoleTextColor = ConsoleColor.Green;
            Type = HumanType.Botan;
        }

        public double AverageMark { get; }

        internal override void PrintToConsole()
        {
            var foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleTextColor;
            Console.WriteLine(Resources.BotanParamOut, Name, Patronymic, Sex, Age, AverageMark);
            Console.ForegroundColor = foregroundColor;
        }
    }
}
