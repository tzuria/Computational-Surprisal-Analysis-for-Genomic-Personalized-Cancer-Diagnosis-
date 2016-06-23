namespace CSA
{
    partial class SVDValueComp
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
            this.chartLambda = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cmdLine1 = new System.Windows.Forms.Button();
            this.cmdLine2 = new System.Windows.Forms.Button();
            this.cmdLine3 = new System.Windows.Forms.Button();
            this.cmdLine4 = new System.Windows.Forms.Button();
            this.cmdStatisticalAnalysis = new System.Windows.Forms.Button();
            this.cmdBoxPlot = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartLambda)).BeginInit();
            this.SuspendLayout();
            // 
            // chartLambda
            // 
            chartArea1.Name = "ChartArea1";
            this.chartLambda.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartLambda.Legends.Add(legend1);
            this.chartLambda.Location = new System.Drawing.Point(0, 0);
            this.chartLambda.Name = "chartLambda";
            this.chartLambda.Size = new System.Drawing.Size(856, 470);
            this.chartLambda.TabIndex = 4;
            this.chartLambda.Text = "chart1";
            // 
            // cmdLine1
            // 
            this.cmdLine1.Location = new System.Drawing.Point(0, 467);
            this.cmdLine1.Name = "cmdLine1";
            this.cmdLine1.Size = new System.Drawing.Size(189, 40);
            this.cmdLine1.TabIndex = 5;
            this.cmdLine1.Text = "button1";
            this.cmdLine1.UseVisualStyleBackColor = true;
            this.cmdLine1.Click += new System.EventHandler(this.cmdLine1_Click);
            // 
            // cmdLine2
            // 
            this.cmdLine2.Location = new System.Drawing.Point(187, 467);
            this.cmdLine2.Name = "cmdLine2";
            this.cmdLine2.Size = new System.Drawing.Size(181, 40);
            this.cmdLine2.TabIndex = 6;
            this.cmdLine2.Text = "button2";
            this.cmdLine2.UseVisualStyleBackColor = true;
            this.cmdLine2.Click += new System.EventHandler(this.cmdLine2_Click);
            // 
            // cmdLine3
            // 
            this.cmdLine3.Location = new System.Drawing.Point(366, 467);
            this.cmdLine3.Name = "cmdLine3";
            this.cmdLine3.Size = new System.Drawing.Size(183, 40);
            this.cmdLine3.TabIndex = 7;
            this.cmdLine3.Text = "button3";
            this.cmdLine3.UseVisualStyleBackColor = true;
            this.cmdLine3.Click += new System.EventHandler(this.cmdLine3_Click);
            // 
            // cmdLine4
            // 
            this.cmdLine4.Location = new System.Drawing.Point(546, 467);
            this.cmdLine4.Name = "cmdLine4";
            this.cmdLine4.Size = new System.Drawing.Size(185, 40);
            this.cmdLine4.TabIndex = 8;
            this.cmdLine4.Text = "button4";
            this.cmdLine4.UseVisualStyleBackColor = true;
            this.cmdLine4.Click += new System.EventHandler(this.cmdLine4_Click);
            // 
            // cmdStatisticalAnalysis
            // 
            this.cmdStatisticalAnalysis.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cmdStatisticalAnalysis.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cmdStatisticalAnalysis.Location = new System.Drawing.Point(728, 467);
            this.cmdStatisticalAnalysis.Name = "cmdStatisticalAnalysis";
            this.cmdStatisticalAnalysis.Size = new System.Drawing.Size(66, 40);
            this.cmdStatisticalAnalysis.TabIndex = 9;
            this.cmdStatisticalAnalysis.Text = "Statistical data";
            this.cmdStatisticalAnalysis.UseVisualStyleBackColor = false;
            this.cmdStatisticalAnalysis.Click += new System.EventHandler(this.cmdStatisticalAnalysis_Click);
            // 
            // cmdBoxPlot
            // 
            this.cmdBoxPlot.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cmdBoxPlot.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cmdBoxPlot.Location = new System.Drawing.Point(791, 467);
            this.cmdBoxPlot.Name = "cmdBoxPlot";
            this.cmdBoxPlot.Size = new System.Drawing.Size(65, 40);
            this.cmdBoxPlot.TabIndex = 10;
            this.cmdBoxPlot.Text = "generate box plot";
            this.cmdBoxPlot.UseVisualStyleBackColor = false;
            this.cmdBoxPlot.Click += new System.EventHandler(this.cmdBoxPlot_Click);
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 507);
            this.Controls.Add(this.cmdBoxPlot);
            this.Controls.Add(this.cmdStatisticalAnalysis);
            this.Controls.Add(this.cmdLine4);
            this.Controls.Add(this.cmdLine3);
            this.Controls.Add(this.cmdLine2);
            this.Controls.Add(this.cmdLine1);
            this.Controls.Add(this.chartLambda);
            this.Name = "Graph";
            this.Text = "Graph";
            ((System.ComponentModel.ISupportInitialize)(this.chartLambda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartLambda;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button cmdLine1;
        private System.Windows.Forms.Button cmdLine2;
        private System.Windows.Forms.Button cmdLine3;
        private System.Windows.Forms.Button cmdLine4;
        private System.Windows.Forms.Button cmdStatisticalAnalysis;
        private System.Windows.Forms.Button cmdBoxPlot;


    }
}