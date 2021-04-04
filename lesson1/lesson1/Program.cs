using System;
using System.Collections.Generic;

namespace lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            var Test = new Test[5];
            Test[0] = new Test()
            {
                InputArray = new List<int> { 20, 5, 54, 120, 65, 63, 196, 150, 37, 43, 3, 121, 27, 44, 190 },
                Expected = "3, 5, 20, 27, 37, 43, 44, 54, 63, 65, 120, 121, 150, 190, 191",
                maxValue = 199,
                range = 25
            };

            Test[1] = new Test()
            {
                InputArray = new List<int> { 20, 15, 12, 3, 16, 8, 10, 5, 17, 1, 2, 11, 9, 4, 19, 14, 13, 7, 18, 6 },
                Expected = "1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20",
                maxValue = 20,
                range = 5
            };

            Test[2] = new Test()
            {
                InputArray = new List<int> { 2, 17, 27, 2, 36, 18, 55, 78, 98, 100, 1, 6, 4, 17, 20, 21, 76, 93, 52, 59 },
                Expected = "1, 2, 2, 4, 6, 17, 17, 18, 20, 21, 27, 36, 52, 55, 59, 76, 78, 93, 98, 100",
                maxValue = 100,
                range = 20
            };

            Test[3] = new Test()
            {
                InputArray = new List<int> { 20, 21, 37, 44, 45, 50, 2, 4, 6, 14, 24, 34, 43, 12, 11 },
                Expected = "2, 4, 6, 11, 12, 14, 20, 21, 24, 34, 37, 43, 44, 45, 50",
                maxValue = 50,
                range = 15
            };

            Test[4] = new Test()
            {
                InputArray = new List<int> { 33, 37, 98, 99, 91, 52, 56, 58, 44, 43, 21, 17, 87, 12, 5, 67, 68, 54, 35, 87, 78, 68, 69, 35, 91, 64 },
                Expected = "5, 12, 17, 21, 33, 35, 35, 37, 43, 44, 52, 54, 56, 58, 64, 67, 68, 68, 69, 78, 87, 87, 91, 91, 98, 99, ",
                maxValue = 100,
                range = 25
            };

            BucketSort[] mySort = new BucketSort[5];
            for (int i = 0; i < mySort.GetLength(0); i++)
            {
                mySort[i] = new BucketSort();
                Console.WriteLine($"Test[{i}]");
                string inputValue = "";
                for (int j = 0; j < Test[i].InputArray.Count; j++)
                {
                    inputValue += Test[i].InputArray[j].ToString() + ", ";
                }
                Console.WriteLine($"InputArray = {inputValue}");
                //
                mySort[i].myList = new List<List<int>>();
                mySort[i].maxValue = Test[i].maxValue;
                mySort[i].range = Test[i].range;
                List<int> resultArray = mySort[i].BucketSortMethod(Test[i].InputArray, 0, Test[i].range);
                string resultValue = "";
                for (int j = 0; j < resultArray.Count; j++)
                {
                    resultValue += resultArray[j].ToString() + ", ";
                }
                Test[i].Actual = resultValue;
                //
                Console.WriteLine($"Actual = {Test[i].Actual}");
                Console.WriteLine($"Expected = {Test[i].Expected}");
                Console.WriteLine("");
            }
        }
    }
}
