using System;
using AdvancedWorld.Attributes;
using AdvancedWorld.Properties;

namespace AdvancedWorld.Creatures
{
    [Couple("Student", 0.4, "PrettyGirl")]
    [Couple("Botan", 0.1, "PrettyGirl")]
    public sealed class PrettyGirl : Girl
    {
        public PrettyGirl(string name, string patronymic, int age = 0) : base(name, patronymic, age)
        {
            ConsoleTextColor = ConsoleColor.Magenta;
            Type = HumanType.PrettyGirl;
        }

        internal override void PrintToConsole()
        {
            var foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleTextColor;
            Console.WriteLine(Resources.PrettyGirlParamOut, Name, Patronymic, Sex, Age);
            Console.ForegroundColor = foregroundColor;
        }
    }
}
