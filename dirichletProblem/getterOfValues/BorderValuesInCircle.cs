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

            for (int x = 0; x < numPointX; x++)
            {
                bottom.Add(u.getValue(rectangle.beginX + x * stepX, rectangle.beginY)); //TODO изменить чтобы попадать в круг
                top.Add(u.getValue(rectangle.beginX + x * stepX, rectangle.endY)); //TODO изменить чтобы попадать в круг
            }

            for (int y = 0; y < numPointY; y++)
            {
                left.Add(u.getValue(rectangle.beginX, rectangle.beginY + y * stepY)); //TODO изменить чтобы попадать в круг
                right.Add(u.getValue(rectangle.endX, rectangle.beginY + y * stepY)); //TODO изменить чтобы попадать в круг
            }
        }
    }
}
