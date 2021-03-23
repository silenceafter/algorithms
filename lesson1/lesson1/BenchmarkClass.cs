using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace lesson1
{
    public class BenchmarkClass
    {
        public string[] myArray { get; set; }
        public HashSet<myHashSet> myHash { get; set; }
        
        public BenchmarkClass()
        {
            // String Array
            this.myArray = new string[10000];
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            //
            Random myRandom = new Random();
            for (int i = 0; i < this.myArray.GetLength(0); i++)
            {
                string word = "";
                for (int j = 1; j <= letters.GetLength(0); j++)
                {
                    int letter_num = myRandom.Next(0, letters.Length - 1);
                    word += letters[letter_num];
                }
                this.myArray[i] = word;
            }

            // String HashSet
            this.myHash = new HashSet<myHashSet>();
            for (int i = 0; i < this.myArray.GetLength(0); i++)
            {
                var myvar = new myHashSet() { myString = this.myArray[i] };
                this.myHash.Add(myvar);
            }
        }

        public static string GetStringFromArray(ArrayClass myArrayClass, string myString)
        {
            var result = "";
            for (int i = 0; i < myArrayClass.myArray.GetLength(0); i++)
            {
                if (myString.ToLower() == myArrayClass.myArray[i].ToLower())
                {
                    result = myArrayClass.myArray[i];
                    break;
                }
            }
            return result;
        }

        public static bool GetHashFromHashSet(HashSet<myHashSet> myHashSetClass, string myString)
        {
            var myvar = new myHashSet() { myString = myString };
            return myHashSetClass.Contains(myvar);
        }

        [Benchmark]
        public void TestArrayFind()
        {
            for (int i = 0; i < 10; i++)
            {
                var myvar = new ArrayClass() { myArray = this.myArray };
                var result = GetStringFromArray(myvar, this.myArray[i]);
            }
            return;
        }

        [Benchmark]
        public void TestHashSetFind()
        {
            var result = false;
            for (int i = 0; i < 10; i++)
            {
                var hashSet = this.myHash;
                result = GetHashFromHashSet(hashSet, this.myArray[i]);
            }                             
            return;
        }   
    }
}
