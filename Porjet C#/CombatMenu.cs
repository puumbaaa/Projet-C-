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


        int ID = 0;
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

        public void SetAttackMenu(GameData gameData)
        {
            string Attack1 = ((Pokemon)gameData.PokemonList[ID].ComponentsList[0]).ListAttacks[0].ComponentName;
            string Attack2 = ((Pokemon)gameData.PokemonList[ID].ComponentsList[0]).ListAttacks[1].ComponentName;
            string Attack3 = ((Pokemon)gameData.PokemonList[ID].ComponentsList[0]).ListAttacks[2].ComponentName;
            string Attack4 = ((Pokemon)gameData.PokemonList[ID].ComponentsList[0]).ListAttacks[3].ComponentName;

            if (attackState == AttackState.ATTACK1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                
                Console.Write("                           " + Attack1 + "      ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Attack2 + "         ");
                Console.Write(Attack3 + "        ");
                Console.Write(Attack4 + "        ");
            }

            if (attackState == AttackState.ATTACK2)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("                           " + Attack1 + "      ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(Attack2 + "         ");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Attack3 + "        ");
                Console.Write(Attack4 + "        ");
            }

            if (attackState == AttackState.ATTACK3)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("                           " + Attack1 + "      ");
                Console.Write(Attack2 + "         ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(Attack3 + "        ");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Attack4 + "        ");
            }

            if (attackState == AttackState.ATTACK4)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("                           " + Attack1 + "      ");
                Console.Write(Attack2 + "         ");
                Console.Write(Attack3 + "        ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(Attack4 + "        ");

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

        public void SelectAttack(AttackList attack, GameData gameData)
        {

            if (attackState == AttackState.ATTACK1)
            {
                attack.AttackChoseCases = ((Pokemon)gameData.PokemonList[ID].ComponentsList[0]).ListAttacks[0].OCases.ToList();
                attack.AttackChose = ((Pokemon)gameData.PokemonList[ID].ComponentsList[0]).ListAttacks[0];
            }
                

            if (attackState == AttackState.ATTACK2)
            {
                attack.AttackChoseCases = ((Pokemon)gameData.PokemonList[ID].ComponentsList[0]).ListAttacks[1].OCases.ToList();
                attack.AttackChose = ((Pokemon)gameData.PokemonList[ID].ComponentsList[0]).ListAttacks[1];
            }



            if (attackState == AttackState.ATTACK3)
            {
                attack.AttackChoseCases = ((Pokemon)gameData.PokemonList[ID].ComponentsList[0]).ListAttacks[2].OCases.ToList();
                attack.AttackChose = ((Pokemon)gameData.PokemonList[ID].ComponentsList[0]).ListAttacks[2];
            }
            if (attackState == AttackState.ATTACK4)
            {
                attack.AttackChoseCases = ((Pokemon)gameData.PokemonList[ID].ComponentsList[0]).ListAttacks[3].OCases.ToList();
                attack.AttackChose = ((Pokemon)gameData.PokemonList[ID].ComponentsList[0]).ListAttacks[3];
            }
        }

        public void UseAttack(AttackList attack, Grid grid, GameData gameData)
        {
                for (int i = 0; i < attack.AttackChoseCases.Count(); i++)
                {
                    for (int j = 0; j < grid.gridSlots.Count(); j++)
                    {
                        if (attack.AttackChoseCases[i] == j && grid.gridSlots[j] != null)
                        {
                            ((Pokemon)grid.gridSlots[j].ComponentsList[0]).TakeDamage(((Pokemon)grid.gridSlots[j].ComponentsList[0]), attack.AttackChose, null );
                            if ( ((Pokemon)grid.gridSlots[j].ComponentsList[0]).CurrentHealth <= 0 )
                            {
                               grid.gridSlots[j] = null;
                            }
                        }
                    }
                }
        }

    } // Class End
} // Namespace End
