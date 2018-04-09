using System;

namespace Chapter13{
    
    delegate void MyDel(int value); //声明委托类型

    delegate void PrintFunction();

    delegate int MyDel1();

    delegate void MyDel2(ref int X);

    delegate double MyDel3(int par);

    class MyClass2{
        public void Add2(ref int x){x += 2;}
        public void Add3(ref int x){x += 3;}
    }
    class MyClass1{
        int IntValue = 5;
        public int Add2() {IntValue += 2; return IntValue;}
        public int Add3() {IntValue += 3; return IntValue;}
    }
    class Test{
        public void Print1()
        {Console.WriteLine("Print1 -- instance");}

        public static void Print2()
        {Console.WriteLine("Print2 -- static");}
    }
    class Program{
        void PrintLow(int value){
            Console.WriteLine("{0} - Low Value", value);
        }

        void PrintHigh(int value){
            Console.WriteLine("{0} - High Value", value);
        }
        static void Main(){
            Program program = new Program();

            MyDel del;

            Random rand = new Random();
            int randvalue = rand.Next(99);

            del = randvalue < 50 
                    ? new MyDel(program.PrintLow)
                    : new MyDel(program.PrintHigh);

            del(randvalue);
            Console.WriteLine("******************************************");
            Test t = new Test();
            PrintFunction pf;
            pf = t.Print1;
            pf += Test.Print2;
            pf += t.Print1;
            pf += Test.Print2;

            if(null != pf)
                pf();
            else
                Console.WriteLine("Delegate is empty");

            Console.WriteLine("*******************************************");
            MyClass1 mc1 = new MyClass1();
            MyDel1 mDel = mc1.Add2;
            mDel += mc1.Add3;
            mDel += mc1.Add2;
            Console.WriteLine("Value: {0}", mDel());
            Console.WriteLine("********************************************");
            MyClass2 mc2 = new MyClass2();
            MyDel2 myDel2 = mc2.Add2;
            myDel2 += mc2.Add3;
            myDel2 += mc2.Add2;

            int x = 5;
            myDel2(ref x);
            Console.WriteLine("Value: {0}", x);
            Console.WriteLine("********************************************");

            MyDel3 myDel3   =   delegate(int a)     {return a + 1;} ;//匿名方法
            MyDel3 le1      =           (int a) =>  {return a + 1;}; //Lambda表达式
            MyDel3 le2      =               (a) =>  {return a + 1;};
            MyDel3 le3      =                a  =>  {return a + 1;};
            MyDel3 le4      =                a  =>  a + 1          ;

            Console.WriteLine("{0}", myDel3(12));
            Console.WriteLine("{0}", le1(12)); Console.WriteLine("{0}", le2(12));
            Console.WriteLine("{0}", le3(12)); Console.WriteLine("{0}", le4(12));
        }
    }
}