using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dirichletProblem.Functions;

namespace dirichletProblem.getterOfValues
{
    class BorderValuesInCircle : BorderValues
    {
        public BorderValuesInCircle(Rectangle rectangle, int numPointX, int numPointY, Function u)
            : base(rectangle, numPointX, numPointY, u)
        {

        }

        protected override void getValues(Rectangle rectangle, int numPointX, int numPointY, Function u)
        {
            this.rectangle = rectangle;

            bottom = new List<double>(numPointX);
            top = new List<double>(numPointX);
            left = new List<double>(numPointY);
            right = new List<double>(numPointY);

            double stepX = (rectangle.endX - rectangle.beginX) / (numPointX - 1);
            double stepY = (rectangle.endY - rectangle.beginY) / (numPointY - 1);

            double radius = (rectangle.endX - rectangle.beginX) / 2;

            for (int x = 0; x < numPointX; x++)
            {
                double realX = rectangle.beginX + x * stepX;

                bottom.Add(u.getValue(realX, -Math.Sqrt(radius*radius - realX*realX)));
                top.Add(u.getValue(realX, Math.Sqrt(radius * radius - realX * realX)));
            }

            for (int y = 0; y < numPointY; y++)
            {
                double realY = rectangle.beginY + y * stepY;

                left.Add(u.getValue(-Math.Sqrt(radius * radius - realY * realY), realY));
                right.Add(u.getValue(Math.Sqrt(radius * radius - realY * realY), realY));
            }
        }
    }
}
