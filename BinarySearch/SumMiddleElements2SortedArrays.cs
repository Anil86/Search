using System;
using static System.Console;

namespace Search.BinarySearch
{
    public class SumMiddleElements2SortedArrays
    {
        private int AddMedians(int[] array1, int[] array2)
        {
            if (array1.Length == 1) return array1[0] + array2[0];   // Optimization: If array contains only 1 item


            return AddMedians(0, array1.Length - 1, 0, array2.Length - 1);



            int AddMedians(int s1, int e1, int s2, int e2)
            {
                // Optimizations
                // If 2 arrays are in order (i.e. 2 arrays can be placed next to each other w/o sorting)
                if (array2[s2] >= array1[e1]) return array1[e1] + array2[s2];   // array2 > array1
                if (array1[s1] >= array2[e2]) return array2[e2] + array1[s1];   // array1 > array2


                // Solve small sub-problems
                // If 2 elements in each array, calculate median manually
                if (e1 - s1 == 1) return Math.Max(array1[s1], array2[s2]) + Math.Min(array1[e1], array2[e2]);


                // Divide & Combine
                int m1 = (s1 + e1) / 2,
                    m2 = (s2 + e2) / 2;

                if (IsEvenLength(s1, e1))
                {
                    // If length is even, take both medians
                    if (array1[m1] < array2[m2 + 1]) m2 += 1;
                    else m1 += 1;
                }

                // Case 3: If medians are same
                if (array1[m1] == array2[m2]) return array1[m1] + array2[m2];

                // Case 1 & 2:   If medians are not same
                return array1[m1] < array2[m2]
                    ? AddMedians(m1, e1, s2, m2)   // Take array1[m1:e1] & array2[s2:m2]
                    : AddMedians(s1, m1, m2, e2);   // Take array1[s1:m1] & array2[m2:e2]
            }


            bool IsEvenLength(int start, int end)
            {
                int diff = end - start;
                return diff % 2 == 1;
            }
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

            int sum = new SumMiddleElements2SortedArrays().AddMedians(array1, array2);
            WriteLine(sum);
        }
    }
}