﻿using System;
using VXEN.TestApp.Tests;

namespace VXEN.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Test.CheckSaleTest();
            Console.WriteLine("Press Any Key To Exit");
            Console.Read();
        }
    }
}
