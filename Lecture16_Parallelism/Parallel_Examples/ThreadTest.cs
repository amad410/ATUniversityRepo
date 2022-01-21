using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lecture16_Parallelism
{
    public class ThreadTest
    {
        public ThreadTest()
        {
            Random random = new Random();
            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss"));
            int toWait = (10 + random.Next(10)) * 1000;
            Console.WriteLine($"Waiting for {toWait} seconds");
            Thread.Sleep(toWait);
            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss"));
        }
    }
}
