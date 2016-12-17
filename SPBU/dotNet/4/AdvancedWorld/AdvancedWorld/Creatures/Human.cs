using System;
using AdvancedWorld.Helpers;
using AdvancedWorld.Properties;

namespace AdvancedWorld.Creatures
{
    public class Human : IHasName
    {
        public const string ChildNamingMethod = "GiveName";

        internal Human(string name, int age, Sex sex)
        {
            if ((age < 0) || string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(Resources.InvalidHumanParams);
            }
            Name = name;
            Age = age;
            Sex = sex;
        }

        public HumanType Type { get; set; }
        internal int Age { get; }
        public string Name { get; }
        internal Sex Sex { get; }
        protected ConsoleColor ConsoleTextColor { get; set; }

        internal virtual void PrintToConsole()
        {
            Console.WriteLine(Resources.HumanParamOut, Name, Sex, Age);
        }

        public string GiveName() => Names.GenerateName(Sex.Female);
    }

    public enum Sex
    {
        Male,
        Female
    }

    public enum HumanType
    {
        Student, Botan, Parent, Coolparent, Girl, PrettyGirl, SmartGirl
    }
}
