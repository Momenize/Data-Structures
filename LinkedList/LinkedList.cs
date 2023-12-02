using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
namespace DS_LinkedList{
    public class LinkedList{
        public Node _tail;
        public Node _head;

        public LinkedList()
        {
            _tail = null;
            _head = null;
        }

        public LinkedList(string data)
        {
            AddAtHead(data);
        }



        public LinkedList ReversedList()
        {
            if (this.IsEmpty()) return null;
            Node node = this._head;
            Stack<Node> nodes = new Stack<Node>();
            while (node!=null)
            {
                nodes.Push(node);
                node = node.next;
            }

            LinkedList l = new LinkedList();
            while(!(nodes.Count == 0)) //!nodes.isEmpty()
            {
                l.AddAtTail(nodes.Pop()._data);
            }
            return l;
        }

        public LinkedList SortedList()
        {
            if (this.IsEmpty()) return null;
            
            Node node = this._head;
            
            string[] data = new string[this.Counter()];
            for(int i = 0; i < data.Length; i++)
            {

                data[i] = node._data;
                node = node.next;
            }

            data.Sort();

            LinkedList l = new LinkedList();
            for (int i = 0; i < data.Length; i++)
            {
                l.AddAtTail(data[i]);
            }
            return l;

        }

        public void PrintList()
        {
            if(IsEmpty())
            {
                throw new Exception("Your list is empty. Try again!");
            }

            Node n = _head;
            while(n != null)
            {
                Console.Write(n._data + " -> ");
                n = n.next;
            }
            Console.WriteLine("NULL");
        }
        
        

        public void AddAtHead(string data)
        {
            Node node = new Node(data);
            if (IsEmpty())
            {
                _tail = node;
                _head = node;
                return;
            }

            node.next = _head;
            _head.last = node;
            _head = node;

        }

        private bool IsEmpty()
        {
            if(_head == null) return true;
            return false;
        }

        public int GetIndexFromHead(string data)
        {
            if(Search(data) != null)
            {
                int c = 0; 
                Node node = _head;
                while(node != null)
                {
                    if (node._data.Equals(data))
                    {
                        return c;
                    }
                    c++;
                    node = node.next;
                }
                return c;
            }
            else
            {
                return -1;
            }
        }

        public static bool MirrorCheck(LinkedList l)
        {
            if (l.IsEmpty()) throw new Exception("Your list is empty. Try again!");
            
            Node head = l._head;
            Node tail = l._tail;
            while(head != null && tail != null)
            {
                if(head._data != tail._data)
                {
                    return false;
                }

                if (head == tail || head == tail.last) return true;
                

                head = head.next;
                tail = tail.last;
            }

            return true;

            
        }
        
        public static void SumEqualsToX(LinkedList l, int x)
        {
            if (l.IsEmpty())
            {
                throw new Exception("Your list is empty. Try again!");
            }
            
            Node head = l._head;
            if(head.next == null)
            {
                throw new Exception("Your list doesn't contain enough data. Try again!");
            }

            bool isFirstOne = true;
            
            while(head != null)
            {
                Node tail = l._tail;
                if (head == tail) return;
                
                while (tail != head)
                {
                    if (Convert.ToInt32(head._data) + Convert.ToInt32(tail._data) == x)
                    {
                        if (isFirstOne) 
                        { 
                            Console.Write("(" + head._data + $", {tail._data})");
                            isFirstOne = false;
                        }
                        else Console.Write(", (" + head._data + $", {tail._data})");
                    }
                    tail = tail.last;
                }
                head = head.next;
            }
        }
        public int GetIndexFromTail(char data)
        {
            if(IsEmpty())
            {
                throw new Exception("Your list is empty. Try again!");
            }

            int c = 0;
            Node node = _tail;
            while(node != null)
            {
                c++;
                node = node.last;
            }
            return c;
        }
        public int Counter()
        {
            int c = 0;
            if (!IsEmpty())
            {
                Node n = _head;
                Node n1 = _tail;

                while(n != null && n1 != null)
                {
                    if(n == n1)
                    {
                        c++;
                        break;
                    }
                    c += 2;
                    n = n.next;
                    n1 = n1.last;
                }
                
            }
            return c;
        }
        public void AddAtTail(string data)
        {
            Node node = new Node(data);
            if (IsEmpty())
            {
                _tail = node;
                _head = node;
                return;
            }

            _tail.next = node;
            node.last = _tail;
            _tail = node;
        }


