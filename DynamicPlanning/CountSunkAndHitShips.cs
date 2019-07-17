using System;
using System.Linq;
using System.Collections.Generic;

namespace CSharpAlgorithm.DynamicPlanning
{

    public partial class DynamicPlanningSolution
    {
        public void ProcessShipCells(string S,List<List<string>> shipCells)
        {
            if (S.Length <2)
            { return; }

            string[] ships = S.Split(",");

            for (int i=0;i<ships.Length;i++)
            {
                var shipBox = ships[i].Split(" ");
                int topLeftX = int.Parse(shipBox[0].Substring(0, shipBox[0].Length - 1));
                int topLeftY = shipBox[0][shipBox[0].Length - 1] - 'A';
                int bottomRightX = int.Parse(shipBox[1].Substring(0, shipBox[1].Length - 1));
                int bottomRightY = shipBox[1][shipBox[1].Length - 1] - 'A';

                var ship = new List<string>();

                for (int j= topLeftX;j<=bottomRightX;j++)
                    for (int k= topLeftY;k<=bottomRightY;k++)
                    {
                        string cell = Convert.ToString(j) + Convert.ToChar('A' + k);
                        ship.Add(cell);
                    }
                shipCells.Add(ship);
            }
        }

        public void ProcessHitPos(string T,HashSet<string> hitPos)
        {
            string[] hitPoints = T.Split(" ");

            foreach (var pos in hitPoints)
                hitPos.Add(pos);
        }

        public string CountSunkAndHitEx(int N,string S,string T)
        {
            List<List<string>> shipCells = new List<List<string>>();

            ProcessShipCells(S, shipCells);

            var hitPos = new HashSet<string>();

            ProcessHitPos(T, hitPos);

            int hitShipCount = 0, sunkShipCount = 0;
            foreach(var ship in shipCells)
            {
                int hitCounts = 0;
                foreach(var shipCell in ship)
                {
                    if (hitPos.Contains(shipCell))
                        hitCounts++;
                }

                if (hitCounts > 0 && hitCounts < ship.Count)
                    hitShipCount++;
                else if (hitCounts == ship.Count)
                    sunkShipCount++;
            }

            return sunkShipCount.ToString()+","+hitShipCount.ToString();
        }

        public static string CountSunkAndHit(int N, string S, string T)
        {
            Tuple<char, char, char, char>[] ships;
            int[,] maps = new int[N, N];
            int hitShips = 0, sunkShips = 0;

            string[] shipsSplit = S.Split(",");

            ships = new Tuple<char, char, char, char>[shipsSplit.Length];
            for (int i = 0; i < shipsSplit.Length; i++)
            {
                string[] pos = shipsSplit[i].Split(" ");

                ships[i] = new Tuple<char, char, char, char>(pos[0][0], pos[0][1], pos[1][0], pos[1][1]);
            }

            string[] hitsPos = T.Split(" ");
            for (int i = 0; i < hitsPos.Length; i++)
            {
                int row = Convert.ToChar(hitsPos[i][0]) - '1';
                int col = Convert.ToChar(hitsPos[i][1]) - 'A';

                if (row < 0 || row >= N)
                    continue;

                if (col < 0 || col >= N)
                    continue;

                maps[row, col] = 1;
            }

            for (int i = 0; i < ships.Length; i++)
            {
                int sum = 0;
                for (int j = ships[i].Item1 - '1'; j <= ships[i].Item3 - '1'; j++)
                    for (int k = ships[i].Item2 - 'A'; k <= ships[i].Item4 - 'A'; k++)
                        sum += maps[j, k];
                int shipsSum = (ships[i].Item3 - ships[i].Item1 + 1) * (ships[i].Item4 - ships[i].Item2 + 1);
                if (sum > 0 && sum < shipsSum)
                {
                    hitShips += 1;
                }
                if (sum == shipsSum)
                {
                    sunkShips += 1;
                }
            }

            Console.WriteLine($"hitsShips={hitShips},sunkShips={sunkShips}");

            return sunkShips.ToString() + "," + hitShips.ToString();

        }

        public bool TestCountSunkAndHit(out string res)
        {
            res = "OK";

            int N = 4;
            string S = "1B 2C,2D 4D";
            string T = "2B 2D 3D 4D 4A";

            //int N = 3;
            //string S = "1A 1B,2C 2C";
            //string T = "1B";

            //int N = 12;
            //string S = "1A 2A,12A 12A";
            //string T = "12A";

            Console.WriteLine(CountSunkAndHitEx(N, S, T));

            return true;

        }


        static readonly string[] Columns = new[] { "A", "B", "C", "D", "E", "F", "G",
            "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public static string solution1(int N, string S, string T)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            S = S.ToUpper();
            T = T.ToUpper();

            var ships = S.Split(',');
            var hits = T.Split(' ');

            List<List<string>> shipsCells = new List<List<string>>();
            HashSet<string> hitsSet = new HashSet<string>();
            foreach (var item in hits)
            {
                hitsSet.Add(item);
            }

            foreach (var item in ships)
            {
                ProcessShip(item, shipsCells);
            }

            int sunkCount = 0;
            int hitNotSunkCount = 0;
            foreach (var ship in shipsCells)
            {
                int hitCount = 0;
                foreach (var cell in ship)
                {
                    if (hitsSet.Contains(cell))
                    {
                        hitCount++;
                    }
                }

                if (hitCount > 0)
                {
                    if (hitCount == ship.Count)
                    {
                        sunkCount++;
                    }
                    else
                    {
                        hitNotSunkCount++;
                    }
                }
            }

            return sunkCount.ToString() + "," + hitNotSunkCount.ToString();
        }

        public static void ProcessShip(string ship, List<List<string>> shipsCells)
        {
            var splits = ship.Split(' ');
            string topLeft = splits[0];
            string bottomRight = splits[1];

            int topRow = int.Parse(topLeft.Substring(0, topLeft.Length - 1));
            int bottomRow = int.Parse(bottomRight.Substring(0, bottomRight.Length - 1));
            int topCol = topLeft.Substring(topLeft.Length - 1, 1)[0] - 'A';
            int bottomCol = bottomRight.Substring(bottomRight.Length - 1, 1)[0] - 'A';

            List<string> shipCells = new List<string>();
            for (int row = topRow; row <= bottomRow; row++)
            {
                for (int col = topCol; col <= bottomCol; col++)
                {
                    string cells = row.ToString() + Columns[col];
                    shipCells.Add(cells);
                }
            }

            shipsCells.Add(shipCells);
        }
    }
}