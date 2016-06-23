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
    public partial class SVDValueComp : DataComparison
    {
        string[] m_DataDescriptions;
        Boolean[] activeLines;
        int m_Lambda;
        InputData[] m_Data;
        GraphMetaData[] metaData;

        public SVDValueComp(InputData[] data, int lambda, string[] dataDescriptions)
        {
            metaData = new GraphMetaData[dataDescriptions.Length];
            InitializeComponent();
            m_Lambda = lambda;
            m_Data = data;
            m_DataDescriptions = dataDescriptions;
            activeLines = new Boolean[] { false, false, false, false };
            locateButtuns(data.Length, dataDescriptions);
            printChart(data, lambda, dataDescriptions);


        }

        private void locateButtuns(int numOfLines, string[] dataDescriptions)
        {
            cmdLine1.Text = "Remove " + dataDescriptions[0];
            cmdLine2.Text = "Remove " + dataDescriptions[1];
            if (dataDescriptions[2] == string.Empty && dataDescriptions[3] == string.Empty)
            {
                activeLines[0] = true;
                activeLines[1] = true;
                cmdLine1.Visible = true;
                cmdLine2.Visible = true;
                cmdLine3.Visible = false;
                cmdLine4.Visible = false;
            }
            if (dataDescriptions[2] != string.Empty && dataDescriptions[3] == string.Empty)
            {
                activeLines[2] = true;
                cmdLine3.Text = "Remove " + dataDescriptions[2];
                cmdLine1.Visible = true;
                cmdLine2.Visible = true;
                cmdLine3.Visible = true;
                cmdLine4.Visible = false;
            }

            if (dataDescriptions[2] != string.Empty && dataDescriptions[3] != string.Empty)
            {
                activeLines[3] = true;
                cmdLine4.Text = "Remove " + dataDescriptions[3];
                cmdLine1.Visible = true;
                cmdLine2.Visible = true;
                cmdLine3.Visible = true;
                cmdLine4.Visible = true;
            }
        }

        private void cmdLine1_Click(object sender, EventArgs e)
        {
            if (activeLines[0])
            {
                activeLines[0] = false;
                cmdLine1.Text = "Add " + m_DataDescriptions[0];
            }
            else
            {
                activeLines[0] = true;
                cmdLine1.Text = "Remove " + m_DataDescriptions[0];
            }
            chartLambda.Series.Clear();
            printChart(m_Data, m_Lambda, m_DataDescriptions);
            
        }

        private void cmdLine2_Click(object sender, EventArgs e)
        {
            if (activeLines[1])
            {
                activeLines[1] = false;
                cmdLine2.Text = "Add " + m_DataDescriptions[1];
            }
            else
            {
                activeLines[1] = true;
                cmdLine2.Text = "Remove " + m_DataDescriptions[1];
            }
            chartLambda.Series.Clear();
            printChart(m_Data, m_Lambda, m_DataDescriptions);
        }

        private void cmdLine3_Click(object sender, EventArgs e)
        {
            if (activeLines[2])
            {
                activeLines[2] = false;
                cmdLine3.Text = "Add " + m_DataDescriptions[2];
            }
            else
            {
                activeLines[2] = true;
                cmdLine3.Text = "Remove " + m_DataDescriptions[2];
            }
            chartLambda.Series.Clear();
            printChart(m_Data, m_Lambda, m_DataDescriptions);
        }

        private void cmdLine4_Click(object sender, EventArgs e)
        {
            if (activeLines[3])
            {
                activeLines[3] = false;
                cmdLine4.Text = "Add " + m_DataDescriptions[3];
            }
            else
            {
                activeLines[3] = true;
                cmdLine4.Text = "Remove " + m_DataDescriptions[3];
            }
            chartLambda.Series.Clear();
            PerformComparison();
        }



        private void printChart(InputData[] data, int lambda, string[] dataDescriptions)
        {

            DataTable table1, table2, table3, table4;


            this.Text = "Lambda" + lambda + " comparison";
            if (data.Length >= 1)
            {
                if (data[0] != null && activeLines[0])
                {
                    
                    table1 = data[0].getLagrangeDatatable();
                    double[] array = new double[table1.Rows.Count]; 
                    this.chartLambda.Series.Add(dataDescriptions[0]).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    this.chartLambda.Series[dataDescriptions[0]].Color = Color.Blue;
                    for (int i = 0; i < table1.Rows.Count; i++)
                    {
                        if (table1.Rows.Count > lambda)
                        {
                            this.chartLambda.Series[dataDescriptions[0]].Points.AddXY(i, table1.Rows[lambda][i]);
                            array[i] = (double)table1.Rows[lambda][i];
                        }
                    }
                    metaData[0] = new GraphMetaData 
                    {
                        Average = array.Average(),
                        StandardDeviation = getStandardDeviation(array.ToList<double>())
                    };
                }
                
            }
            if (data.Length >= 2)
            {
                if (data[1] != null && activeLines[1])
                {
                    
                    table2 = data[1].getLagrangeDatatable();
                    double[] array = new double[table2.Rows.Count]; 
                    this.chartLambda.Series.Add(dataDescriptions[1]).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    this.chartLambda.Series[dataDescriptions[1]].Color = Color.Red;
                    for (int i = 0; i < table2.Rows.Count; i++)
                    {
                        if (table2.Rows.Count > lambda)
                        {
                            this.chartLambda.Series[dataDescriptions[1]].Points.AddXY(i, table2.Rows[lambda][i]);
                            array[i] = (double)table2.Rows[lambda][i];
                        }
                    }
                    metaData[1] = new GraphMetaData 
                    {
                        Average = array.Average(),
                        StandardDeviation = getStandardDeviation(array.ToList<double>())
                    };
                }
            }
            if (data.Length >= 3)
            {
                if (data[2] != null && activeLines[2])
                {
                     
                    table3 = data[2].getLagrangeDatatable();
                    double[] array = new double[table3.Rows.Count];
                    this.chartLambda.Series.Add(dataDescriptions[2]).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    this.chartLambda.Series[dataDescriptions[2]].Color = Color.Green;
                    for (int i = 0; i < table3.Rows.Count; i++)
                    {
                        if (table3.Rows.Count > lambda)
                        {
                            this.chartLambda.Series[dataDescriptions[2]].Points.AddXY(i, table3.Rows[lambda][i]);
                            array[i] = (double)table3.Rows[lambda][i];
                        }
                    }
                    metaData[2] = new GraphMetaData 
                    {
                        Average = array.Average(),
                        StandardDeviation = getStandardDeviation(array.ToList<double>())
                    };
                }
            }
            if (data.Length >= 4)
            {
                if (data[3] != null && activeLines[3])
                {
                    table4 = data[3].getLagrangeDatatable();
                    double[] array = new double[table4.Rows.Count];
                    this.chartLambda.Series.Add(dataDescriptions[3]).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    this.chartLambda.Series[dataDescriptions[3]].Color = Color.Orange;
                    for (int i = 0; i < table4.Rows.Count; i++)
                    {
                        if (table4.Rows.Count > lambda)
                        {
                            this.chartLambda.Series[dataDescriptions[3]].Points.AddXY(i, table4.Rows[lambda][i]);
                            array[i] = (double)table4.Rows[lambda][i];
                        }
                    }
                    metaData[3] = new GraphMetaData 
                    {
                        Average = array.Average(),
                        StandardDeviation = getStandardDeviation(array.ToList<double>())
                    };
                }
            
            }
        }
        


        private double getStandardDeviation(List<double> doubleList)
        {
            double average = doubleList.Average();
            double sumOfDerivation = 0;
            foreach (double value in doubleList)
            {
                sumOfDerivation += (value) * (value);
            }
            double sumOfDerivationAverage = sumOfDerivation / (doubleList.Count - 1);
            return Math.Sqrt(sumOfDerivationAverage - (average * average));
        }

        private void cmdStatisticalAnalysis_Click(object sender, EventArgs e)
        {
            Form statisticalAnalysis = new StatisticalAnalysisComp(metaData);
            statisticalAnalysis.Show();
        }

        private void cmdBoxPlot_Click(object sender, EventArgs e)
        {
            Form boxPlot = new BoxPlotComp(m_Data,m_Lambda,m_DataDescriptions);
            boxPlot.Show();
        }


        public override void PerformComparison()
        {
            printChart(m_Data, m_Lambda, m_DataDescriptions);
        }
        
    }
}
