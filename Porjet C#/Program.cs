// See https://aka.ms/new-console-template for more information

using game;
using Mapp;
using Porjet_C_;
using System.IO.Compression;

namespace test
{
    class Program
    {

        enum StateMachineGame {map,menu,combat}

        static void Main(string[] args)
        {
            Console.SetCursorPosition(0, 0);
            Console.SetBufferSize(120, 32);

            GameObject player = new GameObject();
            Component playerRender = new Render("render","P");
            Component bag = new Bag("bag");
            player.AddComponent(playerRender);
            player.AddComponent(bag);
            //a enlever
            GameObject gameObject = new GameObject();
            Component testCompo = new Component("test componenet");
            Component testCompo1 = new Component("test componenet1");
            Component testCompo2 = new Component("test componenet2");
            Component testCompo3 = new Component("test componenet3");
            gameObject.AddComponent(testCompo);
            gameObject.AddComponent(testCompo1);
            gameObject.AddComponent(testCompo2);
            gameObject.AddComponent(testCompo3);
            Types type = new Types("fire");
            Attack attack1 = new Attack("azertyuiop", type, 1000);
            Pokemon pokemon1 = new Pokemon("testPokemon", 1000, 1000, 1000, type, 1111, 2222, 3333, 100, 200, false);
            pokemon1.setAttck(attack1);
            ((Bag)bag).PokemonList.Add(pokemon1);
            GameObject pokemonGameObject = new GameObject();
            pokemonGameObject.AddComponent(pokemon1);
            Menu menuPokemonTest = new Menu("Pokemons", player);

            StateMachineGame stateMachineGame = new StateMachineGame();
            Game game = new Game(player);
            int lastState = 0;
            while (true) {
                switch (stateMachineGame)
                {
                    case (StateMachineGame)0:
                        stateMachineGame = (StateMachineGame)game.gameScript();
                        lastState = 0;
                        Console.Clear();
                        Console.WriteLine("\x1b[3J");
                        break;
                    case (StateMachineGame)1:
                        stateMachineGame = (StateMachineGame)menuPokemonTest.MenuScript(1, lastState);
                        Console.Clear();
                        Console.WriteLine("\x1b[3J");
                        break;
                    case (StateMachineGame)2:
                        stateMachineGame = 0;
                        Console.Clear();
                        Console.WriteLine("\x1b[3J");
                        lastState = 2;
                        break;

                }
            }
            
            
            

        }
    }
}
    