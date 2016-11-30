using System;
using World.Properties;

namespace World.Humans
{
    internal class Parent : Human
    {
        internal Parent(int age, string name, Sex sex, int childsAmount) : base(age, name, sex)
        {
            if (childsAmount < 0)
            {
                throw new ArgumentException(Resources.InvalidChildsAmount);
            }
            ChildsAmount = childsAmount;
        }

        internal int ChildsAmount { get; }

        internal override void PrintToConsole()
        {
            var foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Resources.ParentParamOut, Name, Sex, Age, ChildsAmount);
            Console.ForegroundColor = foregroundColor;
        }
    }
}