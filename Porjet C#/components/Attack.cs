using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Porjet_C_;

namespace Porjet_C_
{
    public class Attack : Component
    {
        float _attackStat;
        Types _oTypes;
        int[] _ocases;

        public float AttackStat { get => _attackStat; private set => _attackStat = value; }
  
        public Types OTypes { get => _oTypes; private set => _oTypes = value;  }

        public int[] OCases { get => _ocases; set => _ocases = value; }

        public Attack(string componentName, Types types, float attack, int[] cases) : base(componentName) 
        {
            OTypes = types;
            AttackStat = attack;
            OCases = cases;
        }

        
    }
}
