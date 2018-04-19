using System;
using System.Collections;

namespace Chapter18
{
    class ColorEnumerator : IEnumerator
    {
        string[] _colors;
        int _position = -1;

        public ColorEnumerator(string[] theColors)
        {
            _colors = new string[theColors.Length];
            for(int i = 0; i < theColors.Length; ++i)
            {
                _colors[i] = theColors[i];
            }
        }

        public object Current
        {
            get
            {
                if(_position == -1)
                    throw new InvalidOperationException();
                if(_position >= _colors.Length)
                    throw new InvalidOperationException();

                return _colors[_position];
            }
        }

        public bool MoveNext()
        {
            if(_position < _colors.Length - 1)
            {
                _position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            _position = -1;
        }
    }

    class Spectrum : IEnumerable
    {
        string[] Colors = {"violet", "blue", "cyan", "green", "yellow", "orange", "red"};

        public IEnumerator GetEnumerator()
        {
            return new ColorEnumerator(Colors);
        }
    }

    class MyClass
    {
        public IEnumerator GetEnumerator()
        {
            return BlackAndWhite();
        }
    

        public IEnumerator BlackAndWhite()
        {   
            yield return "black";
            yield return "gray";
            yield return "white";
        }
    }
    class Program
    {
        static void MainTest()
        {
            Console.WriteLine("2018-4-18");

            int[]  arr1 = {10,11,12,13};
            foreach(int item in arr1)
                Console.WriteLine("Item value: {0}", item);
            Console.WriteLine("********************************************");

            int[] MyArray = {10,11,12,13};
            IEnumerator ie = MyArray.GetEnumerator();

            while(ie.MoveNext())
            {
                int i = (int)ie.Current;
                Console.WriteLine("{0}", i);
            }
            Console.WriteLine("********************************************");

            Spectrum spectrum = new Spectrum();
            foreach(string color in spectrum)
                Console.WriteLine(color);
            Console.WriteLine("********************************************");

            MyClass mc = new MyClass();
            foreach(string shade in mc)
                Console.WriteLine(shade);
            Console.WriteLine("2018-4-19");
            
            
        
        }
    }
}