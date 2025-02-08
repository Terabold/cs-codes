using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;

namespace ConsoleApp25
{
    class gardencolors
    {
        public char color { set; get; }
        public int count { set; get; }

        public gardencolors(char color, int count)
        {
            this.color = color;
            this.count = count;
        }
    }
    class flower
    {
        public string name { get; set; }
        public int height { get; set; }
        public char color { get; set; }

        public flower(string name)
        {
            Random rnd = new Random();
            this.name = name;
            this.height = rnd.Next(1,30);
            this.color = (char)rnd.Next(97, 104);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Queue<flower> garden = new Queue<flower>();
            for(int i = 0; i <  5; i++)
            {
                Console.WriteLine("enter name");
                string name = Console.ReadLine();
                garden.Insert(new flower(name));
            }
            Queue<flower> gardencopy = copyqueueflower(garden); //copyqueue page 13
            Queue<gardencolors> colorvar = new Queue<gardencolors>();
            for(int i = 97; i < 104; i++)
            {
                char color = (char)i;
                gardencolors gcolor = new gardencolors(color, countspecificcolor(garden, color));
                colorvar.Insert(gcolor);
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{gardencopy.Head().name} height: {gardencopy.Head().height} color with char: {gardencopy.Head().color}");
                gardencopy.Remove();
            }
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"count: {colorvar.Head().count} amount: {colorvar.Remove().color}");
            }
        }

        public static int countspecificcolor(Queue<flower> garden, char color)
        {
            int count = 0;
            Queue<flower> gardencopy = copyqueueflower(garden);
            while (!gardencopy.IsEmpty())
            {
                if(gardencopy.Head().color == color) { count++; }
                gardencopy.Remove();
            }
            return count;
        }
        public static Queue<flower> copyqueueflower(Queue<flower> queue)
        {
            Queue<flower> temp = new Queue<flower>();
            Queue<flower> temp2 = new Queue<flower>();
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
        public static Queue<int> copyqueue(Queue<int> queue)
        {
            Queue<int> temp = new Queue<int>();
            Queue<int> temp2 = new Queue<int>();
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
