using System;
using System.Collections.Generic;
using System.Text;

namespace lesson1
{
    class Node
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int TraverseStatus { get; set; }
        public List<Edge> Edges { get; set; } //исходящие связи
    }
}
