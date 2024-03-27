using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mapp;
using Input;
using System;

using Porjet_C_;
using System.Security.Cryptography;
using System.IO.Compression;
using System.Numerics;

namespace game
{
    class Game
    {
        FileReader _mapFile = new FileReader();
        Map _map = new Map();
        GameObject _player;
        InputManager _inputManager = new InputManager();
        int _posX;
        int _posY;

        public int PosX { get => _posX; set => _posX = value; }
        public int PosY { get => _posY; set => _posY = value; }
        public Game(GameObject player)
        {
            _player = player;  
            string sMap = "..\\..\\..\\..\\ASCII\\Map\\map.txt";
            string sCombat = "..\\..\\..\\..\\ASCII\\Scenes\\combat.txt";
            string sMonster = "..\\..\\..\\..\\ASCII\\Sprites\\monster1.txt";

            _mapFile.setFile(sMap);
            _mapFile.printFile();
            
            _map.mapSet(_mapFile.sText);

            Console.SetCursorPosition(0, 0);
            Console.SetBufferSize(120, 31);

            
            List<ConsoleKey> inputKeys = new List<ConsoleKey> { ConsoleKey.LeftArrow, ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.RightArrow };
            _inputManager.Init(inputKeys);

            PosX = 60;
            PosY = 15;
        }
        public void update(int x, int y)
        {
            Console.Clear();
            _mapFile.printFile();

            Console.SetCursorPosition(x, y);
            Console.WriteLine(((Render)_player.ComponentsList[0]).RenderString);
            Console.CursorVisible = false;
            _posX = x;
            _posY = y;
        }
        public void setPos(int x, int y) { PosX = x; PosY = y; }
        public void gameScript()
        {
            int x = PosX;
            int y = PosY;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(((Render)_player.ComponentsList[0]).RenderString);
            Console.CursorVisible = false;
            while (true)
            {

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                _inputManager.Update(keyInfo);
                if (_inputManager.IsKey((ConsoleKey)37))
                {
                    if (x >= 1)
                    {
                        if (_map._mapTab[y, x - 1].ComponentsList[0] is CaseState)
                        {
                            if (((CaseState)_map._mapTab[y, x - 1].ComponentsList[0]).IsWalkable)
                            {
                                Console.MoveBufferArea(x, y, 1, 1, x - 1, y);
                                x -= 1;
                                update(x, y);  
                            }
                        }
                    }

                }
                if (_inputManager.IsKey((ConsoleKey)38))
                {
                    if (y >= 1)
                    {
                        if (_map._mapTab[y - 1, x].ComponentsList[0] is CaseState)
                        {
                            if (((CaseState)_map._mapTab[y - 1, x].ComponentsList[0]).IsWalkable)
                            {

                                Console.MoveBufferArea(x, y, 1, 1, x, y - 1);
                                y -= 1;
                                update(x, y);
                            }
                        }

                    }

                }
                if (_inputManager.IsKey((ConsoleKey)39))
                {
                    if (x < 119)
                    {
                        if (_map._mapTab[y, x + 1].ComponentsList[0] is CaseState)
                        {
                            if (((CaseState)_map._mapTab[y, x + 1].ComponentsList[0]).IsWalkable)
                            {
                                Console.MoveBufferArea(x, y, 1, 1, x + 1, y);
                                x += 1;
                                update(x, y);
                            }
                        }

                    }

                }
                if (_inputManager.IsKey((ConsoleKey)40))
                {
                    if (y <= 28)
                    {
                        if (_map._mapTab[y + 1, x].ComponentsList[0] is CaseState)
                        {
                            if (((CaseState)_map._mapTab[y + 1, x].ComponentsList[0]).IsWalkable)
                            {

                                Console.MoveBufferArea(x, y, 1, 1, x, y + 1);
                                y += 1;
                                update(x, y);
                            }
                        }

                    }
                }
                
                if (((CaseState)_map._mapTab[y, x].ComponentsList[0]).StartFight())
                {
                    //return;
                }
                else if (_map._mapTab[y, x].ComponentsList.Count != 1)
                {
                    if (((Bag)_map._mapTab[y, x].ComponentsList[1]).ObjectsList.FirstOrDefault() != null)
                    {
                        ((Bag)_player.ComponentsList[1]).ObjectsList.Add(((Bag)_map._mapTab[y, x].ComponentsList[1]).ObjectsList[0]);
                        ((Bag)_map._mapTab[y, x].ComponentsList[1]).RemoveObject(((Bag)_map._mapTab[y, x].ComponentsList[1]).ObjectsList[0]);
                        Console.WriteLine("Vous avez ramassé une pokeball !");
                    }

                }
            }
        }
    }    
}
