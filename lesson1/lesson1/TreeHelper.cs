using System;
using System.Collections.Generic;
using System.Text;

namespace lesson1
{
    public static class TreeHelper
    {
        public static NodeInfo[] GetTreeInLine(ITree tree)
        {
            var bufer = new Queue<NodeInfo>();
            var consoleBufer = new Queue<string>();
            var returnArray = new List<NodeInfo>();
            var root = new NodeInfo() { Node = tree.GetRoot() };
            bufer.Enqueue(root);
            consoleBufer.Enqueue(root.Node.Value.ToString());

            Console.WriteLine($"BFS:");
            while (bufer.Count != 0)
            {
                var element = bufer.Dequeue();
                Console.Write($"{consoleBufer.Dequeue()}");                
                returnArray.Add(element);

                var depth = element.Depth + 1;
                if (element.Node.LeftChild != null)
                {
                    var left = new NodeInfo()
                    {
                        Node = element.Node.LeftChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(left);
                    consoleBufer.Enqueue($"-->{left.Node.Value.ToString()}");
                }
                if (element.Node.RightChild != null)
                {
                    var right = new NodeInfo()
                    {
                        Node = element.Node.RightChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(right);
                    consoleBufer.Enqueue($"-->{right.Node.Value.ToString()}");
                }                
            }
            return returnArray.ToArray();
        }
    }
}