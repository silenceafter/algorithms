using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson2
{
    class Task
    {
        public int[,] myArray { get; set; }
        public void FillArray(int N, int M, (int,int)[] tuple)
        {
            int[,] myArray = new int[N, M];
            int[,] mapArray = new int[N, M];
            // заполнить карту доступных и недоступных клеток
            int i, j;
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < M; j++)
                {
                    mapArray[i, j] = 1;
                }
            }
            // препятствия
            for (i = 0; i < tuple.GetLength(0); i++)
            {
                (int, int) myTuple = tuple[i];
                mapArray[myTuple.Item1, myTuple.Item2] = 0;
            }
            // Первая строка заполнена единицами
            for (j = 0; j < M; j++)
            {
                myArray[0, j] = 1;
            }

            for (i = 1; i < N; i++)
            {
                myArray[i, 0] = 1;
                for (j = 1; j < M; j++)
                {
                    if (this.CheckMyElement(i,j,mapArray))
                    {
                        myArray[i, j] = 0;
                    }
                    else
                    {
                        myArray[i, j] = myArray[i, j - 1] + myArray[i - 1, j];
                    }
                }
            }
            this.Print(N, M, myArray);
        }

        public bool CheckMyElement(int i, int j, int[,] mapArray)
        {
            if (mapArray[i, j] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            return false;
        }

        public void Print(int n, int m, int[,] myArray)
        {
            int maxValueLength = myArray[n - 1, m - 1].ToString().Length;

            int i, j;
            (int, int) tuple = (0, 0);
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    tuple = Console.GetCursorPosition();
                    int leftPosition = tuple.Item1 + myArray[i, j].ToString().Length + (maxValueLength - myArray[i, j].ToString().Length) + 1;
                    Console.Write($"|{myArray[i, j]}");
                    Console.SetCursorPosition(leftPosition, tuple.Item2);
                }
                Console.Write("\r\n");
            }
        }
    }
}