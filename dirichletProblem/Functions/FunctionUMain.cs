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
            return (Math.Cos(Math.PI * x * y));
        }
    }
}