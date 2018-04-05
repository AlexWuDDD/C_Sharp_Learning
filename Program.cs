using System;

namespace MyCSharpLearning
{
    class Program2
    {   static void Main2(string[] args)
        {
            

            //Chapter1Exe();
            //PrintNums();
            /* 
            DaysTemp t1 = new DaysTemp();
            DaysTemp t2 = new DaysTemp();

            t1.High = 76; t1.Low = 57;
            t2.High = 75; t2.Low = 53;

            Console.WriteLine("t1 : {0}, {1}, {2}", t1.High, t1.Low, t1.Average());
            Console.WriteLine("t2 : {0}, {1}, {2}", t2.High, t2.Low, t2.Average());
            */

            /* 
            MyClass a1 = new MyClass();
            int a2 = 10;
            //MyMethod(a1, a2);
            MyMethod(ref a1, ref a2);
            Console.WriteLine("a1.val : {0}, a2 : {1}", a1.val, a2);
            */
            /*
            MyClass a1 = new MyClass();
            Console.WriteLine("Before method call : {0}", a1.val);
            //RefAsParameter(a1);
            RefAsParameter(ref a1);
            Console.WriteLine("After method call: {0}", a1.val);
            */
        }

        static void Chapter1Exe()
        {
            Console.WriteLine("Hello World!");
            Console.Write("This is txt1");
            Console.Write("This is txt2");
            Console.Write("This is txt3");
            Console.WriteLine();
            Console.WriteLine("*************************");
            int MyVal = 500;
            Console.WriteLine("|{0,10}|", MyVal);
            Console.WriteLine("|{0,-10}|", MyVal);
            Console.WriteLine("*************************");
            double MyDouble = 12.345678;
            Console.WriteLine("{0,-10:G} -- General",                       MyDouble);
            Console.WriteLine("{0,-10} -- Default,same as General",         MyDouble);
            Console.WriteLine("{0,-10:F4} -- Fixed Point, 4 dec places",    MyDouble);
            Console.WriteLine("{0,-10:C} -- Currency",                      MyDouble);
            Console.WriteLine("{0,-10:E3} -- Sci. Notation, 3 dec places",  MyDouble);
            Console.WriteLine("{0,-10:X} -- Hexadecimal integer",           16);
            Console.WriteLine("**************************");
        }

        static void PrintNums()
        {
            Console.WriteLine("1");
            Console.WriteLine("2");
        }

        /*
        static void MyMethod(MyClass f1, int f2)
        {
            f1.val = f1.val + 5;
            f2 = f2 + 5;
            Console.WriteLine("f1.val : {0}, f2 : {1}", f1.val, f2);
        }
        */
        
        static void MyMethod(ref MyClass f1,  ref int f2)
        {
            f1.val = f1.val + 5;
            f2 = f2 + 5;
            Console.WriteLine("f1.val : {0}, f2 : {1}", f1.val, f2);
        }

        /*    
        static void RefAsParameter(MyClass f1)
        {
            f1.val = 50;
            Console.WriteLine("After member assignment: {0}", f1.val);
            f1 = new MyClass();
            Console.WriteLine("After new object creation: {0}", f1.val);
        }
        */
        
        static void RefAsParameter(ref MyClass f1)
        {
            f1.val = 50;
            Console.WriteLine("After member assignment: {0}", f1.val);
            f1 = new MyClass();
            Console.WriteLine("After new object creation: {0}", f1.val);
        }
              


    }
}


class DaysTemp
{
    public int High = 0, Low = 0;
    public int Average()
    {
        return (High + Low) / 2;
    }
}

class MyClass
{
    public int val = 20;
}
