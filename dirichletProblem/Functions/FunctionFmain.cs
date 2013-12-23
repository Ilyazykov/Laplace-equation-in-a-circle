using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dirichletProblem.Functions
{
    class FunctionFmain : Function
    {
        public FunctionFmain()
        { }

        public override double getValue(double x, double y)
        {
            return Math.Abs(x * x - y * y);
        }
    }
}
