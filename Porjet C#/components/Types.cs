using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porjet_C_
{
    public class Types : Component
    {
        List<Types> _weaknessType;
        List<Types> _strengthType;

        public List<Types> WeaknessType { get => _weaknessType; private set => _weaknessType = new(10); }
        public List<Types> StrengthType { get => _strengthType; private set => _strengthType = new(10); }

        public Types(string componentName) : base(componentName)
        {
            WeaknessType = new List<Types>();
            StrengthType = new List<Types>();
        }
        public void AddWeakness(Types types)
        {
            WeaknessType.Add(types);
        }

        public void AddStrength(Types types)
        {
            StrengthType.Add(types);
        }
    }
}
