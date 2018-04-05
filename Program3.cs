using System;
namespace test3
{
    class Program
    {
        static void MethodA(int par1, int par2)
        {
            Console.WriteLine("Enter MethodA: {0}, {1}", par1, par2);
            MethodB(11, 18);
            Console.WriteLine("Exit MethodA");
        }

        static void MethodB(int par1, int par2)
        {
            Console.WriteLine("Enter MethodB: {0}, {1}", par1, par2);
            Console.WriteLine("Exit MethodB");
        }

        static void Count(int inVal)
        {
            if(inVal == 0)
                return;
            Count(inVal - 1);
            Console.WriteLine("{0}", inVal);
        }

        static void Main4()
        {

            //Console.WriteLine("Enter Main");
            //MethodA(15, 30);
            //Console.WriteLine("Exit Main");
            Count(3);
        }
    }
}