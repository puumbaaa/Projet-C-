using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Porjet_C_;
using Porjet_C_.components;

namespace Mapp
{
    class Map
    {
        GameObject[,] _map = new GameObject[30, 122];
        public GameObject[,] _mapTab {  get => _map; }
        public void  mapSet(string file) 
        {
            int j = 0;
            for (int i = 0; i < 3658; i++)
            {
                if (file[i] == 'H')
                {
                    GameObject grass = new GameObject();
                    Component state = new CaseState("grass", true, false, true);
                    Component bag = new Bag("bag");
                    grass.AddComponent(state);
                    grass.AddComponent(bag);
                    Random rnd = new Random();
                    int r = rnd.Next(1000);
                    if (r <= 10)
                    {
                        if (r > 1)
                        {
                            Objects a = new Objects(false, true);
                            ((Bag)grass.ComponentsList[1]).ObjectsList.Add(a);
                        }
                        else if (r == 1)
                        {
                            Objects a = new Objects(true, false);
                            ((Bag)grass.ComponentsList[1]).ObjectsList.Add(a);
                        }
                    }

                    _map[i / 122, j] = grass;
                }
                else if (file[i] == '|' || file[i] == '_')
                {
                    GameObject wall = new GameObject();
                    Component state = new CaseState("border", false, true, false);
                    wall.AddComponent(state);
                    _map[i / 122, j] = wall;
                }
                else if (file[i] == '/' || file[i] == (char)92){
                    GameObject door = new GameObject();
                    Component state = new CaseState("door", true, false, false);
                    door.AddComponent(state);
                    _map[i / 122, j] = door;
                }
                else if (file[i] == 'N')
                {
                    GameObject npc = new GameObject();
                    Component state = new CaseState("npc", false, false, false);
                    Dialogue dialogue = new Dialogue("dialogue");
                    npc.AddComponent(state);
                    npc.AddComponent(dialogue);
                    _map[i/122, j] = npc;
                }
                else
                {
                    GameObject other = new GameObject();
                    Component state = new CaseState("case",true,false,false);
                    other.AddComponent(state);
                    _map[i / 122, j] = other;
                }
                if (j == 121) {
                    j = (-1);
                }
                j++;
            }
        }

    }
}
