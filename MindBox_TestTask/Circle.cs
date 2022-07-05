using System;

namespace MindBoxTestTask
{
    public class Circle: IShape
    {
        public Circle(double _radius)
        {
            if(_radius > 0)
                radius = _radius;
            else throw new ArgumentException("Radius can't be negative or 0");
        }
        public double radius { get; }
        public double GetArea() => Math.PI*Math.Pow(radius, 2);
    }
}
