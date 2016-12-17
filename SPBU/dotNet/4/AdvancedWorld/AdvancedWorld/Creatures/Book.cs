using System;
using AdvancedWorld.Properties;

namespace AdvancedWorld.Creatures
{
    public sealed class Book : IHasName
    {
        public Book(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(Resources.Book_InvalidName);
            }
            Name = name;
        }
        public string Name { get; }

        public override string ToString() => Resources.Book + Name;
    }
}
