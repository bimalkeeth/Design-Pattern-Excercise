using System;
using System.Collections.Generic;
using System.Threading;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ActivateOpenClose.CallFunction();
            BuilderExec.Execute();
        }
    }
}