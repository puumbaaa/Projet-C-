using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porjet_C_
{
    internal class Pokemon
    {
        string _name;
        int _level;
        int _currentExp;
        int _totalExp;
        Types _types1;
        //Types _types2;
        float _attackStat;
        float _defStat;
        float _speedStat;
        float _currentHealth;
        float _totalHealth;
        bool _isKO;
        List<Attack> _listAttacks;
        List<Objects> _listUsedObjects;


        public string Name { get => _name; private set => _name = value; }
        public int Level { get => _level; private set => _level = value; }
        public int CurrentExp { get => _currentExp; private set => _currentExp = value; }
        public int TotalExp { get => _totalExp; private set => _totalExp = value; }
        public Types Types1 { get => _types1; private set => _types1 = value; }
        //public Types Types2 { get => _types2; private set => _types2 = value; }
        public float AttackStat { get => _attackStat; private set => _attackStat = value; }
        public float DefStat { get => _defStat; private set => _defStat = value; }
        public float SpeedStat { get => _speedStat; private set => _speedStat = value; }
        public float CurrentHealth { get => _currentHealth; private set => _currentHealth = value; }
        public float TotalHealth { get => _totalHealth; private set => _totalHealth = value; }
        public bool IsKO { get => _isKO; private set => _isKO = value; }
        public List<Attack> ListAttacks { get => _listAttacks; private set => _listAttacks = new(10); }
        public List<Objects> ListUsedObjects { get => _listUsedObjects; private set => _listUsedObjects = new(10); }

        public Pokemon(string name, int level, int currentExp, int totalExp, Types types1, float attackStat, float defStat, float speedStat, float currentHealth, float totalHealth, bool isKO)
        {
            Name = name;
            Level = level;
            CurrentExp = currentExp;
            TotalExp = totalExp;
            Types1 = types1;
            AttackStat = attackStat;
            DefStat = defStat;
            SpeedStat = speedStat;
            CurrentHealth = currentHealth;
            TotalHealth = totalHealth;
            Name = name;
            Level = level;
            CurrentExp = currentExp;
            TotalExp = totalExp;
            Types1 = types1;
            AttackStat = attackStat;
            DefStat = defStat;
            SpeedStat = speedStat;
            CurrentHealth = currentHealth;
            TotalHealth = totalHealth;
            IsKO = isKO;
            ListAttacks = new List<Attack>();
            ListUsedObjects = new List<Objects>(1);
        }
        public void setAttck( Attack attack)
        {
            ListAttacks.Add(attack);
        }

        public void UseObject(Objects obj)
        {
            ListUsedObjects.Add(obj);
        }

        public void TakeDamage(Pokemon pokemonEnemy, Attack EnemyAttack, Objects EnemyObject)//if enemy has object
        {
            float totalDamage = 0;
            if (EnemyObject.StatName == "attack")
            {
                totalDamage += EnemyObject.StatValue / 100;
            }
            TakeDamage(pokemonEnemy, EnemyAttack, totalDamage);
        }

        public void TakeDamage(Pokemon pokemonEnemy, Attack EnemyAttack, float totalDamage = 0) //if enemy has no object 
        {
            totalDamage += (pokemonEnemy.AttackStat + EnemyAttack.AttackStat)/100;
            //attaque efficace contre notre pokemon
            for (int i = 0; i < EnemyAttack.OTypes.StrengthType.Count; i++)
            {
                if (EnemyAttack.OTypes.StrengthType[i] == Types1 /*|| EnemyAttack.OTypes.StrengthType[i] == Types2*/)
                {
                    totalDamage *= 2;
                }
            }

            //attaque non efficace contre notre pokemon
            for (int i = 0; i < EnemyAttack.OTypes.WeaknessType.Count; i++)
            {
                if (EnemyAttack.OTypes.WeaknessType[i] == Types1 /*|| EnemyAttack.OTypes.WeaknessType[i] == Types2*/)
                {
                    totalDamage *= 0.5f;
                }
            }

            totalDamage -= DefStat / 100;
            for (int i = 0; i < ListUsedObjects.Count; i++)
            {
                if (ListUsedObjects[i].StatName == "def")
                {
                    totalDamage -= ListUsedObjects[i].StatValue;
                }
            }
            if (CurrentHealth - totalDamage < 0)
            {
                CurrentHealth = 0;
                IsKO = true;
            }
            else
            {
                CurrentHealth -= totalDamage;
            }

        }

        public void Heal(Objects potion)
        {
            CurrentHealth += potion.StatValue;
            if (CurrentHealth > TotalHealth) 
            {
                CurrentHealth = TotalHealth;
            }
        }

        public void GetExp(Pokemon pokemonEnemy)
        {
            if (Level < 100) 
            {
                CurrentExp += pokemonEnemy.Level * 200;
                while (CurrentExp >= TotalExp)
                {
                    CurrentExp -= TotalExp;
                    Level += 1;
                    TotalExp += TotalExp / 10;
                    AttackStat += AttackStat / 10;
                    DefStat += DefStat / 10;
                    SpeedStat += SpeedStat / 10;
                    CurrentHealth += TotalHealth / 10;
                    TotalHealth += TotalHealth / 10;
                }
            }
        }


    }
}
