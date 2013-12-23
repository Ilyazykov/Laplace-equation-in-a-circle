using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dirichletProblem.Functions;

namespace dirichletProblem.getterOfValues
{
    abstract class DifferentialEquation : GetterOfValues
    {
        public Function F;

        public DifferentialEquation()
        {
        }

        public override Table getValues(BorderValues borderValues, int numberOfIteration, double eps)
        {
            int sizeX = borderValues.sizeX;
            int sizeY = borderValues.sizeY;

            Table res = new Table(sizeX, sizeY);

            res = seidelMethod(borderValues, numberOfIteration, eps);

            return res;
        }

        private Table seidelMethod(BorderValues borderValues, int numberOfIteration, double eps)
        {
            double a = borderValues.beginX, b = borderValues.endX, c = borderValues.beginY, d = borderValues.endY;
            int n = borderValues.sizeX - 1;
            int m = borderValues.sizeY - 1;
            double Nmax = numberOfIteration;

            double h = borderValues.stepX;
            double k = borderValues.stepY;

            double[] x = new double[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                x[i] = a + i * h;
            }

            double[] y = new double[m + 1];
            for (int i = 0; i < n + 1; i++)
            {
                y[i] = c + i * k;
            }
            double[,] v = new double[n + 1, m + 1];
            double[,] f = new double[n + 1, m + 1];

            double v_old;
            double v_new;
            double eps_max = 0.0;
            double eps_cur = 0.0;
            int S = 0;
            bool flag = false;

            double h2 = (-n*n) / ((b-a)*(b-a));
            double k2 = (-m*m) / ((d-c)*(d-c));
            double a2 = -2 * (h2 + k2);

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    v[i, j] = 0.0;
                    f[i, j] = F.getValue(x[i], y[j]);
                }
            }
            for (int i = 0; i < n + 1; i++)
            {
                v[i, 0] = borderValues.bottom[i];
                v[i, m] = borderValues.top[i];
            }
            for (int j = 0; j < m + 1; j++)
            {
                v[0, j] = borderValues.left[j];
                v[n, j] = borderValues.right[j];
            }

            while (!flag)
            {
                eps_max = 0;
                for (int j = 1; j < m; j++)
                    for (int i = 1; i < n; i++)
                    {
                        v_old = v[i, j];
                        v_new = -1 * (h2 * (v[i + 1, j] + v[i - 1, j]) + k2 * (v[i, j + 1] + v[i, j - 1]));
                        v_new = v_new + f[i, j];
                        v_new = v_new / a2;
                        eps_cur = Math.Abs(v_old - v_new);
                        if (eps_cur > eps_max)
                        {
                            eps_max = eps_cur;
                        }
                        v[i, j] = v_new;
                    }
                S++;
                if ((eps_max < eps) || (S >= Nmax))
                {
                    flag = true;
                }
            }

            Table res = new Table(v, x, y, S, eps_max);
            return res;
        }
    
    }
}