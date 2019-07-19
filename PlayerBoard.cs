using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLibrary
{
    public class PlayerBoard : GameBoard
    {
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
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(item);
                            Console.ResetColor();
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
