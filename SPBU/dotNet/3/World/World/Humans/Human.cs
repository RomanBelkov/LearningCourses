using System;

namespace World.Humans
{
    internal class Human
    {
        internal Human(int age, string name, Sex sex)
        {
            if ((age < 0) || string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(Properties.Resources.InvalidHumanParams);
            }
            Age = age;
            Name = name;
            Sex = sex;
        }

        internal int Age { get; }
        internal string Name { get; }
        internal Sex Sex { get; }

        internal virtual void PrintToConsole()
        {
            Console.WriteLine("Human {0} {1}, age {2}", Name, Sex, Age);
        }
    }

    internal enum Sex
    {
        Male,
        Female
    }
}