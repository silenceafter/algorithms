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
                InputArray = new int[] { 150, 5, 17, 93, 144, 10, 115, 199, 110, 116, 132, 89, 13, 52, 35, 64, 88, 14, 0, 44 },
                ExpectedArrayBFS = "150, 5, 199, 0, 17, 10, 93, 13, 89, 144, 14, 52, 115, 35, 64, 110, 116, 44, 88, 132",
                ExpectedArrayDFS = "150, 5, 0, 17, 10, 13, 14, 93, 89, 52, 35, 44, 64, 88, 144, 115, 110, 116, 132, 199"   
            };

            Test[1] = new Test()
            {
                InputArray = new int[] { 135, 3, 107, 50, 20, 23, 100, 70, 35, 17, 30, 27, 102, 155, 110, 125, 2, 144, 15, 165 },
                ExpectedArrayBFS = "135, 3, 155, 2, 107, 144, 165, 50, 110, 20, 100, 125, 17, 23, 70, 102, 15, 35, 30, 27",
                ExpectedArrayDFS = "135, 3, 2, 107, 50, 20, 17, 15, 23, 35, 30, 27, 100, 70, 102, 110, 125, 155, 144, 165"
            };

            Test[2] = new Test()
            {
                InputArray = new int[] { 120, 170, 2, 100, 190, 50, 110, 70, 160, 90, 30, 60, 20, 130, 140, 40, 80, 12, 180, 140 },
                ExpectedArrayBFS = "120, 2, 170, 100, 160, 190, 50, 110, 130, 180, 30, 70, 140, 20, 40, 60, 90, 12, 80",
                ExpectedArrayDFS = "120, 2, 100, 50, 30, 20, 12, 40, 70, 60, 90, 80, 110, 170, 160, 130, 140, 190, 180"
            };

            Test[3] = new Test()
            {
                InputArray = new int[] { 27, 35, 121, 40, 43, 45, 48, 192, 57, 191, 78, 120, 36, 150, 190, 67, 50, 193, 194, 195 },
                ExpectedArrayBFS = "27, 35, 121, 40, 192, 36, 43, 191, 193, 45, 150, 194, 48, 190, 195, 57, 50, 78, 67, 120",
                ExpectedArrayDFS = "27, 35, 121, 40, 36, 43, 45, 48, 57, 50, 78, 67, 120, 192. 191, 150, 190, 193, 194, 195"
            };

            Test[4] = new Test()
            {
                InputArray = new int[] { 5, 7, 194, 19, 185, 173, 170, 95, 100, 130, 20, 160, 80, 70, 180, 150, 190, 192, 12, 198 },
                ExpectedArrayBFS = "5, 7, 194, 19, 198, 12, 185, 173, 190, 170, 180, 192, 95, 20, 100, 80, 130, 70, 160, 150",
                ExpectedArrayDFS = "5, 7, 194, 19, 12, 185, 173, 170, 95, 20, 80, 70, 100, 130, 160, 150, 180, 190, 192, 198"         
            };

            MyTree[] myObject = new MyTree[5];
            for (int i = 0; i < myObject.GetLength(0); i++)
            {
                myObject[i] = new MyTree();
            }

            for (int i = 0; i < Test.GetLength(0); i++)
            {
                for (int j = 0; j < Test[i].InputArray.GetLength(0); j++)
                {
                    myObject[i].AddItem(Test[i].InputArray[j]);
                    
                }                                                
                myObject[i].PrintTree();
                Console.WriteLine("");
                Console.WriteLine($"Test[{i}]");              
                Console.WriteLine($"InputArray = {Test[i].InputArray}");
                Console.WriteLine($"ExpectedArrayBFS = {Test[i].ExpectedArrayBFS}");
                Console.WriteLine($"ExpectedArrayDFS = {Test[i].ExpectedArrayDFS}");
            }
            Console.ReadKey();
        }
    }
}