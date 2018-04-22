using System;
using System.Threading.Tasks;

namespace TaskParellel
{
    class Porgram
    {
        static void MainTest()
        {
            Console.WriteLine("2018-4-22");
            Parallel.For(0, 15, i =>
                Console.WriteLine("The square of {0} is {1}", i, i * i));

            const int MaxValues = 50;
            int[] square = new int[MaxValues];

            Parallel.For(0, MaxValues, i => square[i] = i * i);
            foreach(var i in square)
                Console.Write(i + " ");
            Console.WriteLine();

            string[] squares = new string[]
                    {"We", "hold", "these", "truths", "to", "be", "self-evident",
                     "that", "all", "men", "are", "created", "equal"};
            
            Parallel.ForEach(squares,
                i=> Console.WriteLine(string.Format("{0} has {1} letters",i, i.Length)));

        }
        
    }
    
}