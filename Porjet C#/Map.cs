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
        GameObject[,] _map = new GameObject[30, 120];
        public GameObject[,] _mapTab {  get => _map; }
        public void  mapSet(string file) 
        {
            int j = 0;
            for (int i = 0; i < 3600; i++)
            {
                if (file[i] == 'H')
                {
                    GameObject grass = new GameObject();
                    CaseState state = new CaseState("grass",true,false,true);
                    
                    grass.AddComponent(state);
                    _map[i / 120,j] = grass;
                }
                else
                {
                    GameObject other = new GameObject();
                    CaseState state = new CaseState("case",true,false,false);
                    other.AddComponent(state);
                    other._IsWalkable = true;
                    _map[i / 120, j] = other;
                }
                if (j == 119) {
                    j = (-1);
                }
                j++;
            }
        }

    }
}
