using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpThreadsApp
{
    public class Examples
    {
        public static void ThreadCreateExample()
        {
            Thread mainThread = Thread.CurrentThread;

            //mainThread.Name = "Main Thread";
            //Console.WriteLine(mainThread.Name);

            //Thread.Sleep(1000);

            //Console.WriteLine(mainThread.ManagedThreadId);
            //Console.WriteLine(mainThread.Priority);
            //Console.WriteLine(mainThread.ThreadState);
            //Console.WriteLine(mainThread.IsAlive);

            //Thread thread1 = new(Loop);
            //Thread thread2 = new(new ThreadStart(Loop));
            //Thread thread3 = new(() =>
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - {i}");
            //        Thread.Sleep(100);
            //    }
            //});

            //thread1.Start();
            //thread2.Start();
            //thread3.Start();

            //Thread thParam1 = new(new ParameterizedThreadStart(LoopParam));
            //Thread thParam2 = new(LoopParam);

            //thParam1.Start(60);
            //thParam2.Start(80);

            //Thread threadRand1 = new(LoopRandom);
            //Thread threadRand2 = new(LoopRandom);

            //threadRand1.Start(new RandomParam(10, 70, 40));
            //threadRand2.Start(new RandomParam(-50, -10, 50));

            RandomGenerate randomGenerate = new(-50, -10, 50);
            Thread threadRand1 = new(new RandomGenerate(10, 70, 40).Work);
            Thread threadRand2 = new(randomGenerate.Work);

            threadRand1.Start();
            threadRand2.Start();


            //for (int i = 0; i < 50; i++)
            //{
            //    Console.WriteLine($"Main {Thread.CurrentThread.ManagedThreadId} - {i}");
            //    Thread.Sleep(100);
            //}

            static void Loop()
            {
                var loopThread = Thread.CurrentThread;
                //loopThread.Name = "Loop thread";
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"{loopThread.ManagedThreadId} - {i}");
                    Thread.Sleep(100);
                }
            }

            static void LoopParam(object number)
            {
                var loopThread = Thread.CurrentThread;
                //loopThread.Name = "Loop thread";
                for (int i = 0; i < (int)number; i++)
                {
                    Console.WriteLine($"{loopThread.ManagedThreadId} - {i}");
                    Thread.Sleep(100);
                }
            }

            static void LoopRandom(object? param)
            {
                if (param is RandomParam pr)
                {
                    Random random = new();
                    for (int i = 0; i < (int)pr.Count; i++)
                    {
                        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - {random.Next(pr.MinValue, pr.MaxValue)}");
                        Thread.Sleep(100);
                    }
                }
            }
        }
    }

    class RandomParam
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int Count { get; set; }

        public RandomParam(int min, int max, int count)
        {
            MinValue = min;
            MaxValue = max;
            Count = count;
        }
    }

    class RandomGenerate
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int Count { get; set; }

        public RandomGenerate(int min, int max, int count)
        {
            MinValue = min;
            MaxValue = max;
            Count = count;
        }
        public void Work()
        {
            Random random = new();
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - {random.Next(MinValue, MaxValue)}");
                Thread.Sleep(100);
            }
        }

    }
}