        public static void ReversedList(LinkedList l)
        {
            var l1 = new LinkedList();
            Node n = l._tail;
            while(n != null)
            {
                l1.AddAtHead(n._data);
                n = n.next;
            }

            l1.PrintList();
        }

        public static void FixLoop(LinkedList l)
        {
            Stack<Node> nextLoop = new Stack<Node>();
            Stack<Node> lastLoop = new Stack<Node>();
            Node head = l._head;
            Node tail = l._tail; 
            while(head != null)
            {
                
                nextLoop.Push(head);
                if(head.next == null)
                {
                    break;
                }
                if (nextLoop.Contains(head.next))
                {
                    if(head == tail)
                    {
                        head.next = null;
                        break;
                    }

                    Node n1 = l._tail;
                    while(n1 != null)
                    {
                        if(n1.last == head)
                        {
                            head.next = n1;
                            break;
                        }
                        n1 = n1.next;
                    }
                }
                head = head.next;
            }


            while(tail != null)
            {
                lastLoop.Push(tail);
                if(tail.last == null)
                {
                    return;
                }
                else if (lastLoop.Contains(tail.last))
                {
                    
                    head = l._head;
                    if (tail == head)
                    {
                        tail.last = null;
                        return;
                    }
                    while(head != null)
                    {
                        if(head.next == tail)
                        {
                            tail.last = head;
                            break;
                        }
                        head = head.next;
                    }
                }
                tail = tail.last;
            }
        }

        

        
        public Node Search(string data)
        {
            Node node = _tail;
            Node node1 = _head;

            while(node != null && node1 != null)
            {
                if(node == node1)
                {
                    if (node._data.Equals(data)) return node;
                    return null;
                }
                
                if(node._data.Equals(data))
                {
                    return node;
                }
                if (node1._data.Equals(data)) return node1;
                node = node.next;
                node1 = node1.last;
            }
            return null;
        }
        
        
        public static void PrintTwoDimList(Node[,] nodes)
        {
            if (nodes[0, 0] == null)
            {
                return;
            }

            
            for(int i = 0; i < nodes.GetLength(0); i++)
            {
                for(int j = 0; j < nodes.GetLength(1); j++)
                {
                    
                    if(j == nodes.GetLength(1) - 1)
                    {
                        Console.WriteLine(nodes[i, j]._data + "\t-->\tNULL");
                        continue;
                    }
                    Console.Write(nodes[i, j]._data + "\t-->\t");
                }
                Console.WriteLine();
                for(int k = 0; k <= nodes.GetLength(1); k++)
                {
                    Console.Write("|\t\t");
                }
                Console.WriteLine();
                for (int k = 0; k <= nodes.GetLength(1); k++)
                {
                    Console.Write($"▼\t\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            for (int k = 0; k <= nodes.GetLength(1); k++)
            {
                Console.Write("NULL\t\t");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        
        public static Node[,] TwoDimlist(string[,] mat)
        {
            Node[,] nodes = new Node[mat.GetLength(0), mat.GetLength(1)];
            
            for(int i = 0; i < nodes.GetLength(0); i++)
            {
                
                for(int j = 0; j < nodes.GetLength(1); j++)
                {
                    nodes[i, j] = new Node(mat[i, j]);
                    if (j == mat.GetLength(1) - 1 && i != mat.GetLength(0) - 1) 
                    {
                        nodes[i, j].down = nodes[i + 1, j];
                        continue;
                    }
                    else if(j == mat.GetLength(1) - 1 && i == mat.GetLength(0) - 1)
                    {
                        break;
                    }

                    if(i == mat.GetLength(0) - 1)
                    {
                        nodes[i, j].next = nodes[i, j + 1];
                        continue;
                    }
                    nodes[i, j].next = nodes[i, j + 1];
                    nodes[i, j].down = nodes[i + 1, j];
                }
            }

            return nodes;
        }

    }

}