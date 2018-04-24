﻿using System;
using System.Threading;

namespace Timers
{
    class Program
    {
        int TimesCalled = 0;
        
        void Display(object state)
        {
            Console.WriteLine("{0}, {1}", (string)state, ++TimesCalled);
        }

        static void Main(string[] args)
        {
            Program p = new Program();

            Timer myTimer = new Timer(p.Display, "Processing timer event", 2000, 1000);
            Console.WriteLine("Timer started.");

            Console.ReadLine();
        }
    }
}