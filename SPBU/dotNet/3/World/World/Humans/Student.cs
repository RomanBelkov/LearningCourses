using System;
using World.Properties;

namespace World.Humans
{
    internal class Student : Human
    {
        internal Student(int age, string name, Sex sex, string patronymic) : base(age, name, sex)
        {
            if (string.IsNullOrEmpty(patronymic))
            {
                throw new ArgumentException(Resources.InvalidPatronymic);
            }
            Patronymic = patronymic;
        }

        internal string Patronymic { get; }
        internal override void PrintToConsole()
        {
            var foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Resources.StudentParamOut, Name, Patronymic, Sex, Age);
            Console.ForegroundColor = foregroundColor;
        }
    }
}