using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dirichletProblem.getterOfValues
{
    abstract class GetterOfValues
    {
        public GetterOfValues()
        {}

        abstract public Table getValues(BorderValues borderValues, int numberOfIteration = 0, double minError = 0);
    }
}