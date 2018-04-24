using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;

delegate long MyDel(int first, int second);

namespace OtherAsync
{
    class Program
    {
        static long Sum(int x, int y)
        {
            Console.WriteLine("             Inside Sum");
            Thread.Sleep(100);

            return x + y;
        }

        static void CallWhenDone(IAsyncResult iar)
        {
            Console.WriteLine("                 Inside CallWhenDone.");
            AsyncResult ar = (AsyncResult)iar;
            MyDel del = (MyDel)ar.AsyncDelegate;

            long result = del.EndInvoke(iar);
            Console.WriteLine("                         The Result os :{0}", result);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("2018-4-24");
            MyDel del = new MyDel(Sum);
            /*
            Console.WriteLine("Before BeginInvoke");
            IAsyncResult iar = del.BeginInvoke(3, 5, null, null);//开始异步调用
            Console.WriteLine("After BeginInVoke");
            */
            /* 等待到一直结束模式
            Console.WriteLine("Doing stuff");

            long result = del.EndInvoke(iar); //等待结束并获取结果
            Console.WriteLine("After EndInvoke:{0}", result);
            */
            /*轮询模式
            while(!iar.IsCompleted) //检查异步方法是否完成
            {
                Console.WriteLine("Not Done");
                //继续处理
                for (long i = 0; i < 10000000; ++i)
                    ;
            }
            Console.WriteLine("Done");
            long result = del.EndInvoke(iar);//调用EndInvoke来获取接口并进行处理
            Console.WriteLine("Result:{0}", result);
            */
            //回调模式
            Console.WriteLine("Before BeginInvode");
            IAsyncResult iar = del.BeginInvoke(3, 5, new AsyncCallback(CallWhenDone), null);

            Console.WriteLine("Doing more work in Main");
            Thread.Sleep(500);
            Console.WriteLine("Done with Main. Exiting");

        }
    }
}
