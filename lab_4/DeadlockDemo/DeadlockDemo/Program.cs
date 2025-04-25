using System;
using System.Threading;

namespace DeadlockDemo
{
    public class Program
    {
        private static readonly object lockA = new object();
        private static readonly object lockB = new object();

        public static void Main(string[] args)
        {
            Thread thread1 = new Thread(DoWork1);
            Thread thread2 = new Thread(DoWork2);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Програма завершена.");
        }

        public static void DoWork1()
        {
            lock (lockA)
            {
                Console.WriteLine("Thread 1 захопив lockA");
                Thread.Sleep(100);
                lock (lockB)
                {
                    Console.WriteLine("Thread 1 захопив lockB");
                }
            }
        }

        public static void DoWork2()
        {
            lock (lockB)
            {
                Console.WriteLine("Thread 2 захопив lockB");
                Thread.Sleep(100);
                lock (lockA)
                {
                    Console.WriteLine("Thread 2 захопив lockA");
                }
            }
        }
    }
}
