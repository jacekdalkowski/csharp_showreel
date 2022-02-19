﻿using System;

namespace CsharpShowreel
{
    class Program
    {
        static void Main(string[] args)
        {
            var readonlyProperties = new CsharpOne.ReadonlyProperties();
            var weaklyTypedCollections = new CsharpOne.WeaklyTypedCollections();

            new CsharpTwo();
            new CsharpThree();
            new CsharpFour();
            new CsharpFive();
            new CsharpSix();
        }
    }
}
