using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lesson1
{
    class MyGraph
    { 
        public List<Node> NodesArray { get; set; }
        public Deque<Node> FrontArrayD { get; set; }
        public void AddNode(int value)
        {
            this.NodesArray.Add(new Node() { Value = value, TraverseStatus = 1, Edges = new List<Edge>() });
            return;
        }
        public void BreadthFirstSearch()
        {
            Deque<Node> FrontArray = new Deque<Node>();
            Node currentNode = this.NodesArray[0];
            currentNode.TraverseStatus = 2;
            FrontArray.AddLast(currentNode);
            while (FrontArray.Count > 0)
            {
                currentNode = FrontArray.First;
                if (currentNode.TraverseStatus == 3)
                {                  
                    FrontArray.RemoveFirst();                    
                } 
                else
                {
                    Console.Write($"V {currentNode.Value}");
                    int cnt = 0;
                    for (int i = 0; i < currentNode.Edges.Count; i++)
                    {
                        Edge currentEdge = currentNode.Edges[i];
                        if (currentEdge.Weight > 0)
                        {
                            Node nextNode = currentEdge.Node;
                            if (nextNode.TraverseStatus == 1)
                            {
                                cnt++;
                                nextNode.TraverseStatus = 2;
                                FrontArray.AddLast(nextNode);
                                Console.Write($"-->W {currentEdge.Weight}-->");
                                currentNode.TraverseStatus = 3;
                                break;
                            }
                        }
                    }
                    if (cnt == 0) { break; }//обработаны все вершины
                }               
            }          
            return;
        }

        public void DeepFirstSearch()
        {            
            for (int i = 0; i < this.NodesArray.Count; i++)
            {
                // очистка
                this.NodesArray[i].TraverseStatus = 1;
            }
            Node currentNode = this.NodesArray[0];
            currentNode.TraverseStatus = 2; // посещаем вершину сейчас
            Console.Write($"V {currentNode.Value}");
            TraverseMethod(currentNode);
            return;
        }

        public void TraverseMethod(Node node)
        {
            int cnt = 0;
            for (int i = 0; i < node.Edges.Count; i++)
            {
                Edge currentEdge = node.Edges[i];
                if (currentEdge.Weight > 0)
                {
                    Node currentNode = currentEdge.Node;
                    if (currentNode.TraverseStatus == 1)
                    {
                        // новая вершина
                        cnt++;
                        node.TraverseStatus = 3; // посещали вершину
                        currentNode.TraverseStatus = 2; // посещаем вершину сейчас
                        Console.Write($"-->W {currentEdge.Weight}-->");
                        Console.Write($"V {currentNode.Value}");
                        TraverseMethod(currentNode);
                    }
                }
            }

            if (cnt == 0) 
            {
                // тупик
                node.TraverseStatus = 3;
            }
            return;
        }
    }
}