using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dirichletProblem.getterOfValues;
using dirichletProblem.Functions;

namespace dirichletProblem
{
    public partial class Form1 : Form
    {
        int task = 1;

        int sizeX = 15;
        int sizeY = 15;

        Rectangle rectangle;
        Function u;

        Table tableOne;
        Table tableTwo;
        Table tableThree;

        GetterOfValues one;
        GetterOfValues two;

        int numberOfIteration = 500;
        double eps = 0.000001;

        public Form1()
        {
            InitializeComponent();

            one = new testFunction();
            two = new testDifferentialEquation();
            u = new FunctionU();
            rectangle = new Rectangle(-1, 1, -1, 1);
        }

        private void btnToDo_Click(object sender, EventArgs e)
        {
            eps = Convert.ToDouble(textBox1.Text);

            BorderValues borderValuesOne = new BorderValues(rectangle, sizeX, sizeY, u);
            BorderValues borderValuesTwo = new BorderValues(rectangle, sizeX*task - task + 1, sizeY*task -task + 1, u);

            tableOne = two.getValues(borderValuesOne, numberOfIteration, eps);
            tableTwo = one.getValues(borderValuesTwo, numberOfIteration, eps);
            tableThree = tableOne - tableTwo;

            fillTable(tableOne);
            radioButton1.Checked = true;
            label6.Text = tableOne.additonal1.ToString();
            label7.Text = tableOne.additonal2.ToString();
            label8.Text = tableThree.additonal1.ToString();
        }

        private void fillTable(Table t)
        {
            dataGrid.RowCount = t.sizeY;
            dataGrid.ColumnCount = t.sizeX;

            for (int x = 0; x < t.sizeX; ++x)
            {
                dataGrid.Columns[x].Width = 50;
                dataGrid.Columns[x].HeaderText = t.top[x].ToString();
            }

            for (int y = 0; y < t.sizeY; ++y)
            {
                dataGrid.Rows[y].HeaderCell.Value = t.left[y].ToString();
            }

            for (int y = 0; y < t.sizeY; ++y)
            {
                for (int x = 0; x < t.sizeX; ++x)
                {
                    dataGrid.Rows[y].Cells[x].Value = t[x, y];
                }
            }
        }

        private void numericNumberOfIter_ValueChanged(object sender, EventArgs e)
        {
            numberOfIteration = (int)numericNumberOfIter.Value;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            fillTable(tableOne);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            fillTable(tableTwo);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            fillTable(tableThree);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            sizeX = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            sizeY = (int)numericUpDown2.Value;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            task = 1;
            one = new testFunction();
            two = new testDifferentialEquation();
            u = new FunctionU();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            task = 2;
            one = new mainDifferentialEquation();
            two = new mainDifferentialEquation();
            u = new FunctionUMain();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}