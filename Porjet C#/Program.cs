﻿// See https://aka.ms/new-console-template for more information


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

            Attack testAttaque = new Attack("Test", grass, 160.0f);

            Console.WriteLine(testAttaque.ComponentName);
            Console.WriteLine(testAttaque.AttackStat);
            Console.WriteLine(testAttaque.OTypes.ComponentName);

            Objects potion = new Objects("potion", "potion", 150.0f);

            Pokemon testPokemon = new Pokemon("pikachu", 12, 10, 100, water, 150, 100, 20, 1500, 1500, false);
            Pokemon testEnemyPokemon = new Pokemon("NotPikachu", 10, 10, 100, fire, 200000000000, 100, 20, 1500, 1500, false);

            Console.WriteLine($"Name : {testPokemon.Name}, Level : { testPokemon.Level} , Current exp : {testPokemon.CurrentExp}, total exp : {testPokemon.TotalExp}, current health : {testPokemon.CurrentHealth}, total health : { testPokemon.TotalHealth}");
            Console.WriteLine($"Name : {testEnemyPokemon.Name}, Level : {testEnemyPokemon.Level} , Current exp : {testEnemyPokemon.CurrentExp}, total exp : {testEnemyPokemon.TotalExp}, current health : {testEnemyPokemon.CurrentHealth}, total health : {testEnemyPokemon.TotalHealth}");
            testPokemon.TakeDamage(testEnemyPokemon, testAttaque);
            Console.WriteLine($"Name : {testPokemon.Name}, Level : { testPokemon.Level} , Current exp : {testPokemon.CurrentExp}, total exp : {testPokemon.TotalExp}, current health : {testPokemon.CurrentHealth}, total health : { testPokemon.TotalHealth}");
            testPokemon.Heal(potion);
            Console.WriteLine($"Name : {testPokemon.Name}, Level : { testPokemon.Level} , Current exp : {testPokemon.CurrentExp}, total exp : {testPokemon.TotalExp}, current health : {testPokemon.CurrentHealth}, total health : { testPokemon.TotalHealth}");

            while (true) { }
        }
    }
}
    