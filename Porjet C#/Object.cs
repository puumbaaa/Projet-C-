using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porjet_C_
{
    internal class Object : Component
    {
        string _statName;
        float _statValue;
        bool _isKey;

        public string StatName { get => _statName; private set => _statName = value; }
        public float StatValue { get => _statValue; private set => _statValue = value; }
        public bool IsKey { get => _isKey; set => _isKey = value; }

        public Object(string name, string statName, float statValue) : base(name) 
        {
            StatName = statName;
            StatValue = statValue;
        } 

        public Object(string name) : base(name) 
        {
            IsKey = true;
        }
    }
}
