using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porjet_C_
{
    internal class Bag : Component
    {
        List<Objects> _objectsList;
        List<Pokemon> _pokemonList;
        int _nbKey;
        int _nbPokeball;
        int _nbPotion;
        int _attackBoost;
        int _defBoost;
        int _speedBoost;

        public List<Objects> ObjectsList { get => _objectsList; private set => _objectsList = new(10); }
        public List<Pokemon> PokemonList { get => _pokemonList; private set => _pokemonList = new(6); }
        public int NbKey { get => _nbKey; private set => _nbKey = value; }
        public int NbPokeball { get => _nbPokeball; private set => _nbPokeball = value; }
        public int NbPotion { get => _nbPotion; private set => _nbPotion = value; }
        public int AttackBoost { get => _attackBoost; private set => _attackBoost = value; }
        public int DefBoost { get => _defBoost; private set => _defBoost = value; }
        public int SpeedBoost { get => _speedBoost; private set => _speedBoost = value; }

        public Bag(string nameComponent) : base(nameComponent)
        {
            ObjectsList = new List<Objects>();
            NbKey = 0;
            NbPokeball = 0;
            NbPotion = 0;
            AttackBoost = 0;
            DefBoost = 0;
            SpeedBoost = 0;
        }
        public void AddObject(Objects objects)
        {
            ObjectsList.Add(objects);
            ObjZero();
            UpdateBag();
        }
        public void ObjZero()
        {
            NbKey = 0;
            NbPokeball = 0;
            NbPotion = 0;
            AttackBoost = 0;
            DefBoost = 0;
            SpeedBoost = 0;
        }
        public void RemoveObject(Objects objects) 
        {
            ObjectsList.Remove(objects);
            ObjZero();
            UpdateBag();
        }

        public void UpdateBag()
        {
            for (int i = 0; i < ObjectsList.Count; i++)
            {
                if (ObjectsList[i].StatName == "attack")
                {
                    ++AttackBoost;
                }else if (ObjectsList[i].StatName == "def")
                {
                    ++DefBoost;
                }else if (ObjectsList[i].StatName == "potion")
                {
                    ++NbPotion;
                }else if (ObjectsList[i].StatName == "speed")
                {
                    ++SpeedBoost;
                }else if (ObjectsList[i].IsKey)
                {
                   ++ NbKey;
                }else if (ObjectsList[i].IsPokeball)
                {
                    ++NbPokeball;
                }
            }
        }
    }
}
