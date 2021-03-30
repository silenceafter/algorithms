using System;
using System.Collections.Generic;
using System.Text;

namespace lesson1
{
    class Edge
    {
        public int Weight { get; set; } //вес связи
        public Node Node { get; set; } // узел, на который связь ссылается
    }
}
