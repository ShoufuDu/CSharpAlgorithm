using System;
using System.Linq;
using CSharpAlgorithm.Util;

namespace CSharpAlgorithm.DynamicPlanning
{

    public partial class DynamicPlanningSolution
    {
        //
        public static int BasicPacksackSelection(int[] weights, int[] values, int packsackCapacity)
        {
            int m = weights.Length;

            var weightsEx = new int[m + 1];
            var valuesEx = new int[m + 1];

            weights.CopyTo(weightsEx, 1);
            values.CopyTo(valuesEx, 1);

            var valueSelected = new int[m + 1, packsackCapacity + 1];


            for (int i = 1; i <= m; i++)
                for (int j = 1; j <= packsackCapacity; j++)
                {
                    if (weightsEx[i] >= j)
                    {
                        valueSelected[i, j] = valueSelected[i - 1, j];
                    }
                    else
                    {
                        valueSelected[i, j] = Math.Max(valueSelected[i - 1, j], valueSelected[i - 1, j - weightsEx[i]] + valuesEx[i]);
                    }
                }

            return valueSelected[m, packsackCapacity];

        }

        public static int BasicPacksackSelectionEx(int[] weights, int[] values, int packsackCapacity)
        {
            int m = weights.Length;

            var weightsEx = new int[m + 1];
            var valuesEx = new int[m + 1];

            weights.CopyTo(weightsEx, 1);
            values.CopyTo(valuesEx, 1);

            var valueSelected = new int[packsackCapacity + 1];

            //for(int i=1;i<=m;i++)
            //for (int j = packsackCapacity; j >= 1; j--)
            //if (weightsEx[i] <= j)
            //valueSelected[j] = Math.Max(valueSelected[j], valueSelected[j - weightsEx[i]] + valuesEx[i]);

            for (int i = 1; i <= m; i++)
                for (int j = packsackCapacity; j >= weightsEx[i]; j--)
                    valueSelected[j] = Math.Max(valueSelected[j], valueSelected[j - weightsEx[i]] + valuesEx[i]);

            return valueSelected[packsackCapacity];
        }

        public static int FullPacksackSelection(int[] weights, int[] values, int packsackCapacity)
        {
            int m = weights.Length;

            var weightsEx = new int[m + 1];
            var valuesEx = new int[m + 1];

            weights.CopyTo(weightsEx, 1);
            values.CopyTo(valuesEx, 1);

            var valueSelected = new int[packsackCapacity + 1];

            for (int i = 1; i <= m; i++)
                for (int j = weightsEx[i]; j <= packsackCapacity; j++)
                    valueSelected[j] = Math.Max(valueSelected[j], valueSelected[j - weightsEx[i]] + valuesEx[i]);

            return valueSelected[packsackCapacity];
        }

        public static int FullPacksackSelectionEx(int[] weights, int[] values, int packsackCapacity)
        {
            int m = weights.Length;

            float[] quality = new float[m];
            for (int i = 0; i < m; i++)
            {
                quality[i] = (float)values[i] / weights[i];
            }

            Tuple<int, int>[] wv = new Tuple<int, int>[m];
            for(int i=0;i<m;i++)
            {
                wv[i] = new Tuple<int,int>(weights[i], values[i]);
            }

            wv = wv.OrderByDescending(x => (float)x.Item2 / x.Item1).ToArray();

            int times = 0;
            int value, weight,maxValues = 0;
            for (int i = 0; i < m; i++)
            {
                times = packsackCapacity / wv[i].Item1;

                if (times < 1)
                    continue;

                value = times * wv[i].Item2;
                weight = times * wv[i].Item1;
                maxValues += value;
                packsackCapacity -= weight;

                if (packsackCapacity == 0)
                    break;
            }

            return maxValues;
        }


        public static void TestPacksackSelection()
        {
            int[] weights = new int[] { 2, 2, 6, 5, 4 };

            int[] values = new int[] { 6, 3, 5, 4, 6 };

            int packCapacity = 10;

            //Expect.Expect3("TestBasicPacksackSelection", BasicPacksackSelection, weights, values, packCapacity, 15);

            //Expect.Expect3("TestBasicPacksackSelectionEx", BasicPacksackSelectionEx, weights, values, packCapacity, 15);

            //Expect.Expect3("TestFullPacksackSelection", FullPacksackSelection, weights, values, packCapacity, 15);

            //values = new int[] { 6, 3, 5, 16, 6 };

            //Expect.Expect3("TestBasicPacksackSelection", BasicPacksackSelection, weights, values, packCapacity, 15);

            //Expect.Expect3("TestBasicPacksackSelectionEx", BasicPacksackSelectionEx, weights, values, packCapacity, 15);

            //Expect.Expect3("TestFullPacksackSelection", FullPacksackSelection, weights, values, packCapacity, 15);

            weights = new int[] { 2, 2, 6, 5,  4, 1,2,5,2};
            values = new int[]  { 6, 3, 5, 16, 6, 3, 12,10,14 };
            packCapacity = 34;

            Expect.Expect3("TestFullPacksackSelection", FullPacksackSelection, weights, values, packCapacity, 15);
            Expect.Expect3("TestFullPacksackSelectionEx", FullPacksackSelectionEx, weights, values, packCapacity, 15);

        }
    }


}