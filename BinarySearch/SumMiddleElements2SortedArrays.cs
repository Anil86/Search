using System;
using static System.Console;

namespace Search.BinarySearch
{
    public class SumMiddleElements2SortedArrays
    {
        private int SumOfMids(int[] array1, int[] array2)
        {
            // If 2 arrays are in combined array sorted order
            if (array1[array1.Length - 1] <= array2[0]) return array1[array1.Length - 1] + array2[0];
            if (array2[array2.Length - 1] <= array1[0]) return array2[array2.Length - 1] + array1[0];


            return SumOfMids(0, array1.Length - 1, 0, array2.Length - 1);



            int SumOfMids(int s1, int e1, int s2, int e2)
            {
                float mid1, mid2;
                // Solve small sub-problems
                if (e1 - s1 == 1)   // Arrays of length 2
                {
                    mid1 = Math.Max(array1[s1], array2[s2]);
                    mid2 = Math.Min(array1[e1], array2[e2]);
                    return (int)(mid1 + mid2);
                }


                // Divide
                mid1 = FindMedian(array1, s1, e1, out int mid1Index);
                mid2 = FindMedian(array2, s2, e2, out int mid2Index);

                // Case 1: Mid1 = Mid2
                bool isNoOfItemsEven = IsNoOfItemsEven(s1, e1);
                if (mid1 == mid2)   // ToDo: Proper float equality
                    return isNoOfItemsEven
                        ? array1[mid1Index] + array1[mid1Index + 1]   // even items & mids same; so take mids of any 1 array 
                        : array1[mid1Index] + array2[mid2Index];

                // Case 2: Mid1 < Mid2
                if (mid1 < mid2)
                {
                    if (isNoOfItemsEven) mid2Index++;   // Consider both mids of even array
                    return SumOfMids(mid1Index, e1, s2, mid2Index);
                }

                // Case 3: Mid1 >= Mid2
                if (isNoOfItemsEven) mid1Index++;
                return SumOfMids(s1, mid1Index, mid2Index, e2);
            }


            float FindMedian(int[] array, int start, int end, out int index)
            {
                index = (start + end) / 2;

                return IsNoOfItemsEven(start, end)
                    ? (array[index] + array[index + 1]) / 2.0f
                    : array[index];
            }


            bool IsNoOfItemsEven(int start, int end) => (end - start) % 2 == 1;
        }



        internal static void Work()
        {
            int[] array1 = { 1, 2, 4, 6, 10 },
                array2 = { 4, 5, 6, 9, 12 };
            // Ans: 11

            //int[] array1 =
            //    {
            //        1397, 2784, 3922, 9370, 9592, 9660, 9691, 13618, 16539, 16791, 17496, 18000, 19191, 19282, 21357,
            //        22927, 23522, 25972, 26311, 26813, 26901, 28359, 29025, 32056
            //    },
            //    array2 =
            //    {
            //        182, 1157, 1209, 1580, 4143, 4390, 4623, 4767, 5793, 7156, 8009, 8135, 11891, 15901, 21045, 22789,
            //        22837, 23687, 24570, 26571, 26955, 29064, 31267, 31613
            //    };
            // Ans: 34287

            //int[] array1 = { 1, 2 },
            //    array2 = { 3, 4 };
            // Ans: 5

            int sum = new SumMiddleElements2SortedArrays().SumOfMids(array1, array2);
            WriteLine(sum);
        }
    }
}