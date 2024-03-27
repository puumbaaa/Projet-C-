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
        #region Attacks List

        public int[] Error = { -1 };
        public List<int> AttackChose = new List<int>();

        // Attack = { case1, case2, case3, ... caseN, damages }
        public int[] Attack1 = { 12, 13, 14 };
        public int[] Attack2 = { 12, 10, 16 };
        public int[] Attack3 = { 15, 16, 17, 14 };
        public int[] Attack4 = { 9, 10, 11, 14 };


        #endregion

        public void AttackCaseList(string attack)
        {
            int[] Error = { -1 };

            int[] Attack1 = { 13, 14, 15 };
            int[] Attack2 = { 10, 12, 16 };
            int[] Attack3 = { 15, 16, 17, 14 };
            int[] Attack4 = { 9, 10, 11, 14 };
        }

        public int[] GetAttackCase(string attack)
        {
            if (attack == "Attack1")
                return Attack1;

            if (attack == "Attack2")
                return Attack2;

            if (attack == "Attack3")
                return Attack3;

            if (attack == "Attack4")
                return Attack4;

            else return Error;

        }

        
    }
}
