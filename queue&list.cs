using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;

namespace ConsoleApp32
{
    internal class Lists_Queues
    {
        static void Main(string[] args)
        {
            Node<int> node3 = new Node<int>(7, null);
            Node<int> node2 = new Node<int>(18045001, node3);


            Queue<int> mulnums = new Queue<int>();

            bool result = AddNodes(node2, mulnums);
            Console.WriteLine(mulnums.ToString());
        }

        static bool isPrime(int num)
        {
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    return false;

                }
            }
            return true;
        }

        public static int lcd(int number)
        {
            if (number % 2 == 0) return 2;
            int sqrt = (int)Math.Sqrt(number);
            for (int dividor = 3; dividor <= sqrt; dividor += 2)
            {
                if (number % dividor == 0)
                {
                    return dividor;
                }
            }
            return number;
        }

        public static bool AddNodes(Node<int> n, Queue<int> mulNums)
        {
            Node<int> pos = n;
            while (pos.HasNext())
            {
                int number = pos.GetValue();
                if (isPrime(number))
                {
                    return false;
                }
                else
                {
                    int dividor = lcd(number);
                    mulNums.Insert(dividor);
                    mulNums.Insert(number / dividor);
                }
                pos = pos.GetNext();
            }
            return true;
        }
        public static int finddirectionchangeindex(Node<int> temp)
        {
            int index = 0;
            if (temp.GetValue() > temp.GetNext().GetValue())
            {
                while (temp.HasNext() && temp.GetValue() > temp.GetNext().GetValue())
                {
                    index++;
                    temp = temp.GetNext();
                }
            }
            else
            {
                while (temp.HasNext() && temp.GetValue() < temp.GetNext().GetValue())
                {
                    index++;
                    temp = temp.GetNext();
                }
            }
            return index;
        }
        public static void changedirection(Node<int> lst)
        {
            while (lst.HasNext())
            {
                int index = finddirectionchangeindex(lst);

                for (int i = 0; i < index; i++)
                {
                    lst = lst.GetNext();
                }

                if (lst.HasNext() && lst.GetValue() != lst.GetNext().GetValue())
                {
                    int number = lst.GetValue();

                    Node<int> insert = new Node<int>(number);

                    insert.SetNext(lst.GetNext());
                    lst.SetNext(insert);

                    lst = insert.GetNext();
                }
                else
                {
                    lst = lst.GetNext();
                }
            }
        }

    }
}
