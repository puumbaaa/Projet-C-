using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porjet_C_
{
    internal class Component
    {
        string _componentName;

        public string ComponentName { get => _componentName; private set => _componentName = value; }

        public Component(string componentName)
        {
            ComponentName = componentName;
        }
    }
}
