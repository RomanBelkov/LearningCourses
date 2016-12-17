using System;
using System.Collections.Generic;
using AdvancedWorld.Properties;

namespace AdvancedWorld.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal sealed class CoupleAttribute : Attribute
    {
        private readonly HashSet<string> _parentClasses =
            new HashSet<string> { "Student", "Botan", "Girl", "PrettyGirl", "SmartGirl" };
        private readonly HashSet<string> _childClasses =
            new HashSet<string> { "Student", "Botan", "Girl", "PrettyGirl", "SmartGirl", "Book" };
        public string Pair { get; }
        public double Probability { get; }
        public string ChildType { get; }

        public CoupleAttribute(string pair, double probability, string childType)
        {
            if (!_parentClasses.Contains(pair) || !_childClasses.Contains(childType))
            {
                throw new ArgumentException(Resources.CoupleAttribute_InvalidСoupleСlasses);
            }

            if (probability < 0 || probability > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(probability));
            }

            Pair = pair;
            Probability = probability;
            ChildType = childType;
        }
    }
}
