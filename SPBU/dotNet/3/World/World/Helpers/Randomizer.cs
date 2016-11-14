using System;
using World.Humans;

namespace World.Helpers
{
    internal sealed class Randomizer
    {
        private static readonly Random Rnd = new Random();

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
    }
}