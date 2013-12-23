using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dirichletProblem.Functions;

namespace dirichletProblem.getterOfValues
{
    class mainDifferentialEquation : DifferentialEquation
    {
        public mainDifferentialEquation()
        {
            F = new FunctionFmain();
        }
    }
}
