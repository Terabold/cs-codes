using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Unit4.BinTreeUtilsLib;
using Unit4.CollectionsLib;
using Unit4.BinTreeCanvasLib;

namespace ConsoleApp32
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BinNode<string> head = new BinNode<string>("ariel");
            //BinNode<string> n1 = new BinNode<string>("asd");
            //BinNode<string> n2 = new BinNode<string>("ariel");
            //BinNode<string> n3 = new BinNode<string>("asfe");
            //BinNode<string> n4 = new BinNode<string>("sadfghjk");
            //BinNode<string> n5 = new BinNode<string>("as");
            //BinNode<string> n6 = new BinNode<string>("a");

            //n2.SetLeft(n5);
            //n2.SetRight(n6);

            //n1.SetLeft(n3);
            //n1.SetRight(n4);

            //head.SetLeft(n1);
            //head.SetRight(n2);

            //PrintTree(head);
            // PrintTree(lengthtree(head));

            //BinNode<int> head2 = new BinNode<int>(1);
            //BinNode<int> b1 = new BinNode<int>(2);
            //BinNode<int> b2 = new BinNode<int>(3);
            //BinNode<int> b3 = new BinNode<int>(4);
            //BinNode<int> b4 = new BinNode<int>(5);
            //BinNode<int> b5 = new BinNode<int>(6);
            //BinNode<int> b6 = new BinNode<int>(7);
            //BinNode<int> b7 = new BinNode<int>(8);
            //BinNode<int> b8 = new BinNode<int>(9);
            //BinNode<int> b9 = new BinNode<int>(10);

            //head2.SetLeft(b1);
            //head2.SetRight(b2);

            //b1.SetLeft(b3);
            //b1.SetRight(b4);

            //b2.SetLeft(b5);
            //b2.SetRight(b6);

            //b6.SetLeft(b9);

            //b4.SetRight(b8);

            //b3.SetLeft(b7);

            //Console.WriteLine("TREE");
            //Queue<BinNode<int>> q = new Queue<BinNode<int>>();
            //q.Insert(head2);
            //BinNode<int> temp;
            //while (!q.IsEmpty())
            //{
            //    temp = q.Remove();
            //    Console.WriteLine(temp.GetValue());
            //    if (temp.HasLeft()) { q.Insert(temp.GetLeft()); }
            //    if (temp.HasRight()) { q.Insert(temp.GetRight()); }
            //}
            //Console.WriteLine("LEAVES COUNT");
            //Console.WriteLine(CountLeaves(head2));
            //Console.WriteLine("SUM LEAVES");
            //Console.WriteLine(SumLeaves(head2));
            //Console.WriteLine("SUM tree");
            //Console.WriteLine(SumTree(head2));

            //BinNode<int> head = new BinNode<int>(10);

            //BinNode<int> n1 = new BinNode<int>(5);
            //BinNode<int> n2 = new BinNode<int>(20);
            //BinNode<int> n3 = new BinNode<int>(3);
            //BinNode<int> n4 = new BinNode<int>(7);
            //BinNode<int> n5 = new BinNode<int>(15);
            //BinNode<int> n6 = new BinNode<int>(25);

            //n2.SetLeft(n5);
            //n2.SetRight(n6);

            //n1.SetLeft(n3);
            //n1.SetRight(n4);

            //head.SetLeft(n1);
            //head.SetRight(n2);

            //PrintTree(head);
            //Console.WriteLine(sod(head));

            //BinNode<int> root = new BinNode<int>(1);
            //BinNode<int> n1 = new BinNode<int>(2);
            //BinNode<int> n2 = new BinNode<int>(3);
            //BinNode<int> n3 = new BinNode<int>(4);
            //BinNode<int> n4 = new BinNode<int>(5);
            //BinNode<int> n5 = new BinNode<int>(6);
            //BinNode<int> n6 = new BinNode<int>(7);

            //// Build the tree structure
            //root.SetLeft(n1);
            //root.SetRight(n2);

            //n1.SetLeft(n3);
            //n1.SetRight(n4);

            //n2.SetLeft(n5);
            //n2.SetRight(n6);

            //// Test the function
            //Console.WriteLine("is all child:");
            //Console.WriteLine(is2childsalltree(root));


            BinNode<int> head = new BinNode<int>(1);
            BinNode<int> n1 = new BinNode<int>(1);
            BinNode<int> n2 = new BinNode<int>(1);
            BinNode<int> n3 = new BinNode<int>(1);
            BinNode<int> n4 = new BinNode<int>(1);
            BinNode<int> n5 = new BinNode<int>(2);
            BinNode<int> n6 = new BinNode<int>(3);

            head.SetLeft(n1);
            head.SetRight(n5);

            n1.SetLeft(n2);
            n1.SetRight(n3);

            n2.SetLeft(n4);
            n3.SetRight(n6);

            Console.WriteLine("is path = 1 only");
            Console.WriteLine(IsPath1(head));
            TreeCanvas.AddTree(head);
            TreeCanvas.TreeDrawPostOrder();
            Console.ReadLine();

        }
        public static void PrintTree<T>(BinNode<T> node, string indent = "", bool isLeft = true)
        {
            if (node == null) return;

            Console.WriteLine(indent + (isLeft ? "├── " : "└── ") + node.GetValue());

            if (node.GetLeft() != null)
            {
                PrintTree(node.GetLeft(), indent + (isLeft ? "│   " : "    "), true);
            }

            if (node.GetRight() != null)
            {
                PrintTree(node.GetRight(), indent + (isLeft ? "│   " : "    "), false);
            }
        }

        public static BinNode<int> TreeLength(BinNode<string> tree)
        {
            if (tree == null) return null;
            BinNode<int> currentNode = new BinNode<int>(tree.GetValue().Length);
            if (tree.GetLeft() != null)
            {
                currentNode.SetLeft(TreeLength(tree.GetLeft()));
            }
            if (tree.GetRight() != null)
            {
                currentNode.SetRight(TreeLength(tree.GetRight()));
            }
            return currentNode;
        }

        public static bool sod(BinNode<int> tr)
        {
            if (tr == null) return false;
            if (tr.GetLeft() == tr.GetRight()) return true;
            return sod(tr.GetLeft(), tr.GetValue()) || sod(tr.GetRight(), tr.GetValue());
        }
        public static bool sod(BinNode<int> tr, int x)
        {
            if (tr == null) return false;
            if (tr.GetValue() <= x) return false;
            if (!tr.HasLeft() && !tr.HasRight()) return true;
            return sod(tr.GetLeft(), tr.GetValue()) || sod(tr.GetRight(), tr.GetValue());
        }

        //q1
        public static bool IsLeaf(BinNode<int> cell)
        {
            return cell != null && !cell.HasLeft() && !cell.HasRight();
        }
        public static int CountLeaves(BinNode<int> tr)
        {
            return CountLeaves(tr, 0);
        }

        //q2
        public static int CountLeaves(BinNode<int> tr, int count)
        {
            if (tr == null) { return count; }
            if (IsLeaf(tr)) { count++; }
            if (tr.GetLeft() != null)
            {
                count = CountLeaves(tr.GetLeft(), count);
            }
            if (tr.GetRight() != null)
            {
                count = CountLeaves(tr.GetRight(), count);
            }
            return count;
        }
        public static int CountLeavesGPT(BinNode<int> tr)
        {
            if (tr == null) return 0;

            int count = 0;

            if (IsLeaf(tr))
            {
                count++;
            }

            count += CountLeavesGPT(tr.GetLeft());
            count += CountLeavesGPT(tr.GetRight());

            return count;
        }

        //q3
        public static int SumLeaves(BinNode<int> tr)
        {
            return SumLeaves(tr, 0);
        }
        public static int SumLeaves(BinNode<int> tr, int sum)
        {
            if (tr == null) { return sum; }
            if (IsLeaf(tr)) { sum += tr.GetValue(); }
            if (tr.GetLeft() != null)
            {
                sum = SumLeaves(tr.GetLeft(), sum);
            }
            if (tr.GetRight() != null)
            {
                sum = SumLeaves(tr.GetRight(), sum);
            }
            return sum;
        }
        public static int SumLeavesGPT(BinNode<int> tr)
        {
            if (tr == null) return 0;

            int sum = 0;

            if (IsLeaf(tr))
            {
                sum += tr.GetValue();
            }

            sum += SumLeavesGPT(tr.GetLeft());
            sum += SumLeavesGPT(tr.GetRight());

            return sum;
        }

        //q4
        public static int SumTree(BinNode<int> tree)
        {
            if (tree == null) return 0;
            int val = tree.GetValue();
            if (tree.GetLeft() != null)
            {
                val += SumTree(tree.GetLeft());
            }
            if (tree.GetRight() != null)
            {
                val += SumTree(tree.GetRight());
            }
            return val;
        }

        //q5
        public static bool IsPath1(BinNode<int> tr)
        {
            if (tr == null) { return false; }
            if (tr.GetValue() != 1) { return false; }

            if (tr.GetLeft() == null && tr.GetRight() == null) { return true; }

            return IsPath1(tr.GetLeft()) || IsPath1(tr.GetRight());
        }

        //q6
        public static bool is2childsalltree(BinNode<int> tr)
        {
            if (tr == null) { return true; }

            if (!tr.HasLeft() && !tr.HasRight()) { return true; }

            if (!tr.HasLeft() || !tr.HasRight()) { return false; }

            return is2childsalltree(tr.GetLeft()) && is2childsalltree(tr.GetRight());
        }

        //get tree line by line
        public static void BFS(BinNode<int> bt)
        {
            Queue<BinNode<int>> qu = new Queue<BinNode<int>>();
            BinNode<int> curr;
            qu.Insert(bt);

            while (!qu.IsEmpty())
            {
                curr = qu.Remove();
                Console.WriteLine(curr.GetValue());
                if (curr.HasLeft()) qu.Insert(curr.GetLeft());
                if (curr.HasRight()) qu.Insert(curr.GetRight());
            }
        }

        public static void DFS(BinNode<int> bt)
        {
            if (bt == null)
                return;

            Console.WriteLine(bt.GetValue()); // Visit the node
            if (bt.HasLeft()) DFS(bt.GetLeft()); // Recur on left subtree
            if (bt.HasRight()) DFS(bt.GetRight()); // Recur on right subtree
        }
    }
}