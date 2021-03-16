using System;
using System.Collections.Generic;

namespace lesson2
{
    class MyTree : ITree
    {
        private TreeNode Root { get; set; }

        public MyTree()
        {            
        }

        public TreeNode GetRoot()
        {
            // получить корневой элемент
            return this.Root;
        }
        public void AddItem(int value)
        {
            // добавить узел
            TreeNode Node = new TreeNode();
            Node.LeftChild = null;
            Node.RightChild = null;
            Node.Value = value;
            //
            CompareValueWithChild(this.GetRoot(), Node);            
            return;
        }

        public void CompareValueWithChild(TreeNode Current, TreeNode Node)
        {
            // определить место для текущего элемента
            if (Current == null)
            {
                // текущий элемент = корневой
                this.Root = Node;
                Console.WriteLine($"Корень: {Node.Value}");
                return;
            }
            
           if (!Current.Equals(Node)) 
           {
                if (Node.Value < Current.Value)
                {
                    if (Current.LeftChild == null)
                    {
                        Current.LeftChild = Node;
                        Node.Parent = Current;
                        Console.WriteLine($"{Node.Value}");
                    }
                    else
                        this.CompareValueWithChild(Current.LeftChild, Node);                    
                } 
                else
                {
                    if (Current.RightChild == null)
                    {
                        Current.RightChild = Node;
                        Node.Parent = Current;
                        Console.WriteLine($"{Node.Value}");
                    } 
                    else
                        this.CompareValueWithChild(Current.RightChild, Node);                 
                }               
            }                  
            return;
        }

        public void RemoveItem(int value)
        {
            // удалить узел по значению
            TreeNode result = this.GetNodeByValue(value);
            if (result != null)
            {
                RemoveMyNode(result, value);
            }
            return;
        }

        public void RemoveMyNode(TreeNode current, int value)
        {
            // 1 случай - ссылка parent = null
            if (current != null) 
            {
                if (current.LeftChild == null && current.RightChild == null)
                {
                    TreeNode parent = current.Parent;
                    if (parent != null)
                    {
                        if (parent.LeftChild == current)
                        {
                            parent.LeftChild = null;
                            current = null;
                        }
                        if (parent.RightChild == current) 
                        {
                            parent.RightChild = null;
                            current = null;
                        }
                    }
                }
            }
        }

        public TreeNode GetNodeByValue(int value)
        {
            //получить узел дерева по значению
            TreeNode result = this.MyCompare(this.GetRoot(), value);
            if (result == null)
            {
                Console.WriteLine($"Значения {value} нет в дереве");
            }
            return result;
        }

        public TreeNode MyCompare(TreeNode current, int value)
        {
            TreeNode result = current;            
            if (current != null)
            {
                if (value == current.Value)
                {
                    // найден
                    return current;
                }

                if (value < current.Value)
                {
                    // левая ветка
                    result = this.MyCompare(current.LeftChild, value);
                } else
                {
                    // правая ветка
                    result = this.MyCompare(current.RightChild, value);
                }
            }
            return result;
        }

        public void PrintTree()
        {
            //вывести дерево в консоль
            NodeInfo[] myArray = TreeHelper.GetTreeInLine(this);
            var maxDepth = 0;
            // ищем максимальную глубину дерева
            for (int i = 0; i < myArray.GetLength(0); i++)
            {           
                    if (myArray[i].Depth > maxDepth)
                    {
                        maxDepth = myArray[i].Depth;
                    }             
            } 
            return;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyTree myObject = new MyTree();
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                myObject.AddItem(rnd.Next(200));
            }
            myObject.GetRoot();
            myObject.PrintTree();
        }
    }
}
