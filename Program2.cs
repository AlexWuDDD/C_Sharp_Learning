using System;

namespace test2
{
    class MyClass
    {
        public void ListInts(params int[] inVals)
        {
            if((inVals != null) && (inVals.Length != 0))
            {
                for(int i = 0; i < inVals.Length; ++i)
                {
                    inVals[i] = inVals[i] * 10;
                    Console.WriteLine("{0}", inVals[i]);
                }
            }
        }

        public int Calc(int a, int b, int c)
        {
            return (a + b) * c;
        }
    }

    class Program
    {
        static void Main3()
        {
            int first = 5, second = 6, third = 7;
            MyClass mc = new MyClass();
            mc.ListInts(first, second, third);
            Console.WriteLine("{0}, {1}, {2}", first, second, third);

            int[] myArr = new int[]{5,6,7};
            MyClass mc2 = new MyClass();
            mc2.ListInts(myArr);
            foreach(int x in myArr)
            {
                Console.WriteLine("{0}", x);
            }
            
            MyClass mc3 = new MyClass();
            int result = mc3.Calc(c:2, a:4, b:3);
            Console.WriteLine("{0}", result);

            Console.WriteLine("****************************************");
            MyClass mc4 = new MyClass();
            int r0 = mc4.Calc(4,3,2);
            int r1 = mc4.Calc(4, b:3, c:2);
            int r2 = mc4.Calc(4, c:2, b:3);
            int r3 = mc4.Calc(c:2, b:3, a:4);
            int r4 = mc4.Calc(c:2, b:1+2, a:3+1);

            Console.WriteLine("{0},{1},{2},{3},{4}", r0, r1, r2, r3, r4);
            Console.WriteLine("*****************************************");
        }
    }
}