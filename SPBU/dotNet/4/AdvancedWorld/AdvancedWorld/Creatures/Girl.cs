using System;
using AdvancedWorld.Attributes;
using AdvancedWorld.Properties;

namespace AdvancedWorld.Creatures
{
    [Couple("Student", 0.7, "Girl")]
    [Couple("Botan", 0.3, "SmartGirl")]
    public class Girl : Human, IHasPatronymic
    {
        public Girl(string name, string patronymic, int age = 0) : base(name, age, Sex.Female)
        {
            if (string.IsNullOrEmpty(patronymic))
            {
                throw new ArgumentException("Invalid middle name");
            }
            Patronymic = patronymic;
            ConsoleTextColor = ConsoleColor.Red;
            Type = HumanType.Girl;
        }

        public string Patronymic { get; }

        internal override void PrintToConsole()
        {
            var foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleTextColor;
            Console.WriteLine(Resources.GirlParamsOut, Name, Patronymic, Sex, Age);
            Console.ForegroundColor = foregroundColor;
        }
    }
}
