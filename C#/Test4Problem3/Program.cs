using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Test4Problem3
{
    class Program
    {
        static double[] data = new double[10000000];

        static void Main(string[] args)
        {
            Console.WriteLine("Starting to time a sequential loop of 10,000,000 operations.");
            DateTime dt = DateTime.Now;

            calc(0, data.Length);

            TimeSpan ts = (DateTime.Now - dt);
            Console.WriteLine("The elapsed time is {0} milliseconds.", ts.TotalMilliseconds);

            Console.WriteLine("Now you will enter a number of threads to use in order to split the computing amongst threads.");
            Console.WriteLine("How many threads?");
            int numThreads = Convert.ToInt32(Console.ReadLine());
            Thread[] thrd = new Thread[numThreads];

            int steps = data.Length / thrd.Length;
            dt = DateTime.Now;

            Console.WriteLine("Starting to time a multithreaded loop of 10,000,000 operations split up amongst {0} threads.", numThreads);

            for (int i = 0; i < thrd.Length; i++)
            {
                int j = i;
                thrd[i] = new Thread(() => calc(j * steps, steps));
                thrd[i].Start();
            }

            for(int i = 0; i < thrd.Length; i++)
            {
                thrd[i].Join();
            }

            ts = DateTime.Now - dt;

            Console.WriteLine("The elapsed time is {0} milliseconds.", ts.TotalMilliseconds);

        }

        static void calc(int startIndex, int reps)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = Math.Sin(i) + Math.Cos(i) + Math.Tan(i) + Math.Sinh(i) + Math.Cosh(i) + Math.Tanh(i);
            }
        }
    }
}
