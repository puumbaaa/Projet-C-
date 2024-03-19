// See https://aka.ms/new-console-template for more information


using Porjet_C_;

namespace test
{
    class Program
    {

        //static readonly string textFile = "C:\\Users\\wdamour\\source\\repos\\Projet-C-\\Map\\map.txt";


        static void Main(string[] args)
        {
            /*
            if (File.Exists(textFile))
            {
                // Read entire text file content in one string
                string text = File.ReadAllText(textFile);
                Console.WriteLine(text);
            }*/
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

            
            while (true) { }
        }
    }
}
    