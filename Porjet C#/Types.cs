using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porjet_C_
{
    public class Types
    {
        List<Types> _weaknessType;
        List<Types> _strengthType;
        string _name;

        public string Name { get => _name; private set => _name = value; }
        public List<Types> WeaknessType { get => _weaknessType; private set => _weaknessType = new(10); }
        public List<Types> StrengthType { get => _strengthType; private set => _strengthType = new(10); }

        public Types(string typeName)
        {
            Name = typeName;
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
