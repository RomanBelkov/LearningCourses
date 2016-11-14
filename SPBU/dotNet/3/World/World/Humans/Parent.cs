using System;

namespace World.Humans
{
    internal class Parent : Human
    {
        internal Parent(int age, string name, Sex sex, int childsAmount) : base(age, name, sex)
        {
            if (childsAmount < 0)
            {
                throw new ArgumentException("Invalid childs number");
            }
            ChildsAmount = childsAmount;
        }

        internal int ChildsAmount { get; }

        internal override void PrintToConsole()
        {
            var foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Parent {0}, {1}, age {2}, {3} childs", Name, Sex, Age, ChildsAmount);
            Console.ForegroundColor = foregroundColor;
        }
    }
}