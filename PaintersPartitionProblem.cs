using System;
using static System.Console;

namespace Search
{
    public class PaintersPartitionProblem
    {
        private int MinimizeMaxWorkBinary(int noOfPainters, int[] boards)
        {
            int min = int.MinValue,   // If no.of painters = no.of boards
                max = 0;   // if only 1 painter
            foreach (var board in boards)
            {
                min = Math.Max(min, board);
                max += board;
            }

            return MinimizeMaxWork(min, max);



            int MinimizeMaxWork(int minLocal, int maxLocal)
            {
                // Solve small sum-problems
                if (minLocal == maxLocal) return minLocal;


                // Divide & Conquer
                int mid = (minLocal + maxLocal) / 2;

                // No.of painters for "max boards" sum = mid
                int noOfPaintersLocal = CalculateNoOfPainters(mid);

                return noOfPaintersLocal > noOfPainters
                    ? MinimizeMaxWork(mid + 1, maxLocal)   // Take right
                    : MinimizeMaxWork(minLocal, mid);   // Take left
            }


            // Calculate no.of painters for given max boards sum
            int CalculateNoOfPainters(int maxBoards)
            {
                int sum = 0, painters = 1;

                foreach (var board in boards)
                {
                    sum += board;

                    if (sum > maxBoards)   // If boards go over max boards sum, increase painter
                    {
                        sum = board;
                        painters++;

                        // If obtained painters goes over given painters, no need to find more painters 
                        if (painters > noOfPainters) break;
                    }
                }

                return painters;
            }
        }



        internal static void Work()
        {
            int noOfPainters = 2;
            //int[] boards = { 10, 10, 10, 10 };   // Ans: 20
            int[] boards = { 10, 20, 30, 40 };   // Ans: 60

            //int noOfPainters = 5;
            //int[] boards = { 2, 8, 9, 1 };   // Ans: 9

            //int noOfPainters = 14;
            //int[] boards =
            //{
            //    189, 107, 444, 400, 84, 270, 225, 334, 410, 433, 249, 193, 487, 312, 493, 430, 422, 208, 90, 245, 337,
            //    234, 168, 360
            //};
            // Ans: 740   // Calls: 222

            //int noOfPainters = 26;
            //int[] boards =
            //{
            //    274, 465, 130, 135, 254, 45, 70, 122, 149, 95, 453, 65, 392, 331, 316, 484, 372, 339, 45, 46, 31, 167,
            //    351, 415, 387, 275, 355, 440, 290, 462, 436, 416, 279, 66, 403, 33, 464, 473, 8, 113, 420, 461, 30, 312
            //};
            // Ans: 647   // Calls: 776

            int fairMaxWork = new PaintersPartitionProblem().MinimizeMaxWorkBinary(noOfPainters, boards);
            WriteLine(fairMaxWork);
        }
    }
}