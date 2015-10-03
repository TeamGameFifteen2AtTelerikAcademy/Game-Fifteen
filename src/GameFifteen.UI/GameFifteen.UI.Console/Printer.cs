﻿namespace GameFifteen.UI.Console
{
    using System;

    internal class Printer : Logic.IPrinter
    {
        public void Print(object obj)
        {
            Console.Write(obj);
        }

        public void PrintLine(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}