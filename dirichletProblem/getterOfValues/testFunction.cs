using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dirichletProblem.Functions;

namespace dirichletProblem.getterOfValues
{
    class testFunction : GetterOfValues
    {
        Function U;

        public testFunction()
        {
            U = new FunctionU();
        }

        public override Table getValues(BorderValues borderValues, int numberOfIteration = 0, double minError = 0)
        {
            int sizeX = borderValues.sizeX;
            int sizeY = borderValues.sizeY;
 
            Table res = new Table(sizeX, sizeY);

            List<double> row = new List<double>();

            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    double realX = borderValues.beginX + x * borderValues.stepX;
                    double realY = borderValues.beginY + y * borderValues.stepY;

                    res.top[x] = realX;
                    res.left[y] = realY;
                    res[x,y] = U.getValue(realX, realY);
                }
            }

            return res;
        }
    }
}
