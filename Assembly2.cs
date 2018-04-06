using System;
using BaseClassNs;

namespace UsesBaseClass
{
    class DerivedClass:MyBaseClass{

    }

    class Program{
        static void Main()
        {
            DerivedClass mdc = new DerivedClass();
            mdc.PrintMe();
        }
    }
}