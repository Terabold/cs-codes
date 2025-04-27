using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Unit4.CollectionsLib;
namespace Ariel
{

    class Program
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();
            Party[] parties = new Party[rnd.Next(1,100)];

        }

        public static void winners(Party[] parties)
        {
            Party winner1 = parties[0];
            Party winner2 = new Party("placeholder", 0, null);
            for (int i = 1;i< parties.Length ; i++)
            {
                if (parties[i].sumvotes() > winner1.sumvotes())
                {
                    winner2 = winner1;
                    winner1 = parties[i];

                }
                else if (parties[i].sumvotes() > winner2.sumvotes())
                {
                    winner2 = parties[i];
                }
            }
            Console.WriteLine($"number 1 : {winner1} with {winner1.sumvotes()}");
            Console.WriteLine($"number 2 : {winner2} with {winner2.sumvotes()}");
        }


    }
    class Candidate
    {
        private string name;
        private int votes;

        public Candidate(string name, int votes)
        {
            this.name = name;
            this.votes = votes;
        }

        public string getname() { return name; }
        public int getvotes() { return votes; }
        public void setname(string name) { this.name = name; }
        public void setvotes(int votes) { this.votes = votes; }
    }

    class Party
    {
        private string pname;
        private int seats;
        private Candidate[] Candidates;

        public Party(string pname, int seats, Candidate[] candidates)
        {
            this.pname = pname;
            this.seats = seats;
            this.Candidates = new Candidate[seats];
            for (int i = 0; i < seats; i++)
            {
                if (candidates[i] != null)
                {
                    this.Candidates[i] = candidates[i];
                }
                else
                {
                    this.Candidates[i] = null;
                }
            }
        }


// good way to reconstruct arrays
        public void addbettercandidate(Candidate candidate)
        {
            Candidate last = Candidates[Candidates.Length - 1];
            if (last.getvotes() < candidate.getvotes())
            {
                int n = 0;
                while (n < Candidates.Length && Candidates[n].getvotes() > candidate.getvotes())
                {
                    n++;
                }
                if (n <  Candidates.Length)
                {
                    for (int i = Candidates.Length - 1; i > n; i--)
                    {
                        Candidates[i-1] = Candidates[i];
                    }
                    Candidates[n] = candidate;
                }
            }
             
        }

        public int sumvotes()
        {
            int sum = 0;
            foreach (Candidate candidate in Candidates)
            {
                sum += candidate.getvotes();
            }
            return sum;
        }



    }
}
