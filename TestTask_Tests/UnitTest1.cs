using Microsoft.VisualStudio.TestTools.UnitTesting;
using MindBoxTestTask;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class CircleTest
    {
        [TestMethod]
        public void NormalCircle()
        {
            var radius = 3.0;
            var  circle = new Circle(radius);
            Assert.AreEqual((double)(Math.PI*Math.Pow(radius,2)), circle.GetArea());
        }

        [TestMethod]
        public void BadRadiusNegative()
        {
            Assert.ThrowsException<ArgumentException>(() => new Circle(-3));
        }

        [TestMethod]
        public void BadRadiusNull()
        {
            Assert.ThrowsException<ArgumentException>(() => new Circle(0));
        }
    }

    [TestClass]
    public class TriangleTest
    {
        [TestMethod]
        public void NormalTriange()
        {
            var triangle = new Triangle(3,3,3);
            Assert.AreEqual(Math.Sqrt(15.1875), triangle.GetArea());
        }

        [TestMethod]
        public void BadTriangleA()
        {
            Assert.ThrowsException<ArgumentException>(() => new Triangle(-1, 3, 4));
        }

        [TestMethod]
        public void BadTriangleB()
        {
            Assert.ThrowsException<ArgumentException>(() => new Triangle(1, -3, 4));
        }

        [TestMethod]
        public void BadTriangleC()
        {
            Assert.ThrowsException<ArgumentException>(() => new Triangle(1, 3, -4));
        }

        [TestMethod]
        public void BadTriangleUnreal()
        {
            Assert.ThrowsException<ArgumentException>(() => new Triangle(1, 3, 5));
        }

        [TestMethod]
        public void TriangleRect()
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.IsTrue(triangle.IsRectangular());
        }

        [TestMethod]
        public void TriangleNotRect()
        {
            var triangle = new Triangle(3, 3, 3);
            Assert.IsFalse(triangle.IsRectangular());
        }
    }

    [TestClass]
    public class AnotherTests
    {
        [TestMethod]
        public void ManyShapes() //тест о том, что не обязательно знать тип фигуры для расчёта её площади
        {
            var list = new List<IShape>();

            list.Add(new Circle(5));
            list.Add(new Triangle(3, 2, 3.2));
            list.Add(new Circle(10));
            list.Add(new Triangle(3, 4, 5));

            foreach (var i in list)
                i.GetArea();

            Assert.AreEqual(4, list.Count); //if true, then ok
        }

        public class Square : IShape //создаём простой новый тип - демонстрация возможности расширения
        {
            public double a;
            public Square(double _a)
            {
                if (_a > 0)
                    a = _a;
                else throw new ArgumentException("side length can't be negative");
            }
            public double GetArea() => a * a;
        }

        [TestMethod]
        public void NewType()
        {
            var square = new Square(4);
            Assert.AreEqual(16, square.GetArea());
        }
    }
}