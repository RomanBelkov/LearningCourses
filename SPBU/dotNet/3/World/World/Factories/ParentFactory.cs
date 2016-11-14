using System;
using World.Helpers;
using World.Humans;

namespace World.Factories
{
    internal sealed class ParentFactory : IHumanFactory
    {
        private static readonly Random Rnd = new Random();
        private const int MaxChildsAmount = 3;
        public Human CreateHuman(Sex sex)
        {
            return new Parent(Randomizer.GetRandomParentAge(), Names.GenerateName(Sex.Male), Sex.Male, Rnd.Next(MaxChildsAmount));
        }

        public static Parent CreatePair(Student student)
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
            return new Parent(Randomizer.GetRandomParentAge(student.Age), name, Sex.Male, 1 + Rnd.Next(MaxChildsAmount - 1));
        }
    }
}