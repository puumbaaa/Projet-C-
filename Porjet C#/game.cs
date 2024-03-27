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
        int _playerX = 0;
        int _playerY = 0;

        public Game(GameObject player)
        {
            _player = player;  
            string sMap = "..\\..\\..\\..\\ASCII\\Map\\map.txt";

            _mapFile.setFile(sMap);
            _mapFile.printFile();
            
            _map.mapSet(_mapFile.sText);

            Console.SetCursorPosition(0, 0);
            Console.SetBufferSize(120, 31);

            
            List<ConsoleKey> inputKeys = new List<ConsoleKey> { ConsoleKey.LeftArrow, ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.RightArrow, ConsoleKey.Escape };
            _inputManager.Init(inputKeys);

            _playerX = 60;
            _playerY = 15;
            Console.SetCursorPosition(_playerX, _playerY);
            Console.WriteLine(((Render)_player.ComponentsList[0]).RenderString);
            Console.CursorVisible = false;
        }
        public void update()
        {
            Console.Clear();
            _mapFile.printFile();

            Console.SetCursorPosition(_playerX, _playerY);
            Console.WriteLine(((Render)_player.ComponentsList[0]).RenderString);
            Console.CursorVisible = false;
        }
        public void gameScript()
        {
            
            while (true)
            {

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                _inputManager.Update(keyInfo);
                if (_inputManager.IsKey((ConsoleKey)37))
                {
                    if (_playerX >= 1)
                    {
                        if (_map._mapTab[_playerY, _playerX - 1].ComponentsList[0] is CaseState)
                        {
                            if (((CaseState)_map._mapTab[_playerY, _playerX - 1].ComponentsList[0]).IsWalkable)
                            {
                                Console.MoveBufferArea(_playerX, _playerY, 1, 1, _playerX - 1, _playerY);
                                _playerX -= 1;
                                update();  
                            }
                        }
                    }

                }
                if (_inputManager.IsKey((ConsoleKey)38))
                {
                    if (_playerY >= 1)
                    {
                        if (_map._mapTab[_playerY - 1, _playerX].ComponentsList[0] is CaseState)
                        {
                            if (((CaseState)_map._mapTab[_playerY - 1, _playerX].ComponentsList[0]).IsWalkable)
                            {

                                Console.MoveBufferArea(_playerX, _playerY, 1, 1, _playerX, _playerY - 1);
                                _playerY -= 1;
                                update();
                            }
                        }

                    }

                }
                if (_inputManager.IsKey((ConsoleKey)39))
                {
                    if (_playerX < 119)
                    {
                        if (_map._mapTab[_playerY, _playerX + 1].ComponentsList[0] is CaseState)
                        {
                            if (((CaseState)_map._mapTab[_playerY, _playerX + 1].ComponentsList[0]).IsWalkable)
                            {
                                Console.MoveBufferArea(_playerX, _playerY, 1, 1, _playerX + 1, _playerY);
                                _playerX += 1;
                                update();
                            }
                        }

                    }

                }
                if (_inputManager.IsKey((ConsoleKey)40))
                {
                    if (_playerY <= 28)
                    {
                        if (_map._mapTab[_playerY + 1, _playerX].ComponentsList[0] is CaseState)
                        {
                            if (((CaseState)_map._mapTab[_playerY + 1, _playerX].ComponentsList[0]).IsWalkable)
                            {

                                Console.MoveBufferArea(_playerX, _playerY, 1, 1, _playerX, _playerY + 1);
                                _playerY += 1;
                                update();
                            }
                        }

                    }
                }
                
                if (((CaseState)_map._mapTab[_playerY, _playerX].ComponentsList[0]).StartFight())
                {
                    //return;
                }
                else if (_map._mapTab[_playerY, _playerX].ComponentsList.Count != 1)
                {
                    if (((Bag)_map._mapTab[_playerY, _playerX].ComponentsList[1]).ObjectsList.FirstOrDefault() != null)
                    {
                        ((Bag)_player.ComponentsList[1]).ObjectsList.Add(((Bag)_map._mapTab[_playerY, _playerX].ComponentsList[1]).ObjectsList[0]);
                        ((Bag)_map._mapTab[_playerY, _playerX].ComponentsList[1]).RemoveObject(((Bag)_map._mapTab[_playerY, _playerX].ComponentsList[1]).ObjectsList[0]);
                        Console.WriteLine("Vous avez ramassé une pokeball !");
                    }

                }
            }
        }
    }    
}
