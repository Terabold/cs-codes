using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp32
{
    class Bicycle
    {
        private double kilometraz;
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
            :base(kilometraz, color, maxspeed)
        {
            this.maxheight = maxheight;
            this.highgear = highgear;
        }

        public void sethighgear(bool ishighgear) { this.highgear = ishighgear; }
    }

    //class stunbike : Bicycle
}
