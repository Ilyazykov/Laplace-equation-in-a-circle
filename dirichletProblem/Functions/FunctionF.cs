using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dirichletProblem.Functions
{
    class FunctionF : Function
    {
        public FunctionF()
        { }

        public override double getValue(double x, double y)
        {
            double t = 1-x*x-y*y;
            return 4 * t * Math.Exp(t);
        }
    }
}
