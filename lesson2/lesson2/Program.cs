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
                Actual = 56,
                Expected = 56
            };

            Test[1] = new Test()
            {
                InputN = 10,
                InputM = 5,
                InputMapArray = new (int, int)[] { (2, 1), (2, 2), (7, 4) },
                Actual = 148, 
                Expected = 148
            };

            Test[2] = new Test()
            {
                InputN = 5,
                InputM = 6,
                InputMapArray = new (int, int)[] { (2, 2), (3, 3), (3, 4), (4, 3) },
                Actual = 15, 
                Expected = 15
            };

            Test[3] = new Test()
            {
                InputN = 6,
                InputM = 5,
                InputMapArray = new (int, int)[] { (2, 2), (2, 3), (2, 4), (1, 4) },
                Actual = 45, 
                Expected = 45
            };

            Test[4] = new Test()
            {
                InputN = 7,
                InputM = 10,
                InputMapArray = new (int, int)[] { (5, 2), (6, 2), (4, 2) },
                Actual = 4410, 
                Expected = 4410
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
                Console.WriteLine($"Expected = {Test[i].Expected}");
                myTask[i].FillArray(Test[i].InputN, Test[i].InputM, Test[i].InputMapArray);
                Console.WriteLine("");                                
            }

            /*
             * Test[0]
             * |1 |1 |1 |1 |1 |1 |1 |1 |1 |1 
             * |1 |2 |3 |4 |5 |6 |7 |8 |9 |10
             * |1 |3 |6 |10|15|21|28|0 |0 |19
             * |1 |4 |10|20|35|0 |28|28|37|56
             * |1 |5 |15|35|70|70|98|12|0 |56
             * 
             * Test[1]
             * |1  |1  |1  |1  |1  
             * |1  |2  |3  |4  |5
             * |1  |0  |0  |4  |9
             * |1  |1  |1  |5  |14
             * |1  |2  |3  |8  |22
             * |1  |3  |6  |14 |36
             * |1  |4  |10 |24 |60
             * |1  |5  |15 |39 |0
             * |1  |6  |21 |60 |60
             * |1  |7  |28 |88 |148
             * 
             * Test[2]
             * |1 |1 |1 |1 |1 |1 
             * |1 |2 |3 |4 |5 |6
             * |1 |3 |0 |4 |9 |15
             * |1 |4 |4 |0 |0 |15
             * |1 |5 |9 |0 |0 |15
             * 
             * Test[3]
             * |1 |1 |1 |1 |1 
             * |1 |2 |3 |4 |0
             * |1 |3 |0 |0 |0
             * |1 |4 |4 |4 |4 
             * |1 |5 |9 |13|17
             * |1 |6 |15|28|45
             * 
             * Test[4]
             * |1   |1   |1   |1   |1   |1   |1   |1   |1   |1   
             * |1   |2   |3   |4   |5   |6   |7   |8   |9   |10
             * |1   |3   |6   |10  |15  |21  |28  |36  |45  |55
             * |1   |4   |10  |20  |35  |56  |84  |120 |165 |220
             * |1   |5   |0   |20  |55  |111 |195 |315 |480 |700
             * |1   |6   |0   |20  |75  |186 |381 |696 |1176|1876
             * |1   7    |0   |20  |95  |281 |662 |1358|2534|4410
             */
        }
    }
}