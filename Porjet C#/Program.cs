// See https://aka.ms/new-console-template for more information

using game;
using Mapp;
using Input;
using System;
using Gridd;
using Combat;
using Porjet_C_;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Diagnostics;

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

            Menu menuPokemonTest = new Menu("Pokemons", player);

            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, SW_MAXIMIZE);

            StateMachineGame stateMachineGame = new StateMachineGame();
            Game game = new Game(player);
            int lastState = 0;

            List<Types> listType = new List<Types>();
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
                        Console.Clear();
                        Console.WriteLine("\x1b[3J");
                        lastState = 2;
                        break;

                }
            }
        }
    }
}
    