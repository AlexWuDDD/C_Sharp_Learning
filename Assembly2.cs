using System;
using BaseClassNs;

namespace UsesBaseClass
{
    class DerivedClass:MyBaseClass{

    }

    class Program{
        static void MainTest()
        {
            DerivedClass mdc = new DerivedClass();
            mdc.PrintMe();
        }
    }
}