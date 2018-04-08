using System;

namespace Chapter11
{
    enum TrafficLight
    {
        Green,
        Yellow,
        red
    }

    [Flags]
    enum CardDeckSettings : uint
    {
        SingleDeck      = 0x01,
        LargePicture    = 0x02,
        FancyNumbers    = 0x04,
        Animation       = 0x08
    }

    class MyClass
    {
        bool UseSingleDeck                  = false,
             UseBigPics                     = false,
             UseFancyNumbers                = false,
             UseAnimation                   = false,
             UseAnimationAndFancyNumbers    = false;

        public void SetOptions(CardDeckSettings ops)
        {
            UseSingleDeck = ops.HasFlag(CardDeckSettings.SingleDeck);
            UseBigPics    = ops.HasFlag(CardDeckSettings.LargePicture);
            UseFancyNumbers = ops.HasFlag(CardDeckSettings.FancyNumbers);
            UseAnimation = ops.HasFlag(CardDeckSettings.Animation);

            CardDeckSettings testFlags = CardDeckSettings.Animation | CardDeckSettings.FancyNumbers;
            UseAnimationAndFancyNumbers = ops.HasFlag(testFlags);
        }

        public void PrintOptions()
        {
            Console.WriteLine("Option settings:");
            Console.WriteLine(" Use Single Deck                 - {0}", UseSingleDeck);
            Console.WriteLine(" Use Large Picture               - {0}", UseBigPics);
            Console.WriteLine(" Use Fancy Numbers               - {0}", UseFancyNumbers);
            Console.WriteLine(" Show Animation                  - {0}", UseAnimation);
            Console.WriteLine(" Show Animation and FancyNumbers - {0}", UseAnimationAndFancyNumbers);
        }
    }
    class Program
    {
        static void MainTest()
        {
            Console.WriteLine("Alex is cool!");
            Console.WriteLine("*******************************************");
            TrafficLight t1 = TrafficLight.Green;
            TrafficLight t2 = TrafficLight.Yellow;
            TrafficLight t3 = TrafficLight.red;

            Console.WriteLine("{0}, \t{1}", t1, (int)t1);
            Console.WriteLine("{0}, \t{1}", t2, (int)t2);
            Console.WriteLine("{0}, \t{1}", t3, (int)t3);
            Console.WriteLine("********************************************");

           CardDeckSettings ops;
           ops = CardDeckSettings.FancyNumbers;
           Console.WriteLine(ops.ToString());

           ops = CardDeckSettings.FancyNumbers | CardDeckSettings.Animation;
           Console.WriteLine(ops.ToString());
           Console.WriteLine("*********************************************");

           MyClass mc = new MyClass();
           CardDeckSettings ops1 = CardDeckSettings.SingleDeck
                                  | CardDeckSettings.FancyNumbers
                                  | CardDeckSettings.Animation;
            mc.SetOptions(ops1);
            mc.PrintOptions();
            Console.WriteLine("*********************************************");

            Console.WriteLine("Second member of TrafficLight is {0}\n",
                                Enum.GetName(typeof(TrafficLight), 1));
            foreach(var name in Enum.GetNames(typeof(TrafficLight)))
                Console.WriteLine(name);
        }
    }
}