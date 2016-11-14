using System;

namespace World.Humans
{
    internal sealed class CoolParent : Parent
    {
        internal CoolParent(int age, string name, Sex sex, int childsAmount, int moneyAmount) : base(age, name, sex, childsAmount)
        {
            if (moneyAmount < 0)
            {
                throw new ArgumentException("Invalid amount of money");
            }
            MoneyAmount = moneyAmount;
        }

        internal int MoneyAmount { get; }

        internal override void PrintToConsole()
        {
            var foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("CoolParent {0}, {1}, age {2}, {3} childs ", Name, Sex, Age, ChildsAmount);
            var backgroundColor = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("${0}", MoneyAmount);
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
        }
    }
}