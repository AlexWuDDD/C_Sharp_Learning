using System;
using System.IO;

namespace Chapter9
{
    class Program
    {
        public static void MainTest()
        {
            int x = 3;
            while(x > 0)
            {
                Console.WriteLine("x : {0}", x);
                --x;
            }
            Console.WriteLine("Out of loop");
            
            Console.WriteLine("*************************************");
            int y = 0;
            do
                Console.WriteLine("y is {0}", y++);
            while(y < 3);
            Console.WriteLine("*************************************");
            /*
            在C#中，不可以执行一个switch段中的代码然后直接执行接下来的部分
             */
            Console.WriteLine("*************************************");
            using(TextWriter tw = File.CreateText("Lincoln.txt"))
            {
                tw.WriteLine("Four score and seven years ago,...");
            }
            using(TextReader tr = File.OpenText("Lincoln.txt"))
            {
                string InputString;
                while(null != (InputString = tr.ReadLine()))
                    Console.WriteLine(InputString);
            }
        }
    }
}