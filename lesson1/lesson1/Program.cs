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
                InputValuesArray = new int[] { 60, 2, 18, 112, 46 },
                InputWeightArray = new int[,] { { 150, 0, 20, 0, 35 }, { 0, 0, 25, 5, 0 }, { 0, 17, 0, 0, 0 }, { 110, 0, 0, 50, 0 }, { 0, 12, 14, 0, 0 } },
                ExpectedBFS = "V 60-->W 20-->V 18-->W 17-->V 2-->W 5-->V 112",
                ExpectedDFS = "V 60-->W 20-->V 18-->W 17-->V 2-->W 5-->V 112-->W 35-->V 46"
            };

            Test[1] = new Test()
            {
                InputValuesArray = new int[] { 60, 2, 18, 112, 46 },
                InputWeightArray = new int[,] { { 150, 0, 20, 0, 35 }, { 0, 0, 25, 5, 0 }, { 0, 17, 0, 0, 0 }, { 110, 0, 0, 50, 97 }, { 0, 12, 14, 0, 0 } },
                ExpectedBFS = "V 60-->W 20-->V 18-->W 17-->V 2-->W 5-->V 112-->W 97-->V 46",
                ExpectedDFS = "V 60-->W 20-->V 18-->W 17-->V 2-->W 5-->V 112-->W 97-->V 46"
            };

            Test[2] = new Test()
            {
                InputValuesArray = new int[] { 15, 50, 64, 198, 102 },
                InputWeightArray = new int[,] { { 0, 0, 0, 17, 28 }, { 0, 44, 26, 0, 37 }, { 0, 0, 52, 59, 10 }, { 0, 1, 31, 0, 14 }, { 2, 5, 7, 6, 4 } },
                ExpectedBFS = "V 15-->W 17-->V 198-->W 1-->V 50-->W 26-->V 64-->W 10-->V 102",
                ExpectedDFS = "V 15-->W 17-->V 198-->W 1-->V 50-->W 26-->V 64-->W 10-->V 102"
            };

            Test[3] = new Test()
            {
                InputValuesArray = new int[] { 22, 197, 40, 25, 17 },
                InputWeightArray = new int[,] { { 1, 14, 20, 4, 30 }, { 0, 17, 5, 7, 101 }, { 100, 150, 5, 7, 98 }, { 0, 0, 2, 0, 7 }, { 1, 1, 1, 1, 1 } },
                ExpectedBFS = "V 22-->W 14-->V 197-->W 5-->V 40-->W 7-->V 25-->W 7-->V 17",
                ExpectedDFS = "V 22-->W 14-->V 197-->W 5-->V 40-->W 7-->V 25-->W 7-->V 17"
            };

            Test[4] = new Test()
            {
                InputValuesArray = new int[] { 190, 104, 122, 178, 30 },
                InputWeightArray = new int[,] { { 15, 0, 12, 100, 140 }, { 0, 5, 10, 58, 22 }, { 7, 12, 9, 5, 7 }, { 60, 64, 14, 56, 8 }, { 87, 78, 56, 65, 4 } },
                ExpectedBFS = "V 190-->W 12-->V 122-->W 12-->V 104-->W 58-->V 178-->W 8-->V 30",
                ExpectedDFS = "V 190-->W 12-->V 122-->W 12-->V 104-->W 58-->V 178-->W 8-->V 30"
            };

            MyGraph[] myObject = new MyGraph[5];
            for (int i = 0; i < myObject.GetLength(0); i++)
            {
                myObject[i] = new MyGraph();
                myObject[i].NodesArray = new System.Collections.Generic.List<Node>();
                // добавляем ноды
                for (int j = 0; j < Test[i].InputValuesArray.GetLength(0); j++)
                {
                    myObject[i].AddNode(Test[i].InputValuesArray[j]);
                }

                // добавляем ребра
                for (int k = 0; k < myObject[i].NodesArray.Count; k++)
                {
                    for (int j = 0; j < myObject[i].NodesArray.Count; j++)
                    {
                        myObject[i].NodesArray[k].Edges.Add(new Edge() { Weight = Test[i].InputWeightArray[k, j], Node = myObject[i].NodesArray[j] });
                    }
                }
                Console.WriteLine($"Test[{i}]");
                Console.Write($"InputValueArray  = ");
                for (int j = 0; j < Test[i].InputValuesArray.GetLength(0); j++)
                {
                    Console.Write(Test[i].InputValuesArray[j].ToString() + ", ");
                }

                Console.WriteLine("");
                Console.Write($"InputWeightArray = ");
                for (int j = 0; j < Test[i].InputWeightArray.GetLength(0); j++)
                {
                    for (int k = 0; k < Test[i].InputWeightArray.GetLength(1); k++)
                    {
                        Console.Write(Test[i].InputWeightArray[j, k].ToString() + ", ");
                    }
                }

                Console.WriteLine("");
                Console.Write($"ActualBFS        = ");
                myObject[i].BreadthFirstSearch();
                Console.WriteLine("");
                Console.WriteLine($"ExpectedArrayBFS = {Test[i].ExpectedBFS}");
                Console.Write($"ActualDFS        = ");
                myObject[i].DeepFirstSearch();
                Console.WriteLine("");
                Console.WriteLine($"ExpectedArrayDFS = {Test[i].ExpectedDFS}");
                Console.WriteLine($"\n");
            }
            //   0   1   2   3   4     
            //   A   B   C   D   E     
            //0A 150 0   20  0   35      
            //1B 0   0   25  5   0        
            //2C 0   17  0   0   0   
            //3D 110 0   0   50  0         
            //4E 0   12  14  0   0
            //
            //0A 150 0   20  0   35
            //1B 0   0   25  5   0
            //2C 0   17  0   0   0
            //3D 110 0   0   50  97
            //4E 0   12  14  0   0
            //
            //0A 0   0   0   17  28
            //1B 0   44  26  0   37
            //2C 0   0   52  59  10
            //3D 0   1   31  0   14
            //4E 2   5   7   6   4
            //
            //0A 1   14  20  4   30
            //1B 0   17  5   7   101
            //2C 100 150 5   7   98
            //3D 0   0   2   0   7
            //4E 1   1   1   1   1
            //  
            //0A 15  0   12  100 140
            //1B 0   5   10  58  22
            //2C 7   12  9   5   7
            //3D 60  64  14  56  8
            //4E 87  78  56  65  4
        }
    }
}
