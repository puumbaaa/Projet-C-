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

        public int m_Case;
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
                {3, 2}, // Case 0
                {22, 2}, // Case 1
                {41, 2}, // Case 2

                {3, 11}, // Case 3
                {22, 11}, // Case 4
                {41, 11}, // Case 5

                {3, 20}, // Case 6
                {22, 20}, // Case 7
                {41, 20}, // Case 8

                //Enemy
                {65, 2}, // Case 9
                {84, 2}, // Case 10
                {103, 2}, // Case 11

                {65, 11}, // Case 12
                {84, 11}, // Case 13
                {103, 11}, // Case 14

                {65, 20}, // Case 15
                {84, 20}, // Case 16
                {103, 20} // Case 17

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