using System;
using System.Collections.Generic;
using System.Linq;
using AdvancedWorld.Attributes;
using AdvancedWorld.Creatures;
using AdvancedWorld.Exceptions;
using AdvancedWorld.Helpers;
using AdvancedWorld.Properties;

namespace AdvancedWorld
{
    public sealed class AdvancedGod
    {
        private readonly Random _rnd = new Random();
        private const int NewBornAge = 0;
        private const string WorldProject = "AdvancedWorld";
        private const string WorldNameSpace = "Creatures";

        private readonly List<Func<Sex, Human>> _maleGenerator = new List<Func<Sex, Human>>();
        private readonly List<Func<Sex, Human>> _femaleGenerator = new List<Func<Sex, Human>>();

        internal AdvancedGod()
        {
            _maleGenerator.Add(_makeStudent);
            _maleGenerator.Add(_makeBotan);

            _femaleGenerator.Add(_makeGirl);
            _femaleGenerator.Add(_makePrettyGirl);
            _femaleGenerator.Add(_makeSmartGirl);
        }

        public Tuple<Human, Human> GenerateHumansForDating()
        {
            return new Tuple<Human, Human>(
                _femaleGenerator[_rnd.Next(_femaleGenerator.Count)](Sex.Female),
                _maleGenerator[_rnd.Next(_maleGenerator.Count)](Sex.Male));
        }

        public IHasName DateCouple(Tuple<Human, Human> humans) => DateCouple(humans.Item1, humans.Item2);

        private static IHasName DateCouple(Human firstHuman, Human secondHuman)
        {
            if (firstHuman == null || secondHuman == null)
            {
                throw new ArgumentNullException();
            }

            if (firstHuman.Sex == secondHuman.Sex)
            {
                throw new WrongCoupleException(Resources.AdvancedGod_WouldNotWorkOut);
            }

            var firstAttribute = GetAttribute(firstHuman, secondHuman);
            var secondAttribute = GetAttribute(secondHuman, firstHuman);

            if (!Randomizer.CheckIfLikes(firstAttribute.Probability)
                || !Randomizer.CheckIfLikes(secondAttribute.Probability))
            {
                return null;
            }

            return MakeChild(
                firstAttribute.ChildType == secondAttribute.ChildType ? firstAttribute.ChildType : null,
                firstHuman.Sex == Sex.Female ? firstHuman : secondHuman,
                firstHuman.Sex == Sex.Female ? secondHuman : firstHuman);
        }

        private static IHasName MakeChild(string childType, Human mother, Human father)
        {
            if (childType == null) throw new ArgumentNullException(nameof(childType));

            try
            {
                var type = GetTypeOfHuman(childType);
                var name = GetChildsName(mother);

                var constructor = type.GetConstructors().FirstOrDefault();
                if (constructor != null && constructor.GetParameters().Length > 1)
                {
                    return Activator.CreateInstance(type, name,
                        Names.PatronymicFromParentName(Sex.Female, father.Name), NewBornAge)
                        as IHasName;
                }

                return Activator.CreateInstance(type, name) as IHasName;
            }
            catch (Exception e)
            {
                throw new Exception("Child of given type can not be constructed", e);
            }
        }

        private static Type GetTypeOfHuman(string type)
            => Type.GetType($"{WorldProject}.{WorldNameSpace}." + type + $", {WorldProject}");

        private static string GetChildsName(Human human)
        {
            var namingMethod = human.GetType().GetMethods()
                .First(x => x.Name == Human.ChildNamingMethod && x.ReturnType == typeof(string));
            try
            {
                return namingMethod.Invoke(human, null) as string;
            }
            catch (Exception e)
            {
                throw new Exception(Resources.AdvancedGod_ChildNamingNotSupported, e);
            }
        }

        private static CoupleAttribute GetAttribute(Human firstHuman, Human secondHuman)
        {
            var enumerator = new CoupleAttributeEnumerator(firstHuman.GetType());
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.Pair.Equals(secondHuman.GetType().Name))
                {
                    return enumerator.Current;
                }
            }
            throw new WrongCoupleException(Resources.AdvancedGod_IncompatibleTypes);
        }

        private readonly Func<Sex, Human> _makeStudent = sex =>
                new Student(Names.GenerateName(sex), Names.GeneratePatronymic(sex), Randomizer.GetRandomAge());

        private readonly Func<Sex, Human> _makeBotan = sex =>
            new Botan(Randomizer.GetRandomAge(), Names.GenerateName(sex), Names.GeneratePatronymic(sex), Randomizer.GetRandomAverageMark());

        private readonly Func<Sex, Human> _makeGirl = sex =>
            new Girl(Names.GenerateName(sex), Names.GeneratePatronymic(sex), Randomizer.GetRandomAge());

        private readonly Func<Sex, Human> _makePrettyGirl = sex =>
            new PrettyGirl(Names.GenerateName(sex), Names.GeneratePatronymic(sex), Randomizer.GetRandomAge());

        private readonly Func<Sex, Human> _makeSmartGirl = sex =>
            new SmartGirl(Names.GenerateName(sex), Names.GeneratePatronymic(sex), Randomizer.GetRandomAge());
    }
}
