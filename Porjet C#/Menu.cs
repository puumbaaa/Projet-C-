﻿using Input;
using Mapp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Porjet_C_
{
    internal class Menu
    {
        GameObject _player;
        InputManager _inputManager = new InputManager();
        FileReader _menuFile = new FileReader();
        string _title;
        bool _isDisplay;
        string _menu = "";
        int _selectX;
        int _selectY;
        
        public string Title { get => _title; private set => _title = value;  }
        public bool IsDisplay { get => _isDisplay; private set => _isDisplay = value; }

        public Menu(string title, GameObject player)
        {
            Title = title;
            IsDisplay = false;
            _player = player;
            List<ConsoleKey> inputKeys = new List<ConsoleKey> { ConsoleKey.LeftArrow, ConsoleKey.UpArrow, ConsoleKey.DownArrow, ConsoleKey.RightArrow, ConsoleKey.Escape };

            _menuFile.SetFile("..\\..\\..\\..\\ASCII\\Menu\\menu.txt");
            _inputManager.Init(inputKeys);
        }

        public int MenuScript(int menuItem, int lastState)
        {
            _selectX = 19;
            _selectY = 5;
            DisplayMenu();
            while (true)
            {
                
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                _inputManager.Update(keyInfo);
                
                
                if (_inputManager.IsKey((ConsoleKey)38))
                {
                 if (_selectY > 5)
                    {
                        Console.MoveBufferArea(_selectX, _selectY,1,1,_selectX,_selectY - 5);
                        _selectY -= 5;
                        DisplayMenu();
                    }  
                }
                
                if (_inputManager.IsKey((ConsoleKey)40))
                {
                    if (_selectY < 20)
                    {
                        Console.MoveBufferArea(_selectX, _selectY, 1, 1, _selectX, _selectY + 5);
                        _selectY += 5;
                        DisplayMenu();
                    }
                }
                if (_inputManager.IsKey((ConsoleKey)39))
                {
                    if (_selectY == 5)
                    {
                        DisplayObjectMenu();
                    }
                    else if (_selectY == 10)
                    {
                        DisplayPokemonMenu();
                    }
                    else if (_selectY == 15)
                    {
                        return 1;
                    }
                    else if (_selectY == 20)
                    {
                        Environment.Exit(0);
                    }
                    DisplayMenu();
                }

                if (_inputManager.IsKey((ConsoleKey)27))
                {
                    return lastState;
                }
                
                
            }
        }

        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(0, 0);
            _menuFile.PrintFile();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(20, 5);
            Console.WriteLine("Objets");
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("Mon équipe");
            Console.SetCursorPosition(20, 15);
            Console.WriteLine("Sauvegarder");
            Console.SetCursorPosition(20, 20);
            Console.WriteLine("Quitter");
            Console.SetCursorPosition(_selectX, _selectY);
            Console.WriteLine("/");
            Console.CursorVisible = false;
        }

        public void DisplayPokemonMenu()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            _menuFile.PrintFile();
            int x = 20;
            int y = 5;
            _selectX = 19;
            _selectY = 5;
            Console.SetCursorPosition(_selectX, _selectY);
            Console.WriteLine("/");
            while (true)
            {

                for (int i = 0; i < ((Bag)_player.ComponentsList[1]).PokemonList.Count; i++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(((Bag)_player.ComponentsList[1]).PokemonList[i].ComponentsList[0].ComponentName);
                    y += 1;
                }
                y = 5;
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                _inputManager.Update(keyInfo);
                if (_inputManager.IsKey((ConsoleKey)37))
                {
                    _selectX = 19;
                    _selectY = 5;
                    return;

                }
                if (_inputManager.IsKey((ConsoleKey)38))
                {
                    if (_selectY > 5)
                    {
                        Console.MoveBufferArea(_selectX, _selectY, 1, 1, _selectX, _selectY - 1);
                        _selectY -= 1;
                    }
                }

                if (_inputManager.IsKey((ConsoleKey)40))
                {
                    if (_selectY < ((Bag)_player.ComponentsList[1]).PokemonList.Count + 4)
                    {
                        Console.MoveBufferArea(_selectX, _selectY, 1, 1, _selectX, _selectY + 1);
                        _selectY += 1;
                    }
                }
                if (_inputManager.IsKey((ConsoleKey)39))
                {

                    DisplayPokemonStatMenu(_selectY - 5);
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                    _menuFile.PrintFile();
                }
            }
        }

        public void DisplayPokemonStatMenu(int indexPokemon)
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Pokemon pokemon = (Pokemon)((Bag)_player.ComponentsList[1]).PokemonList[indexPokemon].ComponentsList[0];

            FileReader newFileReader = new FileReader();
            newFileReader.SetFile("..\\..\\..\\..\\ASCII\\Menu\\menuPokemontotal.txt");
            string finalMap = "";
            int nbDash = 0;
            while (true)
            {
                for (int i = 0; i < _menuFile.sText.Length; i++)
                {
                    if (newFileReader.sText[i] == '.')
                    {
                        finalMap += _menuFile.sText[i];
                    }
                    else if (newFileReader.sText[i] != '_')
                    {
                        finalMap += newFileReader.sText[i];
                    }
                    else
                    {
                        switch (nbDash)
                        {
                            //level
                            case 0:
                                finalMap += pokemon.Level;
                                if (pokemon.Level < 1000)
                                {
                                    finalMap += " ";
                                }
                                if (pokemon.Level < 100)
                                {
                                    finalMap += " ";
                                }
                                if (pokemon.Level < 10)
                                {
                                    finalMap += " ";
                                }
                                i += 4;
                                nbDash += 4;
                                break;
                            //first attack
                            case 4:
                                string firstAttack = pokemon.ListAttacks[0].ComponentName;
                                if (firstAttack.Length > 10)
                                {
                                    firstAttack = firstAttack.Remove(10);
                                } while (firstAttack.Length < 10)
                                {
                                    firstAttack += " ";
                                }
                                finalMap += firstAttack + " " + pokemon.ListAttacks[0].AttackStat;
                                if (pokemon.ListAttacks[0].AttackStat < 1000)
                                {
                                    finalMap += " ";
                                }
                                if (pokemon.ListAttacks[0].AttackStat < 100)
                                {
                                    finalMap += " ";
                                }
                                if (pokemon.ListAttacks[0].AttackStat < 10)
                                {
                                    finalMap += " ";
                                }
                                finalMap += " ";
                                i += 14;
                                nbDash += 14;
                                break;
                            //exp
                            case 18:
                                string newString = pokemon.CurrentExp + "\\" + pokemon.TotalExp;
                                while (newString.Length < 9)
                                {
                                    newString += " ";
                                }
                                finalMap += newString + " ";
                                i += 9;
                                nbDash += 9;
                                break;
                            //type
                            case 27:
                                string newStringType = pokemon.Types1.Name;
                                if (newStringType.Length > 9)
                                {
                                    newStringType = newStringType.Remove(9);
                                }
                                while (newStringType.Length < 9)
                                {
                                    newStringType += " ";
                                }
                                finalMap += newStringType;
                                i += 9;
                                nbDash += 9;
                                break;
                            //second attack
                            case 36:
                                if (pokemon.ListAttacks.Count >= 2)
                                {
                                    string secondAttack = pokemon.ListAttacks[1].ComponentName;
                                    if (secondAttack.Length > 10)
                                    {
                                        secondAttack = secondAttack.Remove(10);
                                    } 
                                    while (secondAttack.Length < 10)
                                    {
                                        secondAttack += " ";
                                    }
                                    finalMap += secondAttack + " " + pokemon.ListAttacks[1].AttackStat;
                                    if (pokemon.ListAttacks[1].AttackStat < 1000)
                                    {
                                        finalMap += " ";
                                    }
                                    if (pokemon.ListAttacks[1].AttackStat < 100)
                                    {
                                        finalMap += " ";
                                    }
                                    if (pokemon.ListAttacks[1].AttackStat < 10)
                                    {
                                        finalMap += " ";
                                    }
                                }
                                else
                                {
                                    finalMap += "               ";
                                }
                                finalMap += " ";
                                i += 14;
                                nbDash += 14;
                                break;
                            //attack
                            case 50:
                                finalMap += pokemon.AttackStatBase + " ";
                                if (pokemon.AttackStatBase < 1000)
                                {
                                    finalMap += " ";
                                }
                                if (pokemon.AttackStatBase < 100)
                                {
                                    finalMap += " ";
                                }
                                if (pokemon.AttackStatBase < 10)
                                {
                                    finalMap += " ";
                                }
                                nbDash += 4;
                                i += 4;
                                break;
                            //def
                            case 54:
                                finalMap += pokemon.DefStatBase;
                                if (pokemon.DefStatBase < 1000)
                                {
                                    finalMap += " ";
                                }
                                if (pokemon.DefStatBase < 100)
                                {
                                    finalMap += " ";
                                }
                                if (pokemon.DefStatBase < 10)
                                {
                                    finalMap += " ";
                                }
                                i += 4;
                                nbDash += 4;
                                break;
                            //attack3
                            case 58:
                                if (pokemon.ListAttacks.Count >= 3)
                                {
                                    string thirdAttack = pokemon.ListAttacks[2].ComponentName;
                                    if (thirdAttack.Length > 10)
                                    {
                                        thirdAttack = thirdAttack.Remove(10);
                                    } 
                                    while (thirdAttack.Length < 10)
                                    {
                                        thirdAttack += " ";
                                    }
                                    finalMap += thirdAttack + " " + pokemon.ListAttacks[2].AttackStat;
                                    if (pokemon.ListAttacks[2].AttackStat < 1000)
                                    {
                                        finalMap += " ";
                                    }
                                    if (pokemon.ListAttacks[2].AttackStat < 100)
                                    {
                                        finalMap += " ";
                                    }
                                    if (pokemon.ListAttacks[2].AttackStat < 10)
                                    {
                                        finalMap += " ";
                                    }
                                }
                                else
                                {
                                    finalMap += "               ";
                                }
                                finalMap += " ";
                                i += 14;
                                nbDash += 14;
                                break;
                            //speed
                            case 72:
                                finalMap += pokemon.SpeedStatBase + " ";
                                if (pokemon.SpeedStatBase < 1000)
                                {
                                    finalMap += " ";
                                }
                                if (pokemon.SpeedStatBase < 100)
                                {
                                    finalMap += " ";
                                }
                                if (pokemon.SpeedStatBase < 10)
                                {
                                    finalMap += " ";
                                }
                                i += 4;
                                nbDash += 4;
                                break;
                            //HP
                            case 76:
                                string newStringHP = pokemon.CurrentHealth + "\\" + pokemon.TotalHealth;
                                while (newStringHP.Length < 9)
                                {
                                    newStringHP += " ";
                                }
                                finalMap += newStringHP;
                                nbDash += 9;
                                i += 9;
                                break;
                            //forth Attack
                            case 85:
                                if (pokemon.ListAttacks.Count >= 4)
                                {
                                    string forthAttack = pokemon.ListAttacks[3].ComponentName;
                                    if (forthAttack.Length > 10)
                                    {
                                        forthAttack = forthAttack.Remove(10);
                                    }
                                    while (forthAttack.Length < 10)
                                    {
                                        forthAttack += " ";
                                    }
                                    finalMap += forthAttack + " " + pokemon.ListAttacks[3].AttackStat;
                                    if (pokemon.ListAttacks[3].AttackStat < 1000)
                                    {
                                        finalMap += " ";
                                    }
                                    if (pokemon.ListAttacks[3].AttackStat < 100)
                                    {
                                        finalMap += " ";
                                    }
                                    if (pokemon.ListAttacks[3].AttackStat < 10)
                                    {
                                        finalMap += " ";
                                    }
                                }
                                else
                                {
                                    finalMap += "               ";
                                }
                                finalMap += " ";
                                i += 14;
                                nbDash += 14;
                                break;
                        }
                    }

                }
                Console.WriteLine(pokemon.ComponentName + finalMap );
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                _inputManager.Update(keyInfo);
                if (_inputManager.IsKey((ConsoleKey)37))
                {
                    return;
                }
            }
        }
      
        public void DisplayObjectMenu()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            _menuFile.PrintFile();
            int x = 20;
            int y = 5;
            while (true) 
            {
                
                for (int i = 0; i < ((Bag)_player.ComponentsList[1]).ObjectsList.Count; i++)
                {
                    Console.SetCursorPosition(x, y);
                    if (((Bag)_player.ComponentsList[1]).ObjectsList[i].IsPokeball)
                    {
                        Console.WriteLine("Pokeball");
                    }
                    else if (((Bag)_player.ComponentsList[1]).ObjectsList[i].IsKey)
                    {
                        Console.WriteLine("Clé");
                    }
                    y += 1;
                    if (y > 25)
                    {
                        y = 5;
                        x += 10;
                    }
                }
                y = 5;
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                _inputManager.Update(keyInfo);
                if (_inputManager.IsKey((ConsoleKey)37))
                {
                    return;
                }
            }
        }
    }
}
