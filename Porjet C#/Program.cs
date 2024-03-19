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
    