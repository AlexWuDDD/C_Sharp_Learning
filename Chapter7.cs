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


   class Program
   {
       static void Main()
       {
           OtherClass oc = new OtherClass();
           oc.Method1(oc.Field1);
           oc.Method1(oc.Field2);
           oc.Method2(oc.Field1);
           oc.Method2(oc.Field2);
       }
   }
}