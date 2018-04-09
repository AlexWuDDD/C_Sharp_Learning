using System;

namespace Chapter12{
    class Program{

        public static void PrintArray(int[] a)
        {
            foreach(var x in a)
                Console.WriteLine("{0} ", x);

            Console.WriteLine("");
        }
        static void MainTest()
        {
            Console.WriteLine("Alex is cool!");
            Console.WriteLine("********************************");

            int[] intArr1 = new int[15];
            intArr1[2] = 10;
            int var1 = intArr1[2];

            int[,]intArr2 = new int[5,10];
            intArr2[2,3] = 7;
            int var2 = intArr2[2,3];

            int[] myIntArray = new int[4];
            for(int i = 0; i < 4; ++i)
            {
                myIntArray[i] = i*10;
            }

            for(int i = 0; i < 4; ++i)
                Console.WriteLine("Value of element {0} = {1}", i , myIntArray[i]);
            Console.WriteLine("*********************************");

            int[][,]Arr = new int[3][,];
            Arr[0] = new int[,]{{10,20},
                                {100,200}};
            Arr[1] = new int[,]{{30,40,50},
                                {300,400,500}};
            Arr[2] = new int[,]{{60,70,80,90},
                                {600,700,800,900}};
            for(int i = 0; i < Arr.GetLength(0); ++i)
            {
                for(int j = 0; j < Arr[i].GetLength(0); ++j)
                {
                    for(int k = 0; k < Arr[i].GetLength(1); ++k)
                    {
                        Console.WriteLine("[{0}][{1},{2}] = {3}", i,j,k,Arr[i][j,k]);
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("****************************************");

            int total = 0;
            int[][] arr1 = new int[2][];
            arr1[0] = new int[]{10,11};
            arr1[1] = new int[]{12,13,14};
            foreach(int[] array in arr1)
            {
                Console.WriteLine("Starting new array");
                foreach(int item in array)
                {
                    total += item;
                    Console.WriteLine(" Item:{0}, Current Total: {1}", item, total);
                }
            }
            Console.WriteLine("***************************************");

            int[] myArr = new int[]{15,20,5,25,10};
            PrintArray(myArr);

            Array.Sort(myArr);
            PrintArray(myArr);

            Array.Reverse(myArr);
            PrintArray(myArr);

            Console.WriteLine();
            Console.WriteLine("Rank = {0}, Length = {1}", myArr.Rank, myArr.Length);
            Console.WriteLine("GetLength(0)     = {0}", myArr.GetLength(0));
            Console.WriteLine("GetType()        = {0}", myArr.GetType());











        }
    }



}