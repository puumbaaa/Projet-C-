using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Porjet_C_
{
    internal class Objects : Component
    {
        string _statName;
        float _statValue;
        bool _isKey;
        bool _isPokeball;

        public string StatName { get => _statName; private set => _statName = value; }
        public float StatValue { get => _statValue; private set => _statValue = value; }
        public bool IsKey { get => _isKey; set => _isKey = value; }
        public bool IsPokeball { get => _isPokeball; set => _isPokeball = value; }

        public Objects(string name, string statName, float statValue) : base(name) 
        {
            StatName = statName;
            StatValue = statValue;
            IsKey = false;
            IsPokeball = false;
        } 

        public Objects(string name, bool isKey, bool isPokeball) : base(name) 
        {
            IsKey = isKey;
            IsPokeball = isPokeball;
        }
    }
}
