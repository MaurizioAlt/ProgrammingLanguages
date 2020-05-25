using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCSOop
{
    interface IUFO
    {
        string color { get; set; }
        int size { get; set; }
        void fly();
        void goToHyperspace();
        void land();
    }

    class SmallCraft : IUFO
    {
        public string color { get; set; }
        public int size { get; set; }
        public void fly()
        {
            Console.WriteLine("small craft fly");
        }
        public void goToHyperspace()
        {
            Console.WriteLine("small craft go to Hyperspace");
        }
        public void land()
        {
            Console.WriteLine("small craft land");
        }

    }
    class LargeCraft : IUFO
    {
        public string color { get; set; }
        public int size { get; set; }
        public void fly()
        {
            Console.WriteLine("large craft fly");
        }
        public void goToHyperspace()
        {
            Console.WriteLine("large craft go to Hyperspace");
        }
        public void land()
        {
            Console.WriteLine("large craft land");
        }
    }
    class BossCraft : IUFO
    {
        public string color { get; set; }
        public int size { get; set; }
        public void fly()
        {
            Console.WriteLine("Boss craft fly");
        }
        public void goToHyperspace()
        {
            Console.WriteLine("Boss craft go to Hyperspace");
        }
        public void land()
        {
            Console.WriteLine("Boss craft land");
        }
    }

    class Animal
    {
        public void move()
        {
            Console.WriteLine("Animal move");
        }

        public void sleep()
        {
            Console.WriteLine("Animal sleep");
        }

        public void eat()
        {
            Console.WriteLine("Animal eat");
        }
    }

    class Dog : Animal
    {
        public void sing()
        {
            Console.WriteLine("Dog sing");
        }
        public void wash()
        {
            Console.WriteLine("Dog wash");
        }
        public void turnAround()
        {
            Console.WriteLine("Dog turn around");
        }
    }

    class Cat : Animal
    {
        public void sing()
        {
            Console.WriteLine("Cat sing");
        }
        public void wash()
        {
            Console.WriteLine("Cat wash");
        }
        public void turnAround()
        {
            Console.WriteLine("Cat turn around");
        }
    }

    class Bird : Animal
    {
        public void sing()
        {
            Console.WriteLine("Bird sing");
        }
        public void wash()
        {
            Console.WriteLine("Bird wash");
        }
        public void turnAround()
        {
            Console.WriteLine("Bird turn around");
        }
    }

    class FirstCSOop
    {
        static void Main(string[] args)
        {
            Dog puppy = new Dog();
            Cat kitty = new Cat();
            Bird birdy = new Bird();

            puppy.move();
            puppy.sleep();
            puppy.eat();
            puppy.sing();
            puppy.wash();
            puppy.turnAround();

            kitty.move();
            kitty.sleep();
            kitty.eat();
            kitty.sing();
            kitty.wash();
            kitty.turnAround();

            birdy.move();
            birdy.sleep();
            birdy.eat();
            birdy.sing();
            birdy.wash();
            birdy.turnAround();

            SmallCraft small = new SmallCraft();
            LargeCraft large = new LargeCraft();
            BossCraft boss = new BossCraft();

            small.fly();
            small.goToHyperspace();
            small.land();

            large.fly();
            large.goToHyperspace();
            large.land();

            boss.fly();
            boss.goToHyperspace();
            boss.land();

        }
    }
}
