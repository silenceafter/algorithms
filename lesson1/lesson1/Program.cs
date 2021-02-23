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
                Input = 3,
                Expected = "простое"
            };

            Test[1] = new Test()
            {
                Input = 12,
                Expected = "не простое"
            };

            Test[2] = new Test()
            {
                Input = 17,
                Expected = "простое"
            };

            Test[3] = new Test()
            {
                Input = 44,
                Expected = "не простое"
            };

            Test[4] = new Test()
            {
                Input = 564,
                Expected = "не простое"
            };

            foreach (var TestCase in Test)
            {
                var result = MyFunction(TestCase.Input);
                Console.WriteLine($"Input = {TestCase.Input}, Actual = {result}, Expected = {TestCase.Expected}");
            }
        }

        public class Test 
        {
            public int Input { get; set; }
            public string Expected { get; set; }
            // true = простое, false = не простое
        }

        static string MyFunction(int n)
        {
            int d = 0, i = 2;
            while (i < n)
            {
                if (n % i == 0)
                {
                    d++;
                }
                i++;
            }

            if (d == 0)
            {
                // простое
                return "простое";
            }
            else
            {
                // не простое
                return "не простое";
            }
        }
    }
}
