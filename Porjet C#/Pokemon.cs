using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porjet_C_
{
    internal struct Pokemon
    {
        private string _name;
        private int _level;
        private int _currentExp;
        private int _totalExp;
        private Types _types1;
        //private Types _types2;
        private float _attackStat;
        private float _defStat;
        private float _speedStat;
        private float _currentHealth;
        private float _totalHealth;


        public string Name { get => _name; private set => _name = value; }
        public int Level { get => _level; private set => _level = value; }
        public int CurrentExp { get => _currentExp; private set => _currentExp = value; }
        public int TotalExp { get => _totalExp; private set => _totalExp = value; }
        public Types Types1 { get => _types1; private set => _types1 = value; }
        //public Types Types2 { get => _types2; private set => _types2 = value; }
        public float AttackStat { get => _attackStat; private set => _attackStat = value; }
        public float DefStat { get => _defStat; private set => _defStat = value; }
        public float SpeedStat { get => _speedStat; private set => _speedStat = value; }
        public float CurrentHealth { get => _currentHealth; private set => _currentHealth = value; }
        public float TotalHealth { get => _totalHealth; private set => _totalHealth = value; }
    }
}
