namespace FinalProjectPrototype
{
    partial class BoxPlot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartLambda = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartLambda)).BeginInit();
            this.SuspendLayout();
            // 
            // chartLambda
            // 
            chartArea1.Name = "ChartArea1";
            this.chartLambda.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartLambda.Legends.Add(legend1);
            this.chartLambda.Location = new System.Drawing.Point(1, -1);
            this.chartLambda.Name = "chartLambda";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartLambda.Series.Add(series1);
            this.chartLambda.Size = new System.Drawing.Size(558, 356);
            this.chartLambda.TabIndex = 0;
            this.chartLambda.Text = "chartLambda";
            // 
            // BoxPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 356);
            this.Controls.Add(this.chartLambda);
            this.Name = "BoxPlot";
            this.Text = "BoxPlot";
            ((System.ComponentModel.ISupportInitialize)(this.chartLambda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartLambda;
    }
}