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
        

        public int DisplayPokemonMenue(FileReader map, int itemValue, int lastState)
        {
            Pokemon pokemon = (Pokemon)Pokemons.ComponentsList[itemValue];

            string menuPokemon = DisplayMenu(map, Pokemons, itemValue+1);
            FileReader newFileReader = new FileReader();
            newFileReader.setFile("..\\..\\..\\..\\ASCII\\Menu\\menuPokemontotal.txt");
            string finalMap = "";
            int nbDash = 0;
            for (int i = 0; i < menuPokemon.Length; i++)
            {
                if (newFileReader.sText[i] == '.')
                {
                    finalMap += menuPokemon[i];
                } else if (newFileReader.sText[i] != '_')
                {
                    finalMap += newFileReader.sText[i];
                }else
                {
                    switch (nbDash)
                    {
                        //level
                        case 0:
                            finalMap += pokemon.Level;
                            if (pokemon.Level < 1000)
                            {
                                finalMap += " ";
                            }if (pokemon.Level < 100)
                            {
                                finalMap += " ";
                            }if (pokemon.Level < 10)
                            {
                                finalMap += " ";
                            }
                            i += 4;
                            nbDash += 4;
                            break;
                        //first attack
                        case 4:
                            finalMap += pokemon.ListAttacks[0].ComponentName.Remove(10) + " " + pokemon.ListAttacks[0].AttackStat;
                            if (pokemon.ListAttacks[0].AttackStat < 1000)
                            {
                                finalMap += " ";
                            }
                            if (pokemon.ListAttacks[0].AttackStat < 100)
                            {
                                finalMap += " ";
                            }
                            if (pokemon.ListAttacks[0].AttackStat < 10)
                            {
                                finalMap += " ";
                            }
                            finalMap += " ";
                            i += 14;
                            nbDash += 14;
                            break;
                        //exp
                        case 18:
                            string newString = pokemon.CurrentExp + "\\" + pokemon.TotalExp;
                            while (newString.Length < 9)
                            {
                                newString += " ";
                            }
                            finalMap += newString + " ";
                            i += 9;
                            nbDash += 9;
                            break;
                        //type
                        case 27:
                            string newStringType = pokemon.Types1.ComponentName;
                            if (newStringType.Length > 9)
                            {
                                newStringType = newStringType.Remove(9);
                            }
                            while (newStringType.Length < 9)
                            {
                                newStringType += " ";
                            }
                            finalMap += newStringType;
                            i += 9;
                            nbDash += 9;
                            break;
                        //second attack
                        case 36:
                            if (pokemon.ListAttacks.Count>=2)
                            {
                                finalMap += pokemon.ListAttacks[1].ComponentName.Remove(10) + " " + pokemon.ListAttacks[1].AttackStat;
                                if (pokemon.ListAttacks[1].AttackStat < 1000)
                                {
                                    finalMap += " ";
                                }
                                if (pokemon.ListAttacks[1].AttackStat < 100)
                                {
                                    finalMap += " ";
                                }
                                if (pokemon.ListAttacks[1].AttackStat < 10)
                                {
                                    finalMap += " ";
                                }
                            }
                            else
                            {
                                finalMap += "               ";
                            }
                            finalMap += " ";
                            i += 14;
                            nbDash += 14;
                            break;
                        //attack
                        case 50:
                            finalMap += pokemon.AttackStatBase + " ";
                            if (pokemon.AttackStatBase < 1000)
                            {
                                finalMap += " ";
                            }
                            if (pokemon.AttackStatBase < 100)
                            {
                                finalMap += " ";
                            }
                            if (pokemon.AttackStatBase < 10)
                            {
                                finalMap += " ";
                            }
                            nbDash += 4;
                            i += 4;
                            break;
                        //def
                        case 54:
                            finalMap += pokemon.DefStatBase;
                            if (pokemon.DefStatBase < 1000)
                            {
                                finalMap += " ";
                            }
                            if (pokemon.DefStatBase < 100)
                            {
                                finalMap += " ";
                            }
                            if (pokemon.DefStatBase < 10)
                            {
                                finalMap += " ";
                            }
                            i += 4;
                            nbDash += 4;
                            break;
                        //attack3
                        case 58:
                            if (pokemon.ListAttacks.Count >= 3)
                            {
                                finalMap += pokemon.ListAttacks[2].ComponentName.Remove(10) + " " + pokemon.ListAttacks[2].AttackStat;
                                if (pokemon.ListAttacks[2].AttackStat < 1000)
                                {
                                    finalMap += " ";
                                }
                                if (pokemon.ListAttacks[2].AttackStat < 100)
                                {
                                    finalMap += " ";
                                }
                                if (pokemon.ListAttacks[2].AttackStat < 10)
                                {
                                    finalMap += " ";
                                }
                            }
                            else
                            {
                                finalMap += "               ";
                            }
                            finalMap += " ";
                            i += 14;
                            nbDash += 14;
                            break;
                        //speed
                        case 72:
                            finalMap += pokemon.SpeedStatBase + " ";
                            if (pokemon.SpeedStatBase < 1000)
                            {
                                finalMap += " ";
                            }
                            if (pokemon.SpeedStatBase < 100)
                            {
                                finalMap += " ";
                            }
                            if (pokemon.SpeedStatBase < 10)
                            {
                                finalMap += " ";
                            }
                            i += 4;
                            nbDash += 4;
                            break;
                        case 76:
                            string newStringHP = pokemon.CurrentHealth + "\\" + pokemon.TotalHealth;
                            while (newStringHP.Length < 9)
                            {
                                newStringHP += " ";
                            }
                            finalMap += newStringHP;
                            nbDash += 9;
                            i += 9;
                            break;
                        case 85:
                            if (pokemon.ListAttacks.Count >= 4)
                            {
                                finalMap += pokemon.ListAttacks[3].ComponentName.Remove(10) + " " + pokemon.ListAttacks[3].AttackStat;
                                if (pokemon.ListAttacks[3].AttackStat < 1000)
                                {
                                    finalMap += " ";
                                }
                                if (pokemon.ListAttacks[3].AttackStat < 100)
                                {
                                    finalMap += " ";
                                }
                                if (pokemon.ListAttacks[3].AttackStat < 10)
                                {
                                    finalMap += " ";
                                }
                            }
                            else
                            {
                                finalMap += "               ";
                            }
                            finalMap += " ";
                            i += 14;
                            nbDash += 14;
                            break;
                    }                  
                }

            }
            Console.WriteLine(finalMap + "******");
            return lastState;
        }
    }
}
