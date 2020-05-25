using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Problem1
    {
        public static IEnumerable<int> myFilter(IEnumerable<int> input)
        {
            IEnumerable<int> ret;
            ret = input.Where(x => !(x % 5 == 0 && x > 50)).Select(x => x * x * x).Where(x => x % 2 == 1);

            return ret;
        }
    }

    public class Problem2
    {
        public static IEnumerable<int> myFilter(IEnumerable<int> input)
        {
            IEnumerable<int> ret;
            ret = input.Where(x => !(x % 6 == 0 && x < 42)).Select(x => x * x).Where(x => !(x % 2 == 1));

            return ret;
        }

    }

    public class TestProblem2
    {
        public static IEnumerable<int> merge(IEnumerable<int> input1, IEnumerable<int> input2, IEnumerable<int> input3, IEnumerable<int> input4)
        {
            IEnumerable<int> ret;
            ret = input1.Intersect(input2).Intersect(input3).Intersect(input4).Where(x => x % 10 == 0);

            return ret;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random(5); // Important to seed with 5 for repeatability.
            var listForProblem = Enumerable.Range(1, 100).Select(i => rnd.Next() % 101);
            var answer = Problem1.myFilter(listForProblem);

            Console.WriteLine("Part 1 ---------------");

            foreach (int i in answer)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Part 2 ---------------");

            Random rnd2 = new Random(5); // Important to seed with 5 for repeatability.
            var listForProblem2 = Enumerable.Range(1, 100).Select(i => rnd2.Next() % 101);
            var answer2 = Problem2.myFilter(listForProblem2);
            foreach (int i in answer2)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Part 3 ---------------");

            Random rnd3 = new Random();
            var list1 = Enumerable.Range(1, 15);// Generate list here.
            var list2 = Enumerable.Range(2, 41).Where(x => (x % 2 == 0));// Generate list here.
            var list3 = Enumerable.Range(3, 21-2).Where(x => (x % 2 == 1));// Generate list here.
            var list4 = Enumerable.Range(5, 105 - 4).Where(x => (x % 5 == 0));// Generate list here.
            var answer3 = TestProblem2.merge(list1, list2, list3, list4);
            foreach (int i in answer3)
            {
                Console.WriteLine(i);
            }

        }
    }
}
