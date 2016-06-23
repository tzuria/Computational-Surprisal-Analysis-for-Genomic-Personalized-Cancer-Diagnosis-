using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSA
{
    public partial class BoxPlotComp : DataComparison
    {
        InputData[] m_data;
        int m_lambda;
        string[] m_dataDescriptions;

        public BoxPlotComp(InputData[] data, int lambda, string[] dataDescriptions)
        {
            InitializeComponent();
            m_data = data;
            m_dataDescriptions = dataDescriptions;
            m_lambda = lambda;
            PerformComparison();
        }

        private void printChart(InputData[] data, int lambda, string[] dataDescriptions)
        {

            DataTable table;


            this.Text = "Lambda" + lambda + " comparison";
            this.chartLambda.Series.RemoveAt(0);
            for (int i = 0; i < 4; i++)
            {
                if (data.Length >= i + 1)
                {
                    if (data[i] != null)
                    {
                        table = data[i].getLagrangeDatatable();
           
                        this.chartLambda.Series.Add(dataDescriptions[i] + "values").ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;
                        this.chartLambda.Series[dataDescriptions[i] + "values"].Points.DataBindY((table.Rows[lambda]).ItemArray);

                        this.chartLambda.Series.Add(dataDescriptions[i]).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;
                        this.chartLambda.Series[dataDescriptions[i]]["BoxPlotSeries"] = dataDescriptions[i] + "values";
                        this.chartLambda.Series[dataDescriptions[i]]["BoxPlotWhiskerPercentile"] = "15";
                        this.chartLambda.Series[dataDescriptions[i]]["BoxPlotShowAverage"] = "true";
                        this.chartLambda.Series[dataDescriptions[i]]["BoxPlotShowMedian"] = "true";
                        this.chartLambda.Series[dataDescriptions[i]]["BoxPlotShowUnusualValues"] = "true";

                        this.chartLambda.Series[dataDescriptions[i] + "values"].Enabled = false;
                        addColorToBoxPlot(i,dataDescriptions[i]);
                    }
                }
            } 
        }


        private void addColorToBoxPlot(int i, string dataDescription)
        {
            if(i == 0)
            {
                 this.chartLambda.Series[dataDescription].Color = Color.Blue;
            }
            if(i == 1)
            {
                 this.chartLambda.Series[dataDescription].Color = Color.Red;
            }
            if(i == 2)
            {
                 this.chartLambda.Series[dataDescription].Color = Color.Green;
            }
            if(i == 3)
            {
                this.chartLambda.Series[dataDescription].Color = Color.Orange;
            }

            
        }

        public override void PerformComparison()
        {
            printChart(m_data, m_lambda, m_dataDescriptions);
        }
    }
}
