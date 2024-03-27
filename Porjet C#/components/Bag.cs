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
        int _nbKey;
        int _nbPokeball;
        int _nbPotion;
        int _attackBoost;
        int _defBoost;
        int _speedBoost;

        public List<Objects> ObjectsList { get => _objectsList; private set => _objectsList = new(10); }
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

        public void setObjectInBag(int key, int pokeball, int potion, int attackBoost, int defBoost, int speedBoost)
        {
            ObjectsList = new List<Objects>();
            UpdateBag();
            Objects keyBase = new Objects(true, false);
            Objects pokeballBase = new Objects(false, true);
            Objects potionBase = new Objects("potion", 100);
            Objects attackBase = new Objects("attack", 100);
            Objects defBase = new Objects("def", 100);
            Objects speedBase = new Objects("speed", 100);
            for (int i = 0; i < key; i++)
            {
                ObjectsList.Add(keyBase);
            }for (int i = 0; i < pokeball; i++)
            {
                ObjectsList.Add(pokeballBase);
            }for (int i = 0; i < potion; i++)
            {
                ObjectsList.Add(potionBase);
            }for (int i = 0; i < attackBoost; i++)
            {
                ObjectsList.Add(attackBase);
            }for (int i = 0; i < defBoost; i++)
            {
                ObjectsList.Add(defBase);
            }for (int i = 0; i < speedBoost; i++)
            {
                ObjectsList.Add(speedBase);
            }
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
