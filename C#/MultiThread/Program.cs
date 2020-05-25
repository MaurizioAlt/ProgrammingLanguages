using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace MultiThread
{
    class Program
    {
        static Thread thrd1;
        static Thread[] thrd = new Thread[4];
        static int[] data = new int[10000000];

        static void Main(string[] args)
        {
            thrd1 = new Thread(() => calc(0, data.Length));
            thrd1.Start(); 
            DateTime start = DateTime.Now; 
            //Console.WriteLine("The thread has started."); 
            thrd1.Join(); 
            //Console.WriteLine("The thread has completed."); 
            TimeSpan end = DateTime.Now - start;
            Console.WriteLine("Sequentially, calc takes {0} milliseconds to run.", end.TotalMilliseconds);


            int repsPerThread = data.Length / thrd.Length; 
            for (int i = 0; i < thrd.Length; i++) 
            { 
                int j = i; 
                thrd[i] = new Thread(() => calc(j * repsPerThread, repsPerThread)); 
                thrd[i].Start(); 
            }
            DateTime dt = DateTime.Now; 
            //Console.WriteLine("The thread has started."); 
            for (int i = 0; i < thrd.Length; i++) 
            { 
                thrd[i].Join(); 
            }
            //Console.WriteLine("The thread has completed."); 
            TimeSpan ts = DateTime.Now - dt; 
            Console.WriteLine("Multithreaded, calc takes {0} milliseconds to run.", ts.TotalMilliseconds);
        }

        static void calc(int startingIndex, int reps)
        {
            // assign into the data array from startingIndex to
            // startingIndex + reps the following:
            // Math.Atan(i) * Math.Acos(i) * Math.Cos(i) * Math.Sin(i);
            for (int i = startingIndex; i < startingIndex + reps; i++) 
            {
                data[i] = (int)(Math.Atan(i) * Math.Acos(i) * Math.Cos(i) * Math.Sin(i)); 
            }
        }
    }
}
