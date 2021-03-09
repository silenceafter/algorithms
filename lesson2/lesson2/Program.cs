using System;

namespace lesson2
{
    class MyTree : ITree
    {
        public TreeNode GetRoot()
        {
            // получить корневой элемент
            TreeNode a = new TreeNode();
            return a;
        }
        public void AddItem(int value)
        {
            // добавить узел
            TreeNode Node = new TreeNode();
            Node.LeftChild = null;
            Node.RightChild = null;
            Node.Value = value;
            int g;
            return;
        } 
        public void RemoveItem(int value)
        {
            // удалить узел по значению
            return;
        }
        public TreeNode GetNodeByValue(int value)
        {
            //получить узел дерева по значению
            TreeNode a = new TreeNode();
            return a;
        }
        public void PrintTree()
        {
            //вывести дерево в консоль
            return;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyTree a = new MyTree();
            a.AddItem(77);
        }
    }
}
