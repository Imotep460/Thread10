using System;
using System.Diagnostics;
using System.Linq;

namespace Thread10
{
    class Program
    {
        Stopwatch sw = new Stopwatch();
        Random r = new Random();
        const int COUNT = 10000000;
        Money[] arr = new Money[COUNT];

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        private void Run()
        {
            Console.WriteLine("Initializing");
            Init();
            NonParallel();
            sw.Reset();
            PLINQ();
            Console.Write("\n\nDone - Press any key "); Console.ReadKey();
        }

        private void PLINQ()
        {
            int res = 0;
            Console.WriteLine("\n\nStarting with PLINQ");
            sw.Start();

            res = arr.AsParallel().Count(m => m.Value % 2 == 0 && m.Owner.Contains("JO") && m.Zip.CompareTo("5000") < 0);


            sw.Stop();
            Console.WriteLine($"Count: {res} in {sw.ElapsedMilliseconds} mills");
        }

        private void NonParallel()
        {
            int res = 0;
            Console.WriteLine("\n\nStarting without parallel");
            sw.Start();
            for (int i = 0; i < COUNT; i++)
            {
                Money m = arr[i];
                if ((m.Value % 2 == 0) && (m.Owner.Contains("JO")) && (m.Zip.CompareTo("5000") < 0))
                {
                    res++;
                }
            }
            sw.Stop();
            Console.WriteLine($"Count: {res} in {sw.ElapsedMilliseconds} mills");
        }

        private void Init()
        {
            for (int i = 0; i < COUNT; i++)
            {
                int v = r.Next(10000, 100000000);

                int lengthOfName = r.Next(10, 32);
                char[] nameAsArray = new char[lengthOfName];
                for (int j = 0; j < lengthOfName; j++)
                {
                    nameAsArray[j] = (char)r.Next(65, 91); //A - Z
                }
                string o = new string(nameAsArray);

                string z = "" + r.Next(1000, 9000);

                arr[i] = new Money(v, o, z);
            }
        }
    }
}
