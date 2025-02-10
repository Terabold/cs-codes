using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp32
{
    class Bicycle
    {
        protected double kilometraz;
        private string color;
        private int maxspeed;

        public Bicycle(double kilometraz, string color, int maxspeed)
        {
            this.kilometraz = kilometraz;
            this.color = color;
            this.maxspeed = maxspeed;
        }

        public void ride(double distance)
        {
            this.kilometraz += distance;
        }
    }

    class mountainbicycle : Bicycle
    {
        int maxheight;
        bool highgear;

        public mountainbicycle(double kilometraz, string color, int maxspeed, int maxheight, bool highgear)
            : base(kilometraz, color, maxspeed)
        {
            this.maxheight = maxheight;
            this.highgear = highgear;
        }

        public void sethighgear(bool ishighgear) { this.highgear = ishighgear; }
    }

    class stunbike : Bicycle
    {
        private bool iscompatible;
        private double jumpheight;

        public stunbike(int kilometraz, string color, int maxspeed, bool iscompatible, double jumpheight)
            : base(kilometraz, color, maxspeed)
        {
            this.iscompatible = iscompatible;
            this.jumpheight = jumpheight;
        }

        public void Jump(double distance) { this.jumpheight += distance; }
    }

    class racebikes : Bicycle
    {
        DateTime lastcheck;

        public racebikes(int kilometraz, string color, int maxspeed, DateTime lastcheck)
            : base(kilometraz, color, maxspeed)
        {
            this.lastcheck = lastcheck;
        }

        public void race(double distance, double speed)
        {
             this.kilometraz += distance/speed;
        }
    }
}