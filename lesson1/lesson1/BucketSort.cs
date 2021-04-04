using System;
using System.Collections.Generic;
using System.Text;

namespace lesson1
{
    class BucketSort
    {
        public int maxValue { get; set; }
        public int range { get; set; }
        public List<List<int>> myList { get; set; }
        public List<int> BucketSortMethod(List<int> myArray, int from, int range)
        {
            this.SplitIntoParts(myArray, from, range);
            return this.JoinArraysIntoArray(this.myList);
        }
        public void SplitIntoParts(List<int> myArray, int from, int range)
        {
            if (from < this.maxValue)
            {
                List<int> newArray = new List<int>();
                for (int i = 0; i < myArray.Count; i++)
                {
                    if (myArray[i] > from && myArray[i] <= range)
                    {
                        newArray.Add(myArray[i]);
                    }
                }
                if (newArray.Count > 0)
                {
                    newArray.Sort();
                    this.myList.Add(newArray);
                }              
                int newRange = range;
                newRange += this.range;
                this.SplitIntoParts(myArray, range, newRange);
            }
            return;
        }

        public List<int> JoinArraysIntoArray(List<List<int>> myArray)
        {
            List<int> listFinal = new List<int>();
            for (int i = 0; i < myArray.Count; i++)
            {
                List<int> subList = myArray[i];
                for (int j = 0; j < subList.Count; j++)
                {
                    listFinal.Add(subList[j]);
                }
            }
            return listFinal;
        }
    }
}
