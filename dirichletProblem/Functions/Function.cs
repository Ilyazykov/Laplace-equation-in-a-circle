using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dirichletProblem.Functions
{
    abstract class Function
    {
        public Function()
        { }

        abstract public double getValue(double x, double y);
    }
}
