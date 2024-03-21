using Mapp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porjet_C_
{
    internal class MenuPokemon : Menu
    {
        GameObject _pokemons;
        public GameObject Pokemons { get => _pokemons; private set => _pokemons = value; }
        public MenuPokemon(string title, GameObject pokemons) : base(title) 
        {
            Pokemons = pokemons;
        }

        public void DisplayPokemonMenue(FileReader map, int itemValue)
        {
            string menuPokemon = DisplayMenu(map, Pokemons, itemValue);
            FileReader newFileReader = new FileReader();
            newFileReader.setFile("..\\..\\..\\..\\ASCII\\Menu\\menuPokemontotal.txt");
            string finalMap = "";
            for (int i = 0; i < menuPokemon.Length; i++)
            {
                if (newFileReader.sText[i]=='.')
                {
                    finalMap += menuPokemon[i];
                }else if (newFileReader.sText[i] != '_')
                {
                    finalMap += newFileReader.sText[i];
                }
            }
        }


    }
}
