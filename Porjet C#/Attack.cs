using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porjet_C_
{
    internal class Attack : Component
    {
        float _attackStat;
        Types _oTypes;

        public float AttackStat { get => _attackStat; private set => _attackStat = value; }
        public Types OTypes { get => _oTypes; private set => _oTypes = value;  }

        public Attack(string componentName, Types types, float attack) : base(componentName) 
        {
            OTypes = types;
            AttackStat = attack;
        }
    }
}
