using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test4Problem1
{
    class Program
    {
        public static IEnumerable<int> myFilter1(IEnumerable<int> input)
        {
            IEnumerable<int> ret;
            ret = input.Where(x => !(x % 7 == 0 && x > 75)).Select(x => x * x).Where(x => x % 2 == 0);

            return ret;
        }
        public static IEnumerable<int> myFilter2(IEnumerable<int> input)
        {
            IEnumerable<int> ret;
            ret = input.Where(x => !(x % 3 == 0 && x < 35)).Select(x => x * x * x).Where(x => (x % 2 == 1));

            return ret;
        }
        static void Main(string[] args)
        {
            Random rnd = new Random(5); // Important to seed with 5 for repeatability.
                                        // Produces a list of 100 random numbers.
            var listForProblem = Enumerable.Range(1, 100).Select(i => rnd.Next() % 101);
            // myFilter1 takes a sequence of integers with values from 0 to 100
            // It removes all multiples of 7 greater than 75
            // Each number is then squared
            // Finall remive any resulting integer that is odd.
            var firstResults = Program.myFilter1(listForProblem);
            // Show the results.
            Console.WriteLine(String.Join(" ", firstResults));
            // myFilter2 takes a sequence of integers with values from 0 to 100
            // It removes all multiples of 3 less than 35
            // Then cube each number
            // Finally remove any resulting integer that is even.
            var secondResults = Program.myFilter2(listForProblem);
            // Show the results.
            Console.WriteLine(String.Join(" ", secondResults));
        }
    }
}
