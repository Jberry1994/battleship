using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Ship
    {
        public int XPos1 { get; set; }
        public int YPos1 { get; set; }
        public int XPos2 { get; set; }
        public int YPos2 { get; set; }

        public Ship(int x1, int y1, int x2, int y2)
        {

            if (x1 > x2)
            {
                int temp = x1;
                x1 = x2;
                x2 = temp;
            }
            if (y1 > y2)
            {
                int temp = y1;
                y1 = y2;
                y2 = temp;
            }
            XPos1 = x1;
            YPos1 = y1;
            XPos2 = x2;
            YPos2 = y2;

        }
        public Ship(int[] firstCoord, int[] secondCoord)
        {

            if (firstCoord[0] > secondCoord[0])
            {
                int temp = firstCoord[0];
                firstCoord[0] = secondCoord[0];
                firstCoord[0] = temp;
            }
            if (firstCoord[1] > secondCoord[1])
            {
                int temp = firstCoord[1];
                firstCoord[1] = secondCoord[1];
                firstCoord[1] = temp;
            }
            XPos1 = firstCoord[0];
            YPos1 = firstCoord[1];
            XPos2 = secondCoord[0];
            YPos2 = secondCoord[1];

        }


    }
}
