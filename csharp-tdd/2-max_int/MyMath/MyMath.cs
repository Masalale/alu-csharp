using System.Collections.Generic;

namespace MyMath
{
    /// <summary>Arithmetic helpers.</summary>
    public static class Operations
    {
        /// <summary>Adds two integers.</summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>Sum of a and b.</returns>
        public static int Add(int a, int b)
        {
            return a + b;
        }

        /// <summary>Finds the largest integer in a list.</summary>
        /// <param name="nums">List of numbers.</param>
        /// <returns>The largest value, or 0 if the list is empty.</returns>
        public static int Max(List<int> nums)
        {
            if (nums == null || nums.Count == 0)
                return 0;

            int max = nums[0];
            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] > max)
                    max = nums[i];
            }
            return max;
        }
    }
}
