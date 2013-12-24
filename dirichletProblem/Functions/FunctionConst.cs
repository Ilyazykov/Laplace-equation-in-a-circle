using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dirichletProblem.Functions
{
    class FunctionConst : Function
    {
        public FunctionConst()
        { }

        public override double getValue(double x, double y)
        {
            return 10;
        }
    }
}
