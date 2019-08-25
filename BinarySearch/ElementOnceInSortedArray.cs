using static System.Console;

namespace Search.BinarySearch
{
    public class ElementOnceInSortedArray
    {
        private int FindElementBinary(int[] numbers)
        {
            return FindElement(0, numbers.Length - 1);



            int FindElement(int start, int end)
            {
                // Solve small sub-problems
                // Unique no. at odd index can only be present at start
                if (numbers[start] != numbers[start + 1]) return numbers[start];
                // Unique no. at even index can be present at end
                if (numbers[end] != numbers[end - 1]) return numbers[end];

                int mid = (start + end) / 2 & ~1;   // Even mid

                // Unique no. at even index can be present anywhere in-between
                if (numbers[mid] != numbers[mid - 1] &&
                    numbers[mid] != numbers[mid + 1])
                    return numbers[mid];


                // Divide
                return numbers[mid] == numbers[mid - 1]
                    ? FindElement(start, end - 2)   // Left has result
                    // if (numbers[mid] == numbers[mid + 1])
                    : FindElement(start + 2, end);   // Right has result
            }
        }



        internal static void Work()
        {
            int[] numbers = { 1, 1, 2, 2, 3, 3, 4, 50, 50, 65, 65 };
            //int[] numbers = { 1, 1, 2, 2, 3, 3, 4, 4, 50, 50, 65, 65, 66 };
            //int[] numbers = { 0, 1, 1, 2, 2, 3, 3, 4, 4, 50, 50, 65, 65 };

            int uniqueNumber = new ElementOnceInSortedArray().FindElementBinary(numbers);
            WriteLine(uniqueNumber);
        }
    }
}