using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Gridd
{
    class Grid
    {

        int[,] _combatGrid; 
        int[] _gridSlots;

        public int[,] combatGrid { get => _combatGrid; private set => _combatGrid = value; }
        public int[] gridSlots { get => _gridSlots; set => _gridSlots = value; }

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
                {2, 1}, // Case 0
                {21, 1}, // Case 1
                {40, 1}, // Case 2

                {2, 10}, // Case 3
                {21, 10}, // Case 4
                {40, 10}, // Case 5

                {2, 19}, // Case 6
                {21, 19}, // Case 7
                {40, 19}, // Case 8

                //Enemy
                {64, 1}, // Case 9
                {83, 1}, // Case 10
                {102, 1}, // Case 11

                {64, 10}, // Case 12
                {83, 10}, // Case 13
                {102, 10}, // Case 14

                {64, 19}, // Case 15
                {83, 19}, // Case 16
                {102, 19} // Case 17

            };
        }
        void SetCombatSlots()
        {
            _gridSlots = new int[17];
            for (int i = 0; i < 17; i++)
            {
                _gridSlots[i] = 0;
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