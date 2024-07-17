using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Web.Helpers;
using System.Web.UI.DataVisualization.Charting;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Chart = System.Web.UI.DataVisualization.Charting.Chart;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;
using SeriesChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType;

namespace RecursiveVsIterativeLab_Grewal_Harsirat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int Iterations = 40;
        private void Form1_Load(object sender, EventArgs e)
        {
            PlotTimeComplexity(Iterations);
        }
        private void PlotTimeComplexity(int Iterations)
        {
            chart1.Series.Clear();
            Series seriesRecursive = new Series("Recursive");
            Series seriesIterative = new Series("Iterative");
            seriesRecursive.ChartType = SeriesChartType.Line;
            seriesIterative.ChartType = SeriesChartType.Line;
            chart1.Series.Add(seriesRecursive);
            chart1.Series.Add(seriesIterative);

            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Minimum = -1;
            chart1.ChartAreas[0].AxisX.Maximum = Iterations;

            Stopwatch stopwatchItr = new Stopwatch();
            Stopwatch stopwatchRec = new Stopwatch();
            double totalRecursiveTime = 0;
            double totalIterativeTime = 0;

            for (int i = 0; i <= Iterations; i++)
            {
                stopwatchRec.Restart();
                RecFib(i);
                stopwatchRec.Stop();
                seriesRecursive.Points.AddXY(i, stopwatchRec.ElapsedMilliseconds);
                totalRecursiveTime += stopwatchRec.Elapsed.TotalMilliseconds;

                stopwatchItr.Restart();
                IteFib(i);
                stopwatchItr.Stop(); 
                seriesIterative.Points.AddXY(i, stopwatchItr.Elapsed.TotalMilliseconds);
                totalIterativeTime += stopwatchItr.Elapsed.TotalMilliseconds;
            }
            textBoxRec.Text = totalRecursiveTime.ToString();
            textBoxIte.Text = totalIterativeTime.ToString();
        }
        long RecFib(int n)
        {
            if (n <= 1)
                return n;       
            else
                return RecFib(n - 1) + RecFib(n - 2);
        }
        long IteFib(int n)
        {
            if (n <= 1)
                return n;

            long[] fib = new long[n + 1];
            fib[0] = 0;
            fib[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
            }

            return fib[n]; 
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlotTimeComplexity(Iterations);
        }

        private void textBoxRec_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxIte_TextChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
