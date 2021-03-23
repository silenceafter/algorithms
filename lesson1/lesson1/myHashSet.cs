using System;
using System.Collections.Generic;
using System.Text;

namespace lesson1
{
    public class myHashSet
    {
        public string myString { get; set; }
        public override bool Equals(object obj)
        {
            var myvar = obj as myHashSet;
            if (myvar == null)
            {
                return false;
            }
            return myString == myvar.myString;
        }

        public override int GetHashCode()
        {
            int myvarHashCode = myString?.GetHashCode() ?? 0;
            return myvarHashCode;
        }
    }
}
