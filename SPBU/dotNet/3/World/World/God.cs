using System;
using System.Collections.Generic;
using World.Helpers;
using World.Humans;

namespace World
{
    internal sealed class God : IGod
    {
        private readonly Random _rnd = new Random();

        private readonly List<Func<Sex, Human>> _maleGenerator   = new List<Func<Sex, Human>>();
        private readonly List<Func<Sex, Human>> _femaleGenerator = new List<Func<Sex, Human>>();

        private readonly List<Human> _humans = new List<Human>();
        internal God()
        {
            Func<Sex, Human> makeStudent = sex =>
                new Student(Randomizer.GetRandomStudentAge(), Names.GenerateName(sex), sex, Names.GeneratePatronymic(sex));

            Func<Sex, Human> makeBotan = sex =>
                new Botan(Randomizer.GetRandomStudentAge(), Names.GenerateName(sex), sex, Names.GeneratePatronymic(sex), Randomizer.GetRandomAverageMark());

            _maleGenerator.Add(makeStudent);
            _maleGenerator.Add(makeBotan);

            _femaleGenerator.Add(makeStudent);
            _femaleGenerator.Add(makeBotan);

            _maleGenerator.Add(sex =>
                new Parent(Randomizer.GetRandomParentAge(), Names.GenerateName(sex), sex, Randomizer.GetRandomChildsAmount()));

            _maleGenerator.Add(sex =>
                new CoolParent(Randomizer.GetRandomParentAge(), Names.GenerateName(sex), sex, Randomizer.GetRandomChildsAmount(), Randomizer.GetRandomMoneyAmount()));
        }

        public Human CreateHuman()
        {
            switch (_humans.Count)
            {    
                case 0:
                    return CreateHuman(Sex.Male);
                case 1:
                    return CreateHuman(Sex.Female);
                default:
                    return CreateHuman(Randomizer.GetRandomSex());
            }
        }

        public Human CreateHuman(Sex sex)
        {
            var human = sex == Sex.Male ?
                _maleGenerator[_rnd.Next(_maleGenerator.Count)](sex) :
                _femaleGenerator[_rnd.Next(_femaleGenerator.Count)](sex);
            _humans.Add(human);
            return human;
        }

        public Human CreatePair(Human human)
        {
            if (human == null)
            {
                throw new ArgumentNullException(Properties.Resources.NullHuman);
            }
            Human newHuman;
            if (human is Botan)
            {
                var botan = (Botan) human;
                var name = Names.NameFromPatronymic(botan.Sex, botan.Patronymic);
                newHuman = new CoolParent(Randomizer.GetRandomParentAge(botan.Age), name, Sex.Male,
                    Randomizer.GetRandomChildsAmount(1), Money.MarkToMoney(botan.AverageMark));
            }
            else if (human is CoolParent)
            {
                var coolParent = (CoolParent) human;
                var sex = Randomizer.GetRandomSex();
                newHuman = new Botan(Randomizer.GetRandomStudentAge(), Names.GenerateName(sex), sex, Names.PatronymicFromParentName(sex, coolParent.Name), Money.MoneyToMark(coolParent.MoneyAmount));
            }
            else if (human is Student)
            {
                var student = (Student) human;
                var name = Names.NameFromPatronymic(student.Sex, student.Patronymic);
                newHuman = new Parent(Randomizer.GetRandomParentAge(student.Age), name, Sex.Male, Randomizer.GetRandomChildsAmount(1));
            }
            else if (human is Parent)
            {
                var parent = (Parent) human;
                var sex = Randomizer.GetRandomSex();
                return new Student(Randomizer.GetRandomStudentAge(), Names.GenerateName(sex), sex, Names.PatronymicFromParentName(sex, parent.Name));
            }
            else
            {
                throw new ArgumentException(Properties.Resources.InvalidHumanType);
            }
            _humans.Add(newHuman);
            return newHuman;
        }

        internal int this[int index]
        {
            get
            {
                if ((index < 0) || (index >= _humans.Count))
                {
                    throw new ArgumentOutOfRangeException();
                }

                var parent = _humans[index] as CoolParent;
                return parent?.MoneyAmount ?? 0;
            }
        }

        internal int GetTotalMoney()
        {
            var size = _humans.Count;
            var totalMoney = 0;
            for (var i = 0; i < size; ++i)
            {
                totalMoney += this[i];
            }
            return totalMoney;
        }

        internal Human[] GetCreatedHumans()
        {
            return _humans.ToArray();
        }
    }
}