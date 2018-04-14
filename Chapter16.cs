using System;
namespace Chapter16
{
    class Program
    {
        class A {public int Field1;}
        class B: A {public int Field2;}
        class Person
        {
            public string Name;
            public int Age;

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public static implicit operator int(Person P)
            {
                return P.Age;
            }

            public static implicit operator Person(int i)
            {
                return new Person("Nemo", i);
            }
        }

        class Employee : Person1 {}

        class Person1
        {
            public string Name;
            public int Age;
            public static implicit operator int(Person1 P)
            {
                return P.Age;
            }
        }

        class Employee1 : Person2 {}

        class Person2
        {
            public string Name = "Anonymous";
            public int Age = 25;
        }
        static void Main()
        {
            ushort sh =10;
            byte sb = (byte)sh;
            Console.WriteLine("Sh : {0} = 0x{0:X}",sb);

            sh = 1365;
            sb = (byte)sh;
            Console.WriteLine("Sh : {0} = 0x{0:X}",sb); 

            Console.WriteLine("************************************************");

            sh = 2000;
            sb = unchecked((byte)sh);
            Console.WriteLine("Sh : {0} = 0x{0:X}",sb);
/*
            sb = checked((byte)sh);
            Console.WriteLine("Sh : {0} = 0x{0:X}",sb);
*/
            Console.WriteLine("**************************************************");
            B myVar1 = new B();
            A myVar2 = (A)myVar1;
            Console.WriteLine("{0}",myVar2.Field1);
            Console.WriteLine("{0}",myVar1.Field2);       

            Console.WriteLine("***************************************************");
            int i = 10;
            object oi = i;
            Console.WriteLine("i:{0}, io: {1}", i, oi);

            i = 12;
            oi = 15;
            Console.WriteLine("i:{0}, io: {1}", i, oi);

            Console.WriteLine("****************************************************");
            int k = 10;
            object ok = k;

            int h = (int)ok;
            Console.WriteLine("i: {0}, oi: {1}, j: {2}", k, ok, h);    

            Console.WriteLine("****************************************************");
            Person bill = new Person("bill", 25);

            int age = bill;
            Console.WriteLine("Person Info: {0}, {1}", bill.Name, age);

            Person anon = 35;
            Console.WriteLine("Person Info: {0}, {1}", anon.Name, anon.Age);

            Console.WriteLine("****************************************************");
            Employee bill1 = new Employee();
            bill1.Name = "William";
            bill1.Age = 25;

            float fvar = bill1;
            Console.WriteLine("Person Info: {0}, {1}", bill1.Name, fvar);     

            Console.WriteLine("*****************************************************");
            Employee1 bill2 = new Employee1();
            Person2 p2;
            if(bill2 is Person2)
            {
                p2 = bill2;
                Console.WriteLine("Person Info: {0}, {1}", p2.Name, p2.Age);                 
            }

            Employee1 bill3 = new Employee1();

            p2 = bill3 as Person2;
            if(null != p2)
            {
                Console.WriteLine("Person Info: {0}, {1}", p2.Name, p2.Age);               
            }


        }
    }
}