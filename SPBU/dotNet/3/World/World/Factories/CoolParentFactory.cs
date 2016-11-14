using System;
using World.Helpers;
using World.Humans;

namespace World.Factories
{
    internal sealed class CoolParentFactory : IHumanFactory
    {
        private static readonly Random Rnd = new Random();
        private const int MaxChildsAmount = 3;
        private const int MaxMoneyAmount = 100000;
        public Human CreateHuman(Sex sex)
        {
            return new CoolParent(Randomizer.GetRandomParentAge(), Names.GenerateName(Sex.Male), Sex.Male, Rnd.Next(MaxChildsAmount), Rnd.Next(MaxMoneyAmount));
        }

        public static CoolParent CreatePair(Botan student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("null student");
            }
            if (student.Patronymic.Length < 5)
            {
                throw new ArgumentException("Patronymic is too short");
            }

            var name = Names.NameFromPatronymic(student.Sex, student.Patronymic);
            return new CoolParent(Randomizer.GetRandomParentAge(student.Age), name, Sex.Male, 1 + Rnd.Next(MaxChildsAmount - 1), Money.MarkToMoney(student.AverageMark));
        }
    }
}