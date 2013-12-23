using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dirichletProblem.Functions;

namespace dirichletProblem.getterOfValues
{
    class BorderValues
    {
        public List<double> bottom { get; private set; }
        public List<double> top { get; private set; }
        public List<double> left { get; private set; }
        public List<double> right { get; private set; }

        public Rectangle rectangle { get; private set; }

        public int sizeX { get { return bottom.Count; } }

        public int sizeY { get { return left.Count; } }

        public double stepX
        {
            get { return (rectangle.endX - rectangle.beginX) / (sizeX - 1); }
        }

        public double stepY
        {
            get { return (rectangle.endY - rectangle.beginY) / (sizeY - 1); }
        }

        public double beginX { get { return rectangle.beginX; } }

        public double beginY { get { return rectangle.beginY; } }

        public double endX { get { return rectangle.endX; } }

        public double endY { get { return rectangle.endY; } }

        public BorderValues(Rectangle rectangle, int numPointX, int numPointY, Function u)
        {
            this.rectangle = rectangle;

            bottom = new List<double>(numPointX);
            top = new List<double>(numPointX);
            left = new List<double>(numPointY);
            right = new List<double>(numPointY);

            double stepX = (rectangle.endX - rectangle.beginX) / (numPointX - 1);
            double stepY = (rectangle.endY - rectangle.beginY) / (numPointY - 1);

            for (int x = 0; x < numPointX; x++)
            {
                bottom.Add(u.getValue(rectangle.beginX + x*stepX, rectangle.beginY));
                top.Add(u.getValue(rectangle.beginX + x*stepX, rectangle.endY));
            }

            for (int y = 0; y < numPointY; y++)
            {
                left.Add(u.getValue(rectangle.beginX, rectangle.beginY + y * stepY));
                right.Add(u.getValue(rectangle.endX, rectangle.beginY + y * stepY));
            }
        }
    }
}