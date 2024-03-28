using Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porjet_C_
{
    public class AttackList
    {

        public int[] Error = { -1 };
        public List<int> AttackChoseCases = new List<int>();
        public Attack AttackChose;

        // Attack = { case1, case2, case3, ... caseN, damages }
        public int[] novaStrike = { 9, 11, 15, 17 };
        public int[] stellarRoar = { 9, 10, 15, 16 };
        public int[] lunarShield = { 9, 12, 15 };
        public int[] celestialBeam = { 9, 11, 13, 16 };


    }
}
