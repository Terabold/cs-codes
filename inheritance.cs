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
            this.kilometraz += distance / speed;
        }
    }

    class Creature
    {
        private string name;
        private char gender;

        public Creature(string name, char gender)
        {
            this.name = name;
            this.gender = gender;
        }

        public void SetName(string name) { this.name = name; }
        public string GetName() { return name; }

        public void SetGender(char gender) { this.gender = gender; }
        public char GetGender() { return gender; }

        public override string ToString() { return $"Creature: {name}, Gender: {gender}"; }
    }

    class Wizard : Creature
    {
        private int strength;

        public Wizard(string name, char gender, int strength)
            : base(name, gender)
        {
            this.strength = strength;
        }

        public void SetStrength(int strength) { this.strength = strength; }
        public int GetStrength() { return strength; }

        public override string ToString() { return $"{base.ToString()}, Strength: {strength}"; }
    }

    class WizardProgrammer : Wizard
    {
        private string[] languages;

        public WizardProgrammer(string[] languages, string name, char gender, int strength)
            : base(name, gender, strength)
        {
            this.languages = languages;
        }

        public void SetLanguages(string[] languages) { this.languages = languages; }
        public string[] GetLanguages() { return languages; }

        public override string ToString() { return $"{base.ToString()}, Languages: {string.Join(", ", languages)}"; }
    }

    class Dwarf : Creature
    {
        private double height;

        public Dwarf(string name, char gender, double height)
            : base(name, gender)
        {
            this.height = height;
        }

        public void SetHeight(double height) { this.height = height; }
        public double GetHeight() { return height; }

        public override string ToString() { return $"{base.ToString()}, Height: {height}"; }
    }

    class DwarfJump : Dwarf
    {
        private bool jump;

        public DwarfJump(string name, char gender, double height, bool jump)
            : base(name, gender, height)
        {
            this.jump = jump;
        }

        public void SetJump(bool jump) { this.jump = jump; }
        public bool GetJump() { return jump; }

        public override string ToString() { return $"{base.ToString()}, Can Jump: {jump}"; }
    }
}
