using System;

namespace lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
          //
        }

        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;
            for (int i = 0; i < inputArray.Length; i++) // O(N)
            {
                for (int j = 0; j < inputArray.Length; j++) // O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++) // O(1+5+N) ~ O(N)
                    {
                        int y = 0;

                        if (j != 0)
                        {
                            y = k / j; // O(1)
                        }
                        sum += inputArray[i] + i + k + j + y; // O(1)+O(1)+..+N = 5
                    }
                }
            }
            return sum; // O(N^3)
        }
    }
}
