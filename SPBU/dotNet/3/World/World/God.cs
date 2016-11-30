using System;
using System.Collections.Generic;
using World.Factories;
using World.Helpers;
using World.Humans;

namespace World
{
    internal sealed class God : IGod
    {
        private readonly Random _rnd = new Random();
        private readonly List<IHumanFactory> _factories = new List<IHumanFactory>();
        private readonly List<Human> _humans = new List<Human>();
        internal God()
        {
            _factories.Add(new ParentFactory());
            _factories.Add(new CoolParentFactory());
            _factories.Add(new StudentFactory());
            _factories.Add(new BotanFactory());
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
            var human = _factories[_rnd.Next(_factories.Count)].CreateHuman(sex);
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
                newHuman = CoolParentFactory.CreatePair((Botan) human);
            }
            else if (human is CoolParent)
            {
                newHuman = BotanFactory.CreatePair((CoolParent) human);
            }
            else if (human is Student)
            {
                newHuman = ParentFactory.CreatePair((Student) human);
            }
            else if (human is Parent)
            {
                newHuman = StudentFactory.CreatePair((Parent) human);
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