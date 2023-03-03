using System.Diagnostics;

namespace ThreadAndTask
{
    internal class Program
    {
        static StreamWriter writer;
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            //sw.Start();
            //Raw();
            //sw.Stop();
            //Console.WriteLine("Raw Time Taken: " + sw.ElapsedMilliseconds + " ms");


            //sw.Start();
            //Thread();
            //sw.Stop();
            //Console.WriteLine("Time taken for two threads: " + sw.ElapsedMilliseconds + " ms");

            sw.Start();
            Taske();
            sw.Stop();
            Console.WriteLine("Time taken for Task: " + sw.ElapsedMilliseconds + " ms");


        }
        public static void fil()
        {
          

        }
        public static bool IsBusy()
        {
            try
            {
                writer = new StreamWriter(@"D:\data.txt");
                writer.WriteLine("");
                File.WriteAllText(@"D:\data.txt", "");
            }
            catch
            {
                return true;
            }
            return false;
        }
        public static void Thread()
        {
            // thread 1
            ThreadStart threadStart1 = new ThreadStart(LongProcess1);
            Thread thread1 = new Thread(threadStart1);

            // thread 2
            ThreadStart threadStart2 = new ThreadStart(LongProcess2);
            Thread thread2 = new Thread(threadStart2);
            Console.WriteLine("Main Employee created 2 sub employees");

            // will now start the threads
            thread1.Start();
            thread2.Start();

        }
        public static void Raw()
        {
            LongProcess1();
            LongProcess2();
        }
        public static void Taske()
        {
            var task = Task.Run(LongProcess1);
            var task2 = Task.Run(LongProcess2);

            Task.WaitAll(task, task2);
        }
        public static void LongProcess1()
        {
            for (int i = 0; i <= 100; i++)
            {
                Console.WriteLine(" Long Process1: " + i);
            }
        }
        public static void LongProcess2()
        {
            for (int i = 0; i <= 100; i++)
            {
                Console.WriteLine(" Long Process2: " + i);
            }
        }
    }
}