using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porjet_C_
{
    public class GameObject
    {
        List<Component> _componentsList;
        public List<Component> ComponentsList { get => _componentsList; private set => _componentsList = new(10); }

        public GameObject()
        {
            ComponentsList = new List<Component>();
        }
        public void AddComponent(Component component)
        {
            ComponentsList.Add(component);
        }
    }
}
