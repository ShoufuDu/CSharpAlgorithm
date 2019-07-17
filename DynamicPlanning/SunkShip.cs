using System;
using System.Linq;
using System.Collections.Generic;

namespace CSharpAlgorithm.DynamicPlanning
{

    public partial class DynamicPlanningSolution
    {
        static public void GetShipsAndClicks(string S,string T, out List<List<string>>ships, out HashSet<string>clicks)
        {
            ships = new List<List<string>>();
            string[] strs = S.Split(",");
            for(int i=0;i<strs.Length;i++)
            {
                string[] AShip = strs[i].Split(" ");

                int leftX = Convert.ToInt32(AShip[0].Substring(0,AShip[0].Length-1));
                char leftY = AShip[0][AShip[0].Length-1];
                int rightX = Convert.ToInt32(AShip[1].Substring(0,AShip[1].Length-1));
                char rightY = AShip[1][AShip[1].Length-1];

                List<string> aship = new List<string>();
                for(int j=leftX;j<=rightX;j++)
                    {
                        for(var k=leftY;k<=rightY;k++)
                        {
                            string point = Convert.ToString(j)+Convert.ToString(k);

                            aship.Add(point);
                        }
                    }

                ships.Add(aship);
            }

            string[] clickStr = T.Split(" ");
            clicks = new HashSet<string>();
            for(int i=0;i<clickStr.Length;i++)
            {
                clicks.Add(clickStr[i]);
            }
        }

        static public string GetSunkAndHit(int N, string S,string T)
        {
            List<List<string>> ships;
            HashSet<string> clickHash;

            GetShipsAndClicks(S,T,out ships, out clickHash);

            int sunkCnt=0,hitCns=0;
            for(int i=0;i<ships.Count;i++)
            {
                int hitForOneShip = 0;
                for(int j=0;j<ships[i].Count;j++)
                {
                    if(clickHash.Contains(ships[i][j]))
                        hitForOneShip++;
                }
                if (hitForOneShip == ships[i].Count)
                    sunkCnt++;
                else if (hitForOneShip>0)
                    hitCns++;
            }

            return Convert.ToString(sunkCnt)+","+Convert.ToString(hitCns);
        }

        static public bool MyTestCountSunkAndHit()
        {
            // int N = 4;
            // string S = "1B 2C,2D 4D";
            // string T = "2B 2D 3D 4D 4A";

            // int N = 3;
            // string S = "1A 1B,2C 2C";
            // string T = "1B";

            int N = 12;
            string S = "1A 2A,12A 12A";
            string T = "12A";

            Console.WriteLine(GetSunkAndHit(N, S, T));

            return true;

        }
    }
}