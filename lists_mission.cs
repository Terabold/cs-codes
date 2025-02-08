using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            //check-quest 5
            Node<int> check5_1 = Build();
            Node<int> check5_2 = Build(5, 20, 12);
            int[] arrlist = { 1, 2, 3 };
            Node<int> check5_3 = Build(arrlist);
            Show(check5_1);
            Show(check5_2);
            Show(check5_3);
            Console.ReadLine();

            //check-quest 16:
            Node<int> quest16 = BuildRandom();
            Show(quest16);
            int numberToDelete = rnd.Next(10);
            Console.WriteLine($"Trying to delete the first: {numberToDelete}");
            quest16 = Delete(quest16, numberToDelete);
            Console.WriteLine();
            Show(quest16);
            Console.ReadLine();

            //check-quest 17:
            Node<int> quest17 = BuildRandom();
            Show(quest17);
            Console.WriteLine($"Trying to delete every: {numberToDelete}");
            quest17 = Delete(quest17, numberToDelete);
            Console.WriteLine();
            Show(quest17);
            Console.ReadLine();

            //check-quest 18:
            Node<int> quest18 = BuildRandom();
            Show(quest18);
            Console.WriteLine($"compressing: ");
            quest18 = Compress(quest18);
            Console.WriteLine();
            Show(quest18);
            Console.ReadLine();

            //check-quest 19:
            Node<int> quest19 = BuildRandom();
            Show(quest19);
            Console.WriteLine($"super compressing: ");
            quest19 = NoRepete(quest19);
            Console.WriteLine();
            Show(quest19);
            Console.ReadLine();

            int[] values = { 2, 5, 1, 7, -4, 6, -1, 12, 3, 9, 11, 4, 7, -2, 11, -2 };
            Node<int> list = Build(values);
            Show(list);
            Console.WriteLine(CountSequences(list));
            Console.WriteLine();
            Console.WriteLine(LongestSequenceLength(list));
            Console.WriteLine();
            Show(LengthSequence(list));
            Show(SumOfSequences(list));
            Console.ReadLine();

            int[] numbers = { 2, 5, 7, 8, -3, -1, 0, 2, 4, 6, 5, 5, 6, 7, 12 };
            int[] number1s = { 2, 5, 7, 8, -3, -1, 0, 2 };
            int[] number2s = { 2, 8, 5, 7, -1, 0, 2, -3 };
            Node<int> list2 = Build(number1s);
            Node<int> list3 = Build(number2s);
            Node<int> lst = Build(numbers);
            Console.WriteLine(IsListContains(list3, lst));
            Console.WriteLine(IsSubList(list2, lst));
            Console.WriteLine(IsSubListWithSequence(list2, lst));
            Console.WriteLine(MaxIncreasingSequenceLength(lst));
            Console.ReadLine();
        }

        public static Node<int> BuildRandom()
        {
            Random rnd = new Random();
            Node<int> lst = new Node<int>(rnd.Next(0, 10));
            Node<int> pos = lst;

            for (int i = 1; i < 15; i++)
            {
                pos.SetNext(new Node<int>(rnd.Next(0, 10)));
                pos = pos.GetNext();
            }

            return lst;
        }

        public static Node<int> Build()
        {
            Console.Write($"Enter value for node 1: ");
            int value = int.Parse(Console.ReadLine());
            Node<int> lst = new Node<int>(value);
            Node<int> pos = lst;
            for (int i = 1; i < 10; i++)
            {
                Console.Write($"Enter value for node {i + 1}: ");
                value = int.Parse(Console.ReadLine());
                pos.SetNext(new Node<int>(value));
                pos = pos.GetNext();
            }
            return lst;
        }

        public static Node<int> Build(int len, int to, int from)
        {
            Random rnd = new Random();
            Node<int> lst = new Node<int>(rnd.Next(from, to + 1));
            Node<int> pos = lst;
            for (int i = 1; i < len; i++)
            {
                pos.SetNext(new Node<int>(rnd.Next(from, to + 1)));
                pos = pos.GetNext();
            }
            return lst;
        }

        public static Node<int> Build(int[] arr)
        {
            Node<int> lst = new Node<int>(arr[0]);
            Node<int> pos = lst;
            for (int i = 1; i < arr.Length; i++)
            {
                pos.SetNext(new Node<int>(arr[i]));
                pos = pos.GetNext();
            }
            return lst;
        }

        public static void Show(Node<int> toShow)
        {
            if (toShow == null)
            {
                Console.WriteLine("[]");
                return;
            }

            Console.Write("[");
            Node<int> pos = toShow;
            while (pos != null)
            {
                Console.Write($" {pos.GetValue()} ");
                pos = pos.GetNext();
            }
            Console.WriteLine("]");
            Console.WriteLine();
        }

        public static bool Exist(Node<int> toExist, int number)
        {
            Node<int> pos = toExist;
            while (pos != null)
            {
                if (number == pos.GetValue())
                {
                    return true;
                }
                pos = pos.GetNext();
            }
            return false;
        }

        public static Node<int> GetPosition(Node<int> list, int value)
        {
            Node<int> pos = list;
            while (pos != null)
            {
                if (value == pos.GetValue())
                {
                    return pos;
                }
                pos = pos.GetNext();
            }
            return null;
        }

        public static Node<int> Update(Node<int> list, int value1, int value2)
        {
            Node<int> pos = GetPosition(list, value1);
            if (pos != null)
            {
                pos.SetValue(value2);
            }
            return list;
        }

        public static Node<int> GetMax(Node<int> lst)
        {
            if (lst == null)
            {
                return null;
            }

            Node<int> pos = lst;
            Node<int> maxNode = lst;
            int max = int.MinValue;
            while (pos != null)
            {
                if (pos.GetValue() > max) { max = pos.GetValue(); }
                pos = pos.GetNext();
            }
            while (pos != null)
            {
                if (pos.GetValue() > max)
                {
                    max = pos.GetValue();
                    maxNode = pos;
                }
                pos = pos.GetNext();
            }
            return maxNode;
        }

        public static int Length(Node<int> lst)
        {
            int count = 0;
            Node<int> pos = lst;
            while (pos != null)
            {
                count++;
                pos = pos.GetNext();
            }
            return count;
        }

        public static Node<int> Swap(Node<int> lst, int p)
        {
            if (lst == null || p < 0)
            {
                return lst;
            }

            Node<int> current = lst;
            Node<int> previous = null;
            int index = 0;

            while (current != null && index < p)
            {
                previous = current;
                current = current.GetNext();
                index++;
            }

            if (current == null || current.GetNext() == null)
            {
                return lst;
            }

            Node<int> nextNode = current.GetNext();

            if (previous == null)
            {
                lst = nextNode;
            }
            else
            {
                previous.SetNext(nextNode);
            }

            current.SetNext(nextNode.GetNext());
            nextNode.SetNext(current);

            return lst;
        }

        public static Node<int> Delete(Node<int> lst, int value)
        {
            if (lst == null)
            {
                return lst;
            }

            Node<int> current = lst;
            Node<int> previous = null;

            while (current != null && current.GetValue() != value)
            {
                previous = current;
                current = current.GetNext();
            }

            if (current != null)
            {
                if (previous == null)
                {
                    lst = current.GetNext();
                }
                else
                {
                    previous.SetNext(current.GetNext());
                }
            }
            return lst;
        }

        public static Node<int> DelX(Node<int> lst, int value)
        {
            while (lst != null && lst.GetValue() == value)
            {
                lst = Delete(lst, value);
            }

            Node<int> current = lst;

            while (current != null && current.GetNext() != null)
            {
                if (current.GetNext().GetValue() == value)
                {
                    current.SetNext(current.GetNext().GetNext());
                }
                else
                {
                    current = current.GetNext();
                }
            }

            return lst;
        }

        public static Node<int> Compress(Node<int> lst)
        {
            if (lst == null)
            {
                return null;
            }
            Node<int> current = lst;
            while (current != null && current.GetNext() != null)
            {
                if (current.GetValue() == current.GetNext().GetValue())
                {
                    current.SetNext(current.GetNext().GetNext());
                }
                else
                {
                    current = current.GetNext();
                }
            }

            return lst;
        }

        public static Node<int> NoRepete(Node<int> lst)
        {
            if (lst == null)
            {
                return null;
            }

            Node<int> current = lst;

            while (current != null && current.GetNext() != null)
            {
                Node<int> check = current;

                while (check.GetNext() != null)
                {
                    if (check.GetNext().GetValue() == current.GetValue())
                    {
                        // Remove the duplicate node
                        check.SetNext(check.GetNext().GetNext());
                    }
                    else
                    {
                        // Move to the next node
                        check = check.GetNext();
                    }
                }

                // Move to the next node to check for duplicates
                current = current.GetNext();
            }

            return lst;
        }

        public static Node<int> Concat(Node<int> lst1, Node<int> lst2)
        {
            if (lst1 == null)
            {
                return lst2;
            }
            if (lst2 == null)
            {
                return lst1;
            }

            Node<int> ls3 = lst1;
            Node<int> temp = ls3;

            while (temp.GetNext() != null)
            {
                temp = temp.GetNext();
            }

            temp.SetNext(lst2);

            return ls3;
        }

        public static Node<int> Concat2(Node<int> lst1, Node<int> lst2)
        {
            if (lst1 == null)
            {
                return lst2;
            }
            if (lst2 == null)
            {
                return lst1;
            }

            Node<int> temp = lst1;

            while (temp.GetNext() != null)
            {
                temp = temp.GetNext();
            }

            temp.SetNext(lst2);
            return lst1;
        }

        public static Node<int> Concat3(Node<int> lst1, Node<int> lst2)
        {
            if (lst1 == null)
            {
                return lst2;
            }
            if (lst2 == null)
            {
                return lst1;
            }

            Node<int> temp = lst1;

            while (temp.GetNext() != null)
            {
                temp = temp.GetNext();
            }

            temp.SetNext(lst2);

            Node<int> current = lst2;
            while (current != null)
            {
                Node<int> nextNode = current.GetNext();
                current.SetNext(null);
                current = nextNode;
            }
            lst2 = null;
            return lst1;
        }

        public static Node<int> InsertSorted(Node<int> lst, int value)
        {
            Node<int> newNode = new Node<int>(value);

            if (lst == null || value < lst.GetValue())
            {
                newNode.SetNext(lst);
                return newNode;
            }

            Node<int> current = lst;
            while (current.GetNext() != null && current.GetNext().GetValue() < value)
            {
                current = current.GetNext();
            }

            newNode.SetNext(current.GetNext());
            current.SetNext(newNode);

            return lst;
        }

        public static Node<int> BuildSorted(int[] numbers)
        {
            Node<int> lst = null;

            for (int i = 0; i < numbers.Length; i++)
            {
                lst = InsertSorted(lst, numbers[i]);
            }
            return lst;
        }

        public static bool IsSorted(Node<int> lst)
        {
            if (lst == null || lst.GetNext() == null)
            {
                return true;
            }

            Node<int> current = lst;
            while (current.GetNext() != null)
            {
                if (current.GetValue() > current.GetNext().GetValue())
                {
                    return false;
                }
                current = current.GetNext();
            }
            return true;
        }

        public static Node<int> UnionWithDuplicates(Node<int> first, Node<int> second)
        {
            Node<int> combine = null;

            while (first != null)
            {
                combine = InsertSorted(combine, first.GetValue());
                first = first.GetNext();
            }

            while (second != null)
            {
                combine = InsertSorted(combine, second.GetValue());
                second = second.GetNext();
            }
            return combine;
        }

        public static Node<int> UnionWithoutDuplicates(Node<int> first, Node<int> second)
        {
            Node<int> result = UnionWithDuplicates(first, second);
            Node<int> finalsresult = NoRepete(result);
            return finalsresult;
        }

        public static Node<int> Intersection(Node<int> first, Node<int> second)
        {
            if (first == null || second == null)
            {
                return null;
            }

            Node<int> result = null;
            Node<int> last = null;

            while (first != null && second != null)
            {
                if (first.GetValue() == second.GetValue())
                {
                    Node<int> newNode = new Node<int>(first.GetValue());
                    if (result == null)
                    {
                        result = newNode;
                        last = result;
                    }
                    else
                    {
                        last.SetNext(newNode);
                        last = newNode;
                    }
                    first = first.GetNext();
                    second = second.GetNext();
                }
                else if (first.GetValue() < second.GetValue())
                {
                    first = first.GetNext();
                }
                else
                {
                    second = second.GetNext();
                }
            }
            return result;
        }

        public static Node<int> UnionWithoutDuplicatesUnsorted(Node<int> first, Node<int> second)
        {
            Node<int> combined = Concat3(first, second);

            Node<int> result = NoRepete(combined);

            return result;
        }

        public static int CountSequences(Node<int> lst)
        {
            if (lst == null)
            {
                return 0;
            }

            Node<int> current = lst;
            int sequenceCount = 0;

            while (current != null)
            {
                if (current.GetValue() < 0)
                {
                    sequenceCount++;
                }
                current = current.GetNext();
            }

            return sequenceCount;
        }

        public static int LongestSequenceLength(Node<int> lst)
        {
            if (lst == null)
            {
                return 0;
            }

            Node<int> current = lst;
            int maxLength = 0;
            int currentLength = 0;

            while (current != null)
            {
                if (current.GetValue() >= 0)
                {
                    currentLength++;
                }
                else
                {
                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }
                    currentLength = 0;
                }
                current = current.GetNext();
            }

            if (currentLength > maxLength)
            {
                maxLength = currentLength;
            }

            return maxLength;
        }

        public static Node<int> LengthSequence(Node<int> lst)
        {
            if (lst == null)
            {
                return null;
            }

            Node<int> lengthList = null;
            Node<int> currentNode = null;
            Node<int> current = lst;

            while (current != null)
            {
                int counter = 0;

                while (current != null && current.GetValue() > 0)
                {
                    counter++;
                    current = current.GetNext();
                }

                if (counter > 0)
                {
                    Node<int> newNode = new Node<int>(counter);
                    if (lengthList == null)
                    {
                        lengthList = newNode;
                        currentNode = newNode;
                    }
                    else
                    {
                        currentNode.SetNext(newNode);
                        currentNode = newNode;
                    }
                }

                while (current != null && current.GetValue() <= 0)
                {
                    current = current.GetNext();
                }
            }

            return lengthList;
        }

        public static Node<int> SumOfSequences(Node<int> lst)
        {
            if (lst == null)
            {
                return null;
            }

            Node<int> sumList = null;
            Node<int> currentNode = null;
            Node<int> current = lst;

            while (current != null)
            {
                int sum = 0;

                while (current != null && current.GetValue() > 0)
                {
                    sum += current.GetValue();
                    current = current.GetNext();
                }

                if (sum > 0)
                {
                    Node<int> newNode = new Node<int>(sum);
                    if (sumList == null)
                    {
                        sumList = newNode;
                        currentNode = newNode;
                    }
                    else
                    {
                        currentNode.SetNext(newNode);
                        currentNode = newNode;
                    }
                }

                while (current != null && current.GetValue() <= 0)
                {
                    current = current.GetNext();
                }
            }

            return sumList;
        }

        public static int MaxIncreasingSequenceLength(Node<int> lst)
        {
            if (lst == null)
            {
                return 0;
            }

            int maxLength = 0;
            int currentLength = 1;
            Node<int> current = lst;

            while (current.GetNext() != null)
            {
                if (current.GetValue() < current.GetNext().GetValue())
                {
                    currentLength++;
                }
                else
                {
                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }
                    currentLength = 1;
                }
                current = current.GetNext();
            }

            if (currentLength > maxLength)
            {
                maxLength = currentLength;
            }
            return maxLength;
        }

        public static int UpSequencesByConsecutive(Node<int> lst)
        {
            if (lst == null)
            {
                return 0;
            }

            int maxLength = 0;
            int currentLength = 1;

            Node<int> temp = lst;

            while (temp != null && temp.GetNext() != null)
            {
                if (temp.GetValue() == temp.GetNext().GetValue() - 1)
                {
                    currentLength++;
                }
                else
                {
                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }
                    currentLength = 1;
                }
                temp = temp.GetNext();
            }

            if (currentLength > maxLength)
            {
                maxLength = currentLength;
            }

            return maxLength;
        }

        public static bool IsSubList(Node<int> list1, Node<int> list2)
        {
            if (list1 == null) return true;
            if (list2 == null) return false;

            Node<int> current1 = list1;
            Node<int> current2 = list2;

            while (current2 != null)
            {
                if (current2.GetValue() == current1.GetValue())
                {
                    current1 = current1.GetNext();
                    if (current1 == null)
                        return true;
                }
                current2 = current2.GetNext();
            }
            return false;
        }

        public static bool IsSubListWithSequence(Node<int> list1, Node<int> list2)
        {
            if (list1 == null) return true;
            if (list2 == null) return false;

            Node<int> current1 = list1;

            while (list2 != null)
            {
                if (list2.GetValue() == current1.GetValue())
                {
                    current1 = current1.GetNext();
                    if (current1 == null)
                        return true;
                }
                else
                {
                    current1 = list1;
                }
                list2 = list2.GetNext();
            }
            return false;
        }

        public static bool IsListContains(Node<int> list1, Node<int> list2)
        {
            Node<int> current1 = list1;
            while (current1 != null)
            {
                bool found = false;

                Node<int> current2 = list2;
                while (current2 != null)
                {
                    if (current1.GetValue() == current2.GetValue())
                    {
                        found = true;
                        break;
                    }
                    current2 = current2.GetNext();
                }

                if (!found)
                {
                    return false;
                }

                current1 = current1.GetNext();
            }

            return true;
        }



        //27 second??????
        public class CharNode
        {
            private char value;
            private CharNode next;

            public CharNode(char value)
            {
                this.value = value;
                this.next = null;
            }

            public char GetValue() { return value; }
            public CharNode GetNext() { return next; }
            public void SetNext(CharNode next) { this.next = next; }
            public CharNode LongestWord(CharNode lst)
            {
                CharNode current = lst;
                CharNode longestWordHead = null;
                CharNode longestWordTail = null;
                int longestLength = 0;

                while (current != null)
                {
                    CharNode temp = current;
                    int length = 0;

                    while (temp != null && temp.GetValue() != '*')
                    {
                        length++;
                        temp = temp.GetNext();
                    }

                    if (temp != null && temp.GetValue() == '*')
                    {
                        length++;
                    }

                    if (length > longestLength)
                    {
                        longestLength = length;
                        longestWordHead = current;
                        longestWordTail = temp;
                    }

                    if (temp != null)
                    {
                        current = temp.GetNext();
                    }
                    else
                    {
                        current = null;
                    }
                }

                return longestWordHead;
            }
        }
    }
}
