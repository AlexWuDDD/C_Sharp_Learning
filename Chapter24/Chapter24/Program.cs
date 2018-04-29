//#define DoTrace
using System;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.CompilerServices;



namespace Chapter24
{
    class BaseClass
    {
        public int BaesField = 0;
    }

    class DerivedClass : BaseClass
    {
        public int DerivedField = 0;
    }


    class Program
    {
        [Obsolete("Use method SuperPrintOut", true)]
        static void PrintOut(string str)
        {
            Console.WriteLine(str);
        }

        [Conditional("DoTrace")]
        static void TraceMessage(string str)
        {
            Console.WriteLine(str);
        }

        public static void MyTrace(string message,
                                    [CallerFilePath] string fileName = "",
                                    [CallerLineNumber] int lineNumer = 0,
                                    [CallerMemberName] string callingMember = "")
        {
            Console.WriteLine("File:        {0}", fileName);
            Console.WriteLine("Line:        {0}", lineNumer);
            Console.WriteLine("Called From: {0}", callingMember);
            Console.WriteLine("Message:     {0}", message);
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("2018-4-29");

            var bc = new BaseClass();
            var dc = new DerivedClass();

            BaseClass[] bca = new BaseClass[] { bc, dc };

            foreach(var v in bca)
            {
                Type t = v.GetType();

                Console.WriteLine("Object type : {0}", t.Name);
                FieldInfo[] fi = t.GetFields();
                foreach (var f in fi)
                    Console.WriteLine("     Filed: {0}", f.Name);
                Console.WriteLine();

            }

            Type tbc = typeof(DerivedClass);
            Console.WriteLine("Result is {0}.", tbc.Name);

            Console.WriteLine("It has the following fields:");
            FieldInfo[] fi1 = tbc.GetFields();
            foreach (var f in fi1)
                Console.WriteLine("     Filed: {0}", f.Name);

            Console.WriteLine("************************************************");
            //PrintOut("Start of Main");
            TraceMessage("start of Main");
            Console.WriteLine("Doing work in Main.");
            TraceMessage("End of Main");

            Console.WriteLine("***********************************************");
            MyTrace("Simple message");



        }
    }
}
