using System;

namespace lesson1
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
                Actual = 715
            };

            Test[1] = new Test()
            {
                InputN = 10,
                InputM = 5, 
                Actual = 715
            };

            Test[2] = new Test()
            {
                InputN = 2,
                InputM = 4, 
                Actual = 4
            };

            Test[3] = new Test()
            {
                InputN = 4, 
                InputM = 2, 
                Actual = 4
            };

            Test[4] = new Test()
            {
                InputN = 7, 
                InputM = 10, 
                Actual = 5005
            };

            Task[] myTask = new Task[5];
            for (int i = 0; i < myTask.GetLength(0); i++)
            {
                myTask[i] = new Task();
                Console.WriteLine($"Test[{i}]");
                Console.WriteLine($"InputArray = {Test[i].InputN}, {Test[i].InputM}");
                Console.WriteLine($"Actual = {Test[i].Actual}");
                myTask[i].FillArray(Test[i].InputN, Test[i].InputM, myTask[i].myArray);
                Console.WriteLine("");
            }
        }
    }
}