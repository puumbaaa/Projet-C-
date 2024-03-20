using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porjet_C_
{
    internal class GameObject
    {
        List<Component> _componentsList;
        bool _isWalkable = false;
        public bool _IsWalkable { get => _isWalkable; set => _isWalkable = value; }
        public List<Component> ComponentsList { get => _componentsList; private set => _componentsList = new(10); }

        public GameObject()
        {
            ComponentsList = new List<Component>();
        }
        public void AddComponent(Component component)
        {
            _componentsList.Add(component);
            //if (component.GetType() == typeof(CaseState)) { 
            //    _isWalkable = true;
            //}
        }
    }
}
