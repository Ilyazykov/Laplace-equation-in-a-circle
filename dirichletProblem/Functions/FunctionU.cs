using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dirichletProblem.Functions
{
    class FunctionU : Function
    {
        public FunctionU()
        { }

        public override double getValue(double x, double y)
        {
            double t = 1-x*x-y*y;
            return Math.Exp(t);
        }
    }
}