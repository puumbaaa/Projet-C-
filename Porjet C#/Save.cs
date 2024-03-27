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

        public void SaveTheGame(string playerName, Game game, Bag bag, List<Pokemon> pokemons)
        {
            string fileName = "..\\..\\..\\..\\SAVE\\" + playerName + ".txt";
            using (FileStream playerFile = File.Create(fileName));
            using (StreamWriter writePlayerFile = File.AppendText(fileName))
            {
                writePlayerFile.WriteLine(playerName);
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
                    writePlayerFile.WriteLine(pokemons[i].Name);
                    writePlayerFile.WriteLine(pokemons[i].Level);
                    writePlayerFile.WriteLine(pokemons[i].CurrentExp);
                    writePlayerFile.WriteLine(pokemons[i].TotalExp);
                    writePlayerFile.WriteLine(pokemons[i].Types1.ComponentName);
                    writePlayerFile.WriteLine(pokemons[i].AttackStatBase);
                    writePlayerFile.WriteLine(pokemons[i].DefStatBase);
                    writePlayerFile.WriteLine(pokemons[i].SpeedStatBase);
                    writePlayerFile.WriteLine(pokemons[i].CurrentHealth);
                    writePlayerFile.WriteLine(pokemons[i].TotalHealth);
                    writePlayerFile.WriteLine(pokemons[i].ListAttacks.Count);

                    for (int j = 0; j < pokemons[i].ListAttacks.Count; j++)
                    {
                        writePlayerFile.WriteLine(pokemons[i].ListAttacks[j].ComponentName);
                        writePlayerFile.WriteLine(pokemons[i].ListAttacks[j].AttackStat);
                        writePlayerFile.WriteLine(pokemons[i].ListAttacks[j].OTypes.ComponentName);
                    }
                }
            }
        }
    }
}
