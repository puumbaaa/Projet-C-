using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Porjet_C_;
namespace Mapp
{
    class Map
    {
        GameObject[,] _map = new GameObject[120, 30];
        public GameObject[,] _mapTab {  get => _map; }
        public void  mapSet(string file) 
        {
            int j = 0;
            for (int i = 0; i < 1925; i++)
            {

                if (file[i] == 'H')
                {
                    GameObject grass = new GameObject();
                    CaseState state = new CaseState("grass",true,false,true);
                    grass.AddComponent(state);
                    _map[i / 30, j] = grass;
                }
                else
                {
                    GameObject other = new GameObject();
                    CaseState state = new CaseState("case",true,false,false);
                    other.AddComponent(state);
                    _map[i / 30, j] = other;
                }
                if (j == 29) {
                    j = (-1);
                }
                j++;
            }
        }

    }
}
