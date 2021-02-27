using System;

namespace lesson1
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }

    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

    class MyNodeClass : ILinkedList
    {
        private Node Head { get; set; }
        private Node Tail { get; set; }

        public MyNodeClass()
        { }

        public int GetCount()
        {
            // возвращает количество элементов в списке                                   
            int cnt = 0;
            Node Current = this.Head;
            while (Current != null)
            {
                cnt++;
                Current = Current.NextNode;
            }
            return cnt;
        }

        public void AddNode(int value)
        {
            // добавляет новый элемент списка
            Node Current = new Node();
            Current.Value = value;
            Current.PrevNode = null;
            Current.NextNode = null;

            if (this.Head == null)
            {
                // список пустой
                this.Head = Current;
                this.Tail = Current;
                return;
            }

            // в списке уже есть элементы
            Node Temp = this.Tail;
            this.Tail = Current;
            Temp.NextNode = this.Tail;
            this.Tail.NextNode = null;
            this.Tail.PrevNode = Temp;
            return;
        }

        public void AddNodeAfter(Node node, int value)
        {
            // добавляет новый элемент списка после определённого элемента                        
            Node Current = new Node();
            Current.Value = value;
            Current.PrevNode = null;
            Current.NextNode = null;
            //
            Node NextNode = null;
            if (node.NextNode != null)
            {
                NextNode = node.NextNode;
                NextNode.PrevNode = Current;
            }
            node.NextNode = Current;
            Current.PrevNode = node;
            Current.NextNode = NextNode;
            return;
        }

        public void RemoveNode(int index)
        {
            // удаляет элемент по порядковому номеру
            Node Current = this.Head;
            int cnt = 0;
            while (Current != null)
            {
                cnt++;
                if (cnt == index)
                {
                    this.RemoveNode(Current);
                    break;
                }
                Current = Current.NextNode;
            }
            return;
        }

        public void RemoveNode(Node node)
        {
            // удаляет указанный элемент
            Node PrevNode = node.PrevNode;
            Node NextNode = node.NextNode;
            //
            if (PrevNode == null && NextNode != null)
            {
                // удаление первого элемента
                NextNode.PrevNode = PrevNode;
                this.Head = NextNode;
            }

            if (PrevNode != null && NextNode != null)
            {
                // удаление элемента в середине
                PrevNode.NextNode = NextNode;
                NextNode.PrevNode = PrevNode;
            }

            if (PrevNode != null && NextNode == null)
            {
                // удаление последнего элемента
                PrevNode.NextNode = NextNode;
                this.Tail = PrevNode;
            }
            return;
        }

        public Node FindNode(int searchValue)
        {
            // ищет элемент по его значению
            Node Current = this.Head;
            while (Current != null)
            {
                if (Current.Value == searchValue)
                {
                    break;
                }
                Current = Current.NextNode;
            }
            return Current;
        }

        public string GetNodes()
        {
            Node Current = this.Head;
            string Nodes = "";
            while (Current != null)
            {
                Nodes += Current.Value.ToString() + ", ";
                Current = Current.NextNode;
            }
            return Nodes;
        }
    }

    public class Test
    {
        public int Input1 { get; set; }
        public string Expected1 { get; set; }
        public string Expected2 { get; set; }
        public string Expected3 { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyNodeClass MainClass = new MyNodeClass();

            var Test = new Test[5];
            Test[0] = new Test()
            {
                Input1 = 2,
                Expected1 = "2",
                Expected2 = "2, 3, 2, 4, 10, 11",
                Expected3 = "2, 11, 10, 4, 3, 2, 4, 10, 11"
            };

            Test[1] = new Test()
            {
                Input1 = 3,
                Expected1 = "2, 3",
                Expected2 = "2, 3, 3, 2, 4, 10, 11",
                Expected3 = "2, 11, 4, 3, 2, 4, 10, 11"
            };

            Test[2] = new Test()
            {
                Input1 = 4,
                Expected1 = "2, 3, 4",
                Expected2 = "2, 3, 4, 3, 2, 4, 10, 11",
                Expected3 = "2, 11, 4, 2, 4, 10, 11"
            };

            Test[3] = new Test()
            {
                Input1 = 10,
                Expected1 = "2, 3, 4, 10",
                Expected2 = "2, 3, 10, 4, 3, 2, 4, 10, 11",
                Expected3 = "2, 11, 4, 2, 4, 10, 11"
            };

            Test[4] = new Test()
            {
                Input1 = 11,
                Expected1 = "2, 3, 4, 10, 11",
                Expected2 = "2, 3, 11, 10, 4, 3, 2, 4, 10, 11",
                Expected3 = "2, 11, 4, 2, 4, 10, 11"
            };

            Console.WriteLine("1. Метод AddNode()");
            foreach (var TestCase in Test)
            {
                MainClass.AddNode(TestCase.Input1);
                Console.WriteLine($"Input = {TestCase.Input1}, Actual = {MainClass.GetNodes()}Expected = {TestCase.Expected1}");
            }

            Console.WriteLine("");
            Console.WriteLine("2. Метод AddNodeAfter()");
            foreach (var TestCase in Test)
            {
                MainClass.AddNodeAfter(MainClass.FindNode(3), TestCase.Input1);
                Console.WriteLine($"Input = {TestCase.Input1}, Actual = {MainClass.GetNodes()} Expected = {TestCase.Expected2}");
            }

            Console.WriteLine("");
            Console.WriteLine("3. Метод FindNode()");
            foreach (var TestCase in Test)
            {
                Node myNode = MainClass.FindNode(TestCase.Input1);
                Console.WriteLine($"Input = {TestCase.Input1}, Actual = {myNode.Value} Expected = {TestCase.Expected2}");
            }

            Console.WriteLine("");
            Console.WriteLine("4. Метод RemoveNode(index), в том числе RemoveNode(node)");
            foreach (var TestCase in Test)
            {
                MainClass.RemoveNode(TestCase.Input1);
                Console.WriteLine($"Input = {TestCase.Input1}, Actual = {MainClass.GetNodes()} Expected = {TestCase.Expected2}");
            }
        }
    }
}
