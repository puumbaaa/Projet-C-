using Gridd;
using Input;
using Porjet_C_;
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


        public void SelectMenu(InputManager input)
        {
            // Global Menu

            // Go to Left in Attacks Menu
            if (attackState != AttackState.OUT && attackState != AttackState.ATTACK1)
            {
                if (input.IsKey((ConsoleKey)37)) // Left
                {
                    attackState -= 1;
                }
            }

            // Go to Right in Combat Menu
            if (attackState != AttackState.OUT && attackState != AttackState.ATTACK4)
            {
                if (input.IsKey((ConsoleKey)39)) // Right
                {
                    attackState += 1;
                }
            }


            // Combat Menu

            // Go to Left in Combat Menu
            if (globalState > GlobalState.ATTACK && globalState != GlobalState.OUT)
            {
                if (input.IsKey((ConsoleKey)37)) // Left
                {
                    globalState -= 1;
                }
            }

            // Go to Right in Combat Menu
            if (globalState < GlobalState.FLEE && globalState != GlobalState.OUT)
            {
                if (input.IsKey((ConsoleKey)39)) // Right
                {
                    globalState += 1;
                }
            }


            // Select Attack Menu in combat
            if (globalState == GlobalState.ATTACK && attackState == AttackState.OUT)
            {
                if (input.IsKey((ConsoleKey)13)) // Enter
                {
                    attackState = AttackState.ATTACK1;
                    globalState = GlobalState.OUT;
                }
            }

            // Return to combat Menu
            if (globalState == GlobalState.OUT)
            {
                if (input.IsKey((ConsoleKey)8)) // Backspace
                {
                    globalState = GlobalState.ATTACK;

                    attackState = AttackState.OUT;
                }
            }


        }

        public void ShowAttackCases(AttackList attack)
        {
            if (attackState == AttackState.ATTACK1)
                attack.AttackChose = attack.Attack1.ToList();

            if (attackState == AttackState.ATTACK2)
                attack.AttackChose = attack.Attack2.ToList();

            if (attackState == AttackState.ATTACK3)
                attack.AttackChose = attack.Attack3.ToList();

            if (attackState == AttackState.ATTACK4)
                attack.AttackChose = attack.Attack4.ToList();
        }

        public void UseAttack(AttackList attack, Grid grid)
        {
                for (int i = 0; i < attack.AttackChose.Count(); i++)
                {
                    for (int j = 0; j < grid.gridSlots.Count(); j++)
                    {
                        if (attack.AttackChose[i] == j && grid.gridSlots[j] != 0)
                        {

                        }
                    }
                }
        }

    } // Class End
} // Namespace End
