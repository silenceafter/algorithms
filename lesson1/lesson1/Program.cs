using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

            /*|                             Method  |   Mean     |   Error  |  StdDev  |
              | ----------------------------------- |-----------:|---------:|---------:|
              |                       TestArrayFind | 8,088.3 ns | 158.60 ns|194.78 ns |
              |                     TestHashSetFind | 803.4 ns   | 6.94 ns  |  6.15 ns |*/
        }
    }
}
