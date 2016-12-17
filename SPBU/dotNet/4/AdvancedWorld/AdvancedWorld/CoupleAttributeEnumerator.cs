using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AdvancedWorld.Attributes;

namespace AdvancedWorld
{
    internal sealed class CoupleAttributeEnumerator : IEnumerator<CoupleAttribute>
    {
        private readonly IEnumerator _enumerator;

        public CoupleAttributeEnumerator(Type humanType)
        {
            if (humanType == null)
            {
                throw new ArgumentNullException();
            }
            var attributes = Attribute.GetCustomAttributes(humanType,
                    typeof(CoupleAttribute))
                .Where(x => x != null)
                .ToList();
            _enumerator = attributes.GetEnumerator();
        }

        public CoupleAttribute Current => (CoupleAttribute)_enumerator.Current;

        object IEnumerator.Current => _enumerator.Current;

        public void Dispose() { }

        public bool MoveNext() => _enumerator.MoveNext();

        public void Reset() => _enumerator.Reset();
    }
}
