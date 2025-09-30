using System;

namespace TestTask
{
    public abstract class Shape
    {
        public abstract string Name
        {
            get;
        }

        public abstract double GetArea();
        public abstract double GetPerimeter();
        public abstract bool IsValid();
    }

    public class Circle : Shape
    {
        public double Radius
        {
            get;
        }

        public Circle(string name, double radius)
        {
            Radius = radius;
        }

        public override string Name => "Circle";

        public override double GetArea() => Math.PI * Radius * Radius;

        public override double GetPerimeter() => 2 * Math.PI * Radius;

        public override bool IsValid() => Radius > 0;
    }

    public class Parallelogram : Shape
    {
        public double BaseLength
        {
            get;
        }
        public double SideLength
        {
            get;
        }
        public double AngleDegrees
        {
            get;
        }

        public Parallelogram(string name, double baseLength, double sideLength, double angleDegrees)
        {
            BaseLength = baseLength;
            SideLength = sideLength;
            AngleDegrees = angleDegrees;
        }

        private double AngleRadians => AngleDegrees * Math.PI / 180.0;

        public override string Name => "Parallelogram";

        public override double GetArea() => BaseLength * SideLength * Math.Sin(AngleRadians);

        public override double GetPerimeter() => 2 * (BaseLength + SideLength);

        public override bool IsValid() =>
            BaseLength > 0 &&
            SideLength > 0 &&
            AngleDegrees > 0 &&
            AngleDegrees < 180;
    }

    public class Rectangle : Parallelogram
    {
        public double Width => BaseLength;
        public double Height => SideLength;

        public Rectangle(string name, double width, double height) : base(name, width, height, 90)
        {
        }

        public override string Name => "Rectangle";

        public override bool IsValid() =>
            Width > 0 && Height > 0;
    }

    public class Rhombus : Parallelogram
    {
        public double Side => BaseLength;

        public Rhombus(string name, double side, double angleDegrees)
            : base(name, side, side, angleDegrees)
        {
        }

        public override string Name => "Rhombus";

        public override bool IsValid() =>
            Side > 0 && AngleDegrees > 0 && AngleDegrees < 180;
    }

    public class Square : Rectangle
    {
        public double Side => Width;

        public Square(string name, double side)
            : base(name, side, side)
        {
        }

        public override string Name => "Square";

        public override bool IsValid() => Side > 0;
    }
}
