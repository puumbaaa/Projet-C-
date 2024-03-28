using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Porjet_C_;
namespace Gridd
{
    public class Grid
    {

        int[,] _combatGrid; 
        GameObject[] _gridSlots;

        public int[,] combatGrid { get => _combatGrid; private set => _combatGrid = value; }
        public GameObject[] gridSlots { get => _gridSlots; set => _gridSlots = value; }

        /*//----------------------------------------------------------------------------------|
        |                                                                                     |
        |                                                                                     |
        |                                   Set Grids                                         |
        |                                                                                     |
        |                                                                                     |
        *///----------------------------------------------------------------------------------|


        void SetCombatGrid()
        {
            

            _combatGrid = new int[,] {

                // Ally
                {2, 0}, // Case 0
                {21, 0}, // Case 1
                {40, 0}, // Case 2

                {2, 9}, // Case 3
                {21, 9}, // Case 4
                {40, 9}, // Case 5

                {2, 18}, // Case 6
                {21, 18}, // Case 7
                {40, 18}, // Case 8

                //Enemy
                {64, 0}, // Case 9
                {83, 0}, // Case 10
                {102, 0}, // Case 11

                {64, 9}, // Case 12
                {83, 9}, // Case 13
                {102, 9}, // Case 14

                {64, 18}, // Case 15
                {83, 18}, // Case 16
                {102, 18} // Case 17

            };
        }
        void SetCombatSlots()
        {
            _gridSlots = new GameObject[17];
            for (int i = 0; i < 17; i++)
            {
                _gridSlots[i] = null;
            }
        }


        /*//----------------------------------------------------------------------------------|
        |                                                                                     |
        |                                                                                     |
        |                                      Generate Grids                                 |
        |                                                                                     |
        |                                                                                     |
        *///----------------------------------------------------------------------------------|

        public void GenerateGrids()
        {
            SetCombatGrid();
            SetCombatSlots();
        }
        


    }
}