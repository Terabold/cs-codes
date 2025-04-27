using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using Unit4.CollectionsLib;
namespace Ariel
{

    class Program
    {
        public static void Main(string[] args)
        {
            BinNode<int> root = new BinNode<int>(4);
            BinNode<int> node5 = new BinNode<int>(5);
            BinNode<int> node3 = new BinNode<int>(3);
            BinNode<int> node2 = new BinNode<int>(2);
            BinNode<int> node6 = new BinNode<int>(6);
            BinNode<int> node7 = new BinNode<int>(7);
            BinNode<int> node12 = new BinNode<int>(12);
            BinNode<int> node4 = new BinNode<int>(4);
            BinNode<int> node9 = new BinNode<int>(9);

            // Constructing the tree
            root.SetLeft(node5);
            root.SetRight(node3);
            node3.SetLeft(node2);
            node3.SetRight(node6);
            node2.SetLeft(node7);
            node2.SetRight(node12);
            node6.SetLeft(node4);
            node6.SetRight(node9);

            Node<int> listHead = treetolist(root);

            PrintList(listHead);




            BinNode<int> tree1 = new BinNode<int>(5);
            tree1.SetLeft(new BinNode<int>(3));
            tree1.SetRight(new BinNode<int>(8));
            tree1.GetLeft().SetLeft(new BinNode<int>(2));
            tree1.GetLeft().SetRight(new BinNode<int>(4));
            tree1.GetRight().SetLeft(new BinNode<int>(7));
            tree1.GetRight().SetRight(new BinNode<int>(10));


            BinNode<int> tree2 = new BinNode<int>(6);
            tree2.SetLeft(new BinNode<int>(2));
            tree2.SetRight(new BinNode<int>(9));
            tree2.GetLeft().SetLeft(new BinNode<int>(1));
            tree2.GetLeft().SetRight(new BinNode<int>(4));
            tree2.GetRight().SetLeft(new BinNode<int>(8));
            tree2.GetRight().SetRight(new BinNode<int>(15));
            tree2.GetRight().GetLeft().SetLeft(new BinNode<int>(7));
            tree2.GetRight().GetLeft().SetRight(new BinNode<int>(10));
            tree2.GetRight().GetRight().SetLeft(new BinNode<int>(11));
            tree2.GetRight().GetRight().SetRight(new BinNode<int>(20));

            Queue<int> result = evenupodddown(tree1);
            while (!result.IsEmpty())
            {
                Console.Write(result.Remove() + " ");
            }
            Console.WriteLine();
            Queue<int> result2 = evenupodddown(tree2);
            while (!result2.IsEmpty())
            {
                Console.Write(result2.Remove() + " ");
            }
        }

        public static Node<int> treetolist(BinNode<int> tr)
        {
            Queue<BinNode<int>> q = new Queue<BinNode<int>>();
            Queue<BinNode<int>> temp = new Queue<BinNode<int>>();
            BinNode<int> current = null;
            Node<int> head = new Node<int>(tr.GetValue());
            Node<int> iterator = head;
            if (tr.HasLeft()) q.Insert(tr.GetLeft());
            if (tr.HasRight()) q.Insert(tr.GetRight());
            while (!q.IsEmpty())
            {
                while (!q.IsEmpty()) temp.Insert(q.Remove());
                while(!temp.IsEmpty())
                {
                    current = temp.Remove();
                    iterator.SetNext(new Node<int>(current.GetValue()));
                    iterator = iterator.GetNext();
                    if (current.HasLeft()) q.Insert(current.GetLeft());
                    if (current.HasRight()) q.Insert(current.GetRight());
                }
            }
            return head;
        }

        public static void PrintList(Node<int> head)
        {
            Node<int> current = head;
            while (current != null)
            {
                Console.Write(current.GetValue() + " -> ");
                current = current.GetNext();
            }
            Console.WriteLine("null");
        }

        public static Queue<int> evenupodddown(BinNode<int> bb)
        {
            Queue<BinNode<int>> q1 = new Queue<BinNode<int>>();
            Queue<BinNode<int>> temp = new Queue<BinNode<int>>();
            Queue<int> treetoq = new Queue<int>();
            q1.Insert(bb);
            BinNode<int> curr = null;

            while (!q1.IsEmpty())
            {
                while (!q1.IsEmpty()) temp.Insert(q1.Remove());
                while (!temp.IsEmpty())
                {
                    curr = temp.Remove();
                    treetoq.Insert(curr.GetValue());
                    if (curr.HasLeft()) q1.Insert(curr.GetLeft());
                    if (curr.HasRight()) q1.Insert(curr.GetRight());
                }
            }

            Queue<int> SortedQueue = Sort(treetoq);
            return SortedQueue;
        }


        public static Queue<int> Sort(Queue<int> q)
        {
            Queue<int> maxeven = new Queue<int>();
            Queue<int> minodd = new Queue<int>();
            Queue<int> final = new Queue<int>();

            int Nmaxeven = 0;
            int Nminodd = 0;

            while (!q.IsEmpty() && Nmaxeven != -999999)
            {
                Nmaxeven = FindMaxNum(q);
                if (Nmaxeven != -999999)
                {
                    int count = CountInstances(q, Nmaxeven);
                    for (int i = 0; i < count; i++) maxeven.Insert(Nmaxeven);
                    DelNumber(q, Nmaxeven);
                }
            }

            while (!q.IsEmpty() && Nminodd != 999999)
            {
                Nminodd = FindMinOdd(q);
                if (Nminodd != 999999)
                {
                    int count = CountInstances(q, Nminodd);
                    for (int i = 0; i < count; i++) minodd.Insert(Nminodd);
                    DelNumber(q, Nminodd);
                }
            }

            final = maxeven;
            while (!minodd.IsEmpty()) final.Insert(minodd.Remove());
            return final;
        }

        public static Queue<int> DelNumber(Queue<int> q, int num)
        {
            Queue<int> temp = new Queue<int>();
            while (!q.IsEmpty())
            {
                int val = q.Remove();
                if (val != num) temp.Insert(val);
            }
            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
            return q;
        }

        public static int FindMaxNum(Queue<int> q)
        {
            Queue<int> temp = copyQ(q);
            int max = -999999;
            while (!temp.IsEmpty())
            {
                int current = temp.Remove();
                if (current > max && current % 2 == 0) max = current;
            }
            return max;
        }

        public static int FindMinOdd(Queue<int> q)
        {
            Queue<int> temp = copyQ(q);
            int min = 999999;
            while (!temp.IsEmpty())
            {
                int current = temp.Remove();
                if (current < min && current % 2 == 1) min = current;
            }
            return min;
        }

        public static Queue<int> copyQ(Queue<int> q)
        {
            Queue<int> temp = new Queue<int>();
            Queue<int> temp2 = new Queue<int>();
            while (!q.IsEmpty())
            {
                temp.Insert(q.Head());
                temp2.Insert(q.Head());
                q.Remove();
            }
            while (!temp2.IsEmpty())
            {
                q.Insert(temp2.Head());
                temp2.Remove();
            }
            return temp;
        }

        public static int CountInstances(Queue<int> q, int instance)
        {
            int count = 0;
            Queue<int> copy = copyQ(q);
            while (!copy.IsEmpty())
            {
                if (copy.Head() == instance) { count++; }
                copy.Remove();
            }
            return count;
        }
    }
}
