// See https://aka.ms/new-console-template for more information

using game;
using Mapp;
using Porjet_C_;
using System.IO.Compression;
using System.Runtime.InteropServices;

namespace test
{
    class Program
    {

        enum StateMachineGame {map,menu,combat}

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_MAXIMIZE = 3;
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
            Types type = new Types("firehjsfgkjlfgejhsgflsdgh");
            Attack attack1 = new Attack("aazeazezaazeaeaeaezzeazeazezaeae", type, 1000);
            Pokemon pokemon1 = new Pokemon("testPokemon", 10000, 1000, 1000, type, 1111, 2222, 3333, 100, 200, false);
            pokemon1.setAttck(attack1);
            Types types1 = new Types("fire");
            Types types2 = new Types("water");

            GameObject pokemonGameObject = new GameObject();
            pokemonGameObject.AddComponent(pokemon1);
            ((Bag)bag).PokemonList.Add(pokemonGameObject);
            Menu menuPokemonTest = new Menu("Pokemons", player);

            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, SW_MAXIMIZE);

            StateMachineGame stateMachineGame = new StateMachineGame();
            Game game = new Game(player);
            int lastState = 0;
            List<Types> listType = new List<Types>();
            listType.Add(types1);
            listType.Add(types2);
            types1.AddStrength(types2);
            types2.AddWeakness(types1);
            List<Pokemon> pokemonList = new List<Pokemon>();
            Save save = new Save();
            if (File.Exists("..\\..\\..\\..\\SAVE\\" + game.Playername + ".txt"))
            {
                pokemonList = save.LoadGame(game.Playername, game, (Bag)bag, listType);
            }
            else
            {
                save.SaveTheGame(game, (Bag)bag, pokemonList);
            }
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
                        if (stateMachineGame == (StateMachineGame)1)
                        {
                            save.SaveTheGame(game, (Bag)bag, pokemonList);
                        }
                        Console.Clear();
                        Console.WriteLine("\x1b[3J");
                        break;
                    case (StateMachineGame)2:
                        stateMachineGame = 0;
                        Console.WriteLine("fightiiiiiiiiiing");
                        Console.Clear();
                        Console.WriteLine("\x1b[3J");
                        lastState = 2;
                        break;

                }
            }
            
            
            

        }
    }
}
    