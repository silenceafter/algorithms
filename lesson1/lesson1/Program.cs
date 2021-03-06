using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(BenchmarkClass).Assembly).Run(args);
          /*|                             Method  |   Mean    |   Error  |  StdDev  |
            | ----------------------------------- |----------:|---------:|---------:|
            |         TestPointClassDistanceFloat | 248.40 ns | 0.788 ns | 0.658 ns |
            |        TestPointStructDistanceFloat | 77.93 ns  | 0.177 ns | 0.165 ns |
            |       TestPointStructDistanceDouble | 198.03 ns | 0.400 ns | 0.375 ns |
            |  TestPointStructDistanceWithoutSqrt | 152.55 ns | 0.233 ns | 0.218 ns |*/
        }
    }

    public class PointClass
    {
        public float X { get; set; }
        public float Y { get; set; }
    }

    public struct PointStruct
    {
        public float X { get; set; }
        public float Y { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
    }

    public class BenchmarkClass
    {
        public float[,] myFloatArray { get; }
        public double[,] myDoubleArray { get; }
        public BenchmarkClass()
        {
            this.myFloatArray = new float[100,2];
            this.myDoubleArray = new double[100, 2];
            Random myRandom = new Random();
            for (int i = 0; i < this.myFloatArray.GetLength(0); i++)
            {
                this.myFloatArray[i, 0] = myRandom.Next(100,200);
                this.myFloatArray[i, 1] = myRandom.Next(100,200);
                //
                this.myDoubleArray[i, 0] = myRandom.Next(100, 200);
                this.myDoubleArray[i, 1] = myRandom.Next(100, 200);
            }
        }
        public static float PointClassDistanceFloat(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static float PointStructDistanceFloat(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static double PointStructDistanceDouble(PointStruct pointOne, PointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        public static float PointStructDistanceWithoutSqrt(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }

        [Benchmark]
        public void TestPointClassDistanceFloat()
        {
            for (int i = 0; i < 10; i++)
            {
                var pointOneFloat = new PointClass() { X = this.myFloatArray[i,0], Y = this.myFloatArray[i,1] };
                var pointTwoFloat = new PointClass() { X = this.myFloatArray[i + 1, 0], Y = this.myFloatArray[i + 1, 1] };
                var result = PointClassDistanceFloat(pointOneFloat, pointTwoFloat);
            }
            return;
        }

        [Benchmark]
        public void TestPointStructDistanceFloat()
        {
            for (int i = 0; i < 10; i++)
            {
                var pointOneFloat = new PointStruct() { X = this.myFloatArray[i, 0], Y = this.myFloatArray[i, 1] };
                var pointTwoFloat = new PointStruct() { X = this.myFloatArray[i + 1, 0], Y = this.myFloatArray[i + 1, 1] };
                var result = PointStructDistanceFloat(pointOneFloat, pointTwoFloat);
            }
            return;
        }

        [Benchmark]
        public void TestPointStructDistanceDouble()
        {
            for (int i = 0; i < 10; i++)
            {
                var pointOneDouble = new PointStruct() { X2 = this.myDoubleArray[i, 0], Y2 = this.myDoubleArray[i, 1] };
                var pointTwoDouble = new PointStruct() { X2 = this.myDoubleArray[i + 1, 0], Y2 = this.myDoubleArray[i + 1, 1] };
                var result = PointStructDistanceDouble(pointOneDouble, pointTwoDouble);
            }
            return;
        }

        [Benchmark]
        public void TestPointStructDistanceWithoutSqrt()
        {
            for (int i = 0; i < 10; i++)
            {
                var pointOneFloat = new PointStruct() { X = this.myFloatArray[i, 0], Y = this.myFloatArray[i, 1] };
                var pointTwoFloat = new PointStruct() { X = this.myFloatArray[i + 1, 0], Y = this.myFloatArray[i + 1, 1] };
                var result = PointStructDistanceWithoutSqrt(pointOneFloat, pointTwoFloat);
            }
            return;
        }
    }
}