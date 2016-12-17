using System;
using AdvancedWorld.Attributes;
using AdvancedWorld.Properties;

namespace AdvancedWorld.Creatures
{
    [Couple("Girl", 0.7, "Girl")]
    [Couple("PrettyGirl", 1, "PrettyGirl")]
    [Couple("SmartGirl", 0.5, "Girl")]
    public class Student : Human, IHasPatronymic
    {
        public Student(string name, string patronymic, int age) : base(name, age, Sex.Male)
        {
            if (string.IsNullOrEmpty(patronymic))
            {
                throw new ArgumentException("Invalid patronymic");
            }
            Patronymic = patronymic;
            ConsoleTextColor = ConsoleColor.Cyan;
            Type = HumanType.Student;
        }

        public string Patronymic { get; }

        internal override void PrintToConsole()
        {
            var foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleTextColor;
            Console.WriteLine(Resources.StudentParamOut, Name, Patronymic, Sex, Age);
            Console.ForegroundColor = foregroundColor;
        }
    }
}
