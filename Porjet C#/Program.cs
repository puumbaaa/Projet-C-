// See https://aka.ms/new-console-template for more information

using Mapp;
using Input;
using System;

using Porjet_C_;

namespace test
{
    class Program
    {

    

        static void Main(string[] args)
        {

            
            FileReader map = new FileReader();
            map.setFile();
            Console.WriteLine(map.sText);
            Console.SetCursorPosition(0, 0);
            Console.SetBufferSize(120, 30);
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

            Attack testAttaque = new Attack("Test", water, 160.0f);

            Console.WriteLine(testAttaque.ComponentName);
            Console.WriteLine(testAttaque.AttackStat);
            Console.WriteLine(testAttaque.OTypes.ComponentName);

            GameObject testGameObject = new GameObject();

            testGameObject.AddComponent(testAttaque);
            testGameObject.AddComponent(water);

            Console.WriteLine(testGameObject.ComponentsList[0].ComponentName);
            Console.WriteLine(testGameObject.ComponentsList[1].ComponentName);

            CaseState caseState = new CaseState("testCase", true, false, true);
            Console.WriteLine(caseState.ComponentName);

            Objects testObjectKey = new Objects("testKey");
            Console.WriteLine(testObjectKey.ComponentName);
            Console.WriteLine(testObjectKey.IsKey);
            
            Objects testObjectBoost = new Objects("testObject", "Attaque", 160.0f);
            Console.WriteLine(testObjectBoost.ComponentName);
            Console.WriteLine(testObjectBoost.IsKey);
            Console.WriteLine(testObjectBoost.StatName);
            Console.WriteLine(testObjectBoost.StatValue);
            while (true) {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                inputManager.Update(keyInfo);
                if (inputManager.IsKey((ConsoleKey)37))
                {
                    Console.WriteLine("aaaaa");
                }
                if (inputManager.IsKey((ConsoleKey)38))
                {
                    Console.WriteLine("aaaaaaaa");
                }
                if (inputManager.IsKey((ConsoleKey)39))
                {
                    Console.WriteLine("a");
                }
                if (inputManager.IsKey((ConsoleKey)40))
                {
                    Console.WriteLine("aaa");
                }
            }
        }
    }
}
    