// See https://aka.ms/new-console-template for more information

using Mapp;
using Input;
using System;
using Gridd;
using Porjet_C_;

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

            string sCombat = "..\\..\\..\\..\\ASCII\\Scenes\\combat.txt";
            string sMonster1 = "..\\..\\..\\..\\ASCII\\Sprites\\monster1.txt";

            /*//----------------------------------------------------------------------------------|
            |                                                                                     |
            |                                                                                     |
            |                                  Create FileReaders                                 |
            |                                                                                     |
            |                                                                                     |
            *///----------------------------------------------------------------------------------|

            FileReader combatGridFile = new FileReader();
            FileReader monster1File = new FileReader();

            /*//----------------------------------------------------------------------------------|
            |                                                                                     |
            |                                                                                     |
            |                                  Set Files for FileReaders                          |
            |                                                                                     |
            |                                                                                     |
            *///----------------------------------------------------------------------------------|

            combatGridFile.SetFile(sCombat);
            monster1File.SetFile(sMonster1);

            /*//----------------------------------------------------------------------------------|
            |                                                                                     |
            |                                                                                     |
            |                                  Set Instances                                      |
            |                                                                                     |
            |                                                                                     |
            *///----------------------------------------------------------------------------------|

            Grid grid = new Grid();


            /*//----------------------------------------------------------------------------------|
            |                                                                                     |
            |                                                                                     |
            |                                  Set Grids                                          |
            |                                                                                     |
            |                                                                                     |
            *///----------------------------------------------------------------------------------|

            grid.GenerateGrids();
            grid.gridSlots[1] = 1;
            grid.m_Case = 0;

            /*//----------------------------------------------------------------------------------|
            |                                                                                     |
            |                                                                                     |
            |                                  Draw                                               |
            |                                                                                     |
            |                                                                                     |
            *///----------------------------------------------------------------------------------|
            combatGridFile.printFile();


            Console.SetCursorPosition(0, 0);
            Console.SetBufferSize(120, 31);

            InputManager inputManager = new InputManager();
            List<ConsoleKey> inputKeys = new List<ConsoleKey> { ConsoleKey.LeftArrow, ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.RightArrow };
            inputManager.Init(inputKeys);
            Types water = new Types("water");
            Types fire = new Types("fire");
            Types grass = new Types("grass");
            Types normal = new Types("normal");

            water.AddWeakness(grass);
            grass.AddWeakness(fire);
            fire.AddWeakness(water);

            water.AddStrength(fire);
            grass.AddStrength(water);
            fire.AddStrength(grass);

            normal.AddWeakness(water);
            normal.AddWeakness(fire);
            normal.AddWeakness(grass);

            Attack testAttaque = new Attack("Test", grass, 160.0f);

            //Console.WriteLine(testAttaque.ComponentName);
            //Console.WriteLine(testAttaque.AttackStat);
            //Console.WriteLine(testAttaque.OTypes.ComponentName);


            GameObject testGameObject = new GameObject();

            testGameObject.AddComponent(testAttaque);
            testGameObject.AddComponent(water);

            //Console.WriteLine(testGameObject.ComponentsList[0].ComponentName);
            //Console.WriteLine(testGameObject.ComponentsList[1].ComponentName);

            CaseState caseState = new CaseState("testCase", true, false, true);
            //Console.WriteLine(caseState.ComponentName);

            //Objects testObjectKey = new Objects("testKey");
            //Console.WriteLine(testObjectKey.ComponentName);
            //Console.WriteLine(testObjectKey.IsKey);

            Objects testObjectBoost = new Objects("testObject", "Attaque", 160.0f);
            //Console.WriteLine(testObjectBoost.ComponentName);
            //Console.WriteLine(testObjectBoost.IsKey);
            //Console.WriteLine(testObjectBoost.StatName);
            //Console.WriteLine(testObjectBoost.StatValue);
            int x = 60;
            int y = 15;
            Console.SetCursorPosition(x, y);
            Console.CursorVisible = false;

            while (true) // Game Loop
            {

                /*//----------------------------------------------------------------------------------|
                |                                                                                     |
                |                                                                                     |
                |                                  Moving                                             |
                |                                                                                     |
                |                                                                                     |
                *///----------------------------------------------------------------------------------|

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                inputManager.Update(keyInfo);
                if (x >= 1)
                {
                    if (inputManager.IsKey((ConsoleKey)37)) // Left
                    {
                        Console.MoveBufferArea(x, y, 1, 1, x - 1, y);
                        x -= 1;

                        if (grid.m_Case - 1 >= 0)
                        {
                            grid.m_Case -= 1;
                        }

                    }
                }

                if (y >= 1)
                {
                    if (inputManager.IsKey((ConsoleKey)38)) // Up
                    {
                        Console.MoveBufferArea(x, y, 1, 1, x, y - 1);
                        y -= 1;

                        if (grid.m_Case - 3 >= 0)
                        {
                            grid.m_Case -= 3;
                        }

                    }
                }

                if (x <= 118)
                {
                    if (inputManager.IsKey((ConsoleKey)39)) // Right
                    {
                        Console.MoveBufferArea(x, y, 1, 1, x + 1, y);
                        x += 1;

                        if (grid.m_Case + 1 <= 17)
                        {
                            grid.m_Case += 1;
                        }

                    }
                }

                if (y <= 28)
                {
                    if (inputManager.IsKey((ConsoleKey)40)) // Down
                    {
                        Console.MoveBufferArea(x, y, 1, 1, x, y + 1);
                        y += 1;

                        if (grid.m_Case + 3 <= 17)
                        {
                            grid.m_Case += 3;
                        }

                    }
                }








                /*//----------------------------------------------------------------------------------|
                |                                                                                     |
                |                                                                                     |
                |                                  Clear and redraw                                   |
                |                                                                                     |
                |                                                                                     |
                *///----------------------------------------------------------------------------------|
                Console.Clear();

                // Draw Grid
                combatGridFile.printFile();

                // Draw Enemy
                for (int i = 0; i < monster1File.GetLineCount(sMonster1); i++)
                {
                    Console.SetCursorPosition(grid.combatGrid[grid.m_Case, 0], grid.combatGrid[grid.m_Case, 1] + i);
                    monster1File.PrintFileLine(sMonster1, i);
                }

                


            } // End of Game Loop



        }
    }
}
