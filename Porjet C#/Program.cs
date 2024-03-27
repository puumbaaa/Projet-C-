﻿// See https://aka.ms/new-console-template for more information

using game;
using Mapp;
using Input;
using System;
using Gridd;
using Combat;
using Porjet_C_;
using System.Diagnostics;

namespace test
{
    class Program
    {



        static void Main(string[] args)
        {

            /*//----------------------------------------------------------------------------------|
            |                                                                                     |
            |                                                                                     |
            |                                  Set Files Path                                     |
            |                                                                                     |
            |                                                                                     |
            *///----------------------------------------------------------------------------------|

            string sCombat =   "..\\..\\..\\..\\ASCII\\Scenes\\combat.txt";
            string sMonster1 = "..\\..\\..\\..\\ASCII\\Sprites\\monster1.txt";
            string sCaseFull = "..\\..\\..\\..\\ASCII\\Sprites\\caseFull.txt";

            /*//----------------------------------------------------------------------------------|
            |                                                                                     |
            |                                                                                     |
            |                                  Create FileReaders                                 |
            |                                                                                     |
            |                                                                                     |
            *///----------------------------------------------------------------------------------|

            FileReader combatGridFile = new FileReader();
            FileReader monster1File = new FileReader();
            FileReader caseFullFile = new FileReader();

            /*//----------------------------------------------------------------------------------|
            |                                                                                     |
            |                                                                                     |
            |                                  Set Files for FileReaders                          |
            |                                                                                     |
            |                                                                                     |
            *///----------------------------------------------------------------------------------|

            combatGridFile.SetFile(sCombat);
            monster1File.SetFile(sMonster1);
            caseFullFile.SetFile(sCaseFull);

            /*//----------------------------------------------------------------------------------|
            |                                                                                     |
            |                                                                                     |
            |                                  Set Instances                                      |
            |                                                                                     |
            |                                                                                     |
            *///----------------------------------------------------------------------------------|

            Grid grid = new Grid();
            CombatMenu combatMenu = new CombatMenu();
            AttackList attack = new AttackList();

            
            

            /*//----------------------------------------------------------------------------------|
            |                                                                                     |
            |                                                                                     |
            |                                  Initialize things                                  |
            |                                                                                     |
            |                                                                                     |
            *///----------------------------------------------------------------------------------|

            //Grid
            grid.GenerateGrids();

            /*//----------------------------------------------------------------------------------|
            |                                                                                     |
            |                                                                                     |
            |                                  Draw                                               |
            |                                                                                     |
            |                                                                                     |
            *///----------------------------------------------------------------------------------|
            
            // Draw Grid
            combatGridFile.PrintFile();

            int m_EnemyCase = 13;
            int m_Case;

            // Draw Enemy
            for (int i = 0; i < 2; i++)
            {
                m_Case = i + 13;
                for (int j = 0; j < monster1File.GetLineCount(sMonster1); j++)
                {
                    Console.SetCursorPosition(grid.combatGrid[m_Case, 0], grid.combatGrid[m_Case, 1] + j);
                    monster1File.PrintFileLine(sMonster1, j);
                }
            }


            // Draw Combat Menu
            Console.SetCursorPosition(0, 28);
            combatMenu.globalState = GlobalState.ATTACK;
            combatMenu.attackState = AttackState.OUT;

            combatMenu.SetGlobalMenu();





            Console.SetCursorPosition(0, 0);
            Console.SetBufferSize(120, 31);


            Console.SetCursorPosition(0, 0);
            Console.SetBufferSize(120, 30);
            InputManager inputManager = new InputManager();
            List<ConsoleKey> inputKeys = new List<ConsoleKey> { ConsoleKey.LeftArrow, ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.RightArrow, ConsoleKey.Enter, ConsoleKey.Backspace };
            inputManager.Init(inputKeys);
            
            int x = 60;
            int y = 15;
            Console.SetCursorPosition(x, y);
            Console.CursorVisible = false;

            while (true) // Game Loop
            {

                /*//----------------------------------------------------------------------------------|
                |                                                                                     |
                |                                                                                     |
                |                                  Move                                               |
                |                                                                                     |
                |                                                                                     |
                *///----------------------------------------------------------------------------------|

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                inputManager.Update(keyInfo);

 
                // Move Left
                if (x >= 1)
                {
                    if (inputManager.IsKey((ConsoleKey)37)) // Left
                    {
                        Console.MoveBufferArea(x, y, 1, 1, x - 1, y);
                        x -= 1;
                    }
                }
                
                // Move Up
                if (y >= 1)
                {
                    if (inputManager.IsKey((ConsoleKey)38)) // Up
                    {
                        Console.MoveBufferArea(x, y, 1, 1, x, y - 1);
                        y -= 1;
                    }
                }
                
                // Move Right
                if (x <= 118)
                {
                    if (inputManager.IsKey((ConsoleKey)39)) // Right
                    {
                        Console.MoveBufferArea(x, y, 1, 1, x + 1, y);
                        x += 1;
                    }
                
                  
                }
                
                // Move Down
                if (y <= 28)
                    {
                    if (inputManager.IsKey((ConsoleKey)40)) // Down
                    {
                        Console.MoveBufferArea(x, y, 1, 1, x, y + 1);
                        y += 1;
                    }
                }

            /*//----------------------------------------------------------------------------------|
            |                                                                                     |
            |                                                                                     |
            |                                  Attack Menu                                        |
            |                                                                                     |
            |                                                                                     |
            *///----------------------------------------------------------------------------------|

                combatMenu.SelectMenu(inputManager);

            /*//----------------------------------------------------------------------------------|
            |                                                                                     |
            |                                                                                     |
            |                                  Clear and redraw                                   |
            |                                                                                     |
            |                                                                                     |
            *///----------------------------------------------------------------------------------|
            Console.Clear();

                // Draw Grid
                combatGridFile.PrintFile();

                // Draw Combat Menu
                Console.SetCursorPosition(0, 28);

                if (combatMenu.globalState != GlobalState.OUT)
                    combatMenu.SetGlobalMenu();



                // Attack Menu
                if (combatMenu.attackState != AttackState.OUT)
                {

                    // Use Attack
                    if (inputManager.IsKey((ConsoleKey)13)) // Enter
                    {
                        combatMenu.UseAttack(attack, grid);
                    }

                    // Draw Attack Menu
                    combatMenu.SetAttackMenu();

                    // Show Attack Cases
                    combatMenu.ShowAttackCases(attack);

                    // Draw Selected Cases
                    for (int i = 0; i < attack.AttackChose.Count() ; i++)
                    {
                        m_Case = attack.AttackChose[i];
                        for (int j = 0; j < caseFullFile.GetLineCount(sCaseFull); j++)
                        {
                            Console.SetCursorPosition(grid.combatGrid[m_Case, 0], grid.combatGrid[m_Case, 1] + j);
                            caseFullFile.PrintFileLine(sCaseFull, j);
                        }
                    }

                }


                // Draw Enemy
                for (int i = 0; i < 2; i++)
                {
                    m_Case = i+13;
                    grid.gridSlots[m_Case] = 1;
                    for (int j = 0; j < monster1File.GetLineCount(sMonster1); j++)
                    {
                        Console.SetCursorPosition(grid.combatGrid[m_Case, 0], grid.combatGrid[m_Case, 1] + j);
                        monster1File.PrintFileLine(sMonster1, j);
                    }
                }





            } // End of Game Loop



        }
    }
}