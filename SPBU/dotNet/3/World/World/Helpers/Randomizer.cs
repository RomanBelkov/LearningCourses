using System;
using World.Humans;

namespace World.Helpers
{
    internal sealed class Randomizer
    {
        private static readonly Random Rnd = new Random();
        private const int MaxChildsAmount = 3;
        private const int MaxMoneyAmount = 100000;

        internal static int GetRandomStudentAge()
        {
            return Rnd.Next(5, 25);
        }

        internal static int GetRandomParentAge()
        {
            return Rnd.Next(20, 50);
        }

        internal static int GetRandomParentAge(int studentAge)
        {
            return studentAge + Rnd.Next(20, 30);
        }

        internal static Sex GetRandomSex()
        {
            var values = Enum.GetValues(typeof(Sex));
            return (Sex)values.GetValue(Rnd.Next(values.Length));
        }

        internal static double GetRandomAverageMark()
        {
            return 3 + Rnd.NextDouble() * 2;
        }

        internal static int GetRandomChildsAmount()
        {
            return Rnd.Next(MaxChildsAmount);
        }

        internal static int GetRandomChildsAmount(int childsAmount)
        {
            return childsAmount >= MaxChildsAmount ? 0 : Rnd.Next(MaxChildsAmount - childsAmount);
        }

        internal static int GetRandomMoneyAmount()
        {
            return Rnd.Next(MaxMoneyAmount);
        }
    }
}