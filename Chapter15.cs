using System;

namespace Chapter15{
    interface IInfo{
        string GetName();
        string GetAge();
    }

    class CA : IInfo{
        public string name;
        public int Age;
        public string GetName() {return name;}
        public string GetAge() {return Age.ToString();}
    }

    class CB : IInfo{
        public string First;
        public string Last;
        public double PersonAge;
        public string GetName(){return First + " " + Last;}
        public string GetAge(){return PersonAge.ToString();}
    }

    class MyClass : IComparable
    {
        public int TheValue;
        public int CompareTo(object obj)
        {
            MyClass mc = (MyClass)obj;
            if(this.TheValue < mc.TheValue) return -1;
            if(this.TheValue > mc.TheValue) return 1;
            return 0;
        }
    }

    class Program{

        static void PrintInfo(IInfo item){
            Console.WriteLine("Name: {0}, Age: {1}", item.GetName(), item.GetAge());
        }

        static void PrintOut(string s, MyClass[] mc)
        {
            Console.Write(s);
            foreach(var m in mc)
                Console.Write("{0} ", m.TheValue);
            Console.WriteLine();
        }

        interface ILiveBirth
        {
            string BabyCalled();
        }

        class Animal{}
        class Cat : Animal, ILiveBirth
        {
            public string BabyCalled()
            {
                return "kitten";
            }
        }

        class Dog : Animal, ILiveBirth
        {
            string ILiveBirth.BabyCalled()
            {
                return "puppy";
            }
        }

        class Bird : Animal{}




        static void MainTest(){
            Console.WriteLine("Alex is cool!");
            Console.WriteLine("******************************************");
            CA a = new CA(){name = "John Doe", Age = 35};
            CB b = new CB(){First = "Jane", Last = "Doe", PersonAge = 33};

            PrintInfo(a);
            PrintInfo(b);

            Console.WriteLine("*******************************************");
            var MyInt = new []{20,4,16,9,2};
            MyClass[] mcArr = new MyClass[5];
            for(int i = 0; i < 5; ++i)
            {
                mcArr[i] = new MyClass();
                mcArr[i].TheValue = MyInt[i];
            }
            PrintOut("Initial Order: ", mcArr);
            Array.Sort(mcArr);
            PrintOut("Sorted Order: ", mcArr);

            /*
            如果一个类实现了多个接口，并且其中一些接口有相同签名和返回类型的成员，那么类可以实现单个成员
            来满足所有包含重复成员的接口
             */

            Console.WriteLine("********************************************");
            Animal[] animalArray = new Animal[3];
            animalArray[0] = new Cat();
            animalArray[1] = new Bird();
            animalArray[2] = new Dog();
            foreach(Animal m in animalArray){
                ILiveBirth n = m as ILiveBirth;
                if(n != null)
                    Console.WriteLine("Baby is called: {0}", n.BabyCalled());
            }
        }
    }
}