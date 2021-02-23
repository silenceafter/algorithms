using System;
namespace lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            var Test = new Test[5];
            Test[0] = new Test()
            {
                Input = 0,
                Expected = 0
            };

            Test[1] = new Test()
            {
                Input = 1,
                Expected = 1
            };

            Test[2] = new Test()
            {
                Input = 2,
                Expected = 1
            };

            Test[3] = new Test()
            {
                Input = 5,
                Expected = 5
            };

            Test[4] = new Test()
            {
                Input = 15,
                Expected = 610
            };

            foreach (var TestCase in Test)
            {
                var result1 = GetFibonacciByRecursion(TestCase.Input);
                var result2 = GetFibonacciByCycle(TestCase.Input);
                Console.WriteLine($"Input = {TestCase.Input}, ActualRecursion = {result1}, ActualCycle = {result2}, Expected = {TestCase.Expected}");
            }
        }
        public class Test
        {
            public int Input { get; set; }
            public int Expected { get; set; }
        }

        static int GetFibonacciByRecursion(int number)
        {
            if (number == 0)
            {
                return 0;
            }

            if (number == 1)
            {
                return 1;
            }
            return GetFibonacciByRecursion(number - 1) + GetFibonacciByRecursion(number - 2);
        }

        static int GetFibonacciByCycle(int number)
        {
            if (number == 0)
            {
                return 0;
            }

            if (number == 1 || number == 2)
            {
                return 1;
            }

            int num1 = 1, num2 = 1;
            int i = 0, result;
            
            while (i < number - 2)
            {
                result = num1 + num2;
                num1 = num2;
                num2 = result;
                i++;
            }
            return num2;            
        }
    }
}
