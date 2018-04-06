using System;

namespace Chapter7
{
   class SomeClass
   {
       public string Field1 = "base class field";
       public void Method1(string value)
       {
           Console.WriteLine("Base class -- Method1: {0}", value);
       }
   } 

   class OtherClass : SomeClass
   {
       public string Field2 = "derived class field";
       public void Method2(string value)
       {
           Console.WriteLine("Derived class -- Method: {0}", value);
       }
   }

    class SomeClass1
    {
        public string Field1 = "SomeClass1 Field1";
        public void Method1(string value)
        {
            Console.WriteLine("SomeClass1.Method1: {0}", value);
        }
    }

    class OtherClass1 : SomeClass1
    {
        new public string Field1 = "OtherClass1 Field1";
        new public void Method1(string value)
        {
            Console.WriteLine("OtherClass1.Method1: {0}", value);
        }
    }

    class SomeClass2
    {
        public string Field1 = "Field1 -- In the base class";
    }

    class OtherClass2 : SomeClass2
    {
        new public string Field1 = "Field1 -- In the derived class";
        public void PrintField1()
        {
            Console.WriteLine(Field1);
            Console.WriteLine(base.Field1);
        }
    }

    class MyBaseClass
    {
        public void Print()
        {
            Console.WriteLine("This is the base class.");
        }
    }

    class MyDerivedClass : MyBaseClass
    {
        new public void Print()
        {
            Console.WriteLine("This is the derived class");
        }
    }

    class MyBaseClass1
    {
        virtual public void Print()
        {
            Console.WriteLine("This is the base class.");
        }
    }

    class MyDerivedClass1 : MyBaseClass1
    {
        override public void Print()
        {
            Console.WriteLine("This is the derived class");
        }
    }

    class MyBaseClass2
    {
        virtual public void Print()
        {
            Console.WriteLine("This is the base class.");
        }
    }

    class MyDerivedClass2 : MyBaseClass2
    {
        override public void Print()
        {
            Console.WriteLine("This is the derived class.");
        }
    }

    class SecondDerived2 : MyDerivedClass2
    {
        /* 
        override public void Print()
        {
            Console.WriteLine("This is the second derived class.");
        }
        */
        new public void Print()
        {
            Console.WriteLine("This is the second derived class.");
        }
    }

    class MyBaseClass3
    {
        private int _myInt = 5;
        virtual public int MyProperty
        {
            get{return _myInt;}
        }
    }

    class MyDerivedClass3 : MyBaseClass3
    {
        private int _myInt = 10;
        override public int MyProperty
        {
            get{return _myInt;}
        }
    }

    abstract class AbClass
    {
        public void IdentifyBase()
        {Console.WriteLine("I am AbClass");}

        abstract public void IdentifyDerived();
    }

    class DerivedClass : AbClass
    {
        override public void IdentifyDerived()
        {Console.WriteLine("I am DerivedClass");}
    }

    abstract class MyBase
    {
        public int SideLength   = 10;
        const int TriangleSideCount = 3;

        abstract public void PrintStuff(string s);
        abstract public int MyInt{get; set;}

        public int PerimeterLength()
        {
            return TriangleSideCount * SideLength;
        }
    }

    class MyClass : MyBase
    {
        public override void PrintStuff(string s)
        {
            Console.WriteLine(s);
        }

        private int _myInt;
        public override int MyInt
        {
            get{return _myInt;}
            set{_myInt = value;}
        }
    }

    static public class MyMath
    {
        public static float PI = 3.14f;
        public static bool IsOdd(int x)
        {return x%2 == 1;}

        public static int Times2(int x)
        {return 2*x;}
    }

    class MyData
    {
        private double D1;
        private double D2;
        private double D3;

        public MyData(double d1, double d2, double d3)
        {
            D1 = d1; D2 = d2; D3 = d3;
        }

        public double Sum()
        {
            return D1 + D2 + D3;
        }
    }

    static class ExtendMyData
    {
        public static double Average(this MyData md)
        {
            return md.Sum() / 3;
        }
    }

   class Program
   {
       static void Main()
       {
           OtherClass oc = new OtherClass();
           oc.Method1(oc.Field1);
           oc.Method1(oc.Field2);
           oc.Method2(oc.Field1);
           oc.Method2(oc.Field2);

           Console.WriteLine("*****************************");
           OtherClass1 oc1 = new OtherClass1();
           oc1.Method1(oc1.Field1);

           Console.WriteLine("******************************");
           OtherClass2 oc2 = new OtherClass2();
           oc2.PrintField1();

           Console.WriteLine("*******************************");
           MyDerivedClass derived = new MyDerivedClass();
           MyBaseClass mybc = (MyBaseClass)derived;

           derived.Print();
           mybc.Print();

           Console.WriteLine("********************************");
           MyDerivedClass1 derived1 = new MyDerivedClass1();
           MyBaseClass1 mybc1 = (MyBaseClass1)derived1;

           derived1.Print();
           mybc1.Print();

           Console.WriteLine("*********************************");
           SecondDerived2 derived2 = new SecondDerived2();
           MyBaseClass2 mybc2 = (MyBaseClass2)derived2;

           derived2.Print();
           mybc2.Print();

           Console.WriteLine("**********************************");
           MyDerivedClass3 derived3 = new MyDerivedClass3();
           MyBaseClass3 mybc3 = (MyBaseClass3)derived3;
           
           Console.WriteLine(derived3.MyProperty);
           Console.WriteLine(mybc3.MyProperty);

           Console.WriteLine("***********************************");
           DerivedClass b = new DerivedClass();
           b.IdentifyBase();
           b.IdentifyDerived();

           Console.WriteLine("***********************************");
           MyClass mc = new MyClass();
           mc.PrintStuff("This is a string");
           mc.MyInt = 28;
           Console.WriteLine(mc.MyInt);
           Console.WriteLine("Perimeter Length: {0}", mc.PerimeterLength());
           
           Console.WriteLine("************************************");
           int val = 3;
           Console.WriteLine("{0} is odd is {1}", val, MyMath.IsOdd(val));
           Console.WriteLine("{0} * 2 = {1}", val, MyMath.Times2(val));

           Console.WriteLine("*************************************");
           MyData md = new MyData(3,4,5);
           Console.WriteLine("Sum: {0}", md.Sum());
           Console.WriteLine("Average: {0}", ExtendMyData.Average(md));
           Console.WriteLine("Average: {0}", md.Average());
       }
   }
}