using System;

namespace ToyShopApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ToyShop shop = new ToyShop("Toy World", 6);

            Doll doll1 = new Doll("Pretty Doll", 50, 3, 5);
            Doll doll2 = new Doll("Royal Doll", 60, 2, 7);
            Doll doll3 = new Doll("Hero Doll", 45, 4, 4);

            TeddyBear bear1 = new TeddyBear("Big Bear", 80, Size.MEDIUM);
            TeddyBear bear2 = new TeddyBear("Small Bear", 70, Size.SMALL);
            TeddyBear bear3 = new TeddyBear("Huge Bear", 90, Size.LARGE);

            shop.addToy(doll1);
            shop.addToy(doll2);
            shop.addToy(doll3);
            shop.addToy(bear1);
            shop.addToy(bear2);
            shop.addToy(bear3);

            // .3 
            shop.printToys();

            // .4
            Console.WriteLine("\n4. Total value of all toys in the shop: " + shop.calculateTotalToyValue());

            Console.WriteLine("\n5. Queries by type:");
            Console.WriteLine("- Only Dolls: ");
            shop.printDolls();
            Console.WriteLine("- Only Teddy Bears: ");
            shop.printTeddies();
            Console.WriteLine("- Only Big Teddy Bears: ");
            shop.printBigTeddies();
            Console.WriteLine("- Doll with most accessories: " + shop.dollWithMostStuff());

            // .6 
            Console.WriteLine("\n6. Number of teddy bears of a specific size for large: " + shop.countTeddiesBySize(Size.LARGE));

            // .7 
            Console.WriteLine("\n7. The most expensive toy in the shop: " + shop.expensiveToy());

            // .8 
            Console.WriteLine("\n8. The doll with the most accessories: " + shop.dollWithMostStuff());

            // .9 
            Console.WriteLine("\n9. More dolls or teddy bears? " + shop.compareToyTypes());

            // .10 
            Console.WriteLine("\n10. Total value of all dolls in the shop: " + shop.dollsumval());
        }
    }

    public class Toy
    {
        protected string name;
        protected double price;

        public Toy(string name, double price)
        {
            this.name = name;
            this.price = price;
        }

        public virtual double getPrice()
        {
            return price;
        }

        public override string ToString()
        {
            return $"{name} costs {getPrice()}";
        }
    }

    public class Doll : Toy
    {
        private int accessoriesCount;
        private double accessoryPrice;

        public Doll(string name, double price, int accessoriesCount, double accessoryPrice)
            : base(name, price)
        {
            this.accessoriesCount = accessoriesCount;
            this.accessoryPrice = accessoryPrice;
        }

        public override double getPrice()
        {
            return base.getPrice() + (accessoriesCount * accessoryPrice);
        }

        public override string ToString()
        {
            return base.ToString() + $" with {accessoriesCount} accessories";
        }

        public int getAccessoriesCount()
        {
            return accessoriesCount;
        }
    }

    public enum Size
    {
        LARGE, MEDIUM, SMALL
    }

    public class TeddyBear : Toy
    {
        private Size bearSize;

        public TeddyBear(string name, double price, Size bearSize)
            : base(name, price)
        {
            this.bearSize = bearSize;
        }

        public override double getPrice()
        {
            if (bearSize == Size.LARGE)
            {
                return price * 1.20;
            }
            else if (bearSize == Size.MEDIUM)
            {
                return price * 1.10;
            }
            else
            {
                return price;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $" of size {bearSize}";
        }

        public Size getSize()
        {
            return bearSize;
        }
    }

    public class ToyShop
    {
        private string shopName;
        private Toy[] toys;
        private int toyCount;

        public ToyShop(string shopName, int capacity)
        {
            this.shopName = shopName;
            toys = new Toy[capacity];
            toyCount = 0;
        }

        public void addToy(Toy toy)
        {
            if (toyCount < toys.Length)
            {
                toys[toyCount++] = toy;
            }
        }

        public void printToys()
        {
            foreach (var toy in toys)
            {
                if (toy != null)
                {
                    Console.WriteLine(toy.ToString());
                }
            }
        }

        public double calculateTotalToyValue()
        {
            double totalValue = 0;
            foreach (var toy in toys)
            {
                if (toy != null)
                {
                    totalValue += toy.getPrice();
                }
            }
            return totalValue;
        }

        public void printDolls()
        {
            foreach (var toy in toys)
            {
                if (toy is Doll doll)
                {
                    Console.WriteLine(doll.ToString());
                }
            }
        }

        public void printTeddies()
        {
            foreach (var toy in toys)
            {
                if (toy is TeddyBear teddy)
                {
                    Console.WriteLine(teddy.ToString());
                }
            }
        }

        public void printBigTeddies()
        {
            foreach (var toy in toys)
            {
                if (toy is TeddyBear teddy && teddy.getSize() == Size.LARGE)
                {
                    Console.WriteLine(teddy.ToString());
                }
            }
        }

        public int countTeddiesBySize(Size size)
        {
            int count = 0;
            foreach (var toy in toys)
            {
                if (toy is TeddyBear teddy && teddy.getSize() == size)
                {
                    count++;
                }
            }
            return count;
        }

        public Toy expensiveToy()
        {
            Toy mostExpensive = null;
            foreach (var toy in toys)
            {
                if (toy != null && (mostExpensive == null || toy.getPrice() > mostExpensive.getPrice()))
                {
                    mostExpensive = toy;
                }
            }
            return mostExpensive;
        }

        public Doll dollWithMostStuff()
        {
            Doll mostAccessoriesDoll = null;
            foreach (var toy in toys)
            {
                if (toy is Doll doll && (mostAccessoriesDoll == null || doll.getAccessoriesCount() > mostAccessoriesDoll.getAccessoriesCount()))
                {
                    mostAccessoriesDoll = doll;
                }
            }
            return mostAccessoriesDoll;
        }

        public string compareToyTypes()
        {
            int dollsCount = 0;
            int bearsCount = 0;

            foreach (var toy in toys)
            {
                if (toy is Doll)
                {
                    dollsCount++;
                }
                else if (toy is TeddyBear)
                {
                    bearsCount++;
                }
            }

            if (dollsCount > bearsCount)
                return "More dolls";
            else if (bearsCount > dollsCount)
                return "More teddy bears";
            else
                return "Equal number of dolls and teddy bears";
        }

        public double dollsumval()
        {
            double totalValue = 0;
            foreach (var toy in toys)
            {
                if (toy is Doll doll)
                {
                    totalValue += doll.getPrice();
                }
            }
            return totalValue;
        }
    }
}
