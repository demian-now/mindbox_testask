namespace MindBoxTestTask
{
    public class Triangle: IShape
    {
        public double a { get; }
        public double b { get; }
        public double c { get; }

        public Triangle(double _a, double _b, double _c)
        {
            if(_a > 0 && _b > 0 && _c > 0)
            {
                if ((_a + _b) > _c && (_b + _c) > _a && (_a + _c) > _b)
                { 
                    a = _a; b = _b; c = _c; 
                }
                else throw new ArgumentException("there is no such triangle");
            }
            else throw new ArgumentException("side length cannot be negative");
        }
        public double GetArea()
        {
            double p = (a + b + c) * 0.5;
            return Math.Sqrt(p*(p-a)*(p-b)*(p-c));
        }

        public bool IsRectangular()
        {
            if (a >= b && a >= c) return (a * a == b * b + c * c);
            if (b >= a && b>= c) return (b * b == a * a + c * c);
            return (c*c == b * b + a * a);
        }
    }
}
