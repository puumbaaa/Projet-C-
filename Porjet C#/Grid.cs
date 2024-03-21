using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grid
{
    class GridClass
    {

        int m_Case;
        int[,] combatGrid;
        int[] gridSlots;

        int m_Case;
        int[,] combatGrid;
        int[] gridSlots;


        /*//----------------------------------------------------------------------------------|
        |                                                                                     |
        |                                                                                     |
        |                                   Set Grids                                         |
        |                                                                                     |
        |                                                                                     |
        *///----------------------------------------------------------------------------------|


        void SetCombatGrid()
        {
            

            combatGrid = new int[,] {

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
            gridSlots = new int[17];
            for (int i = 0; i <= 17; i++)
            {
                gridSlots[i] = 0;
            }
        }


        /*//----------------------------------------------------------------------------------|
        |                                                                                     |
        |                                                                                     |
        |                                    Get Grids                                        |
        |                                                                                     |
        |                                                                                     |
        *///----------------------------------------------------------------------------------|
        public int[,] GetCombatGrid()
        {
            return combatGrid;
        }

        public int[] GetSlotGrid()
        {
            return gridSlots;
        }

        public int GetSlot(int i)
        {
            return gridSlots[i];
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