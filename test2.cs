using System;
using System.CodeDom.Compiler;
using System.ComponentModel.Design.Serialization;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Unit4.CollectionsLib;

namespace Roeeov
{
    internal class Program
    {
        // main function

        static void Main(string[] args)
        {

            // 1 א
            Node<Cage> cages = Utils.buildNode(new Cage[]
            {
                new Cage("monkey", 3),
                new Cage("crocodile", 3),
                new Cage("monkey", 5),
                new Cage("bird", 3),
                new Cage("bird", 2),
                new Cage("crocodile", 2)
            });
            cages = joinCages(cages);
            Utils.printNode(cages);

            // 1 ג
            cages = Utils.buildNode(new Cage[]
            {
                new Cage("monkey", 3),
                new Cage("crocodile", 3),
                new Cage("monkey", 5),
                new Cage("bird", 3),
                new Cage("bird", 2),
                new Cage("crocodile", 2)
            });
            addDifferent(cages);
            Utils.printNode(cages);

            // 2
            Queue<int> qq = Utils.buildQueue(new int[]
            {
                3, 4, 5, 12, 19, 20, 100, 101, 102, 103, 104
            });
            Console.WriteLine(ranges(qq));

            //5
            Queue<int> Que = Utils.buildQueue(new int[]
            {
                5, 8, 2, -3, 10, 7, 20, 4
            });
            Console.WriteLine(sumQue(Que));

        }




        // my answers functions

        // 1 א
        public static Node<Cage> joinCages(Node<Cage> lst)
        {
            lst = new Node<Cage>(null, lst); // create dummy for original list
            Node<Cage> lstpos; // create iterator for original list
            Node<Cage> res = new Node<Cage>(null); // create dummy for result list
            Node<Cage> respos = res; // create iterator for result 
            while (lst.HasNext())
            {
                string animal = lst.GetNext().GetValue().GetName(); // animal to search
                lstpos = lst; // reset original list iterator
                while (lstpos.HasNext())
                {
                    if (lstpos.GetNext().GetValue().GetName() == animal)
                    {
                        respos.SetNext(lstpos.GetNext());
                        lstpos.SetNext(lstpos.GetNext().GetNext());
                        respos = respos.GetNext();
                    }
                    else lstpos = lstpos.GetNext();
                }
            }
            return res.GetNext();
        }


        // 1 ג
        public static void addDifferent(Node<Cage> lst)
        {
            lst = new Node<Cage>(null, lst);
            Node<Cage> pos = lst;
            Queue<string> animals = new Queue<string>();
            animals.Insert("stop");
            int count = 0;
            while (pos.HasNext())
            {
                string animal = pos.GetNext().GetValue().GetName();
                bool found = false;
                while (animals.Head() != "stop")
                {
                    if (animals.Head() == animal) found = true;
                    animals.Insert(animals.Remove());
                }
                if (!found)
                {
                    count++;
                    animals.Insert(animal);
                }
                animals.Insert(animals.Remove());
                pos = pos.GetNext();
            }
            Cage diff = new Cage("different", count);
            pos.SetNext(new Node<Cage>(diff));
        }


        // 2
        public static Queue<RangeQueue> ranges(Queue<int> qu)
        {
            Queue<int> temp = new Queue<int>();
            Queue<RangeQueue> res = new Queue<RangeQueue>();
            while (!qu.IsEmpty())
            {
                int from = qu.Head();
                int to = from;
                temp.Insert(qu.Remove());
                while (!qu.IsEmpty() && qu.Head() == 1 + to)
                {
                    to++;
                    temp.Insert(qu.Remove());
                }
                RangeQueue range = new RangeQueue(from, to);
                res.Insert(range);
            }
            while (!temp.IsEmpty()) qu.Insert(temp.Remove());
            return res;
        }


        // 5
        public static Queue<T> copyqueue<T>(Queue<T> qu) //returns a copy of the queue
        {
            Queue<T> copy = new Queue<T>();
            Queue<T> temp = new Queue<T>();
            while (!qu.IsEmpty())
            {
                copy.Insert(qu.Head());
                temp.Insert(qu.Remove());
            }
            while (!temp.IsEmpty()) qu.Insert(temp.Remove());
            return copy;
        }
        public static Queue<int> sumQue(Queue<int> q)
        {
            Queue<int> qu = copyqueue(q);
            Queue<int> temp = new Queue<int>();
            Queue<int> res = new Queue<int>();

            while (!qu.IsEmpty())
            {
                int big1 = int.MinValue;
                int big2 = int.MinValue;
                while (!qu.IsEmpty())
                {
                    big2 = Math.Max(big2, qu.Head());
                    if (big2 > big1)
                    {
                        big1 += big2;
                        big2 = big1 - big2;
                        big1 -= big2;
                    }
                    temp.Insert(qu.Remove());
                }
                while (!temp.IsEmpty())
                {
                    if (temp.Head() == big1 || temp.Head() == big2) temp.Remove();
                    else qu.Insert(temp.Remove());
                }
                res.Insert(big1 + big2);
            }
            return res;
        }

    }



    public class Cage
    {
        private string name;
        private int number;

        public Cage(string name, int number)
        {
            this.name = name;
            this.number = number;
        }

        public void SetName(string name) { this.name = name; }
        public void SetNumber(int number) { this.number = number; }
        public string GetName() { return this.name; }
        public int GetNumber() { return this.number; }

        public override string ToString() { return $"[{this.number} {this.name}s]"; }
    }

    public class RangeQueue
    {
        private int from;
        private int to;

        public RangeQueue(int from, int to)
        {
            this.from = from;
            this.to = to;
        }

        public void SetFrom(int from) { this.from = from; }
        public void SetTo(int to) { this.to = to; }
        public int GetFrom() { return this.from; }
        public int GetTo() { return this.to; }

        public override string ToString() { return $"( {this.from} - {this.to} )"; }
    }
}


