using System;
namespace CSharpAlgorithm.MySort
{
    public class SortSolution
    {
        public static void QuickSort(int[] nums,int start,int end)
        {
            if (start<end)
            {
                int pivot = Part(nums, 0, start);
                QuickSort(nums, 0, pivot - 1);
                QuickSort(nums, pivot + 1, end);
            }
        }

        public static int Part(int[] nums,int start,int end)
        {
            int pivot = nums[start];

            if (start >= end)
                return start;

            int i = start+1;
            int j = end;
            while (i < j)
            {
                while (i < j && nums[i] <= pivot)
                    i++;

                while (i < j && nums[j] >= pivot)
                    j--;

                if (i < j)
                {
                    int temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                }
            }

            if (nums[i] >= pivot)
            {
                return i - 1;
            }
            else
            {
                return i;
            }
        }

        static public int Partion(int[] nums, int start,int end)
        {
            int pivot = nums[start];

            while(start<end)
            {
                while (start < end && nums[end] >= pivot)
                    end--;
                nums[start] = nums[end];
                while (start < end && nums[start] <= pivot)
                    start++;
                nums[end] = nums[start];
            }

            nums[start] = pivot;

            return start;
        }

        static public void QuickSort2(int[] nums, int start, int end)
        {
            if (start >= end)
            {
                Console.WriteLine("start:{0}", start);
                return;
            }

            int pivot = Partion(nums, start, end);

            QuickSort2(nums, 0, pivot - 1);
            QuickSort2(nums, pivot + 1, end);
        }

        static public void TestSort()
        {
            int[] nums = new int[] { 1, 3, 23, 12, 34, 21, 7, 38, 123, 11, 2, 3, 4, 51, 17, 31, 21 };

            //int[] nums = new int[]   { 3, 12, 34, 21,7,11,3,4};

            QuickSort(nums,0,nums.Length-1);

            Console.WriteLine();
            for (int i = 0; i < nums.Length; i++)
                Console.Write("{0} ", nums[i]);
            Console.WriteLine();


            QuickSort2(nums, 0, nums.Length - 1);
            Console.WriteLine("the second method");
            for (int i = 0; i < nums.Length; i++)
                Console.Write("{0} ", nums[i]);
            Console.WriteLine();
        }
    }
}
