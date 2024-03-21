using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porjet_C_
{
    public class Grid
    {
        int[,] CombatGrid = new int[,] {

            // Ally
            { 2, 3 }, // Case 0
            { 2, 22 }, // Case 1
            { 2, 41 }, // Case 2

            { 11, 3 }, // Case 3
            { 11, 22 }, // Case 4
            { 11, 41 }, // Case 5

            { 20 , 3 }, // Case 6
            { 20 , 22 }, // Case 7
            { 20 , 41 }, // Case 8

            //Enemy
            { 2, 65 }, // Case 9
            { 2, 84 }, // Case 10
            { 2, 103 }, // Case 11

            { 11, 65 }, // Case 12
            { 11, 84 }, // Case 13
            { 11, 103 }, // Case 14

            { 20 , 65 }, // Case 15
            { 20 , 84 }, // Case 16
            { 20 , 103 } // Case 17

            };

    }
}
