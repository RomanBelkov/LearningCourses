using System;
using World.Helpers;
using World.Humans;

namespace World.Factories
{
    internal sealed class BotanFactory : IHumanFactory
    {
        private static readonly Random Rnd = new Random();
        public Human CreateHuman(Sex sex)
        {
            return new Botan(Randomizer.GetRandomStudentAge(), Names.GenerateName(sex), sex, Names.GeneratePatronymic(sex), RandomAverageMark());
        }

        public static Botan CreatePair(CoolParent parent)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("null parent");
            }
            var sex = Randomizer.GetRandomSex();

            return new Botan(Randomizer.GetRandomStudentAge(), Names.GenerateName(sex), sex, Names.PatronymicFromParentName(sex, parent.Name), Money.MoneyToMark(parent.MoneyAmount));
        }

        private static double RandomAverageMark()
        {
            return 3 + Rnd.NextDouble() * 2;
        }
    }
}