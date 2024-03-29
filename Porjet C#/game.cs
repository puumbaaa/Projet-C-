using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mapp;
using Input;

using Porjet_C_;

namespace game
{
    class Game
    {
        FileReader _mapFile1 = new FileReader();
        FileReader _mapFile2 = new FileReader();
        FileReader _mapFile;
        Map _map1 = new Map();
        Map _map2 = new Map();
        Map _map;
        GameObject _player;
        InputManager _inputManager = new InputManager();
        string _playername;
        int _playerX = 0;
        int _playerY = 0;
        bool _isKey = false;
        int _indexMap = 0;
        string _sMap1 = "..\\..\\..\\..\\ASCII\\Map\\map.txt";
        string _sMap2 = "..\\..\\..\\..\\ASCII\\Map\\map2.txt";
        bool _isDisplayDialogue;

        public bool IsKey { get => _isKey; set => _isKey = value; }
        public int IndexMap { get => _indexMap; set => _indexMap = value; }
        public string Playername { get => _playername; set => _playername = value; }
        public int PosX { get => _playerX; set => _playerX = value; }
        public int PosY { get => _playerY; set => _playerY = value; }
        public Game(GameObject player)
        {
            _player = player;
            _mapFile1.SetFile(_sMap1);
            _mapFile2.SetFile(_sMap2);
            _map1.mapSet(_mapFile1.sText);
            _map2.mapSet(_mapFile2.sText);

            Console.Write("Enter name : ");
            Playername = Console.ReadLine();
            _mapFile = _mapFile1;
            _map = _map1;
            
            _mapFile.PrintFile();
            
            _map.mapSet(_mapFile.sText);

            _isDisplayDialogue = false;

            Console.SetCursorPosition(0, 0);

            
            List<ConsoleKey> inputKeys = new List<ConsoleKey> { ConsoleKey.LeftArrow, ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.RightArrow, ConsoleKey.Escape };
            _inputManager.Init(inputKeys);

            _playerX = 80;
            _playerY = 1;
            Console.SetCursorPosition(_playerX, _playerY);
            Console.WriteLine(((Render)_player.ComponentsList[0]).RenderString);
            Console.CursorVisible = false;
        }
        public void update()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            if (IndexMap == 0)
            {
                _mapFile = _mapFile1;
                _map = _map1;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.SetCursorPosition(0, 0);
                _mapFile.PrintFile();

                Console.SetCursorPosition(_playerX, _playerY);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(((Render)_player.ComponentsList[0]).RenderString);
                Console.CursorVisible = false;
            }
            else if (IndexMap == 1)
            {
                _mapFile = _mapFile2;
                _map = _map2;
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(0, 0);
                _mapFile.PrintFile();

                Console.SetCursorPosition(_playerX, _playerY);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(((Render)_player.ComponentsList[0]).RenderString);
                Console.CursorVisible = false;
            }
            
        }
        public void setPos(int x, int y) { _playerX = x; _playerY = y; }
        public int gameScript()
        {
            update();

            while (true)
            {
                //test dialogue
                Dialogue dialogue = new Dialogue("dialogue");

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                _inputManager.Update(keyInfo);
                if (_inputManager.IsKey((ConsoleKey)37))
                {
                    if (_playerX >= 1)
                    {
                        if (((CaseState)_map._mapTab[_playerY, _playerX - 1].ComponentsList[0]).IsDoor)
                        {
                            if (IsKey)
                            {
                                ((CaseState)_map._mapTab[_playerY, _playerX - 1].ComponentsList[0]).IsWalkable = true;
                            }
                        }

                        if (((CaseState)_map._mapTab[_playerY, _playerX - 1].ComponentsList[0]).IsWalkable)
                        {
                            Console.MoveBufferArea(_playerX, _playerY, 1, 1, _playerX - 1, _playerY);
                            _playerX -= 1;
                            update();  
                        }
                        
                    }
                    else
                    {
                        if (((CaseState)_map._mapTab[_playerY, _playerX].ComponentsList[0]).IsDoor)
                        {
                            Console.MoveBufferArea(_playerX, _playerY, 1, 1, 1, _playerY);
                            _playerX = 119;
                            _playerY = 15;
                            IndexMap = 0;
                            update();
                        }
                    }

                }
                if (_inputManager.IsKey((ConsoleKey)38))
                {
                    if (_playerY >= 1)
                    {
                        
                        if (((CaseState)_map._mapTab[_playerY - 1, _playerX].ComponentsList[0]).IsWalkable)
                        {

                            Console.MoveBufferArea(_playerX, _playerY, 1, 1, _playerX, _playerY - 1);
                            _playerY -= 1;
                            update();
                        }
                        

                    }

                }
                if (_inputManager.IsKey((ConsoleKey)39))
                {
                    if (_playerX < 119)
                    {
                        if (((CaseState)_map._mapTab[_playerY, _playerX + 1].ComponentsList[0]).IsDoor) 
                        {
                            if (IsKey)
                            {
                                ((CaseState)_map._mapTab[_playerY, _playerX + 1].ComponentsList[0]).IsWalkable = true;
                            }
                        }
                        if (((CaseState)_map._mapTab[_playerY, _playerX + 1].ComponentsList[0]).IsWalkable)
                        {
                            Console.MoveBufferArea(_playerX, _playerY, 1, 1, _playerX + 1, _playerY);
                            _playerX += 1;
                            update();
                        }
                        

                    }
                    else
                    {
                        if (((CaseState)_map._mapTab[_playerY, _playerX].ComponentsList[0]).IsDoor)
                        {
                            Console.MoveBufferArea(_playerX, _playerY, 1, 1, 1, _playerY);
                            _playerX = 1;
                            _playerY = 2;
                            IndexMap = 1;
                            update();
                        }
                    }

                }
                if (_inputManager.IsKey((ConsoleKey)40))
                {
                    if (_playerY <= 28)
                    {
                        
                        if (((CaseState)_map._mapTab[_playerY + 1, _playerX].ComponentsList[0]).IsWalkable)
                        {

                            Console.MoveBufferArea(_playerX, _playerY, 1, 1, _playerX, _playerY + 1);
                            _playerY += 1;
                            update();
                        }
                        

                    }
                }
                if (_inputManager.IsKey((ConsoleKey)27))
                {
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                    return 1;
                }

                if (((CaseState)_map._mapTab[_playerY, _playerX].ComponentsList[0]).IsFight)
                {
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                    return 2;
                }
                else if (_map._mapTab[_playerY, _playerX].ComponentsList.Count != 1)
                {
                    if (((Bag)_map._mapTab[_playerY, _playerX].ComponentsList[1]).ObjectsList.FirstOrDefault() != null)
                    {
                        ((Bag)_player.ComponentsList[1]).ObjectsList.Add(((Bag)_map._mapTab[_playerY, _playerX].ComponentsList[1]).ObjectsList[0]);
                        ((Bag)_map._mapTab[_playerY, _playerX].ComponentsList[1]).RemoveObject(((Bag)_map._mapTab[_playerY, _playerX].ComponentsList[1]).ObjectsList[0]);
                        if (((Bag)_player.ComponentsList[1]).ObjectsList[((Bag)_player.ComponentsList[1]).ObjectsList.Count - 1].IsPokeball){
                            Console.WriteLine("Vous avez ramassé une pokeball !");
                        }
                        else
                        {
                            IsKey = true;
                            Console.WriteLine("Vous avez ramassé une clé !");
                        }
                    }

                }
                    //Dialogue
                if (_playerX == 92 && _playerY==16)
                {
                    if (!_isDisplayDialogue)
                    {
                        Console.WriteLine(dialogue.Dialogues[0]);
                        Console.WriteLine(dialogue.Dialogues[1]);
                        Console.WriteLine(dialogue.Dialogues[2]);
                        Console.WriteLine(dialogue.Dialogues[3]);
                        _isDisplayDialogue = true;
                    }
                }
                else
                {
                    _isDisplayDialogue = false;
                }
            }
        }
    }    
}
