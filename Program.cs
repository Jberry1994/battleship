using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipLibrary;

/*
 * Battlship!
 * Contributors: Jonathon, Takeshi, Alysha
 * 
 */
namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {


            CompetitorBoard gameBoard = new CompetitorBoard();
            List<List<Ship>> shipLists = new List<List<Ship>>();
            List<Ship> shipsLayout0 = new List<Ship>();
            List<Ship> shipsLayout1 = new List<Ship>();
            List<Ship> shipsLayout2 = new List<Ship>();
            List<Ship> shipsLayout3 = new List<Ship>();
            Ship playerDestroyer = new Ship(7, 10, 8, 10);
            Ship playerBattleship = new Ship(1, 1, 1, 4);
            Ship playerCruiser = new Ship(10, 3, 10, 5);
            Ship playerSubmarine = new Ship(5, 1, 5, 3);
            Ship playerCarrier = new Ship(4, 5, 8, 5);

            shipsLayout0.Add(new Ship(7, 10, 8, 10));
            shipsLayout0.Add(new Ship(1, 1, 1, 4));
            shipsLayout0.Add(new Ship(10, 3, 10, 5));
            shipsLayout0.Add(new Ship(5, 1, 5, 3));
            shipsLayout0.Add(new Ship(4, 5, 8, 5));

            shipsLayout1.Add(new Ship(2, 1, 3, 1));
            shipsLayout1.Add(new Ship(2, 3, 6, 3));
            shipsLayout1.Add(new Ship(9, 4, 9, 6));
            shipsLayout1.Add(new Ship(3, 5, 3, 6));
            shipsLayout1.Add(new Ship(5, 6, 5, 9));

            shipsLayout2.Add(new Ship(2, 1, 2, 3));
            shipsLayout2.Add(new Ship(9, 1, 9, 2));
            shipsLayout2.Add(new Ship(6, 4, 6, 8));
            shipsLayout2.Add(new Ship(4, 8, 8, 8));
            shipsLayout2.Add(new Ship(6, 10, 8, 10));

            shipsLayout3.Add(new Ship(9, 1, 9, 2));
            shipsLayout3.Add(new Ship(10, 1, 10, 3));
            shipsLayout3.Add(new Ship(6, 2, 6, 6));
            shipsLayout3.Add(new Ship(4, 7, 7, 7));
            shipsLayout3.Add(new Ship(7, 9, 9, 9));

            shipLists.Add(shipsLayout0);
            shipLists.Add(shipsLayout1);
            shipLists.Add(shipsLayout2);
            shipLists.Add(shipsLayout3);






            PlayerBoard playerBoard = new PlayerBoard();


            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Do you want to play BattleShip? Y/N");
                ConsoleKey userChoice = Console.ReadKey(true).Key;
                bool reload = false;

                switch (userChoice)
                {
                    case ConsoleKey.Y:
                        Console.WriteLine("Welcome to BattleShip!");
                        break;
                    case ConsoleKey.N:
                        Console.WriteLine("Good Bye");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please choose again");
                        break;
                }//end switch
                foreach (Ship ship in shipLists[new Random().Next(shipLists.Count)])
                {
                    AddShip(gameBoard, ship);
                }
                //makeBoard(playerBoard);
                AddShip(playerBoard, playerCarrier);
                AddShip(playerBoard, playerBattleship);
                AddShip(playerBoard, playerCruiser);
                AddShip(playerBoard, playerSubmarine);
                AddShip(playerBoard, playerDestroyer);

                while (!reload && !exit)
                {
                    Console.Clear();
                    Console.WriteLine("Enemy board:");
                    Console.WriteLine(gameBoard);
                    Console.WriteLine("\nYour board");
                    Console.WriteLine(playerBoard);

                    Attack(gameBoard);
                    if (WinCheck(gameBoard))
                    {
                        Console.WriteLine("You Win!");
                        Console.ReadLine();
                        exit = true;
                    }
                    else { enemyCompAttack(gameBoard, playerBoard); }

                }
            }
        }

        static void enemyCompAttack(CompetitorBoard competitorBoard, PlayerBoard playerBoard)
        {



            int[] coords = new int[2];
            coords[0] = competitorBoard.LastHitCoords[0];
            coords[1] = competitorBoard.LastHitCoords[1];


            //coords[0] = new Random().Next(1, 11);
            //System.Threading.Thread.Sleep(35);
            //coords[1] = new Random().Next(1, 11);

            if (competitorBoard.HitStreak > 1)
            {
                if (competitorBoard.LastAttackCoords[0] - competitorBoard.savedHit[0] > 0)
                {
                    if (competitorBoard.LastAttackCoords[0] > competitorBoard.savedHit[0])
                    {
                        coords[0] = competitorBoard.LastAttackCoords[0]++;
                        coords[1] = competitorBoard.LastAttackCoords[1];
                    }
                    else
                    {
                        coords[0] = competitorBoard.savedHit[0]++;
                        coords[1] = competitorBoard.savedHit[1];
                    }
                }
                else if (competitorBoard.LastAttackCoords[1] - competitorBoard.savedHit[1] > 0)
                {
                    if (competitorBoard.LastAttackCoords[0] > competitorBoard.savedHit[0])
                    {
                        coords[0] = competitorBoard.LastAttackCoords[0];
                        coords[1] = competitorBoard.LastAttackCoords[1]++;
                    }
                    else
                    {
                        coords[0] = competitorBoard.savedHit[0];
                        coords[1] = competitorBoard.savedHit[1]++;
                    }
                }
                else if (competitorBoard.LastAttackCoords[0] - competitorBoard.savedHit[0] < 0)
                {
                    if (competitorBoard.LastAttackCoords[0] > competitorBoard.savedHit[0])
                    {
                        coords[0] = competitorBoard.LastAttackCoords[0]--;
                        coords[1] = competitorBoard.LastAttackCoords[1];
                    }
                    else
                    {
                        coords[0] = competitorBoard.savedHit[0]--;
                        coords[1] = competitorBoard.savedHit[1];
                    }
                }
                else if (competitorBoard.LastAttackCoords[1] - competitorBoard.savedHit[1] < 0)
                {
                    if (competitorBoard.LastAttackCoords[0] > competitorBoard.savedHit[0])
                    {
                        coords[0] = competitorBoard.LastAttackCoords[0];
                        coords[1] = competitorBoard.LastAttackCoords[1]--;
                    }
                    else
                    {
                        coords[0] = competitorBoard.savedHit[0];
                        coords[1] = competitorBoard.savedHit[1]--;
                    }
                }

            }
            else if (competitorBoard.IsShipHit)
            {
                int[] stored1 = new int[2];
                int[] stored2 = new int[2];
                int[] stored3 = new int[2];
                int[] stored4 = new int[2];
                competitorBoard.StoredCoords = new List<int[]>();
                if (competitorBoard.LastHitCoords[0] < 10)
                {
                    stored1[0] = coords[0] + 1;
                    stored1[1] = coords[1];
                    competitorBoard.StoredCoords.Add(stored1);
                }
                if (competitorBoard.LastHitCoords[0] > 1)
                {
                    stored2[0] = coords[0] - 1;
                    stored2[1] = coords[1];
                    competitorBoard.StoredCoords.Add(stored2);
                }

                if (competitorBoard.LastHitCoords[1] < 10)
                {
                    stored3[0] = coords[0];
                    stored3[1] = coords[1] + 1;
                    competitorBoard.StoredCoords.Add(stored3);
                }

                if (competitorBoard.LastHitCoords[1] > 1)
                {
                    stored4[0] = coords[0];
                    stored4[1] = coords[1] - 1;
                    competitorBoard.StoredCoords.Add(stored4);
                }


                coords = competitorBoard.StoredCoords[new Random().Next(0, competitorBoard.StoredCoords.Count)];
            }
            else if ((!competitorBoard.IsShipHit) && (competitorBoard.StoredCoords != null))
            {
                for (int i = 0; i < competitorBoard.StoredCoords.Count; i++)
                {
                    if (competitorBoard.StoredCoords[i] == competitorBoard.LastAttackCoords)
                    {
                        competitorBoard.StoredCoords.RemoveAt(i);
                    }
                }
                if (competitorBoard.StoredCoords.Count != 0)
                {
                    coords = competitorBoard.StoredCoords[new Random().Next(0, competitorBoard.StoredCoords.Count)];
                }
                else
                {
                    competitorBoard.StoredCoords = null;
                    coords[0] = new Random().Next(1, 11);
                    System.Threading.Thread.Sleep(35);
                    coords[1] = new Random().Next(1, 11);
                }
            }

            else
            {
                competitorBoard.StoredCoords = null;
                coords[0] = new Random().Next(1, 11);
                System.Threading.Thread.Sleep(35);
                coords[1] = new Random().Next(1, 11);
            }

            if (playerBoard.rows[coords[1]][coords[0]] == playerBoard.Ship)
            {

                playerBoard.rows[coords[1]][coords[0]] = playerBoard.Hit;
                competitorBoard.HitStreak++;
                competitorBoard.IsShipHit = true;
                competitorBoard.LastHitCoords = coords;
                if (competitorBoard.HitStreak < 2)
                {
                    competitorBoard.savedHit = coords;
                }
            }

            else
            {
                if (playerBoard.rows[coords[1]][coords[0]] == playerBoard.Hit ||
                    playerBoard.rows[coords[1]][coords[0]] == playerBoard.Miss)
                {
                    coords[0] = new Random().Next(1, 11);
                    System.Threading.Thread.Sleep(35);
                    coords[1] = new Random().Next(1, 11);
                    competitorBoard.HitStreak = 0;

                    if (playerBoard.rows[coords[1]][coords[0]] == playerBoard.Ship)
                    {

                        playerBoard.rows[coords[1]][coords[0]] = playerBoard.Hit;
                        competitorBoard.HitStreak++;
                        competitorBoard.IsShipHit = true;
                        competitorBoard.LastHitCoords = coords;
                        if (competitorBoard.HitStreak < 2)
                        {
                            competitorBoard.savedHit = coords;
                        }
                    }

                    else
                    {
                        if (playerBoard.rows[coords[1]][coords[0]] == playerBoard.Hit ||
                            playerBoard.rows[coords[1]][coords[0]] == playerBoard.Miss)
                        {
                            coords[0] = new Random().Next(1, 11);
                            System.Threading.Thread.Sleep(35);
                            coords[1] = new Random().Next(1, 11);
                            competitorBoard.HitStreak = 0;


                        }
                        else
                        {
                            playerBoard.rows[coords[1]][coords[0]] = playerBoard.Miss;
                            competitorBoard.IsShipHit = false;
                            competitorBoard.HitStreak = 0;
                            competitorBoard.LastAttackCoords = coords;
                        }
                    }

                }
                else
                {
                    playerBoard.rows[coords[1]][coords[0]] = playerBoard.Miss;
                    competitorBoard.IsShipHit = false;
                    competitorBoard.HitStreak = 0;
                    competitorBoard.LastAttackCoords = coords;
                }
            }

        }

        public static void AddShip(GameBoard gameboard, Ship newShip)
        {
            gameboard.rows[newShip.YPos1][newShip.XPos1] = gameboard.Ship;
            if (newShip.YPos1 == newShip.YPos2)
            {
                for (int i = newShip.XPos1; i < newShip.XPos2; i++)
                {
                    gameboard.rows[newShip.YPos1][i] = gameboard.Ship;
                }
            }
            else
            {
                for (int i = newShip.YPos1; i < newShip.YPos2; i++)
                {
                    gameboard.rows[i][newShip.XPos1] = gameboard.Ship;
                }
            }
            gameboard.rows[newShip.YPos2][newShip.XPos2] = gameboard.Ship;
        }
        static int[] getCoord(string text)
        {
            Console.WriteLine(text);
            int[] coords = new int[2];
            coords[0] = 1;
            ConsoleKey userKey = Console.ReadKey().Key;
            coords[1] = int.Parse(Console.ReadLine());
            if (coords[1] > 10)
                coords[1] = 10;
            else if (coords[1] < 1)
                coords[1] = 1;
            switch (userKey)
            {
                case ConsoleKey.A:
                    coords[0] = 1;
                    break;
                case ConsoleKey.B:
                    coords[0] = 2;
                    break;
                case ConsoleKey.C:
                    coords[0] = 3;
                    break;
                case ConsoleKey.D:
                    coords[0] = 4;
                    break;
                case ConsoleKey.E:
                    coords[0] = 5;
                    break;
                case ConsoleKey.F:
                    coords[0] = 6;
                    break;
                case ConsoleKey.G:
                    coords[0] = 7;
                    break;
                case ConsoleKey.H:
                    coords[0] = 8;
                    break;
                case ConsoleKey.I:
                    coords[0] = 9;
                    break;
                case ConsoleKey.J:
                    coords[0] = 10;
                    break;
                default:
                    break;
            }
            return coords;
        }
        static void Attack(GameBoard gameBoard)
        {
            int[] attackCoords = getCoord("Enter coords to attack: (A2)");
            if (gameBoard.rows[attackCoords[1]][attackCoords[0]] == gameBoard.Ship)
            {
                gameBoard.rows[attackCoords[1]][attackCoords[0]] = gameBoard.Hit;
            }
            else
            {
                gameBoard.rows[attackCoords[1]][attackCoords[0]] = gameBoard.Miss;
            }

        }
        static bool WinCheck(GameBoard gameboard)
        {
            int ships = 0;
            foreach (string[] sArray in gameboard.rows)
            {
                foreach (string item in sArray)
                {
                    if (item == gameboard.Ship)
                    {
                        ships++;
                    }
                }

            }
            return ships == 0 ? true : false;
        }
        static void makeBoard(GameBoard gameBoard)
        {
            string[,] ships = new string[5, 2] { { "Carrier", "5" }, { "Battleship", "4" }, { "Cruiser", "3" }, { "Submarine", "3" }, { "Destroyer", "2" } };
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(gameBoard);
                Console.WriteLine($"Now placing {ships[i, 0]} with a size of {ships[i, 1]}");
                Ship newship = new Ship(getCoord("Enter first coord (A2)"), getCoord("Enter second coord (A2)"));
                AddShip(gameBoard, newship);
                Console.Clear();
            }

            Console.WriteLine(gameBoard);
        }


        static void AiAttack(CompetitorBoard competitorBoard, PlayerBoard playerBoard)
        {
            int[] coords = new int[2];
            coords[0] = competitorBoard.LastHitCoords[0];
            coords[1] = competitorBoard.LastHitCoords[1];
            competitorBoard.savedHit = new int[2];

            competitorBoard.savedHit[0] = competitorBoard.LastHitCoords[0];
            competitorBoard.savedHit[1] = competitorBoard.LastHitCoords[1];


            if (competitorBoard.IsShipHit)

            {
                competitorBoard.savedIsHit = true;
                while (coords[0] == competitorBoard.LastHitCoords[0] && coords[1] == competitorBoard.LastHitCoords[1])
                {

                    switch (new Random().Next() % 4)
                    {

                        case 0:
                            if (competitorBoard.LastHitCoords[0] <= 10)
                            {
                                coords[0] = competitorBoard.LastHitCoords[0] + 1;
                            }
                            break;
                        case 1:
                            if (competitorBoard.LastHitCoords[0] > 1)
                            {
                                coords[0] = competitorBoard.LastHitCoords[0] - 1;
                            }
                            //x--
                            break;

                        case 2:
                            if (competitorBoard.LastHitCoords[1] <= 10)
                            {
                                coords[0] = competitorBoard.LastHitCoords[1] + 1;
                            }

                            //y++
                            break;
                        case 3:
                            if (competitorBoard.LastHitCoords[1] > 1)
                            {
                                coords[1] = competitorBoard.LastHitCoords[1] - 1;
                            }

                            //y--
                            break;
                        default:
                            break;
                    }
                }
            }
            else if (competitorBoard.savedIsHit)
            {
                switch (new Random().Next() % 4)
                {

                    case 0:
                        if (competitorBoard.LastHitCoords[0] <= 10)
                        {
                            coords[0] = competitorBoard.savedHit[0] + 1;
                        }
                        break;
                    case 1:
                        if (competitorBoard.LastHitCoords[0] > 1)
                        {
                            coords[0] = competitorBoard.savedHit[0] - 1;
                        }
                        //x--
                        break;

                    case 2:
                        if (competitorBoard.LastHitCoords[1] <= 10)
                        {
                            coords[0] = competitorBoard.savedHit[1] + 1;
                        }

                        //y++
                        break;
                    case 3:
                        if (competitorBoard.LastHitCoords[1] > 1)
                        {
                            coords[1] = competitorBoard.savedHit[1] - 1;
                        }

                        //y--
                        break;
                    default:
                        break;
                }
            }
            else
            {
                coords[0] = new Random().Next(1, 11);
                System.Threading.Thread.Sleep(35);
                coords[1] = new Random().Next(1, 11);
            }
            if (playerBoard.rows[coords[1]][coords[0]] == playerBoard.Ship)
            {
                playerBoard.rows[coords[1]][coords[0]] = playerBoard.Hit;
                competitorBoard.HitStreak++;
                competitorBoard.IsShipHit = true;
                competitorBoard.LastHitCoords = coords;
            }

            else
            {
                playerBoard.rows[coords[1]][coords[0]] = playerBoard.Miss;
                competitorBoard.IsShipHit = false;
                competitorBoard.HitStreak = 0;

            }

        }
    }
}
