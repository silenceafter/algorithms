using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            PointClass pointOne = new PointClass();
            pointOne.X = 5;
            pointOne.Y = 10;
            PointClass pointTwo = new PointClass();
            pointTwo.X = 10;
            pointTwo.Y = 15;

            BenchmarkClass a = new BenchmarkClass();
            Console.WriteLine(a.PointDistance(pointOne, pointTwo));
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }

    public class PointClass
    { 
        public float X;
        public float Y; 
    }

    public struct PointStruct
    {
        public float X;
        public float Y;

        public float PointDistance(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
    }

    public class BenchmarkClass
    {
        [Benchmark]
        public float PointDistance(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        //[Benchmark]
        public void TestFloatPointClass()
        {
            
        }

        //[Benchmark]
        public void TestSumBoxing()
        {
            object x = 99;
            //SumRefType(x);
        }
    }
}
