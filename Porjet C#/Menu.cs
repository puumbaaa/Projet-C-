using Mapp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porjet_C_
{
    internal class Menu
    {
        string _title;

        public string Title { get => _title; private set => _title = value;  }

        public Menu(string title)
        {
            Title = title;
        }

        public string DisplayMenu(FileReader map, GameObject gameObject, int menuItem)
        {
            int nbLine = gameObject.ComponentsList.Count +2;
            string menu = map.sText.Remove(map.sText.Length-120*nbLine - nbLine*2);
            int indexTitle = 0;
            for (int i = 0; i < 120; i++)
            {
                if (i <= (120 / 2 - (Title.Length / 2)) || i > (120 / 2 + (Title.Length / 2)))
                {
                    menu += "*";
                }
                else
                {
                    menu += Title[indexTitle] ;
                    indexTitle++;
                }
            }
            for (int j = 0; j < gameObject.ComponentsList.Count; j++)
            {
                indexTitle = 0;
                for (int i = 0; i < 120; i++)
                {
                    if (i <= 10 || i > 12 + gameObject.ComponentsList[j].ComponentName.Length)
                    {
                        menu += " ";
                    }
                    else if (i==11 && (j +1) != menuItem)
                    {
                        menu += "_";
                    }else if (i==11 && (j +1) == menuItem)
                    {
                        menu += ">";
                    }else if (i==12)
                    {
                        menu += " ";
                    }else
                    {
                        menu += gameObject.ComponentsList[j].ComponentName[indexTitle];
                        indexTitle++;
                    }
                }
            }
            for (int i = 0; i < 120; i++)
            {
                menu += "*";
            }
            return menu;
        }
    }
}
