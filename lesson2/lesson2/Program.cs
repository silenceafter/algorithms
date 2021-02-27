using System;

namespace lesson2
{
    class Program
    {
        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1; // O(1)
            while (min <= max) // O(N)
            {
                int mid = (min + max) / 2; // O(1)
                if (searchValue == inputArray[mid]) // O(1)
                {
                    return mid; // O(1)
                }
                else if (searchValue < inputArray[mid]) // O(1)
                {
                    max = mid - 1; // O(1)
                }
                else
                {
                    min = mid + 1; // O(1)
                }
            }
            return -1;// O(7 + N) ~ O(N)
        }
        public class Test
        {
            public int[] InputArray { get ; set; }
            public int Input { get; set; }
            public int Expected { get; set; }     
            
            public string myGet()
            {
                string result = "";
                for (int i = 0; i < this.InputArray.Length; i++)
                {
                    result += this.InputArray[i].ToString() + ", ";
                }
                return result;
            }

            public int[] GetMyArray(int[] myArray)
            {
                Array.Sort(myArray);// O(N^2)
                return myArray;
            }
        }
        static void Main(string[] args)
        {
            var Test = new Test[5];
            Test[0] = new Test()
            {
                InputArray = new int[] { 55, 14, 23, 17, 68, 91, 5, 37, 65, 47 },
                Input = 65,
                Expected = 7 // 5, 14, 17, 23, 37, 47, 55, 65, 68, 91
            };

            Test[1] = new Test()
            {
                InputArray = new int[] { 55, 14, 23, 17, 68, 91, 5, 37, 65, 47 },
                Input = 91,
                Expected = 9 // 5, 14, 17, 23, 37, 47, 55, 65, 68, 91
            };

            Test[2] = new Test()
            {
                InputArray = new int[] { 55, 14, 23, 17, 68, 91, 5, 37, 65, 47 },
                Input = 17,
                Expected = 2 // 5, 14, 17, 23, 37, 47, 55, 65, 68, 91
            };

            Test[3] = new Test()
            {
                InputArray = new int[] { 55, 14, 23, 17, 68, 91, 5, 37, 65, 47 },
                Input = 37,
                Expected = 4 // 5, 14, 17, 23, 37, 47, 55, 65, 68, 91
            };

            Test[4] = new Test()
            {
                InputArray = new int[] { 55, 14, 23, 17, 68, 91, 5, 37, 65, 47 },
                Input = 68,
                Expected = 8 // 5, 14, 17, 23, 37, 47, 55, 65, 68, 91
            };

            Console.WriteLine("Проверка метода бинарного поиска");
            foreach (var TestCase in Test)
            {
                Console.WriteLine($"Ввод = {TestCase.myGet()} Результат = {BinarySearch(TestCase.GetMyArray(TestCase.InputArray), TestCase.Input)}, Ожидание = {TestCase.Expected}");// O(N^2 + N)
            }

            // Sort(myArray) = O(N^2)
            // BinarySearch(myArray,someNumber) = O(7 + N) ~ O(N)
            // Result = O(N^2 + N)
        }
    }
}
