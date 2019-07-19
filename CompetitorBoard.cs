using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLibrary
{
    public class CompetitorBoard : GameBoard
    {
        public bool IsShipHit { get; set; }
        public int[] LastHitCoords { get; set; }
        public int[] LastAttackCoords { get; set; }
        public int HitStreak { get; set; }
        public List<int[]> StoredCoords { get; set; }

        public bool savedIsHit { get; set; }
        public int[] savedHit { get; set; }
        public CompetitorBoard()
        {
            IsShipHit = false;
            LastHitCoords = new int[2];
            LastAttackCoords = new int[2];
            HitStreak = 0;
            //StoredCoords = new List<int[]>();
            StoredCoords = null;
            int[] savedHit = new int[2];

            savedIsHit = false;

        }
        public override string ToString()
        {
            foreach (string[] sArray in rows)
            {
                foreach (string item in sArray)
                {
                    pipe();
                    switch (item)
                    {
                        case hit:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(item);
                            Console.ResetColor();
                            break;
                        case ship:
                            Console.Write(" ");
                            break;
                        case miss:
                            Console.Write(item);
                            break;
                        case empty:
                            Console.Write(item);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(item);
                            Console.ResetColor();
                            break;
                    }

                }
                pipe();
                Console.WriteLine();
               
            }
            return "";
        }
    }
}
