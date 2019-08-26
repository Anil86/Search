using System;
using static System.Console;

namespace Search.BinarySearch
{
    public class PaintersPartitionProblem
    {
        private int MinimizeMaxBoards(int[] boards, int noOfPainters)
        {
            // Optimizations
            if (boards.Length == 1) return boards[0];   // If only 1 board, return it

            int maxBoard = int.MinValue, total = 0;
            foreach (var board in boards)
            {
                maxBoard = Math.Max(board, maxBoard);
                total += board;
            }

            if (noOfPainters == 1) return total;   // If only 1 painter, he paints all boards
            if (noOfPainters >= boards.Length) return maxBoard;   // If painters >= boards, return max board


            // Max time lies between min (when no.of painters = no.of boards) & max (when no.of painter = 1)
            return MinimizeMaxBoards(maxBoard, total);



            int MinimizeMaxBoards(int min, int max)
            {
                // Solve small sub-problems
                if (min == max) return min;


                // Divide & combine
                int mid = (min + max) / 2;
                int obtainedNoOfPainters = CalculatePainters(mid);   // No.of painters if max time = mid

                return obtainedNoOfPainters > noOfPainters
                    ? MinimizeMaxBoards(mid + 1, max)   // Case 1: painters ↑, reduce painters by ↑ times 
                    : MinimizeMaxBoards(min, mid);   // Case 2: painters ↓, increase painters by ↓ times 
            }


            // Calculate no.of painters for given max boards sum
            int CalculatePainters(int maxTime)
            {
                int sum = 0, painters = 1;

                foreach (var board in boards)
                {
                    sum += board;

                    if (sum > maxTime)   // If boards go over max boards sum, increase painter
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
            // Ans: 740

            //int noOfPainters = 26;
            //int[] boards =
            //{
            //    274, 465, 130, 135, 254, 45, 70, 122, 149, 95, 453, 65, 392, 331, 316, 484, 372, 339, 45, 46, 31, 167,
            //    351, 415, 387, 275, 355, 440, 290, 462, 436, 416, 279, 66, 403, 33, 464, 473, 8, 113, 420, 461, 30, 312
            //};
            // Ans: 647

            int fairMaxWork = new PaintersPartitionProblem().MinimizeMaxBoards(boards, noOfPainters);
            WriteLine(fairMaxWork);
        }
    }
}