// See https://aka.ms/new-console-template for more information

using game;
using Porjet_C_;

namespace test
{
    class Program
    {

    

        static void Main(string[] args)
        {
            
            GameObject player = new GameObject();
            Component playerRender = new Render("render","P");
            Component bag = new Bag("bag");
            player.AddComponent(playerRender);
            player.AddComponent(bag);
            //Faire une liste de pokemon pour le joueur?
            Bag bag2 = new Bag("Bag2");
            Objects object1 = new Objects("def", 10);

            List<Pokemon> pokemonList = new List<Pokemon>();
            Types types1 = new Types("fire");
            Types types2 = new Types("water");
            Attack attack1 = new Attack("Attack1", types1, 10);
            Attack attack2 = new Attack("Attack2", types2, 20);
            Attack attack3 = new Attack("Attack3", types2, 30);
            Attack attack4 = new Attack("Attack4", types1, 40);
            Pokemon pokemon1 = new Pokemon("Pokemon1", 10, 100, 200, types1, 111, 222, 333, 444, 555, false);
            pokemon1.setAttck(attack1);
            pokemon1.setAttck(attack2);
            Pokemon pokemon2 = new Pokemon("Pokemon1", 1000, 10, 20, types2, 1111, 2222, 3333, 4444, 5555, false);
            pokemon2.setAttck(attack3);
            pokemon2.setAttck(attack4);
            pokemonList.Add(pokemon1);
            pokemonList.Add(pokemon2);
            bag2.AddObject(object1);

            Game game = new Game(player);

            Save save = new Save();
            save.SaveTheGame("testPlayer1212311", game, bag2, pokemonList);
            Console.Clear();
            Console.WriteLine($"Pos : {game.PosX} , {game.PosY}");
            Console.WriteLine($"Key : {bag2.NbKey} ,  Pokeball : {bag2.NbPokeball}, potion : {bag2.NbPotion}, nbAttack : {bag2.AttackBoost}, nbDef : {bag2.DefBoost}, nbSpeed ; {bag2.SpeedBoost}");
            foreach (var item in pokemonList)
            {
                Console.WriteLine($"Name : {item.Name}");
                Console.WriteLine($"Name : {item.Types1.ComponentName}");
                Console.WriteLine($"nbAttack : {item.ListAttacks.Count}");
            }


            types1.AddStrength(types2);
            types2.AddWeakness(types1);
            List<Types> listType = new List<Types>();
            listType.Add(types1);
            listType.Add(types2);
            pokemonList = save.LoadGame("testPlayer11", game, bag2, listType);
            Console.WriteLine($"Pos : {game.PosX} , {game.PosY}"); 
            Console.WriteLine($"Key : {bag2.NbKey} ,  Pokeball : {bag2.NbPokeball}, potion : {bag2.NbPotion}, nbAttack : {bag2.AttackBoost}, nbDef : {bag2.DefBoost}, nbSpeed ; {bag2.SpeedBoost}");
            foreach (var item in pokemonList)
            {
                Console.WriteLine($"Name : {item.Name}");
                Console.WriteLine($"Name : {item.Types1.ComponentName}");
                Console.WriteLine($"nbAttack : {item.ListAttacks.Count}");
            }
            //game.gameScript();

        }
    }
}
    