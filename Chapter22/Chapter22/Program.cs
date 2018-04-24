using System;

namespace Chapter22
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            int x = 10;
            try
            {
                int y = 0;
                x /= y;
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                Console.WriteLine("Source:  {0}", e.Source);
                Console.WriteLine("Stack:   {0}", e.StackTrace);
                Console.WriteLine("Handling all exceptions - Keep on Running");
            }

            try
            {
                if (x < 20)
                {
                    Console.Write("First Branch - ");
                    return;
                }
                else
                {
                    Console.Write("Second Branch -");
                }
            }
            finally
            {
                Console.WriteLine("In finally statement");
            }
            */

            MyClass mc = new MyClass();
            try
            {
                mc.A();
            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("catch clause in Main()");
            }
            finally
            {
                Console.WriteLine("finally clause in Main()");
            }
            Console.WriteLine("After try statement in Main.");
            Console.WriteLine("             -- Keep running");


            string s = null;
            MyClass.PrintArg(s);
            MyClass.PrintArg("Hi, there");

        }

        class MyClass
        {
            public void A()
            {
                try
                {
                    B();
                }
                catch (System.NullReferenceException)
                {
                    Console.WriteLine("catch clause in A()");
                }
                finally
                {
                    Console.WriteLine("finally clause in A()");
                }

            }

            void B()
            {
                int x = 10, y = 0;
                try
                { x /= y; }
                catch(System.IndexOutOfRangeException)
                {
                    Console.WriteLine("catch clause in B()");
                }
                finally
                {
                    Console.WriteLine("finally clause in B()");
                }
            }

            public static void PrintArg(string arg)
            {
                try
                {
                    try
                    {
                        if (arg == null)
                        {
                            ArgumentNullException myEx = new ArgumentNullException("arg");
                            throw myEx;
                        }
                        Console.WriteLine(arg);
                    }
                    catch (ArgumentNullException e)
                    {
                        Console.WriteLine("Message: {0}", e.Message);
                        throw;
                    }
                }
                catch
                {
                    Console.WriteLine("Outer catch: Handling an Exception.");
                }
            }
        }
    }
}
