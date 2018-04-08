using System;
using System.Reflection;

namespace Chapter8{

    class LimitedInt
    {
        const int MaxValue = 100;
        const int MinValue = 0;

        public static explicit operator int(LimitedInt li)
        {
            return li.TheValue;
        }

        public static implicit operator LimitedInt(int x)
        {
            LimitedInt li = new LimitedInt();
            li.TheValue = x;
            return li;
        }

        private int _theValue = 0;
        public int TheValue
        {
            get{return _theValue;}
            set{
                if(value < MinValue)
                    _theValue = 0;
                else
                    _theValue = value > MaxValue
                                    ? MaxValue
                                    : value;
            }
        }

        public static LimitedInt operator -(LimitedInt x)
        {
            //在这个奇怪的类中，取一个值得负数等于0
            LimitedInt li = new LimitedInt();
            li.TheValue = 0;
            return li;
        }

        public static LimitedInt operator -(LimitedInt x, LimitedInt y)
        {
            LimitedInt li = new LimitedInt();
            li.TheValue = x.TheValue - y.TheValue;
            return li;
        }

        public static LimitedInt operator +(LimitedInt x, double y)
        {
            LimitedInt li = new LimitedInt();
            li.TheValue = x.TheValue + (int)y;
            return li;
        }
    }

    class SomeClass
    {
        public int Field1 = 0;
        public int Field2 = 0;

        public void Method1(){}
        public int Method2(){return 1;}
    }
    class Program
    {
        public static void MainTest()
        {
            Console.WriteLine("{0}", 1024);         //整数字面量
            Console.WriteLine("{0}", 3.1416);       //双精度型字面量
            Console.WriteLine("{0}", 3.1416f);      //浮点型字面量
            Console.WriteLine("{0}", true);         //布尔型字面量
            Console.WriteLine("{0}", 'x');          //字符型字面量
            Console.WriteLine("{0}", "Hi there");   //字符串字面量

            Console.WriteLine("******************************************");
            string rst1 = "Hi, there!";
            string vst1 = @"Hi, there!";

            string rst2 = "It started, \"Four socre and seven...\"";
            string vst2 = @"It started, ""Four socre and seven...""";

            string rst3 = "Value 1 \t 5, Val2 \t 10";
            string vst3 = @"Value 1 \t 5, Val2 \t 10";

            string rst4 = "C:\\Program Files\\Microsoft\\";
            string vst4 = @"C:\Program Files\Microsoft\";

            string rst5 = " Print \x000A Multiple \u000A Lines";
            string vst5 = @" Print
 Multiple
 Lines";

            Console.WriteLine(rst1);
            Console.WriteLine(vst1);

            Console.WriteLine(rst2);
            Console.WriteLine(vst2);

            Console.WriteLine(rst3);
            Console.WriteLine(vst3);

            Console.WriteLine(rst4);
            Console.WriteLine(vst4);

            Console.WriteLine(rst5);
            Console.WriteLine(vst5);

            Console.WriteLine("********************************************");
            Console.WriteLine("0.0f % 1.5f is {0}", 0.0f % 1.5f);
            Console.WriteLine("0.5f % 1.5f is {0}", 0.5f % 1.5f);
            Console.WriteLine("1.0f % 1.5f is {0}", 1.0f % 1.5f);
            Console.WriteLine("1.5f % 1.5f is {0}", 1.5f % 1.5f);
            Console.WriteLine("2.0f % 1.5f is {0}", 2.0f % 1.5f);
            Console.WriteLine("2.5f % 1.5f is {0}", 2.5f % 1.5f);

            Console.WriteLine("********************************************");
            int x = 5, y = 4;
            Console.WriteLine("x == x is {0}", x == x);
            Console.WriteLine("x == y is {0}", x == y);

            Console.WriteLine("********************************************");
            int a = 5, b;
            b = a++;
            Console.WriteLine("b ： {0}, a ： {1}", b, a);

            a = 5;
            b = ++a;
            Console.WriteLine("b ： {0}, a ： {1}", b, a);

            a = 5;
            b = a--;
            Console.WriteLine("b ： {0}, a ： {1}", b, a);

            a = 5;
            b = --a;
            Console.WriteLine("b ： {0}, a ： {1}", b, a);

            Console.WriteLine("********************************************");
            LimitedInt li   = 500;
            int value       = (int)li;

            Console.WriteLine("li:{0}, value:{1}", li.TheValue, value);
            Console.WriteLine("li:{0}, value:{1}", li, value);

            Console.WriteLine("********************************************");
            LimitedInt li1 = new LimitedInt();
            LimitedInt li2 = new LimitedInt();
            LimitedInt li3 = new LimitedInt();
            li1.TheValue = 10; li2.TheValue = 26;
            Console.WriteLine("li1: {0}, li2: {0}", li1.TheValue, li2.TheValue);

            li3 = -li1;
            Console.WriteLine("-{0} = {1}", li1.TheValue, li3.TheValue);

            li3 = li2 - li1;
            Console.WriteLine("{0} - {1} = {2}", li2.TheValue, li1.TheValue, li3.TheValue);

            li3 = li1 - li2;
            Console.WriteLine("{0} - {1} = {2}", li1.TheValue, li2.TheValue, li3.TheValue);

            Console.WriteLine("***********************************************");
            Type t = typeof(SomeClass);
            FieldInfo[] fi = t.GetFields();
            MethodInfo[] mi = t.GetMethods();

            foreach(FieldInfo f in fi)
                Console.WriteLine("Field:{0}", f.Name);
            foreach(MethodInfo m in mi)
                Console.WriteLine("Method:{0}", m.Name);

            Console.WriteLine("**********************************************");
            SomeClass s = new SomeClass();
            Console.WriteLine("Type s : {0}", s.GetType().Name);
        }
    }
}