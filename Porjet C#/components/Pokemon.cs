using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porjet_C_
{
    internal class Pokemon : Component
    {
        int _level;
        int _currentExp;
        int _totalExp;
        Types _types1;
        //Types _types2;
        int _attackStatBase;
        float _attackStatInFight;
        int _defStatBase;
        float _defStatInFight;
        int _speedStatBase;
        float _speedStatInFight;
        int _currentHealth;
        int _totalHealth;
        bool _isKO;
        List<Attack> _listAttacks;
        List<Objects> _listUsedObjects;


        public int Level { get => _level; private set => _level = value; }
        public int CurrentExp { get => _currentExp; private set => _currentExp = value; }
        public int TotalExp { get => _totalExp; private set => _totalExp = value; }
        public Types Types1 { get => _types1; private set => _types1 = value; }
        //public Types Types2 { get => _types2; private set => _types2 = value; }
        public int AttackStatBase { get => _attackStatBase; private set => _attackStatBase = value; }
        public int DefStatBase { get => _defStatBase; private set => _defStatBase = value; }
        public int SpeedStatBase { get => _speedStatBase; private set => _speedStatBase = value; }
        public float AttackStatInFight { get => _attackStatInFight; private set => _attackStatInFight = value; }
        public float DefStatInFight { get => _defStatInFight; private set => _defStatInFight = value; }
        public float SpeedStatInFight { get => _speedStatInFight; private set => _speedStatInFight = value; }
        public int CurrentHealth { get => _currentHealth; private set => _currentHealth = value; }
        public int TotalHealth { get => _totalHealth; private set => _totalHealth = value; }
        public bool IsKO { get => _isKO; private set => _isKO = value; }
        public List<Attack> ListAttacks { get => _listAttacks; private set => _listAttacks = new(10); }
        public List<Objects> ListUsedObjects { get => _listUsedObjects; private set => _listUsedObjects = new(10); }

        public Pokemon(string name, int level, int currentExp, int totalExp, Types types1, int attackStat, int defStat, int speedStat, int currentHealth, int totalHealth, bool isKO) : base(name)
        {
            Level = level;
            CurrentExp = currentExp;
            TotalExp = totalExp;
            Types1 = types1;
            AttackStatBase = attackStat;
            AttackStatInFight = attackStat;
            DefStatBase = defStat;
            DefStatInFight = defStat;
            SpeedStatBase = speedStat;
            SpeedStatInFight = speedStat;
            CurrentHealth = currentHealth;
            TotalHealth = totalHealth;
            IsKO = isKO;
            ListAttacks = new List<Attack>();
            ListUsedObjects = new List<Objects>(1);
            TestMaxStat();
            StatBeginingFight();
        }

        public void TestMaxStat() 
        {
            while (CurrentExp >= TotalExp)
            {
                CurrentExp -= TotalExp;
                Level += 1;
                TotalExp += TotalExp / 10;
                AttackStatBase += AttackStatBase / 10;
                DefStatBase += DefStatBase / 10;
                SpeedStatBase += SpeedStatBase / 10;
                CurrentHealth += TotalHealth / 10;
                TotalHealth += TotalHealth / 10;
            }
            if (Level > 9999)
            {
                Level = 9999;
            }
            if (TotalExp > 9999)
            {
                TotalExp = 9999;
            }
            if (CurrentExp > 9999)
            {
                CurrentExp = 9999;
            }
            if (AttackStatBase > 9999)
            {
                AttackStatBase = 9999;
            }
            if (DefStatBase > 9999)
            {
                DefStatBase = 9999;
            }
            if (SpeedStatBase > 9999)
            {
                SpeedStatBase = 9999;
            }
            if (TotalHealth > 9999)
            {
                TotalHealth = 9999;
            }
            if (CurrentHealth > TotalHealth)
            {
                CurrentHealth = TotalHealth;
            }
        }

        public void setAttck( Attack attack)
        {
            ListAttacks.Add(attack);
        }

        public void UseObject(Objects obj, Bag bag)
        {
            ListUsedObjects.Add(obj);
            bag.RemoveObject(obj);
            if (obj.StatName=="potion")
            {
                Heal(obj);
            }
            else if (obj.StatName=="attack")
            {
                AttackStatInFight += obj.StatValue;   
            }else if (obj.StatName=="def")
            {
                DefStatInFight += obj.StatValue;   
            }else if (obj.StatName=="speed")
            {
                SpeedStatInFight += obj.StatValue;   
            }
        }

        public void StatBeginingFight()
        {
            AttackStatInFight = AttackStatBase;
            DefStatInFight = DefStatBase;
            SpeedStatInFight = SpeedStatBase;
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
            totalDamage += (pokemonEnemy.AttackStatInFight + EnemyAttack.AttackStat)/100;
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

            totalDamage -= DefStatInFight / 100;
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
                StatBeginingFight();
            }
            else
            {
                CurrentHealth -= (int) totalDamage;
            }

        }

        public void Heal(Objects potion)
        {
            CurrentHealth += (int) potion.StatValue;
            if (CurrentHealth > TotalHealth) 
            {
                CurrentHealth = TotalHealth;
            }
            IsKO = false;
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
                    AttackStatBase += AttackStatBase / 10;
                    DefStatBase += DefStatBase / 10;
                    SpeedStatBase += SpeedStatBase / 10;
                    CurrentHealth += TotalHealth / 10;
                    TotalHealth += TotalHealth / 10;
                }
            }
            TestMaxStat();
        }
    }
}
