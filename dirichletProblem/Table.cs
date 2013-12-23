using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dirichletProblem.getterOfValues;

namespace dirichletProblem
{
    class Table
    {
        public double additonal1 { get; private set; }
        public double additonal2 { get; private set; }

        public int sizeX
        {
            get { return top.Length; }
        }
        public int sizeY
        {
            get { return left.Length; }
        }

        public double[] top { get; set; }
        public double[] left { get; set; }

        private double[,] values;

        public double this[int x, int y]
        {
            get { return values[x, y]; }
            set { values[x, y] = value; }
        } 

        static public Table operator-(Table one, Table two)
        {
            int task = 1;
            if (one.sizeX == two.sizeX)
            {
                task = 1;
            }
            else if (one.sizeX * 2 - 1 == two.sizeX)
            {
                task = 2;
            }
            else
            {
                throw new Exception();
            }

            Table res = new Table(one.sizeX, one.sizeY);
            for (int i = 0; i < one.sizeX; i++)
            {
                res.top[i] = one.top[i];
            }

            for (int i = 0; i < one.sizeY; i++)
            {
                res.left[i] = one.left[i];
            }

            double max = 0;
            for (int i = 0; i < one.sizeX; i++)
            {
                for (int j = 0; j < one.sizeY; j++)
                {
                    res[i, j] = Math.Abs(one[i, j] - two[i * task, j * task]);
                    max = Math.Max(res[i, j], max);
                }
            }
            res.additonal1 = max;

            return res;
        }

        public Table(int sizeX, int sizeY)
        {
            top = new double[sizeX];
            left = new double[sizeY];

            values = new double[sizeX, sizeY];
        }

        public Table()
        {
            top = new double[1];
            top[0] = 0;
            left = new double[1];
            left[0] = 0;
            values = new double[1, 1];
            values[0, 0] = 0;
        }

        public Table(double[,] v, double[] x, double[] y, double additonalInformation1=0, double additonalInformation2=0)
        {
            this.additonal1 = additonalInformation1;
            this.additonal2 = additonalInformation2;

            top = new double[x.Length];
            left = new double[y.Length];

            values = new double[x.Length, y.Length];

            for (int i = 0; i < x.Length; i++)
            {
                top[i] = x[i];
            }

            for (int i = 0; i < y.Length; i++)
            {
                left[i] = y[i];
            }

            for (int i = 0; i < x.Length; i++)
            {
                for (int j = 0; j < y.Length; j++)
                {
                    values[i, j] = v[i, j];
                }
            }
        }
    }
}