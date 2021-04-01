using System;

namespace lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            var Test = new Test[5];
            Test[0] = new Test()
            {
                InputN = 5,
                InputM = 10,
                InputMapArray = new (int,int)[] { (2,7), (3,5), (4,8) },
                Actual = 56
            };

            Test[1] = new Test()
            {
                InputN = 10,
                InputM = 5,
                InputMapArray = new (int, int)[] { (2, 1), (2, 2), (7, 4) },
                Actual = 148
            };

            Test[2] = new Test()
            {
                InputN = 5,
                InputM = 6,
                InputMapArray = new (int, int)[] { (2, 2), (3, 3), (3, 4), (4, 3) },
                Actual = 15
            };

            Test[3] = new Test()
            {
                InputN = 6,
                InputM = 5,
                InputMapArray = new (int, int)[] { (2, 2), (2, 3), (2, 4), (1, 4) },
                Actual = 45
            };

            Test[4] = new Test()
            {
                InputN = 7,
                InputM = 10,
                InputMapArray = new (int, int)[] { (5, 2), (6, 2), (4, 2) },
                Actual = 4410
            };

            Task[] myTask = new Task[5];
            for (int i = 0; i < myTask.GetLength(0); i++)
            {
                myTask[i] = new Task();
                Console.WriteLine($"Test[{i}]");
                Console.WriteLine($"InputArray = {Test[i].InputN}, {Test[i].InputM}");
                Console.Write($"InputMapArray = ");
                for (int j = 0; j < Test[i].InputMapArray.GetLength(0); j++)
                {
                    Console.Write($"{Test[i].InputMapArray[j]}, ");
                }
                Console.WriteLine("");
                Console.WriteLine($"Actual = {Test[i].Actual}");
                myTask[i].FillArray(Test[i].InputN, Test[i].InputM, Test[i].InputMapArray);
                Console.WriteLine("");
            }
        }
    }
}