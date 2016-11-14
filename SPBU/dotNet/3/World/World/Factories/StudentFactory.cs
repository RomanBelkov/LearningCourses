using System;
using World.Helpers;
using World.Humans;

namespace World.Factories
{
    internal sealed class StudentFactory : IHumanFactory
    {
        public Human CreateHuman(Sex sex)
        {
            return new Student(Randomizer.GetRandomStudentAge(), Names.GenerateName(sex), sex,  Names.GeneratePatronymic(sex));
        }

        public static Student CreatePair(Parent parent)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("null parent");
            }
            var sex = Randomizer.GetRandomSex();

            return new Student(Randomizer.GetRandomStudentAge(), Names.GenerateName(sex), sex, Names.PatronymicFromParentName(sex, parent.Name));
        }
    }
}