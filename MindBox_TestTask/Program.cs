using System;
using MindBoxTestTask;

namespace TestTask
{
    class Program {
        public static void Main(string[] args)
        {
            var tr = new Triangle(3, 4, 5);
            Console.WriteLine(tr.GetArea());
            Console.WriteLine(tr.IsRectangular());
        }
    }
}
