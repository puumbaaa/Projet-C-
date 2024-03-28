using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using game;

namespace Porjet_C_
{
    internal class Save
    {

        public Save() 
        {
        }

        public void SaveTheGame( Game game, Bag bag, List<Pokemon> pokemons)
        {
            string fileName = "..\\..\\..\\..\\SAVE\\" + game.Playername + ".txt";
            using (FileStream playerFile = File.Create(fileName));
            using (StreamWriter writePlayerFile = File.AppendText(fileName))
            {
                writePlayerFile.WriteLine(game.PosX);
                writePlayerFile.WriteLine(game.PosY);
                writePlayerFile.WriteLine(bag.NbKey);
                writePlayerFile.WriteLine(bag.NbPokeball);
                writePlayerFile.WriteLine(bag.NbPotion);
                writePlayerFile.WriteLine(bag.AttackBoost);
                writePlayerFile.WriteLine(bag.DefBoost);
                writePlayerFile.WriteLine(bag.SpeedBoost);
                writePlayerFile.WriteLine(pokemons.Count);
                for (int i = 0; i < pokemons.Count; i++)
                {
                    writePlayerFile.WriteLine(pokemons[i].ComponentName);
                    writePlayerFile.WriteLine(pokemons[i].Level);
                    writePlayerFile.WriteLine(pokemons[i].CurrentExp);
                    writePlayerFile.WriteLine(pokemons[i].TotalExp);
                    writePlayerFile.WriteLine(pokemons[i].Types1.Name);
                    writePlayerFile.WriteLine(pokemons[i].AttackStatBase);
                    writePlayerFile.WriteLine(pokemons[i].DefStatBase);
                    writePlayerFile.WriteLine(pokemons[i].SpeedStatBase);
                    writePlayerFile.WriteLine(pokemons[i].CurrentHealth);
                    writePlayerFile.WriteLine(pokemons[i].TotalHealth);
                    writePlayerFile.WriteLine(pokemons[i].ListAttacks.Count);

                    for (int j = 0; j < 4; j++)
                    {
                        if (pokemons[i].ListAttacks.Count > j)
                        {
                            writePlayerFile.WriteLine(pokemons[i].ListAttacks[j].ComponentName);
                            writePlayerFile.WriteLine(pokemons[i].ListAttacks[j].AttackStat);
                            writePlayerFile.WriteLine(pokemons[i].ListAttacks[j].OTypes.Name);
                        }
                        else
                        {
                            writePlayerFile.WriteLine("");
                            writePlayerFile.WriteLine("");
                            writePlayerFile.WriteLine("");
                        }
                        
                    }
                }
            }
        }

        public List<Pokemon> LoadGame(string playerName, Game game, Bag bag, List<Types> allTypes) 
        {
            string fileName = "..\\..\\..\\..\\SAVE\\" + playerName + ".txt";
            if (File.Exists(fileName)) 
            {
                string[] lines = File.ReadAllLines(fileName);
                game.setPos(Int32.Parse(lines[0]), Int32.Parse(lines[1]));
                bag.setObjectInBag(Int32.Parse(lines[2]), Int32.Parse(lines[3]), Int32.Parse(lines[4]), Int32.Parse(lines[5]), Int32.Parse(lines[6]), Int32.Parse(lines[7]));

                int nbPokemon = Int32.Parse(lines[8]);
                List<Pokemon> pokemonList = new List<Pokemon>();
                for (int i = 0; i < nbPokemon; i++)
                {

                    Types pokmeonType = null;
                    int currentPokemon = 9 + (11+12)*i;
                    foreach (var item in allTypes)
                    {
                        if (item.Name == lines[currentPokemon+4])
                        {
                            pokmeonType = item;
                        }
                    }
                    Pokemon newPokemon = new Pokemon(lines[currentPokemon], Int32.Parse(lines[currentPokemon + 1]), Int32.Parse(lines[currentPokemon + 2]), Int32.Parse(lines[currentPokemon + 3]), pokmeonType, Int32.Parse(lines[currentPokemon + 5]), Int32.Parse(lines[currentPokemon + 6]), Int32.Parse(lines[currentPokemon + 7]), Int32.Parse(lines[currentPokemon + 8]), Int32.Parse(lines[currentPokemon + 9]), false);
                    for (int j = 0; j < Int32.Parse(lines[currentPokemon+10]); j++)
                    {
                        string name = lines[currentPokemon+10+j*3];
                        Types types = null;
                        foreach (var item in allTypes)
                        {
                            if (item.Name == lines[currentPokemon + 10 + j * 3 +1])
                            {
                                types = item;
                            }
                        }
                        int attack= Int32.Parse(lines[currentPokemon + 10 + j * 3 + 2]); 
                        Attack newAttack = new Attack(name, types, attack);
                        newPokemon.setAttck(newAttack);
                    }
                    pokemonList.Add(newPokemon);
                }

                return pokemonList;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
