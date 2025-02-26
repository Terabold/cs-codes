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
        public static void Main(string[] args)
        {

        }

    }
    class BinaryTreeUtils
    {
        public static BinNode<int[]> CreateRandomBinaryTree(int depth)
        {
            Random rnd = new Random();
            if (depth == 0) return null;

            int size = rnd.Next(10, 31);
            int[] values = new int[size];
            for (int i = 0; i < size; i++)
                values[i] = rnd.Next(100, 5001);

            BinNode<int[]> node = new BinNode<int[]>(values);
            node.SetLeft(CreateRandomBinaryTree(depth - 1));
            node.SetRight(CreateRandomBinaryTree(depth - 1));

            return node;
        }

        public static int FindLevelWithMaxSum(BinNode<int[]> root)
        {
            if (root == null) return -1;

            Queue<BinNode<int[]>> queue = new Queue<BinNode<int[]>>();
            queue.Insert(root); 

            int level = 0;
            int maxSumLevel = 0;
            int maxSum = int.MinValue;

            while (!queue.IsEmpty())
            {
                int levelSum = 0;

                Queue<BinNode<int[]>> tempQueue = new Queue<BinNode<int[]>>();

                while (!queue.IsEmpty())
                {
                    BinNode<int[]> currentNode = queue.Remove();  
                    levelSum += currentNode.GetValue().Sum(); 

                    if (currentNode.HasLeft()) tempQueue.Insert(currentNode.GetLeft());
                    if (currentNode.HasRight()) tempQueue.Insert(currentNode.GetRight());
                }

                while (!tempQueue.IsEmpty())
                {
                    queue.Insert(tempQueue.Remove());
                }

                if (levelSum > maxSum)
                {
                    maxSum = levelSum;
                    maxSumLevel = level;
                }

                level++;
            }

            return maxSumLevel; 
        }

        public static Queue<double> AvgEachLevel(BinNode<int[]> root)
        {
            if (root == null) return null;

            Queue<BinNode<int[]>> queue = new Queue<BinNode<int[]>>();
            queue.Insert(root);
            
            Queue<double> AvgVal = new Queue<double>();

            while (!queue.IsEmpty())
            {
                int levelSum = 0;
                double countlevelnodes = 0;
                Queue<BinNode<int[]>> tempQueue = new Queue<BinNode<int[]>>();

                while (!queue.IsEmpty())
                {
                    BinNode<int[]> currentNode = queue.Remove();
                    levelSum += currentNode.GetValue().Sum();

                    if (currentNode.HasLeft()) tempQueue.Insert(currentNode.GetLeft());
                    if (currentNode.HasRight()) tempQueue.Insert(currentNode.GetRight());
                    countlevelnodes++;
                }

                while (!tempQueue.IsEmpty())
                {
                    queue.Insert(tempQueue.Remove());
                }

                AvgVal.Insert(levelSum/countlevelnodes);
            }

            return AvgVal;
        }

        public static bool SameStartEnd(BinNode<string> root)
        {
            if (root == null) return false;
            if (root.GetValue()[0] == root.GetValue()[root.GetValue().Length -1]) return true;
            return SameStartEnd(root.GetLeft()) || SameStartEnd(root.GetRight());
        }

        public static string FindLongestNode(BinNode<string> root)
        {
            if (root == null) return "";

            string longest = root.GetValue();
            string leftLongest = FindLongestNode(root.GetLeft());
            string rightLongest = FindLongestNode(root.GetRight());

            if (leftLongest.Length > longest.Length)
                longest = leftLongest;
            if (rightLongest.Length > longest.Length)
                longest = rightLongest;

            return longest;
        }

        public static Queue<char> FindQueueWithSameStartEnd(BinNode<Queue<char>> root)
        {
            if (root == null) return null;

            if (IsSameStartEnd(root.GetValue()))
            {
                return root.GetValue(); 
            }

            if (root.HasLeft())
            {
            Queue<char> leftResult = FindQueueWithSameStartEnd(root.GetLeft());
                return leftResult;
            }
            if (root.HasRight())
            {
            Queue<char> rightResult = FindQueueWithSameStartEnd(root.GetRight());
                return rightResult; 
            }
            return null;
        }

        public static bool IsSameStartEnd(Queue<char> queue)
        {
            if (queue.IsEmpty()) return false;
            Queue<char> copy = copyqueue(queue);

            char first = copy.Remove();
            if (copy.IsEmpty()) return true;

            char last = '\0';
            while (!copy.IsEmpty())
            {
                last = copy.Remove();
            }

            return first == last;
        }

        public static Queue<T> copyqueue<T>(Queue<T> queue)
        {
            Queue<T> temp = new Queue<T>();
            Queue<T> temp2 = new Queue<T>();
            while (!queue.IsEmpty())
            {
                temp.Insert(queue.Head());
                temp2.Insert(queue.Head());
                queue.Remove();
            }
            while (!temp2.IsEmpty())
            {
                queue.Insert(temp2.Head());
                temp2.Remove();
            }
            return temp;
        }
    }
}

