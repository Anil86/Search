using static System.Console;

namespace Search.BinarySearch
{
    public class ElementOnceInSortedArray
    {
        private long FindElement(long[] numbers)
        {
            return FindElement(0, numbers.Length - 1);



            long FindElement(int start, int end)
            {
                // Solve small sub-problems
                if (end - start == 0) return numbers[0];   // Only 1 element

                if (numbers[start] != numbers[start + 1]) return numbers[start];   // Unequal element present at start
                if (numbers[end] != numbers[end - 1]) return numbers[end];   // Unequal element present at end


                int mid = (start + end) / 2;
                // Unequal element present at middle
                if (numbers[mid] != numbers[mid - 1] &&   // Check left
                    numbers[mid] != numbers[mid + 1])   // Check right
                    return numbers[mid];


                // Divide & Combine
                if (mid % 2 == 0)   // Even mid → unequal present on side mid = side
                {
                    return numbers[mid - 1] == numbers[mid]
                        ? FindElement(start, mid)   // Take left
                        : FindElement(mid, end);   // Take right
                }

                // Odd mid → unequal present on side mid ≠ side
                return numbers[mid - 1] != numbers[mid]
                    // Unequal cannot be mid, neglect mid
                    ? FindElement(start, mid - 1)   // Take left
                    : FindElement(mid + 1, end);   // Take right
            }
        }



        internal static void Work()
        {
            long[] numbers = { 1, 1, 2, 2, 3, 3, 4, 50, 50, 65, 65 };
            //long[] numbers = { 1, 1, 2, 2, 3, 3, 4, 4, 50, 50, 65, 65, 66 };
            //long[] numbers = { 0, 1, 1, 2, 2, 3, 3, 4, 4, 50, 50, 65, 65 };

            long uniqueNumber = new ElementOnceInSortedArray().FindElement(numbers);
            WriteLine(uniqueNumber);
        }
    }
}