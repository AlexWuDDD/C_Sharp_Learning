using System;
namespace Chapter17
{
    class MyStack<T>
    {
        T[] StackArray;
        int StackPointer = 0;
        public void Push(T x)
        {
            if(!IsStackFull)
                StackArray[StackPointer++] = x;
        }
        public T Pop()
        {
            return (!IsStackEmpty)
                ? StackArray[--StackPointer]
                : StackArray[0];
        }

        const int MaxStack = 10;
        bool IsStackFull {get{ return StackPointer >= MaxStack;}}
        bool IsStackEmpty {get{ return StackPointer <= 0;}}
        public MyStack()
        {
            StackArray = new T[MaxStack];
        }
        public void Print()
        {
            for(int i = StackPointer-1; i >= 0; i--)
            {
                Console.WriteLine(" Value: {0}", StackArray[i]);
            }
        }
    }

    class Simple
    {
        static public void ReverseAndPrint<T>(T[] arr)
        {
            Array.Reverse(arr);
            foreach(T item in arr)
                Console.Write("{0}, ", item.ToString());
            Console.WriteLine("");
        }
    }

    class Holder<T>
    {
        T[] Vals = new T[3];
        public Holder(T v0, T v1, T v2)
        {Vals[0] = v0; Vals[1] = v1; Vals[2] = v2;}

        public T[] GetValues() {return Vals;}
    }

    static class ExtendHolder
    {
        public static void Print<T>(this Holder<T> h)
        {
            T[] vals = h.GetValues();
            Console.WriteLine("{0},\t{1},\t{2}", vals[0], vals[1], vals[2]);
        }
    }

    struct PieceOfData<T>
    {
        public PieceOfData(T value){_data = value;}
        private T _data;
        public T Data
        {
            get{return _data;}
            set{_data = value;}
        }
    }

    delegate void MyDelegate<T>(T value);

    class Simple1
    {
        static public void PrintString(string s)
        {
            Console.WriteLine(s);
        }

        static public void PrintUpperString(string s)
        {
            Console.WriteLine("{0}", s.ToUpper());
        }
    }

    delegate TR Func<T1, T2, TR>(T1 p1, T2 p2);

    class Simple2
    {
        static public string PrintString(int p1, int p2)
        {
            int total = p1 + p2;
            return total.ToString();
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Alex 2018-4-16");
            Console.WriteLine("*************************************");

            MyStack<int> StackInt = new MyStack<int>();
            MyStack<String> StackString = new MyStack<string>();

            StackInt.Push(3);
            StackInt.Push(5);
            StackInt.Push(7);
            StackInt.Push(9);
            StackInt.Print();

            StackString.Push("This is fun");
            StackString.Push("Hi there!");
            StackString.Print();
            Console.WriteLine("**************************************");

            var intArray    = new int[] {3,5,7,9,11};
            var stringArray = new string[] {"first", "second", "third"};
            var doubleArray = new double[] {3.567, 7.891, 2.345};

            Simple.ReverseAndPrint<int>(intArray);
            Simple.ReverseAndPrint(intArray);

            Simple.ReverseAndPrint<string>(stringArray);
            Simple.ReverseAndPrint(stringArray);

            Simple.ReverseAndPrint<double>(doubleArray);
            Simple.ReverseAndPrint(doubleArray);
            Console.WriteLine("***************************************");

            var intHolder = new Holder<int>(3,5,7);
            var stringHolder = new Holder<string>("a1", "b2", "c3");
            intHolder.Print();
            stringHolder.Print();
            Console.WriteLine("***************************************");

            var intData = new PieceOfData<int>(10);
            var stringData = new PieceOfData<string>("Hi there.");

            Console.WriteLine("intData = {0}", intData.Data);
            Console.WriteLine("stringData = {0}", stringData.Data);
            Console.WriteLine("***************************************");

            var MyDel = new MyDelegate<string>(Simple1.PrintString);
            MyDel += Simple1.PrintUpperString;

            MyDel("Hi, there!");
            Console.WriteLine("****************************************");

            var MyDel1 = new Func<int, int, string>(Simple2.PrintString);
            Console.WriteLine("Total: {0}", MyDel1(15,13));
            Console.WriteLine("****************************************");

            
            
        }
    }
}