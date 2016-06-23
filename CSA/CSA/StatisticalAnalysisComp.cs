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
    public partial class StatisticalAnalysisComp : DataComparison
    {
        GraphMetaData[] m_metaData;
        public StatisticalAnalysisComp(GraphMetaData[] metaData)
        {
            InitializeComponent();
            this.m_metaData = metaData;

            lblAverage1.Visible = false;
            lblAverage2.Visible = false;
            lblAverage3.Visible = false;
            lblAverage4.Visible = false;
            lblSD1.Visible = false;
            lblSD2.Visible = false;
            lblSD3.Visible = false;
            lblSD4.Visible = false;

            txtAverag1.Visible = false;
            txtAverage2.Visible = false;
            txtAverage3.Visible = false;
            txtAverage4.Visible = false;
            txtSD1.Visible = false;
            txtSD2.Visible = false;
            txtSD3.Visible = false;
            txtSD4.Visible = false;

            PerformComparison();
        }

        private void showMetaData(GraphMetaData[] metaData)
        {
            if (metaData[0] != null)
            {
                lblAverage1.Visible = true;
                lblSD1.Visible = true;
                txtSD1.Visible = true;
                txtAverag1.Visible = true;
                txtAverag1.Text = metaData[0].Average.ToString();
                txtSD1.Text = metaData[0].StandardDeviation.ToString();
            }
            if (metaData[1] != null)
            {
                lblAverage2.Visible = true;
                lblSD2.Visible = true;
                txtSD2.Visible = true;
                txtAverage2.Visible = true;
                txtAverage2.Text = metaData[1].Average.ToString();
                txtSD2.Text = metaData[1].StandardDeviation.ToString();
            }
            if (metaData[2] != null)
            {
                lblAverage3.Visible = true;
                lblSD3.Visible = true;
                txtSD3.Visible = true;
                txtAverage3.Visible = true;
                txtAverage3.Text = metaData[2].Average.ToString();
                txtSD3.Text = metaData[2].StandardDeviation.ToString();
            }
            if (metaData[3] != null)
            {
                lblAverage4.Visible = true;
                lblSD4.Visible = true;
                txtSD4.Visible = true;
                txtAverage4.Visible = true;
                txtAverage4.Text = metaData[3].Average.ToString();
                txtSD4.Text = metaData[3].StandardDeviation.ToString();
            }
        }

        public override void PerformComparison()
        {
            showMetaData(m_metaData);
        }
    }
}
