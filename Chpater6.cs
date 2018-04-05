using System;

namespace Chapter6
{
    class D
    {
        int         Mem1;
        static int  Mem2;

        public void SetVars(int v1, int v2)
        {Mem1 = v1; Mem2 = v2;}

        public void Display(string str)
        {
            Console.WriteLine("{0} : Mem1 = {1}, Mem2 = {2}", str, Mem1, Mem2);
        }
    }

    class X
    {
        public static int A;
        public static void PrintValA()
        {
            Console.WriteLine("Value of A : {0}", A);
        }
        public const double PI = 3.1416;
    }

    class C1
    {
        private int TheRealValue = 10;
        public int MyValue
        {
            set
            {
                TheRealValue = value;
            }
            get
            {
                return TheRealValue;
            }
        }
    }

    class RightTriangle
    {
        public double A = 3;
        public double B = 4;
        public double Hypotenuse
        {
            get
            {
                return Math.Sqrt(A*A + B*B);
            }
        }
    }

    class C2
    {
        public int MyValue
        {
            set;get;
        }
    }
    class Trivial
    {
        public static int MyValue {get;set;}
        public void PrintValue()
        {
            Console.WriteLine("Value from inside:{0}", MyValue);
        }
    }

    class Class1
    {
        int Id;
        string Name;
        public Class1()             {Id = 28; Name = "Nemo";}
        public Class1(int val)      {Id = val; Name = "Nemo";}
        public Class1(string name)  {Name = name;}
        public void SoundOff()
        {
            Console.WriteLine("Name {0}, Id {1}", Name, Id);
        }
    }

    class RandomNumberClass
    {
        private static Random RandomKey;
        static RandomNumberClass()
        {
            RandomKey = new Random();
        }

        public int GetRandomNumber()
        {
            return RandomKey.Next();
        }
    }

    class Point
    {
        public int X = 1;
        public int Y = 2;
    }

    class Employee
    {
        public string LastName;
        public string FirstName;
        public string CityOfBirth;

        public string this[int index]
        {
            set
            {
                switch(index){
                    case 0 : LastName = value;
                        break;
                    case 1 : FirstName = value;
                        break;
                    case 2 : CityOfBirth = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("index"); 
                }
            }

            get
            {
                switch(index){
                    case 0 : return LastName;
                    case 1 : return FirstName;
                    case 2 : return CityOfBirth;

                    default:
                        throw new ArgumentOutOfRangeException("index");

                }

            }
        }
    }


    class Program
    {
        static void Main2()
        {
            {
                D d1 = new D();
                D d2 = new D();
                d1.SetVars(2,4);
                d1.Display("d1");

                d2.SetVars(15, 17);
                d2.Display("d2");

                d1.Display("d1");
            }
            Console.WriteLine("*****************************");
            {
                X.A = 10;
                X.PrintValA();
                Console.WriteLine("pi = {0}", X.PI);
            }
            Console.WriteLine("*****************************");
            {
                C1 C = new C1();
                Console.WriteLine("MyValue : {0}", C.MyValue);
                C.MyValue = 20;
                Console.WriteLine("MyValue : {0}", C.MyValue);
            }
            Console.WriteLine("******************************");
            {
                RightTriangle c = new RightTriangle();
                Console.WriteLine("Hypotenuse:{0}", c.Hypotenuse);
            }
            Console.WriteLine("*******************************");
            {
                C2 c = new C2();
                Console.WriteLine("MyValue: {0}", c.MyValue);
                c.MyValue = 20;
                Console.WriteLine("MyValue: {0}", c.MyValue);
            }
            Console.WriteLine("********************************");
            {
                Console.WriteLine("Init Value: {0}", Trivial.MyValue);
                Trivial.MyValue = 10;
                Console.WriteLine("New Value : {0}", Trivial.MyValue);
                Trivial tr = new Trivial();
                tr.PrintValue();
            }
            Console.WriteLine("*********************************");
            {
                Class1 a = new Class1();
                Class1 b = new Class1(7);
                Class1 c = new Class1("Bill");

                a.SoundOff();
                b.SoundOff();
                c.SoundOff();
            }
            Console.WriteLine("*********************************");
            {
                RandomNumberClass a = new RandomNumberClass();
                RandomNumberClass b = new RandomNumberClass();

                Console.WriteLine("Next Random #: {0}", a.GetRandomNumber());
                Console.WriteLine("Next Random #: {0}", b.GetRandomNumber());
            }
            Console.WriteLine("**********************************");
            {
                Point pt1 = new Point();
                Point pt2 = new Point { X = 5, Y = 6};
                Console.WriteLine("pt1: {0}, {1}", pt1.X, pt2.Y);
                Console.WriteLine("pt2：{0}, {1}", pt2.X, pt2.Y);
            }
            Console.WriteLine("**********************************");
            {
                Employee emp1 = new Employee();
                emp1[0] = "Doe";
                emp1[1] = "Jane";
                emp1[2] = "Dallas";
                Console.WriteLine("{0}", emp1[0]);
                Console.WriteLine("{0}", emp1[1]);
                Console.WriteLine("{0}", emp1[2]);
                
            }


        }
    }
}