﻿using System;
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
                    Component state = new CaseState("grass",true,false,true);
                    Component bag = new Bag("bag");
                    grass.AddComponent(state);
                    grass.AddComponent(bag);
                    Random rnd = new Random();
                    if (rnd.Next(100) <= 1)
                    {
                        Objects a = new Objects(false,true);
                        ((Bag)grass.ComponentsList[1]).ObjectsList.Add(a);
                    }
                    
                    _map[i / 122,j] = grass;
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
