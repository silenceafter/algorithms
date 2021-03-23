using System;
using System.Collections.Generic;

namespace lesson1
{
    class MyTree : ITree
    {
        private TreeNode Root { get; set; }

        public List<NodeInfo> DeepFirstSearch(ITree tree)
        {
            // Поиск в глубину (до окончания ветви)
            Stack<NodeInfo> myStack = new Stack<NodeInfo>();
            Stack<string> consoleStack = new Stack<string>();
            List<NodeInfo> myList = new List<NodeInfo>();
            var root = new NodeInfo() { Node = tree.GetRoot() };
            myStack.Push(root);
            consoleStack.Push(root.Node.Value.ToString());
            //
            Console.WriteLine($"DFS:");
            while (myStack.Count != 0) 
            {
                NodeInfo element = myStack.Pop();
                Console.Write($"{consoleStack.Pop()}");
                myList.Add(element);
                var depth = element.Depth - 1;
                if (element.Node.RightChild != null)
                {
                    var right = new NodeInfo()
                    {
                        Node = element.Node.RightChild,
                        Depth = element.Depth + 1,
                    };
                    myStack.Push(right);
                    consoleStack.Push($"-->{right.Node.Value.ToString()}");
                }
                if (element.Node.LeftChild != null)
                {
                    var left = new NodeInfo()
                    {
                        Node = element.Node.LeftChild,
                        Depth = element.Depth + 1, 
                    };
                    myStack.Push(left);
                    consoleStack.Push($"-->{left.Node.Value.ToString()}");
                }
            }            
            return myList;
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
                //Console.WriteLine($"Корень: {Node.Value}");
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
                        //Console.WriteLine($"{Node.Value}");
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
                        //Console.WriteLine($"{Node.Value}");
                    }
                    else
                        this.CompareValueWithChild(Current.RightChild, Node);
                }
            }
            return;
        }

        public string GetMyArray()
        {
            NodeInfo[] myArray = TreeHelper.GetTreeInLine(this);
            string result = "";
            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                result += $"{myArray[i].Node.Value.ToString()}, ";
            }
            return result;
        }

        public void RemoveItem(int value)
        {
            // удалить узел по значению
            TreeNode result = this.GetNodeByValue(value);
            if (result != null)
            {
                RemoveMyNode(result);
            }
            return;
        }

        public int RemoveMyNode(TreeNode current)
        {
            TreeNode parent = null;
            // 1 случай - ссылка parent = null
            if (current != null)
            {
                parent = current.Parent;
                TreeNode child = null;
                // удаление листа
                if (current.LeftChild == null && current.RightChild == null)
                {
                    if (parent != null)
                    {
                        if (parent.LeftChild == current)
                        {
                            parent.LeftChild = null;
                        }
                        if (parent.RightChild == current)
                        {
                            parent.RightChild = null;
                        }
                        current = null;
                    }
                    return 1;
                }

                // удаление узла с одним дочерним элементом
                if (current.LeftChild == null || current.RightChild == null)
                {
                    if (current.LeftChild != null && current.RightChild == null)
                    {
                        child = current.LeftChild;
                    }
                    if (current.LeftChild == null && current.RightChild != null)
                    {
                        child = current.RightChild;
                    }

                    if (parent.LeftChild == current)
                    {
                        parent.LeftChild = child;
                    }
                    else if (parent.RightChild == current)
                    {
                        parent.RightChild = child;
                    }
                    child.Parent = parent;
                    current = null;
                    return 1;
                }

                // удаление узла с двумя дочерними элементами
                if (current.LeftChild != null && current.RightChild != null)
                {
                    // ищем в ветке current.LeftChild наибольшее значение
                    child = current.LeftChild;
                    TreeNode nodeT = this.GetNodeByValue(this.GetMaxValue(child));
                    if (nodeT != null)
                    {
                        current.Value = nodeT.Value;
                        //1 случай, у найденного элемента нет потомков
                        if (nodeT.LeftChild == null)
                        {
                            if (nodeT.Parent.LeftChild == nodeT)
                            {
                                nodeT.Parent.LeftChild = null;
                            }
                            if (nodeT.Parent.RightChild == nodeT)
                            {
                                nodeT.Parent.RightChild = null;
                            }
                        }
                        //2 случай, когда у найденного элемента есть leftChild
                        if (nodeT.LeftChild != null)
                        {
                            if (nodeT.Parent.LeftChild == nodeT)
                            {
                                nodeT.Parent.LeftChild = nodeT.LeftChild;
                            }
                            if (nodeT.Parent.RightChild == nodeT)
                            {
                                nodeT.Parent.RightChild = nodeT.LeftChild;
                            }
                        }
                    }
                    return 1;
                }
            }
            return 0;
        }

        public int GetMaxValue(TreeNode node)
        {
            int value = 0, valueLeft = 0, valueRight = 0;
            if (node.LeftChild != null && node.RightChild != null)
            {
                valueLeft = this.GetMaxValue(node.LeftChild);
                valueRight = this.GetMaxValue(node.RightChild);
                if (valueLeft < valueRight)
                {
                    valueLeft = valueRight;
                }
            }

            if (node.LeftChild != null && node.RightChild == null)
            {
                valueLeft = this.GetMaxValue(node.LeftChild);
            }

            if (node.LeftChild == null && node.RightChild != null)
            {
                valueRight = this.GetMaxValue(node.RightChild);
            }

            if (node.LeftChild == null && node.RightChild == null)
            {
                value = node.Value;
            }

            value = node.Value;
            if (valueLeft < valueRight) { valueLeft = valueRight; }
            if (value < valueLeft) { value = valueLeft; }
            return value;
        }

        public TreeNode GetNodeByValue(int value)
        {
            //получить узел дерева по значению
            TreeNode result = this.MyCompare(this.GetRoot(), value);
            if (result == null)
            {
                result = new TreeNode();
                result.LeftChild = null;
                result.RightChild = null;
                result.Value = -1;
                //Console.WriteLine($"Значения {value} нет в дереве");
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
                }
                else
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
            var tuple = (0, 0);
            tuple = Console.GetCursorPosition();
            this.PrintNode(this.GetRoot(), 0, tuple.Item2 + 1, "Root");
            // вывод обхода дерева BFS
            Console.WriteLine("");
            tuple = Console.GetCursorPosition();
            Console.SetCursorPosition(0,tuple.Item2);
            NodeInfo[] myArray = TreeHelper.GetTreeInLine(this);
            // вывод обхода дерева DFS
            Console.WriteLine("");           
            tuple = Console.GetCursorPosition();
            Console.SetCursorPosition(0, tuple.Item2);
            List<NodeInfo> myList = this.DeepFirstSearch(this);
            Console.WriteLine("");
            return;
        }

        public (int, int) PrintNode(TreeNode node, int consoleLeft, int consoleTop, string branch)
        {
            Console.SetCursorPosition(consoleLeft, consoleTop);
            Console.Write("|");
            Console.Write("__");
            Console.Write($"{branch}: {node.Value}");
            /**/
            var tuple = (0, 0);
            tuple = Console.GetCursorPosition();
            var leftCoordinate = tuple.Item1;
            var topCoordinate = tuple.Item2 + 1;
            if (leftCoordinate > 0) { leftCoordinate -= 1; }
            Console.SetCursorPosition(leftCoordinate, topCoordinate);
            tuple = Console.GetCursorPosition();
            leftCoordinate = tuple.Item1;
            topCoordinate = tuple.Item2;

            if (node.LeftChild != null || node.RightChild != null)
            {
                TreeNode myChildNode = null;
                if (node.LeftChild != null && node.RightChild != null)
                {
                    tuple = this.PrintNode(node.LeftChild, leftCoordinate, topCoordinate, "L");
                    // откорректировать координату top
                    for (int i = topCoordinate; i < tuple.Item2; i++)
                    {
                        Console.SetCursorPosition(leftCoordinate, i);
                        Console.Write("|");
                    }
                    topCoordinate = tuple.Item2;
                    tuple = this.PrintNode(node.RightChild, leftCoordinate, topCoordinate, "R");
                }
                else
                {
                    var myBranch = "";
                    if (node.LeftChild != null)
                    {
                        myChildNode = node.LeftChild;
                        myBranch = "L";
                    }

                    if (node.RightChild != null)
                    {
                        myChildNode = node.RightChild;
                        myBranch = "R";
                    }
                    tuple = this.PrintNode(myChildNode, leftCoordinate, topCoordinate, myBranch);
                }
            }
            return tuple;
        }
        public List<int> GenerateRandomArray(List<int> myArray)
        {
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                myArray.Add(rnd.Next(200));
            }
            return myArray;
        }
    }
}