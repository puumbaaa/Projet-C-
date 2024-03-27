using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat
{

    public enum GlobalState
    {
        OUT,
        ATTACK,
        ITEM,
        TEAM,
        FLEE
    }

    public enum AttackState
    {
        OUT,
        ATTACK1,
        ATTACK2,
        ATTACK3,
        ATTACK4
    }

    public class CombatMenu
    {
        public GlobalState globalState;
        public AttackState attackState;
        public void SetGlobalMenu() {


            if(globalState == GlobalState.ATTACK)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("                                      Attack        ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Item         ");
                Console.Write("Team          ");
                Console.Write("Flee          ");
            }

            if(globalState == GlobalState.ITEM)
            {
                Console.ForegroundColor = ConsoleColor.White;
                
                Console.Write("                                      Attack        ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Item         ");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Team          ");
                Console.Write("Flee          ");
            }

            if(globalState == GlobalState.TEAM)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("                                      Attack        ");
                Console.Write("Item         ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Team          ");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Flee          ");
            }

            if(globalState == GlobalState.FLEE)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("                                      Attack        ");
                Console.Write("Item         ");
                Console.Write("Team          ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Flee          ");

                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        public void SetAttackMenu()
        {
            if (attackState == AttackState.ATTACK1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("                                    Attack1      ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Attack2         ");
                Console.Write("Attack3        ");
                Console.Write("Attack4        ");
            }

            if (attackState == AttackState.ATTACK2)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("                                    Attack1      ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Attack2         ");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Attack3        ");
                Console.Write("Attack4        ");
            }

            if (attackState == AttackState.ATTACK3)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("                                    Attack1      ");
                Console.Write("Attack2         ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Attack3        ");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Attack4        ");
            }

            if (attackState == AttackState.ATTACK4)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("                                    Attack1      ");
                Console.Write("Attack2         ");
                Console.Write("Attack3        ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Attack4        ");

                Console.ForegroundColor = ConsoleColor.White;
            }
        }


        public void SelectMenu()
        {
            if(globalState == GlobalState.ATTACK)
            {

            }


        }


    } // Class End
} // Namespace End
