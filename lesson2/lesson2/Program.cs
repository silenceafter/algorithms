using System;
using System.Collections.Generic;

namespace lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            var Test = new Test[5];
            Test[0] = new Test()
            {    
                InputArray = new int[] { 150, 5, 17, 93, 144, 10, 115, 199, 110, 116, 132, 89, 13, 52, 35, 64, 88, 14, 0, 44 },
                ExpectedArray = "150, 5, 199, 0, 17, 10, 93, 13, 89, 144, 14, 52, 115, 35, 64, 110, 116, 44, 88, 132",
                ExpectedArrayRemove = "150, 5, 199, 0, 17, 10, 93, 13, 89, 144, 14, 52, 115, 35, 64, 110, 116, 88, 132",
                Input = 44,
                Expected = "44"
            };

            Test[1] = new Test()
            {
                InputArray = new int[] { 135, 3, 107, 50, 20, 23, 100, 70, 35, 17, 30, 27, 102, 155, 110, 125, 2, 144, 15, 165 },
                ExpectedArray = "135, 3, 155, 2, 107, 144, 165, 50, 110, 20, 100, 125, 17, 23, 70, 102, 15, 35, 30, 27",
                ExpectedArrayRemove = "135, 3, 2, 107, 144, 165, 50, 110, 20, 100, 125, 17, 23, 70, 102, 15, 35, 30, 27",
                Input = 155,
                Expected = "155"
            };

            Test[2] = new Test()
            {
                InputArray = new int[] { 120, 170, 2, 100, 190, 50, 110, 70, 160, 90, 30, 60, 20, 130, 140, 40, 80, 12, 180, 140 },
                ExpectedArray = "120, 2, 170, 100, 160, 190, 50, 110, 130, 180, 30, 70, 140, 20, 40, 60, 90, 12, 80",
                ExpectedArrayRemove = "120, 2, 170, 100, 160, 190, 50, 110, 130, 180, 30, 70, 140, 20, 40, 60, 12, 80",
                Input = 90,                
                Expected = "90"
            };

            Test[3] = new Test()
            {
                InputArray = new int[] { 27, 35, 121, 40, 43, 45, 48, 192, 57, 191, 78, 120, 36, 150, 190, 67, 50, 193, 194, 195 },
                ExpectedArray = "27, 35, 121, 40, 192, 36, 43, 191, 193, 45, 150, 194, 48, 190, 195, 57, 50, 78, 67, 120",
                ExpectedArrayRemove = "27, 35, 121, 40, 192, 36, 43, 191, 193, 45, 150, 48, 190, 195, 57, 50, 78, 67, 120",
                Input = 194,                
                Expected = "194"
            };

            Test[4] = new Test()
            {
                InputArray = new int[] { 5, 7, 194, 19, 185, 173, 170, 95, 100, 130, 20, 160, 80, 70, 180, 150, 190, 192, 12, 198 },
                ExpectedArray = "5, 7, 194, 19, 198, 12, 185, 173, 190, 170, 180, 192, 95, 20, 100, 80, 130, 70, 160, 150",
                ExpectedArrayRemove = "5, 7, 194, 19, 198, 12, 185, 173, 190, 170, 180, 192, 95, 20, 100, 80, 130, 70, 160, 150",
                Input = 8,                
                Expected = "-1"
            };
            
            MyTree[] myObject = new MyTree[5];
            for (int i = 0; i < myObject.GetLength(0); i++)
            {
                myObject[i] = new MyTree();
            }

            string myStr;
            Console.WriteLine("1. Метод AddItem()");
            for (int i = 0; i < Test.GetLength(0); i++)
            {
                myStr = "";                
                for (int j = 0; j < Test[i].InputArray.GetLength(0); j++)
                {
                    myObject[i].AddItem(Test[i].InputArray[j]);
                    myStr += $"{Test[i].InputArray[j].ToString()}, ";
                }
                Console.WriteLine($"Test[{i}]");
                Console.WriteLine($"InputArray = {myStr}");
                Console.WriteLine($"Actual = {myObject[i].GetMyArray()}");// из NodeInfo
                Console.WriteLine($"ExpectedArray = {Test[i].ExpectedArray}");
                Console.WriteLine("");
            }

            Console.WriteLine("");
            Console.WriteLine("2. Метод GetNodeByValue()");
            for (int i = 0; i < Test.GetLength(0); i++)
            {                               
                Console.WriteLine($"Test[{i}]");
                Console.WriteLine($"Input = {Test[i].Input}");
                Console.WriteLine($"Actual = {myObject[i].GetNodeByValue(Test[i].Input).Value}");
                Console.WriteLine($"Expected = {Test[i].Expected}");
                Console.WriteLine("");
            }

            Console.WriteLine("");
            Console.WriteLine("3. Метод RemoveItem()");
            for (int i = 0; i < Test.GetLength(0); i++)
            {
                Console.WriteLine($"Test[{i}]");
                Console.WriteLine($"Input = {Test[i].Input}");
                myObject[i].RemoveItem(myObject[i].GetNodeByValue(Test[i].Input).Value);
                Console.WriteLine($"Actual = {myObject[i].GetMyArray()}");                
                Console.WriteLine($"ExpectedArrayRemove = {Test[i].ExpectedArrayRemove}");
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("4. Метод PrintTree()");            
            for (int i = 0; i < Test.GetLength(0); i++)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Test[{i}]");
                myObject[i].PrintTree();              
                Console.WriteLine("");
            }
        }
    }
}
