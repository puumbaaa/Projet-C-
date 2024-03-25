using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porjet_C_
{
    internal class Render : Component
    {
        string _renderString;

        public string RenderString { get => _renderString;  set => _renderString = value; }
        public Render(string componentName, string playerString) : base(componentName) 
        {
            _renderString = playerString;
        }
        
    }
}
