using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;

namespace TimerVSSleep
{
    class Program
    {
        static System.Timers.Timer timer = new System.Timers.Timer(100) { AutoReset = true };
        static AutoResetEvent autoResetEvent = new AutoResetEvent(false);


        static void Main(string[] args)
        {
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            ThreadPool.QueueUserWorkItem((state) =>
            {
                while (true)
                {
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss-fff"));
                    autoResetEvent.WaitOne();
                }
            });
            Console.ReadLine();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            autoResetEvent.Set();
        }
    }
}
