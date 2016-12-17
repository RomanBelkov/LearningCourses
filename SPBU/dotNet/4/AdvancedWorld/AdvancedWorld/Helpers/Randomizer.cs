using System;

namespace AdvancedWorld.Helpers
{
    internal sealed class Randomizer
    {
        private static readonly Random Rnd = new Random();

        internal static int GetRandomAge()
        {
            return Rnd.Next(20, 50);
        }

        internal static double GetRandomAverageMark()
        {
            return 3 + Rnd.NextDouble() * 2;
        }

        public static bool CheckIfLikes(double probability) =>
            Rnd.NextDouble() < probability;
    }
}
