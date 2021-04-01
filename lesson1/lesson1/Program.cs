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
                Actual = 715,
                Expected = 715
            };

            Test[1] = new Test()
            {
                InputN = 10,
                InputM = 5, 
                Actual = 715, 
                Expected = 715
            };

            Test[2] = new Test()
            {
                InputN = 2,
                InputM = 4, 
                Actual = 4, 
                Expected = 4
            };

            Test[3] = new Test()
            {
                InputN = 4, 
                InputM = 2, 
                Actual = 4, 
                Expected = 4
            };

            Test[4] = new Test()
            {
                InputN = 7, 
                InputM = 10, 
                Actual = 5005, 
                Expected = 5005
            };

            Task[] myTask = new Task[5];
            for (int i = 0; i < myTask.GetLength(0); i++)
            {
                myTask[i] = new Task();
                Console.WriteLine($"Test[{i}]");
                Console.WriteLine($"InputArray = {Test[i].InputN}, {Test[i].InputM}");
                Console.WriteLine($"Actual = {Test[i].Actual}");
                Console.WriteLine($"Expected = {Test[i].Expected}");
                myTask[i].FillArray(Test[i].InputN, Test[i].InputM, myTask[i].myArray);
                Console.WriteLine("");
            }
            /* Test[0]
             * |1  |1  |1  |1  |1  |1  |1  |1  |1  |1 
             * |1  |2  |3  |4  |5  |6  |7  |8  |9  |10
             * |1  |3  |6  |10 |15 |21 |28 |36 |45 |55
             * |1  |4  |10 |20 |35 |56 |84 |120|165|220
             * |1  |5  |15 |35 |70 |126|210|330|495|715
             * 
             * Test[1]
             * |1  |1  |1  |1  |1
             * |1  |2  |3  |4  |5
             * |1  |3  |6  |10 |15
             * |1  |4  |10 |20 |35
             * |1  |5  |15 |35 |70
             * |1  |6  |21 |56 |126
             * |1  |7  |28 |84 |210
             * |1  |8  |36 |120|330
             * |1  |9  |45 |165|495
             * |1  |10 |55 |220|715
             * 
             * Test[2]
             * |1|1|1|1
             * |1|2|3|4
             * 
             * Test[3]
             * |1|1
             * |1|2
             * |1|3
             * |1|4
             * 
             * Test[4]
             * |1   |1   |1   |1   |1   |1   |1   |1   |1   |1
             * |1   |2   |3   |4   |5   |6   |7   |8   |9   |10
             * |1   |3   |6   |10  |15  |21  |28  |36  |45  |55
             * |1   |4   |10  |20  |35  |56  |84  |120 |165 |220
             * |1   |5   |15  |35  |70  |126 |210 |330 |495 |715
             * |1   |6   |21  |56  |126 |252 |462 |792 |1287|2002    
             * |1   |7   |28  |84  |210 |462 |924 |1716|3003|5005
             */
        }
    }
}