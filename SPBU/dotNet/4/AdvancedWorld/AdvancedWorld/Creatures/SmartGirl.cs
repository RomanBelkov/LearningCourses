using System;
using AdvancedWorld.Attributes;
using AdvancedWorld.Properties;

namespace AdvancedWorld.Creatures
{
    [Couple("Student", 0.2, "Girl")]
    [Couple("Botan", 0.5, "Book")]
    public sealed class SmartGirl : Girl
    {
        public SmartGirl(string name, string patronymic, int age = 0) : base(name, patronymic, age)
        {
            ConsoleTextColor = ConsoleColor.DarkRed;
            Type = HumanType.SmartGirl;
        }

        internal override void PrintToConsole()
        {
            var foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleTextColor;
            Console.WriteLine(Resources.SmartGirlParamOut, Name, Patronymic, Sex, Age);
            Console.ForegroundColor = foregroundColor;
        }
    }
}
