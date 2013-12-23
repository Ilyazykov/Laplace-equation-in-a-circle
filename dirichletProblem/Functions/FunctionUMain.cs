using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dirichletProblem.Functions
{
    class FunctionUMain : Function
    {
        public FunctionUMain()
        { }

        public override double getValue(double x, double y)
        {
            if (x == -1) return 1 - y * y;
            else if (x == 1) return (1 - y * y) * Math.Exp(y);
            if (y == -1) return 1 - x * x;
            else if (y == 1) return 1 - x * x;

            throw new Exception();
        }
    }
}
