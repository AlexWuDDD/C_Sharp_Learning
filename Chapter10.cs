using System;

struct Point
{
    public int x;
    public int y;
}

struct Simple
{
    public int x;
    public int y;
    public Simple(int a, int b)
    {
        x = a;
        y = b;
    }
}

namespace Chapter10
{
    class Program{
        static void MainTest()
        {
            Point first, second, third;
            first.x = 10; first.y = 10;
            second.x = 10; second.y = 10;
            third.x = first.x + second.x;
            third.y = first.y + second.y;

            Console.WriteLine("first: {0}, {1}", first.x, first.y);
            Console.WriteLine("second: {0}, {1}", second.x, second.y);
            Console.WriteLine("third: {0}, {1}", third.x, third.y);

            Console.WriteLine("*************************************************");
            Simple s1 = new Simple();
            Simple s2 = new Simple(5,10);

            Console.WriteLine("{0}, {1}", s1.x, s1.y);
            Console.WriteLine("{0}, {1}", s2.x, s2.y);




        }
    }
}