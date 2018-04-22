using System;
using System.Net;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Chapter20
{
    class MyDownloadStringLow
    {
        Stopwatch sw = new Stopwatch();

        public void DoRun()
        {
            const int LargeNumber = 6000000;
            sw.Start();
            
            int t1 = CountCharacters(1, "http://www.sina.com");
            int t2 = CountCharacters(2, "http://www.baidu.com");

            CounterToALargeNumber(1, LargeNumber);
            CounterToALargeNumber(2, LargeNumber);
            CounterToALargeNumber(3, LargeNumber);
            CounterToALargeNumber(4, LargeNumber);

            Console.WriteLine("Chars in http://www.sina.com     :{0}",  t1);
            Console.WriteLine("Chars in http://www.baidu.com    :{0}",  t2);

        }

        private int CountCharacters(int id, string uristring)
        {
            WebClient wc1 = new WebClient();
            Console.WriteLine("Starting call {0}    :   {1} ms", id, sw.Elapsed.TotalMilliseconds);
            
            string result = wc1.DownloadString(new Uri(uristring));
            Console.WriteLine(" Call {0} completed:   {1} ms", id, sw.Elapsed.TotalMilliseconds);

            return result.Length;           
        }

        private void CounterToALargeNumber(int id, int value)
        {
            for(long i = 0; i < value; ++i)
                ;
            Console.WriteLine(" End counting{0}:    {1} ms", id, sw.Elapsed.TotalMilliseconds);
        }
    }

  class MyDownloadStringHigh
    {
        Stopwatch sw = new Stopwatch();

        public void DoRun()
        {
            const int LargeNumber = 6000000;
            sw.Start();
            
            Task<int> t1 = CountCharacters(1, "http://www.sina.com");
            Task<int> t2 = CountCharacters(2, "http://www.baidu.com");

            CounterToALargeNumber(1, LargeNumber);
            CounterToALargeNumber(2, LargeNumber);
            CounterToALargeNumber(3, LargeNumber);
            CounterToALargeNumber(4, LargeNumber);

            Console.WriteLine("Chars in http://www.sina.com     :{0}",  t1.Result);
            Console.WriteLine("Chars in http://www.baidu.com    :{0}",  t2.Result);

        }

        private async Task<int> CountCharacters(int id, string uristring)
        {
            WebClient wc1 = new WebClient();
            Console.WriteLine("Starting call {0}    :   {1} ms", id, sw.Elapsed.TotalMilliseconds);
            
            string result = await wc1.DownloadStringTaskAsync(new Uri(uristring));
            Console.WriteLine(" Call {0} completed:   {1} ms", id, sw.Elapsed.TotalMilliseconds);

            return result.Length;           
        }

        private void CounterToALargeNumber(int id, int value)
        {
            for(long i = 0; i < value; ++i)
                ;
            Console.WriteLine(" End counting{0}:    {1} ms", id, sw.Elapsed.TotalMilliseconds);
        }
    }

    static class DoAsyncStuff1
    {
        public static async Task<int> CalculateSumAsync(int i1, int i2)
        {
            int sum = await Task.Run(() => GetSum(i1, i2));
            return sum;
        }

        private static int GetSum(int i1, int i2){return i1 + i2;}
    }

    static class DoStuff
    {
        public static async Task<int> FindSeriesSum(int i1)
        {
            int sum = 0;
            for(int i=0; i < i1; ++i)
            {
                sum += i;
                if(i%1000 == 0)
                    await Task.Yield();
            }

            return sum;
        }
    }



    class Program
    {
        static void MainTest()
        {
            Console.WriteLine("2018-4-21");
            Console.WriteLine("**********************************");
            //MyDownloadStringLow ds1 = new MyDownloadStringLow();
            //MyDownloadStringHigh ds2 = new MyDownloadStringHigh();
            //ds1.DoRun();
            //ds2.DoRun();
            Console.WriteLine("************************************************");

            Task<int> value = DoStuff.FindSeriesSum(1000000);
            CountBig(100000);
            CountBig(100000);
            CountBig(100000);
            CountBig(100000);
            Console.WriteLine("Sum:{0}", value.Result);
        }

        private static void CountBig(int p)
        {
            for(int i = 0; i < p ; ++i)
                ;
        }
    }
}