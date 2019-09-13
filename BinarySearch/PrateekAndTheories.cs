using System;
using System.IO;
using static System.Console;

namespace Search.BinarySearch
{
    public class PrateekAndTheories
    {
        private int CalculateMaxPopularity(Theory[] theories, out int popularTime)
        {
            // Find min start time & max end time
            int minStartTime = theories[0].StartTime,
                maxEndTime = theories[0].EndTime;
            for (int i = 1; i < theories.Length; i++)
            {
                if (theories[i].StartTime < minStartTime) minStartTime = theories[i].StartTime;
                if (theories[i].EndTime > maxEndTime) maxEndTime = theories[i].EndTime;
            }

            return CalculateMaxPopularity(minStartTime, maxEndTime, theories.Length, out popularTime);



            int CalculateMaxPopularity(int start, int end, int popularity, out int popTime)
            {
                // Solve small sub-problems
                if (start == end)
                {
                    popTime = start;
                    return popularity;   // If start = end, partition w/ max popularity reached
                }


                // Divide
                int mid = (start + end) / 2;

                // Count no.of theories in left & right
                CountTheories(start, mid, end, out int leftTheoryCount, out int rightTheoryCount);

                // If theories in left > right, take left
                if (leftTheoryCount > rightTheoryCount)   
                    return CalculateMaxPopularity(start, mid, leftTheoryCount, out popTime);
                // If theories in right > left, take right
                if (rightTheoryCount > leftTheoryCount)
                    return CalculateMaxPopularity(mid + 1, end, rightTheoryCount, out popTime);

                // If theories in left = right, take both
                int leftTheoryPopularity = CalculateMaxPopularity(start, mid, leftTheoryCount, out popTime);
                int rightTheoryPopularity = CalculateMaxPopularity(mid + 1, end, rightTheoryCount, out popTime);


                // Combine
                // When theories in left = right, take side w/ max popularity
                return Math.Max(leftTheoryPopularity, rightTheoryPopularity);
            }



            void CountTheories(int start, int mid, int end, out int leftTheoryCount, out int rightTheoryCount)
            {
                leftTheoryCount = rightTheoryCount = default;

                foreach (var theory in theories)
                {
                    // Count left theories
                    // 
                    // If left part lies within theory range
                    //                  |           |
                    // t    h       e       o           r       y
                    if (theory.StartTime <= start && theory.EndTime >= mid) leftTheoryCount++;
                    
                    // If theory range lies outside left part
                    //  |           |
                    //                                  theory
                    else if (theory.StartTime > mid) { }
                    else   // Check theory lies in left
                    {
                        for (int i = theory.StartTime; i <= theory.EndTime; i++)
                            if (i >= start && i <= mid)
                            {
                                leftTheoryCount++;
                                break;
                            }
                    }

                    // Count right theories
                    // 
                    // If right part lies within theory range
                    //                  |           |
                    // t    h       e       o           r       y
                    if (theory.StartTime <= mid + 1 && theory.EndTime >= end) rightTheoryCount++;
                    
                    // If theory range lies outside right part
                    //                      |               |
                    // theory
                    else if (theory.EndTime < mid + 1) { }
                    else   // Check theory lies in right
                    {
                        for (int i = theory.StartTime; i <= theory.EndTime; i++)
                            if (i >= mid + 1 && i <= end)
                            {
                                rightTheoryCount++;
                                break;
                            }
                    }
                }
            }
        }



        internal static void Work()
        {
            Theory[] theories =
            {
                new Theory(1, 10),
                new Theory(2, 4),
                new Theory(3, 5),
                new Theory(11, 12),
                new Theory(12, 13)
            };

            int popularity = new PrateekAndTheories().CalculateMaxPopularity(theories, out int popularTime);
            WriteLine($"Popularity: {popularity}\tPopular time: {popularTime + 1}");

            // Read i/p data from text file
            //using (StreamReader file =
            //    new StreamReader(@"E:\Tutorials\C# Programming\App Business Logic\Algorithms\Books\Sample.txt"))
            //{
            //    int t = int.Parse(file.ReadLine().Trim());
            //    for (int i = 0; i < t; i++)
            //    {
            //        int noOfTheories = int.Parse(file.ReadLine().Trim());
            //        Theory[] theories = new Theory[noOfTheories];

            //        for (int j = 0; j < noOfTheories; j++)
            //        {
            //            int[] theoryTimes = Array.ConvertAll(file.ReadLine().Trim().Split(), int.Parse);
            //            theories[j] = new Theory(theoryTimes[0], theoryTimes[1]);
            //        }

            //        WriteLine(new PrateekAndTheories().CalculateMaxPopularity(theories, out int popularTime));
            //        break;
            //    }
            //}
        }
    }


    internal struct Theory
    {
        public Theory(int startTime, int endTime)
        {
            StartTime = --startTime;
            EndTime = endTime -= 2;
        }


        public int StartTime { get; }
        public int EndTime { get; }
    }
}