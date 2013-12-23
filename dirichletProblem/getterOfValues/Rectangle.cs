using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dirichletProblem.getterOfValues
{
    class Rectangle
    {
        public double beginX { get; private set; }
        public double beginY { get; private set; }
        public double endX { get; private set; }
        public double endY { get; private set; }

        public Rectangle(double beginX, double endX, double beginY, double endY)
        {
            this.beginX = beginX;
            this.endX = endX;
            this.beginY = beginY;
            this.endY = endY;
        }
    }
}
