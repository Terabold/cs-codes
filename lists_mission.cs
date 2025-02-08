using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp4
{
    internal class IntNode
    {
        //class + basic functions
        private int value;
        private IntNode next;

        public IntNode(int value, IntNode next)
        {
            this.value = value;
            this.next = next;
        }

        public IntNode(int value)
        {
            this.value = value;
            this.next = null;
        }

        public int GetValue()
        {
            return this.value;
        }

        public IntNode GetNext()
        {
            return this.next;
        }

        public void SetNext(IntNode next)
        {
            this.next = next;
        }

        public void SetValue(int value) { this.value = value; }

        //1
        public static IntNode build()
        {
            Console.Write($"Enter value for node 1: ");
            int value = int.Parse(Console.ReadLine());
            IntNode lst = new IntNode(value);
            IntNode pos = lst;
            for (int i = 1; i < 10; i++)
            {
                Console.Write($"Enter value for node {i + 1}: ");
                value = int.Parse(Console.ReadLine());
                pos.SetNext(new IntNode(value));
                pos = pos.GetNext();
            }
            return lst;
        }

        //2
        public static IntNode build(int len, int to, int from)
        {
            Random rnd = new Random();
            IntNode lst = new IntNode(rnd.Next(from, to + 1));
            IntNode pos = lst;
            for (int i = 1; i < len; i++)
            {
                pos.SetNext(new IntNode(rnd.Next(from, to + 1)));
                pos = pos.GetNext();
            }
            return lst;
        }

        //3
        public static IntNode build(int[] arr)
        {
            IntNode lst = new IntNode(arr[0]);
            IntNode pos = lst;
            for (int i = 1; i < arr.Length; i++)
            {
                pos.SetNext(new IntNode(arr[i]));
                pos = pos.GetNext();
            }
            return lst;
        }

        //4
        public static void Show(IntNode toShow)
        {
            if (toShow == null)
            {
                Console.WriteLine("[]");
                return;
            }

            Console.Write("[");
            IntNode pos = toShow;
            while (pos != null)
            {
                Console.Write($" {pos.GetValue()} ");
                pos = pos.GetNext();
            }
            Console.WriteLine("]");
            Console.WriteLine();
        }

        //6
        public bool exist(IntNode toExist, int number)
        {
            IntNode pos = toExist;
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

        //7
        public static IntNode getPosition(IntNode list, int value)
        {
            IntNode pos = list;
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

        //8
        public static IntNode update(IntNode list, int value1, int value2)
        {
            IntNode pos = getPosition(list, value1);
            if (pos != null)
            {
                pos.SetValue(value2);
            }
            return list;
        }

        //9
        public static IntNode getmax(IntNode lst)
        {
            if (lst == null)
            {
                return null;
            }

            IntNode pos = lst;
            IntNode maxNode = lst;
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

        //10
        public int Length(IntNode lst)
        {
            int count = 0;
            IntNode pos = lst;
            while (pos != null)
            {
                count++;
                pos = pos.GetNext();
            }
            return count;
        }

        public static IntNode Swap(IntNode lst, int p)
        {
            if (lst == null || p < 0)
            {
                return lst;
            }

            IntNode current = lst;
            IntNode previous = null;
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

            IntNode nextNode = current.GetNext();

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

        //11
        public static IntNode delete(IntNode lst, int value)
        {
            if (lst == null)
            {
                return lst;
            }

            IntNode current = lst;
            IntNode previous = null;

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

        //12
        public static IntNode delX(IntNode lst, int value)
        {
            while (lst != null && lst.GetValue() == value)
            {
                lst = delete(lst, value);
            }

            IntNode current = lst;

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

        // לא היה 13

        //14
        public static IntNode compress(IntNode lst)
        {
            if (lst == null)
            {
                return null;

            }
            IntNode current = lst;
            while (current != null && current.next != null)
            {
                if (current.GetValue() == current.GetNext().GetValue())
                {
                    current.next = current.next.next;
                }
                else
                {
                    current = current.next;
                }
            }

            return lst;
        }

        //15
        public static IntNode NoRepete(IntNode lst)
        {
            if (lst == null)
            {
                return null;
            }

            IntNode current = lst;

            while (current != null)
            {
                IntNode check = current;
                IntNode previous = current;

                while (check.GetNext() != null)
                {
                    if (check.GetNext().GetValue() == current.GetValue())
                    {
                        previous.SetNext(check.GetNext().GetNext());
                    }
                    else
                    {
                        previous = check;
                    }
                    check = check.GetNext();
                }
                current = current.GetNext();
            }
            return lst;
        }

        //20
        public static IntNode Concat(IntNode lst1, IntNode lst2)
        {
            if (lst1 == null)
            {
                return lst2;
            }
            if (lst2 == null)
            {
                return lst1;
            }

            IntNode ls3 = lst1;
            IntNode temp = ls3;

            while (temp.GetNext() != null)
            {
                temp = temp.GetNext();
            }

            temp.next = lst2;

            return ls3;
        }

        //21
        public static IntNode Concat2(IntNode lst1, IntNode lst2)
        {
            if (lst1 == null)
            {
                return lst2;
            }
            if (lst2 == null)
            {
                return lst1;
            }

            IntNode temp = lst1;

            while (temp.GetNext() != null)
            {
                temp = temp.GetNext();
            }

            temp.SetNext(lst2);
            return lst1;
        }

        //22
        public static IntNode Concat3(IntNode lst1, IntNode lst2)
        {
            if (lst1 == null)
            {
                return lst2;
            }
            if (lst2 == null)
            {
                return lst1;
            }

            IntNode temp = lst1;

            while (temp.GetNext() != null)
            {
                temp = temp.GetNext();
            }

            temp.SetNext(lst2);

            IntNode current = lst2;
            while (current != null)
            {
                IntNode nextNode = current.GetNext();
                current.SetNext(null);
                current = nextNode;
            }
            lst2 = null;
            return lst1;
        }

        //21
        public static IntNode insertSorted(IntNode lst, int value)
        {
            IntNode newNode = new IntNode(value);

            if (lst == null || value < lst.GetValue())
            {
                newNode.SetNext(lst);
                return newNode;
            }

            IntNode current = lst;
            while (current.GetNext() != null && current.GetNext().GetValue() < value)
            {
                current = current.GetNext();
            }

            newNode.SetNext(current.GetNext());
            current.SetNext(newNode);

            return lst;
        }

        public static IntNode buildSorted(int[] numbers)
        {
            IntNode lst = null;

            for (int i = 0; i < numbers.Length; i++)
            {
                lst = insertSorted(lst, numbers[i]);
            }
            return lst;
        }

        public static IntNode insertSorted(IntNode lst, string value)
        {
            IntNode newNode = new IntNode(value);

            if (lst == null || value.CompareTo(lst.GetValue()) < 0)
            {
                newNode.SetNext(lst);
                return newNode;
            }

            IntNode current = lst;
            while (current.GetNext() != null && current.GetNext().GetValue().CompareTo(value) < 0)
            {
                current = current.GetNext();
            }

            newNode.SetNext(current.GetNext());
            current.SetNext(newNode);

            return lst;
        } //assuming the node class is getting a string

        public static IntNode buildSorted(string[] names)
        {
            IntNode lst = null;

            for (int i = 0; i < names.Length; i++)
            {
                lst = insertSorted(lst, names[i]);
            }

            return lst;
        } //assuming the node class is getting a string

        //22
        public static bool isSortedString(IntNode lst)
        {
            if (lst == null || lst.GetNext() == null)
            {
                return true;
            }

            IntNode current = lst;
            while (current.GetNext() != null)
            {
                if (string.Compare(current.GetValue(), current.GetNext().GetValue()) > 0)
                {
                    return false;
                }
                current = current.GetNext();
            }
            return true;
        } //assuming the node class is getting a string

        public static bool isSorted(IntNode lst)
        {
            if (lst == null || lst.GetNext() == null)
            {
                return true;
            }

            IntNode current = lst;
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

        //23
        public static IntNode UnionWithDuplicates(IntNode first, IntNode second)
        {
            IntNode combine = null;

            while (first != null)
            {
                combine = insertSorted(combine, first.GetValue());
                first = first.GetNext();
            }

            while (second != null)
            {
                combine = insertSorted(combine, second.GetValue());
                second = second.GetNext();
            }
            return combine;
        }

        public static IntNode UnionWithoutDuplicates(IntNode first, IntNode second)
        {
            IntNode result = UnionWithDuplicates(first, second);
            IntNode finalsresult = NoRepete(result);
            return finalsresult;
        }

        //24
        public static IntNode Intersection(IntNode first, IntNode second)
        {
            if (first == null || second == null)
            {
                return null;
            }

            IntNode result = null;
            IntNode last = null;

            while (first != null && second != null)
            {
                if (first.GetValue() == second.GetValue())
                {
                    IntNode newNode = new IntNode(first.GetValue());
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

        //25
        public static IntNode UnionWithoutDuplicatesUnsorted(IntNode first, IntNode second)
        {
            IntNode combined = Concat3(first, second);

            IntNode result = NoRepete(combined);

            return result;
        }

        //26.1
        public static int CountSequences(IntNode lst)
        {
            if (lst == null)
            {
                return 0;
            }

            IntNode current = lst;
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

        //26.2
        public static int LongestSequenceLength(IntNode lst)
        {
            if (lst == null)
            {
                return 0;
            }

            IntNode current = lst;
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

        //26.3
        public static IntNode LengthSequence(IntNode lst)
        {
            if (lst == null)
            {
                return null;
            }

            IntNode lengthList = null;
            IntNode currentNode = null;
            IntNode current = lst;

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
                    IntNode newNode = new IntNode(counter);
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

        //26.4
        public static IntNode SumOfSequences(IntNode lst)
        {
            if (lst == null)
            {
                return null;
            }

            IntNode sumList = null;
            IntNode currentNode = null;
            IntNode current = lst;

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
                    IntNode newNode = new IntNode(sum);
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

        //27
        public static int MaxIncreasingSequenceLength(IntNode lst)
        {
            if (lst == null)
            {
                return 0;
            }

            int maxLength = 0;
            int currentLength = 1;
            IntNode current = lst;

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

        //26 twice????
        public int UpSequencesByConsecutive(IntNode lst)
        {
            if (lst == null)
            {
                return 0;
            }

            int maxLength = 0;
            int currentLength = 1;

            IntNode temp = lst;

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

        //28
        public static bool isSubList(IntNode list1, IntNode list2)
        {
            if (list1 == null) return true;
            if (list2 == null) return false;

            IntNode current1 = list1;
            IntNode current2 = list2;

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

        //29
        public static bool isSubListWithSequence(IntNode list1, IntNode list2)
        {
            if (list1 == null) return true;
            if (list2 == null) return false;

            IntNode current1 = list1;

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

        //30
        public static bool isListContains(IntNode list1, IntNode list2)
        {
            IntNode current1 = list1;
            while (current1 != null)
            {
                bool found = false;

                IntNode current2 = list2;
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

        internal class Program
        {
            static void Main(string[] args)
            {
                Random rnd = new Random();
                //check-quest 5
                IntNode check5_1 = build();
                IntNode check5_2 = build(5, 20, 12);
                int[] arrlist = { 1, 2, 3 };
                IntNode check5_3 = build(arrlist);
                Show(check5_1);
                Show(check5_2);
                Show(check5_3);
                Console.ReadLine();

                //check-quest 16:
                IntNode quest16 = buildrandom();
                Show(quest16);
                int numberToDelete = rnd.Next(10);
                Console.WriteLine($"Trying to delete the first: {numberToDelete}");
                quest16 = delete(quest16, numberToDelete);
                Console.WriteLine();
                Show(quest16);
                Console.ReadLine();

                //check-quest 17:
                IntNode quest17 = buildrandom();
                Show(quest17);
                Console.WriteLine($"Trying to delete every: {numberToDelete}");
                quest17 = delete(quest17, numberToDelete);
                Console.WriteLine();
                Show(quest17);
                Console.ReadLine();

                //check-quest 18:
                IntNode quest18 = buildrandom();
                Show(quest18);
                Console.WriteLine($"compressing: ");
                quest18 = compress(quest18);
                Console.WriteLine();
                Show(quest18);
                Console.ReadLine();

                //check-quest 19:
                IntNode quest19 = buildrandom();
                Show(quest19);
                Console.WriteLine($"super compressing: ");
                quest19 = NoRepete(quest19);
                Console.WriteLine();
                Show(quest19);
                Console.ReadLine();

                int[] values = { 2, 5, 1, 7, -4, 6, -1, 12, 3, 9, 11, 4, 7, -2, 11, -2 };
                IntNode list = build(values);
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
                IntNode list2 = build(number1s);
                IntNode list3 = build(number2s);
                IntNode lst = build(numbers);
                Console.WriteLine(isListContains(list3, lst));
                Console.WriteLine(isSubList(list2, lst));
                Console.WriteLine(isSubListWithSequence(list2, lst));
                Console.WriteLine(MaxIncreasingSequenceLength(lst));
                Console.ReadLine();
            }
            public static IntNode buildrandom()
            {
                Random rnd = new Random();
                IntNode lst = new IntNode(rnd.Next(0, 10));
                IntNode pos = lst;

                for (int i = 1; i < 15; i++)
                {
                    pos.SetNext(new IntNode(rnd.Next(0, 10)));
                    pos = pos.GetNext();
                }

                return lst;
            }
        }
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
