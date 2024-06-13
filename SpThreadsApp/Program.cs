using static System.Runtime.InteropServices.JavaScript.JSType;



namespace SpThreadsApp
{
    public class Program
    {
        static int count = 0;
        static void Main(string[] args)
        {
            //for(int i = 0; i < 5; i++)
            //{
            //    Thread thread = new(CountInc);
            //    thread.Start();
            //}

            Thread thread1 = new(CountInc);
            thread1.Start();
            Thread thread2 = new(CountInc);
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"Count = {count}");
        }

        static void CountInc()
        {
            for (int i = 0; i < 10; i++)
            {
                count++;
                Thread.Sleep(100);
            }
        }


    }
}
